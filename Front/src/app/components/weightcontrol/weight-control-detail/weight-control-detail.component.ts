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
import { WeightControlSeparationRequest } from '../../../models/Requests/WeightControlSeparationRequest';
import { WeightControlSeparationDetailRequest } from '../../../models/Requests/WeightControlSeparationDetailRequest';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsRequest } from '../../../models/Requests/ProductsRequest';

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
  weightcontroldetaillist: WeightControlSeparationDetailRequest[] = [];
  weightDetailForm: FormGroup;
  specificProducts: ProductsRequest[] = [];
  filterProducts: ProductsRequest[] = [];
  ngOnInit(): void {
    this.GetSpecificProducts();
  }
  GetSpecificProducts() {
    this.productService.GetSpecificProducts().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.specificProducts = r.Data;
        this.filterProducts = this.specificProducts.filter(
          (p) => p.ParentId == this.productid
        );
      } else {
        this.toastr.info('No se encontraron los productos especificos');
      }
    });
  }
  SaveDetail() {
    const WeightDetail: WeightControlSeparationDetailRequest = {
      ProductId: this.weightDetailForm.value.productid,
      Name:
        this.specificProducts.find(
          (p) => p.Id == this.weightDetailForm.value.productid
        )?.Name ?? '',
      Weight: this.weightDetailForm.value.weight,
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
    const weightcontrol: WeightControlSeparationRequest = {
      EmployeeId: this.employeeid,
      WeightControlDetails: this.weightcontroldetaillist,
    };
    this.weightControlService.CreateSeparation(weightcontrol).subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.toastr.success(r.StatusMessage);
        this.weightcontroldetaillist = [];
        this.onComplete.emit();
      } else {
        this.toastr.success(r.StatusMessage);
      }
    });
  }
}
