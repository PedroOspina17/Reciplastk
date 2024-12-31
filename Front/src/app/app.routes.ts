import { Routes } from '@angular/router';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AboutusComponent } from './components/general/aboutus/aboutus.component';
import { WelcomeComponent } from './components/general/welcome/welcome.component';
import { ShipmentTypeComponent } from './components/config/shipmentType/shipment-type.component';
import { AddEditShipmentTypeComponent } from './components/config/add-edit-shipment-type/add-edit-shipment-type.component';
import { CustomerListComponent } from './components/config/customer-list/customer-list.component';
import { AddEditCustomerComponent } from './components/config/add-edit-customer/add-edit-customer.component';
import { ProviderCustomerSelectionComponent } from './components/weightcontrol/provider-customer-selection/provider-customer-selection.component';
import { ShipmentDetailComponent } from './components/weightcontrol/shipment-detail/shipment-detail.component';
import { WeightControlTypeComponent } from './components/config/weight-control-type/weight-control-type.component';
import { AddEditWeightControlTypeComponent } from './components/config/add-weight-control-type/add-edit-weight-control-type.component';
import { WeightControlComponent } from './components/weightcontrol/weight-control/weight-control.component';
import { RemainigComponent } from './components/admin/remainig/remainig.component';
import { WeightControlReportsComponent } from './components/reports/weight-control-reports/weight-control-reports.component';
import { ShimentReportsComponent } from './components/reports/shiment-reports/shiment-reports.component';
import { WeightControlGrindingComponent } from './components/weightcontrol/weight-control-grinding/weight-control-grinding.component';
import { AddEditProductsComponent } from './components/admin/products/add-edit-products/add-edit-products.component';
import { ListProductsComponent } from './components/admin/products/list-products/list-products.component';
import { WeightControlForPaymentsComponent } from './components/admin/weight-control-for-payments/weight-control-for-payments.component';
import { PaymentReceiptComponent } from './components/admin/payment-receipt/payment-receipt.component';
import { ShowAllBillsComponent } from './components/admin/show-all-bills/show-all-bills.component';
import { CustomerTypeComponent } from './components/config/customer-type/customer-type.component';
import { AddEditCustomerTypeComponent } from './components/config/add-edit-customer-type/add-edit-customer-type.component';
import { ShipmentPayableComponent } from './components/admin/shipment-payable/shipment-payable.component';
import { ShipmentPayableReceiptComponent } from './components/admin/shipment-payable-receipt/shipment-payable-receipt.component';
import { ProductPriceInnerComponent } from './components/admin/product-price-inner/product-price-inner.component';
import { ProductPriceComponent } from './components/admin/product-price/product-price.component';
import { CopyCustomerPricesComponent } from './components/admin/copy-customer-prices/copy-customer-prices.component';
import { MaterialProcessingPricesComponent } from './components/admin/material-processing-prices/material-processing-prices.component';

export const routes: Routes = [
  { path: '', redirectTo: '/welcome', pathMatch: 'full' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'aboutus', component: AboutusComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'admin', children: [ 
      { path: 'dashboard', component: DashboardComponent },
      { path: 'PaymentReceiptComponent', component: PaymentReceiptComponent },
      { path: 'PaymentReceiptComponent/:id', component: PaymentReceiptComponent },
      { path: 'products', component: ListProductsComponent },
      { path: 'addProduct', component: AddEditProductsComponent },
      { path: 'editProduct/:id', component: AddEditProductsComponent },
      { path: 'ShipmentPayableComponent/:id', component: ShipmentPayableComponent }, 
      { path: 'ShipmentReceivablesComponent/:id', component: ShipmentPayableComponent }, 
      { path: 'ShipmentPayableReceiptComponent/:id', component: ShipmentPayableReceiptComponent },
      { path: 'RemainigComponent', component: RemainigComponent },
      { path: 'ShowAllBills', component: ShowAllBillsComponent },
      { path: 'Payments', component: WeightControlForPaymentsComponent },
      { path: 'ProductPriceComponent', component: ProductPriceComponent },
      { path: 'ProductPriceInnerComponent', component: ProductPriceInnerComponent }, 
      { path: 'CopyCustomerPricesComponent', component: CopyCustomerPricesComponent },
      { path: 'MaterialProcessingPricesComponent', component: MaterialProcessingPricesComponent }

    ],
  },
  {
    path: 'config', children: [
      { path: 'customer', component: CustomerListComponent },
      { path: 'addCustomer', component: AddEditCustomerComponent },
      { path: 'editCustomer/:id', component: AddEditCustomerComponent },
      { path: 'CustomerTypeComponent', component: CustomerTypeComponent },
      { path: 'AddCustomerType', component: AddEditCustomerTypeComponent },
      { path: 'EditCustomerType/:id', component: AddEditCustomerTypeComponent },
      { path: 'WeightControlTypeComponent', component: WeightControlTypeComponent },
      { path: 'AddWeightControlTypeComponent', component: AddEditWeightControlTypeComponent },
      { path: 'EditWeightControlTypeComponent/:id', component: AddEditWeightControlTypeComponent },
      { path: 'shipmenttype', component: ShipmentTypeComponent },
      { path: 'addshipmenttype', component: AddEditShipmentTypeComponent },
      { path: 'editshipmenttype/:id', component: AddEditShipmentTypeComponent },
      { path: 'roles', redirectTo: '/dashboard' },
    ]
  },
  {
    path: 'reports', children: [
      { path: 'ShimentReportsComponent', component: ShimentReportsComponent },
      { path: 'WeightControlReportsComponent', component: WeightControlReportsComponent },
    ]
  },
  {
    path: 'weightcontrol', children: [
      { path: 'ProviderCustomerSelectionComponent', component: ProviderCustomerSelectionComponent },
      { path: 'ShipmentDetailComponent', component: ShipmentDetailComponent },
      { path: 'WeightControlComponent', component: WeightControlComponent },
      { path: 'WeightControlGrindingComponent', component: WeightControlGrindingComponent },
    ]
  },
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' },
];
