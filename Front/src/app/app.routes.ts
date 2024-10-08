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
      { path: 'roles', redirectTo: '/dashboard' },
      { path: 'customer', component: CustomerListComponent },
      { path: 'addCustomer', component: AddEditCustomerComponent },
      { path: 'editCustomer/:id', component: AddEditCustomerComponent },
      { path: 'EditWeightControlTypeComponent/:id',component: AddEditWeightControlTypeComponent },
      { path: 'AddWeightControlTypeComponent',component: AddEditWeightControlTypeComponent },
      { path: 'WeightControlTypeComponent',component: WeightControlTypeComponent },
      { path: 'WeightControlComponent', component: WeightControlComponent }, 
      { path: 'RemainigComponent', component: RemainigComponent }
    ],
  },
  { path: 'ShipmentDetailComponent', component: ShipmentDetailComponent},
  { path: 'ProviderCustomerSelectionComponent', component: ProviderCustomerSelectionComponent},
  { path: 'shipmenttype', component: ShipmentTypeComponent},
  { path: 'addshipmenttype', component: AddEditShipmentTypeComponent},
  { path: 'editshipmenttype/:id', component: AddEditShipmentTypeComponent},
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' }, 
];
