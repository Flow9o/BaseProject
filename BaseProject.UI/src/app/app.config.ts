import {ApplicationConfig, provideZoneChangeDetection} from '@angular/core';
import {provideRouter} from '@angular/router';
import {routes} from './app.routes';
import {BASE_PATH} from '@api/baseproject';
import {provideHttpClient} from '@angular/common/http';

export function getApiBasePath() {
    let hostname = window.location.hostname

    if(hostname === "localhost") {
      hostname = "http://localhost:5000"
    } else if(hostname === ".dev") {
      hostname = "http://localhost:5000"
    } else if(hostname === ".hot") {
      hostname = "http://localhost:5000"
    }

    return hostname;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({eventCoalescing: true}),
    provideRouter(routes),
    provideHttpClient(),
    {
      provide: BASE_PATH,
      useFactory: getApiBasePath
    }
  ]
};
