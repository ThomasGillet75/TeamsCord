import {Component, inject, input, InputSignal, signal, WritableSignal} from '@angular/core';
import {Banner} from "../../../../shared/components/banner/banner";
import {Button} from "../../../../shared/components/button/button";
import {Input} from '../../../../shared/components/input/input';
import {EPage} from '../../../../shared/enum/EPage';
import {Router} from '@angular/router';
import {AuthService} from '../../../../core/service/auth.service';
import {SignUpRequest, SignUpResponse} from '../../../../core/models/auth.model';

@Component({
  selector: 'tc-signup',
  imports: [
    Banner,
    Button,
    Input
  ],
  templateUrl: './signup.html',
  styleUrl: './signup.css',
})
export class Signup {
  private router = inject(Router);
  private readonly authService: AuthService = inject(AuthService);

  username: WritableSignal<string> = signal<string>('');
  email: WritableSignal<string> = signal<string>('');
  password: WritableSignal<string> = signal<string>('');
  verifyPassword: WritableSignal<string> = signal<string>('');

  onSignUp() {
    const payload: SignUpRequest = {
      username: this.username(),
      email: this.email(),
      password: this.password(),
    }
    this.authService.signUp(payload).subscribe({
      next: (response: SignUpResponse) => {
        this.router.navigate([EPage.Signin]);
      },
      error: (err: unknown) => {
        // Why: network/API errors are normal runtime events and should be handled.
        console.error('Signup failed', err);
      },
    })

  }
}
