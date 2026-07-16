import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeuix/themes/aura';
import { MessageService } from 'primeng/api';

import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    providePrimeNG({
      theme: {
        preset: Aura
      },
      license: 'eyJpZCI6IjY5NTFmNzBiLTVlYzUtNDI4Ni04NTkzLThjMTQ2Y2RkZTU3NCIsInByb2R1Y3QiOiJwcmltZXVpIiwidGllciI6ImNvbW11bml0eSIsInR5cGUiOiJkZXYiLCJpYXQiOjE3ODM5ODE1ODEsImV4cCI6MTgxNTUxNzU4MX0.ZyzdM1AuJRw3PyoCL490FO8MrPXR85mlbKnPtuKTPwOaqHvsacPF1RzKw0d1vLI131NCo1lwuHRHz8f33xd8BA'
    }),
    MessageService,
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes)
  ]
};
