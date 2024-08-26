import { Routes } from '@angular/router';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AboutusComponent } from './components/general/aboutus/aboutus.component';
import { WelcomeComponent } from './components/general/welcome/welcome.component';
import { ShipmentDetailComponent } from './components/general/shipment-detail/shipment-detail.component';
import { ShipmentCustomerSelectionComponent } from './components/general/shipment-customer-selection/shipment-customer-selection.component';
import { CustomerListComponent } from './components/admin/customer-list/customer-list.component';
import { AddEditCustomerComponent } from './components/admin/add-edit-customer/add-edit-customer.component';

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
      { path: 'editCustomer/:id', component: AddEditCustomerComponent }
    ],
  },
  { path: 'shipmentDetail', component: ShipmentDetailComponent},
  { path: 'ShipmentCustomerSelection', component: ShipmentCustomerSelectionComponent},
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' },
];
