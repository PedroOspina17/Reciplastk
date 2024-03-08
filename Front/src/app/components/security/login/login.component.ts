import { Component } from '@angular/core';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SecurityService } from '../../../services/security.service';
import { LoginModel } from '../../../models/LoginModel';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, LoaderComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private securityService: SecurityService
  ) {
    this.loginForm = fb.group({
      email: ['', [Validators.required]],
      password: ['', Validators.required],
    });
  }

  Save(): void {
    
    const loginData: LoginModel = {
      userName: this.loginForm.value.email,
      password: this.loginForm.value.password
    };

    this.isLoading = true;

    this.securityService.LogIn(loginData).subscribe(result => {
      // Here i can place any code i want.      
      console.log("Login result", result);
      if(result.wasSuccessful == true){
        this.toastr.success(`Bienvenido, ${result.data.name} ${result.data.lastname} al sistema`, 'Bienvenido!');
        this.router.navigate(['/admin/dashboard']);
      }else{
        console.log("informacion incorrecta");
        this.toastr.error('El usuario o contraseña ingresado es incorrecto.', 'Invalid credentials!');
        
      }
    });
    
    
    this.isLoading = false;
  }

}
