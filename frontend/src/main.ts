import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './conponent/app/app.config';
import { App } from './conponent/app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));
