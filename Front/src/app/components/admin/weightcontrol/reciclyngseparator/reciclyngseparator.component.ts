import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { WeightcontrolService } from '../../../../services/weightcontrol.service';
import { SepartormodalsComponent } from '../../../modals/separtormodals/separtormodals.component';
import { WeightControlModel } from '../../../../models/WeightControlModel';
import { ToastrService } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reciclyngseparator',
  standalone: true,
  imports: [CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    SepartormodalsComponent,
  ],
  templateUrl: './reciclyngseparator.component.html',
  styleUrl: './reciclyngseparator.component.css',
})
export class ReciclyngseparatorComponent {
  loading: boolean = false;
  id: number;
  columnTable: string[] = [
    'nombreCompleto',
    'correo',
    'rolDescripcion',
    'estado',
    'acciones',
  ];
  listWeightControl: WeightControlModel[] = [];
  dateListWeightControl = new MatTableDataSource(this.listWeightControl);
  @ViewChild(MatPaginator) paginacionTabla!: MatPaginator;

  listEmployee = [
    { id: 1, nombre: 'Pedro', descripcion: 'xxxxx' },
    { id: 2, nombre: 'pablo', descripcion: 'yyyyy' },
    { id: 3, nombre: 'Jacinto', descripcion: 'zzzzzz' },
    { id: 4, nombre: 'Jose', descripcion: 'aaaaaa' },
  ];

  listProducts = [
    { id: 1, nombre: 'pp' },
    { id: 2, nombre: 'soplado' },
    { id: 3, nombre: 'ps' },
    { id: 4, nombre: 'pasta' },
  ];

  constructor(
    private dialog: MatDialog,
    private weightControlService: WeightcontrolService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
  ) {

    this.id = Number(aRoute.snapshot.paramMap.get('id'));
  }

  GetAll() {
    this.loading = true;
    this.weightControlService.GetAll().subscribe(result => {
      // this.listWeightControl = result;
      this.loading = false;
    });
  }
  GetById(id: number){
    this.loading = true;
    this.weightControlService.GetById(id).subscribe((result) => {
      // this.listWeightControl = result;
      this.loading = false;
    });

  }

  ngOnInit(): void {
    this.GetAll;
  }

  ngAfterViewInit(): void {
    this.dateListWeightControl.paginator = this.paginacionTabla;
  }

  FilterTable(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dateListWeightControl.filter = filterValue.trim().toLocaleLowerCase();
  }

  Save() {
    //logica para guardar temporamente los datos en el local storage
  }
  NewRegister() {

    this.dialog.open(SepartormodalsComponent, {
        disableClose: true,
      }).afterClosed().subscribe((result) => {
        if (result === true) this.GetAll();
      });
  }

  Update() {
    this.dialog
      .open(SepartormodalsComponent, {
        disableClose: true,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === true) this.Update();
      });
  }

  Delete(id: number) {
    this.loading = true;
    Swal.fire({
      title: '¿Desea eliminar el registro?',
      text:"registro",
      icon: "warning",
      confirmButtonColor: '#3085d6',
      confirmButtonText: "Si, Eliminar",
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No, volver',
    }).then((result)=>{
      if(result.isConfirmed){
        this.weightControlService.Delete(id).subscribe({
          next:(data)=>{
            if(data.wasSuccessful){

            }else{

            }
          },
          error:(e)=>{}
        })
      }

    })
    this.weightControlService.Delete(id).subscribe(() => {
      this.GetAll();
    });
  }
}
