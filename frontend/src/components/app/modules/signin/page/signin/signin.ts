import {Component, inject, signal, WritableSignal} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {Banner} from '../../../../shared/components/banner/banner';
import {Input} from '../../../../shared/components/input/input';
import {Router} from '@angular/router';
import {EPage} from '../../../../shared/enum/EPage';
import {AuthService} from '../../../../core/services/auth.service';
import {SignInRequest} from '../../../../core/models/auth.model';
import {AuthTokenService} from '../../../../core/services/auth-token.service';
import {BackgroundShader} from '../../../../core/background-shader/background-shader';

@Component({
  selector: 'tc-signin',
  imports: [
    Button,
    Banner,
    Input,
    BackgroundShader
  ],
  templateUrl: './signin.html',
  styleUrl: './signin.css',
})
export class Signin {
  private router = inject(Router);
  private readonly authService: AuthService = inject(AuthService)
  private readonly authTokenService:AuthTokenService = inject(AuthTokenService);

  email: WritableSignal<string> = signal<string>('');
  password: WritableSignal<string> = signal<string>('');

  onRedirect() {
    this.router.navigate([EPage.Signup]);
  }

  onSignIn() {
    const payload: SignInRequest = {
      email: this.email(),
      password: this.password(),
    }
    this.authService.signIn(payload).subscribe({
      next: result => {
        this.authTokenService.setAccessToken(result.accessToken);
        if(this.authTokenService.hasToken()) {
          this.router.navigate([EPage.Home]);
        }
      },
      error: error => {
        console.log(error);
      }
    })
  }
}
