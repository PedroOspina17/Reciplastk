import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { ShipmentService } from '../../../services/shipment.service';
import { ShipmentDetailModel } from '../../../models/ShipmentDetailModel';
import { ShipmentRequest } from '../../../models/Requests/ShipmentRequest';
import { ProductsService } from '../../../services/products.service';
import { ProductsRequest } from '../../../models/Requests/ProductsRequest';
import { ProductPriceService } from '../../../services/product-price.service';
import { ProductPriceInnerComponent } from "../../admin/product-price-inner/product-price-inner.component";

@Component({
  selector: 'app-shipment-detail',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProductPriceInnerComponent
  ],
  templateUrl: './shipment-detail.component.html',
  styleUrl: './shipment-detail.component.css',
})
export class ShipmentDetailComponent {
  @Input() type = '1';
  @Input() personname = '';
  @Input() personid = -1;
  @Output() onComplete = new EventEmitter();
  shipmentDetailList: ShipmentDetailModel[] = [];
  formShipment: FormGroup;
  loader: boolean = false;
  GeneralProductsList: ProductsRequest[] = [];
  SpecificProductsList: ProductsRequest[] = [];
  shipmenttypeid: number = -1;
  productPrice: number = 0;
  subtotal: number = 0;
  TotalPrice: number = 0;
  producttochangeprice: number = -1;
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private shipmentService: ShipmentService,
    private productsService: ProductsService,
    private productPriceService: ProductPriceService) {
    this.formShipment = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required]],
    });
  }
  ChangePrice(productid: number) {
    this.producttochangeprice = productid
  }
  onSelectedProductChange(value: any) { // To do: send the id when the real EndPoint is created
    if (this.type == '1') {
      this.shipmenttypeid = 1;
      this.productPriceService.GetCurrentPrice(value.target.value, this.personid, this.shipmenttypeid).subscribe(r => {
        if (r.wasSuccessful) {
          this.productPrice = r.data;
        } else {
          this.toastr.error('No se encontro el precio de venta');
        }
      })
    } else {
      this.shipmenttypeid = 2;
      this.productPriceService.GetCurrentPrice(value.target.value, this.personid, this.shipmenttypeid).subscribe(r => {
        if (r.wasSuccessful) {
          this.productPrice = r.data;
        } else {
          this.toastr.error('No se encontro el precio de venta');
        }
      })
    }
  }
  SaveWeight() {
    const shipmentDetail: ShipmentDetailModel = {
      shipmenttypeid: this.shipmenttypeid,
      productid: this.formShipment.value.productid,
      productname: this.getProductName(this.formShipment.value.productid),
      weight: this.formShipment.value.weight,
      price: this.productPrice,
      subtotal: this.productPrice * this.formShipment.value.weight
    };
    this.TotalPrice += shipmentDetail.subtotal;
    this.shipmentDetailList.unshift(shipmentDetail);
    this.formShipment = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required]],
    });
    this.loader = false;
  }
  getProductName(id: number): string {
    if (this.type == '1') {
      return this.GeneralProductsList.find((p) => p.Id == id)?.Name ?? '';
    } else {
      return this.SpecificProductsList.find((p) => p.Id == id)?.Name ?? '';
    }
  }
  ngOnInit(): void {
    this.ShowProducts();
  }
  ShowProducts() {
    this.loader = true;
    if (this.type == '1') {
      this.productsService.GetMain().subscribe((GeneralResult) => {
        if (GeneralResult.wasSuccessful == true) {
          this.GeneralProductsList = GeneralResult.data;
        } else {
          this.toastr.info('No se encontro ningun producto general');
        }
      });
    } else if (this.type == '2') {
      this.productsService.GetSpecificProducts().subscribe((SpecificResult) => {
        if (SpecificResult.wasSuccessful == true) {
          this.SpecificProductsList = SpecificResult.data;
        } else {
          this.toastr.info('No se encontraron productos espesificos');
        }
      });
    }
  }
  ShipmentDetailDelete(ShipmentDetailId: number) {
    this.loader = true;
    const index = this.shipmentDetailList.findIndex((i) => i.productid === ShipmentDetailId);
    if (index !== -1) {
      this.TotalPrice -= this.shipmentDetailList[index].subtotal;
      this.shipmentDetailList.splice(index, 1);
      this.toastr.info('Producto eliminado con éxito');
    }
    this.loader = false;
  }
  Save() {
    const shipment: ShipmentRequest = {
      ShipmentTypeId: this.shipmenttypeid,
      CustomerId: Number(this.personid),
      TotalPrice: this.TotalPrice,
      Details: this.shipmentDetailList,
    };
    this.shipmentService.Create(shipment).subscribe((result) => {
      if (result.wasSuccessful == true) {
        this.loader = false;
        this.toastr.success(result.statusMessage, 'Felicitaciones');
        this.shipmentDetailList = [];
        this.onComplete.emit();
      } else {
        this.loader = false;
        this.toastr.error('Ocurrio un error', 'Error');
      }
    });
  }
  cancelDetil() {
    this.onComplete.emit();
    // this.onComplete.emit({idSelected: 9}); To send parameter.

  }
}
