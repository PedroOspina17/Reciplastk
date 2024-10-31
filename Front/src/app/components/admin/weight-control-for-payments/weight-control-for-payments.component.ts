import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { WeightControlReportParams } from '../../../models/WeightControlReportParams';
import { WeightControlReport } from '../../../models/WeightControlReport';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-weight-control-for-payments',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    LoaderComponent,
  ],
  providers: [DatePipe],
  templateUrl: './weight-control-for-payments.component.html',
  styleUrl: './weight-control-for-payments.component.css',
})
export class WeightControlForPaymentsComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private weightControlService: WeightControlService,
    private datePipe: DatePipe
  ) {
    this.FormPayments = this.fb.group({
      StartDate: [],
      EndDate: [],
      EmployeeId: [-1],
    });
  }
  FormPayments: FormGroup;
  EmployeeList: any[] = [];
  Filtered: WeightControlReport[] = [];
  selectedProductIds: any[] = [];
  isVisible: boolean = false;
  ngOnInit(): void {
    this.GetEmployee();
  }
  GetEmployee() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.EmployeeList = r.data;
      } else {
        this.toastr.error('No se encontro ningun empleado');
      }
    });
  }
  Filter() {
    const Model: WeightControlReportParams = {
      StartDate: this.FormPayments.value.StartDate,
      EndDate: this.FormPayments.value.EndDate,
      EmployeeId: this.FormPayments.value.EmployeeId,
    };
    console.log(Model);
    this.weightControlService.Filter(Model).subscribe((r) => {
      if (r.wasSuccessful) {
        this.Filtered = r.data.map((item: WeightControlReport) => ({
          ...item,
          date: this.datePipe.transform(item.date, 'short') || '',
        }));
        console.log('Filters:', this.FormPayments);
      } else {
        this.toastr.error(
          'No se encontraron los detalles con los filtros aplicado'
        );
      }
    });
    this.isVisible = true;
  }
  onCheckboxChange(event: Event, productId: number) {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      this.selectedProductIds.push(productId);
    } else {
      this.selectedProductIds = this.selectedProductIds.filter(
        (id) => id !== productId
      );
    }
    console.log('Productos seleccionados:', this.selectedProductIds);
  }
  PayAndSave() {
    const Model: WeightControlReportParams = {
      productsId: this.selectedProductIds,
    };
    if (this.selectedProductIds.length > 0) {
      this.weightControlService.PayAndSave(Model).subscribe((r) => {
        console.log('Respuesta',r)
        if (r.wasSuccessful == true) {
          this.toastr.success('Se modificaron los pagos correctamente')
          this.Filter();
        } else {
          this.toastr.success('No se pudieron modificar los pagos correctamente')
        }
      });
    } else {
      this.toastr.error('No hay productos seleccionados.');
    }
  }
}
