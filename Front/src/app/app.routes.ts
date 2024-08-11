import { Routes } from '@angular/router';
import { LoginComponent } from './components/security/login/login.component';
import { RegisterComponent } from './components/security/register/register.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { AboutusComponent } from './components/general/aboutus/aboutus.component';
import { WelcomeComponent } from './components/general/welcome/welcome.component';
import { MillerComponent } from './components/admin/weightcontrol/miller/miller.component';
import { ReciclyngseparatorComponent } from './components/admin/weightcontrol/reciclyngseparator/reciclyngseparator.component';
import { SeparatedmaterialhistoryComponent } from './components/admin/weightcontrol/separatedmaterialhistory/separatedmaterialhistory.component';

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
      { path: 'miller', component: MillerComponent},
      { path: 'separator', component: ReciclyngseparatorComponent},
      { path: 'historySeparator', component: SeparatedmaterialhistoryComponent},
    ],
  },
  { path: '**', redirectTo: '/welcome', pathMatch: 'full' },
];
