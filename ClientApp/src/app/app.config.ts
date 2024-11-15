import { APP_INITIALIZER, ApplicationConfig, inject, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, Router } from '@angular/router';

import { routes } from './app.routes';
import { BASE_PATH, GameService } from './generated-api-client';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { authInterceptor } from './services/auth-interceptor.service';
import { MatDialogRef } from '@angular/material/dialog';
import { AccountsService } from './generated-api-client/api/accounts.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes),
    GameService,
    AccountsService,
    { provide: MatDialogRef, useValue: {} },
    provideHttpClient(withInterceptors([authInterceptor])), 
    provideAnimations(),
   //Aleksa - check this
   { provide: BASE_PATH, useValue: "http://localhost:5205" }],
  
};

