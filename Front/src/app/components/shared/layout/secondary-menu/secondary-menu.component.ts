import { Component } from '@angular/core';
import { NotifierComponent } from '../notifier/notifier.component';
import { UserProfileComponent } from '../user-profile/user-profile.component';

@Component({
  selector: 'app-secondary-menu',
  standalone: true,
  imports: [NotifierComponent,UserProfileComponent],
  templateUrl: './secondary-menu.component.html',
  styleUrl: './secondary-menu.component.css'
})
export class SecondaryMenuComponent {

}
