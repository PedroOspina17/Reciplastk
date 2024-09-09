import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';

import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
/* import { provideMomentDateAdapter } from '@angular/material-moment-adapter';
import { MatNativeDateModule, provideNativeDateAdapter } from '@angular/material/core'; */

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimations(), // required animations providers
    provideToastr(), // Toastr providers
    HttpClientModule,
    provideHttpClient(), 
    provideAnimationsAsync(),
    // provideMomentDateAdapter(),
    // MatNativeDateModule,
    // provideNativeDateAdapter()

  ]


};
