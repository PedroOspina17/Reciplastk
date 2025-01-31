import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ProductsService } from '../../../services/products.service';
import { WeightControlModel } from '../../../models/WeightControlModel';
import { WeightControlDetailModel } from '../../../models/WeightControlDetailModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductModel } from '../../../models/ProductModel';

@Component({
  selector: 'app-weight-control-detail',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './weight-control-detail.component.html',
  styleUrl: './weight-control-detail.component.css',
})
export class WeightControlDetailComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
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
  specificProducts: ProductModel[] = [];
  filterProducts: ProductModel[] = [];
  ngOnInit(): void {
    this.GetSpecificProducts();
  }
  GetSpecificProducts() {
    this.productService.GetSpecificProducts().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.specificProducts = r.data;
        this.filterProducts = this.specificProducts.filter(
          (p) => p.parentid == this.productid
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
          (p) => p.productid == this.weightDetailForm.value.productid
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
  Detele(Index: number) {
    this.weightcontroldetaillist.splice(Index, 1);
    this.toastr.info('Producto eliminado con éxito');
  }
  SaveAll() {
    const weightcontrol: WeightControlModel = {
      employeeid: this.employeeid,
      weightdetail: this.weightcontroldetaillist,
    };
    this.weightControlService.CreateSeparation(weightcontrol).subscribe((r) => {
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
