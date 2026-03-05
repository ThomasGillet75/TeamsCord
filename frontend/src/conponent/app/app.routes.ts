import { Routes } from '@angular/router';
import {ProfilePage} from './modules/profile/pages/profile/profile';
import {CallPage} from './modules/call/pages/call/call-page.component';

export const routes: Routes = [
  {
    path: '',
    component: CallPage,
  },
  {
    path: 'profile',
    component: ProfilePage,
  }
];
