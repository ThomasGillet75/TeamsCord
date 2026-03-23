import {CanActivateFn, Router, UrlTree} from '@angular/router';
import {AuthTokenService} from './auth-token.service';
import {inject} from '@angular/core';
import {EPage} from '../../shared/enum/EPage';

export const authGuard: CanActivateFn = ():boolean|UrlTree => {
  const authTokenService: AuthTokenService = inject(AuthTokenService);
  const router:Router = inject(Router);
  if(!authTokenService.hasToken()) {
    return router.createUrlTree([EPage.Signin]);
  }
  return true;
}
