import { Routes } from '@angular/router';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AboutusComponent } from './components/general/aboutus/aboutus.component';
import { WelcomeComponent } from './components/general/welcome/welcome.component';
import { ShipmentTypeComponent } from './components/general/shipmentType/shipment-type.component';
import { AddEditShipmentTypeComponent } from './components/general/add-edit-shipment-type/add-edit-shipment-type.component';
import { CustomerListComponent } from './components/admin/customer-list/customer-list.component';
import { AddEditCustomerComponent } from './components/admin/add-edit-customer/add-edit-customer.component';
import { ProviderCustomerSelectionComponent } from './components/general/provider-customer-selection/provider-customer-selection.component';
import { ShipmentDetailComponent } from './components/general/shipment-detail/shipment-detail.component';
import { WeightControlTypeComponent } from './components/admin/weight-control-type/weight-control-type.component';
import { AddEditWeightControlTypeComponent } from './components/admin/add-weight-control-type/add-edit-weight-control-type.component';
import { WeightControlComponent } from './components/admin/weight-control/weight-control.component';
import { RemainigComponent } from './components/admin/remainig/remainig.component';
import { WeightControlReportsComponent } from './components/admin/weight-control-reports/weight-control-reports.component';
import { ShimentReportsComponent } from './components/admin/shiment-reports/shiment-reports.component';
import { WeightControlGrindingComponent } from './components/admin/weight-control-grinding/weight-control-grinding.component';

import { AddEditProductsComponent } from './components/admin/products/add-edit-products/add-edit-products.component';
import { ListProductsComponent } from './components/admin/products/list-products/list-products.component';
import { CustomerTypeComponent } from './components/admin/customer-type/customer-type.component';
import { AddEditCustomerTypeComponent } from './components/admin/add-edit-customer-type/add-edit-customer-type.component';

export const routes: Routes = [
  { path: '', redirectTo: '/welcome', pathMatch: 'full' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'aboutus', component: AboutusComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'admin',
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'products', component: ListProductsComponent },
      { path: 'addProduct', component: AddEditProductsComponent },
      { path: 'editProduct/:id', component: AddEditProductsComponent },
      { path: 'roles', redirectTo: '/dashboard' },
      { path: 'CustomerTypeComponent', component: CustomerTypeComponent }, 
      { path: 'AddCustomerType', component: AddEditCustomerTypeComponent},
      { path: 'EditCustomerType/:id', component: AddEditCustomerTypeComponent},
      { path: 'customer', component: CustomerListComponent },
      { path: 'addCustomer', component: AddEditCustomerComponent },
      { path: 'editCustomer/:id', component: AddEditCustomerComponent },
      { path: 'EditWeightControlTypeComponent/:id',component: AddEditWeightControlTypeComponent },
      { path: 'AddWeightControlTypeComponent',component: AddEditWeightControlTypeComponent },
      { path: 'WeightControlTypeComponent',component: WeightControlTypeComponent },
      { path: 'WeightControlComponent', component: WeightControlComponent }, 
      { path: 'WeightControlGrindingComponent', component: WeightControlGrindingComponent }, 
      { path: 'WeightControlReportsComponent', component: WeightControlReportsComponent },
      { path: 'ShimentReportsComponent', component: ShimentReportsComponent},
      { path: 'RemainigComponent', component: RemainigComponent },

    ],
  },
  { path: 'ShipmentDetailComponent', component: ShipmentDetailComponent},
  { path: 'ProviderCustomerSelectionComponent', component: ProviderCustomerSelectionComponent},
  { path: 'shipmenttype', component: ShipmentTypeComponent},
  { path: 'addshipmenttype', component: AddEditShipmentTypeComponent},
  { path: 'editshipmenttype/:id', component: AddEditShipmentTypeComponent},
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' }, 
];
