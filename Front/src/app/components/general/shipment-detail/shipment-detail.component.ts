import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { ProviderCustomerSelectionComponent } from '../provider-customer-selection/provider-customer-selection.component';
import { ShipmentService } from '../../../services/shipment.service';
import { ShipmentDetailModel } from '../../../models/ShipmentDetailModel';
import { ProductsModel } from '../../../models/ProductsModel';
import { ShipmentModel } from '../../../models/ShipmentModel';
import { ProductsService } from '../../../services/products.service';

@Component({
  selector: 'app-shipment-detail',
  standalone: true,
  imports: [
    RouterLink,
    LoaderComponent,
    CommonModule,
    HttpClientModule,
    ProviderCustomerSelectionComponent,
    ReactiveFormsModule,
  ],
  templateUrl: './shipment-detail.component.html',
  styleUrl: './shipment-detail.component.css',
})
export class ShipmentDetailComponent {
  @Input() type = '1';
  @Input() personname = '';
  @Input() personid: string = '';
  @Output() onComplete = new EventEmitter();
  shipmentDetailList: ShipmentDetailModel[] = [];
  formShipment: FormGroup;
  loader: boolean = false;
  GeneralProductsList: ProductsModel[] = [];
  SpecificProductsList: ProductsModel[] = [];
  shipmenttypeid: number = -1;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
    private shipmentService: ShipmentService,
    private productsService: ProductsService
  ) {
    this.formShipment = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required]],
    });
  }
  SaveWeight() {
    this.loader = true;
    if (this.type == '1') {
      this.shipmenttypeid = 1;
    } else {
      this.shipmenttypeid = 2;
    }
    const shipmentDetail: ShipmentDetailModel = {
      shipmenttypeid: this.shipmenttypeid,
      productid: this.formShipment.value.productid,
      productname: this.getProductName(this.formShipment.value.productid),
      weight: this.formShipment.value.weight,
    };
    console.log(shipmentDetail);
    this.shipmentDetailList.unshift(shipmentDetail);
    this.formShipment = this.fb.group({
      productid: ['-1', [Validators.required, Validators.min(0)]],
      weight: ['', [Validators.required]],
    });
    this.loader = false;
  }
  getProductName(id: number): string {
    if (this.type == '1') {
      return this.GeneralProductsList.find((p) => p.id == id)?.name ?? '';
    } else {
      return this.SpecificProductsList.find((p) => p.id == id)?.name ?? '';
    }
  }
  ngOnInit(): void {
    this.ShowProducts();
  }
  ShowProducts() {
    this.loader = true;
    if (this.type == '1') {
      this.productsService.GetGeneralProducts().subscribe((GeneralResult) => {
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
    const index = this.shipmentDetailList.findIndex(
      (i) => i.productid === ShipmentDetailId
    );
    if (index !== -1) {
      this.shipmentDetailList.splice(index, 1);
      this.toastr.info('Producto eliminado con éxito');
    }
    this.loader = false;
  }
  Save() {
    const shipment: ShipmentModel = {
      shipmenttypeid: this.shipmenttypeid,
      customerid: Number(this.personid),
      details: this.shipmentDetailList,
    };
    console.log('shipmentDetail', shipment);
    this.shipmentService.CreateShipment(shipment).subscribe((result) => {
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
    this.onComplete.emit()
  }
}
