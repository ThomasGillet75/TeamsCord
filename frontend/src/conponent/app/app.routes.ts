import { Routes } from '@angular/router';
import {ProfilePage} from './modules/profile/pages/profile/profile';
import {CallPage} from './modules/call/pages/call/call-page.component';
import {Signin} from './modules/signin/page/signin/signin';
import {Signup} from './modules/signup/page/signup/signup';
import {EPage} from './shared/enum/EPage';
import {authGuard} from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: CallPage,
    canActivate: [authGuard],
  },
  {
    path: EPage.Signin,
    component: Signin,
  },
  {
    path: EPage.Signup,
    component: Signup,
  },
  {
    path: EPage.Profile,
    component: ProfilePage,
    canActivate: [authGuard],
  }
];
