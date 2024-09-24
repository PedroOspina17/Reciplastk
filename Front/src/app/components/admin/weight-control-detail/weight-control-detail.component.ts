import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WeightControlComponent } from '../weight-control/weight-control.component';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ProductsService } from '../../../services/products.service';
import { ProductsModel } from '../../../models/ProductsModel';
import { WeightControlModel } from '../../../models/WeightControlModel';
import { WeightControlDetailModel } from '../../../models/WeightControlDetailModel';
import { WeightControlService } from '../../../services/weight-control-service';

@Component({
  selector: 'app-weight-control-detail',
  standalone: true,
  imports: [
    RouterLink,
    LoaderComponent,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    WeightControlComponent,
  ],
  templateUrl: './weight-control-detail.component.html',
  styleUrl: './weight-control-detail.component.css',
})
export class WeightControlDetailComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
    private productService: ProductsService,
    private weightControlService: WeightControlService
  ) {
    this.weightDetailForm = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', Validators.required],
    });
  }
  @Input() employeeid = -1;
  @Input() employeename = '';
  @Input() productid = -1;
  @Input() productname = '';
  @Output() onComplete = new EventEmitter();
  weightcontroldetaillist: WeightControlDetailModel[] = [];
  weightDetailForm: FormGroup;
  specificProducts: ProductsModel[] = [];
  filterProducts: ProductsModel[] = [];
  ngOnInit(): void {
    this.GetSpecificProducts();
  }
  GetSpecificProducts() {
    this.productService.GetSpecificProducts().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.specificProducts = r.data;
        this.filterProducts = this.specificProducts.filter(
          (p) => p.pid == this.productid
        );
      } else {
        this.toastr.info('No se encontraron los productos especificos');
      }
    });
  }
  SaveDetail() {
    const WeightDetail: WeightControlDetailModel = {
      productid: this.weightDetailForm.value.productid,
      name:
        this.specificProducts.find(
          (p) => p.id == this.weightDetailForm.value.productid
        )?.name ?? '',
      weight: this.weightDetailForm.value.weight,
    };
    this.weightcontroldetaillist.unshift(WeightDetail);
    this.weightDetailForm = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', Validators.required],
    });
  }
  cancelDetail() {
    this.onComplete.emit();
  }
  Detele(id: number) {
    const index = this.weightcontroldetaillist.findIndex(
      (p) => p.productid == id
    );
    if (index !== -1) {
      this.weightcontroldetaillist.splice(index, 1);
      this.toastr.info('Producto eliminado con éxito');
    }
  }
  SaveAll() {
    const weightcontrol: WeightControlModel = {
      Employeeid: this.employeeid,
      WeightControlTypeId: 2,
      weightdetail: this.weightcontroldetaillist,
    };
    this.weightControlService.Create(weightcontrol).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.toastr.success(r.statusMessage);
        this.weightcontroldetaillist = [];
        this.onComplete.emit();
      } else {
        this.toastr.success(r.statusMessage);
      }
    });
  }
}
