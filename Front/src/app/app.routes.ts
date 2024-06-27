import { Routes } from '@angular/router';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AboutusComponent } from './components/general/aboutus/aboutus.component';
import { WelcomeComponent } from './components/general/welcome/welcome.component';
import { AddEditProductsComponent } from './components/admin/products/add-edit-products/add-edit-products.component';
import { ListProductsComponent } from './components/admin/products/list-products/list-products.component';

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
    ],
  },
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' },
];
