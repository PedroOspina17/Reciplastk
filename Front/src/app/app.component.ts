import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MenuComponent } from './components/shared/layout/menu/menu.component';
import { FooterComponent } from "./components/shared/layout/footer/footer.component";
import { SecondaryMenuComponent } from "./components/shared/layout/secondary-menu/secondary-menu.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, MenuComponent, FooterComponent, SecondaryMenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Reciplastk';
  constructor(private toastr: ToastrService) {

  }
  ShowAlert():void{
    this.toastr.success('Hello world!', 'Toastr fun!');
    this.toastr.info('Hello world!', 'Toastr fun!');
    this.toastr.error('Hello world!', 'Toastr fun!');
    this.toastr.warning('Hello world!', 'Toastr fun!');
  }
}
