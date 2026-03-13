import { Component, inject } from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {Banner} from '../../../../shared/components/banner/banner';
import {Input} from '../../../../shared/components/input/input';
import {Router} from '@angular/router';
import {EPage} from '../../../../shared/enum/EPage';

@Component({
  selector: 'tc-signin',
  imports: [
    Button,
    Banner,
    Input
  ],
  templateUrl: './signin.html',
  styleUrl: './signin.css',
})
export class Signin {
  private router = inject(Router);
  protected readonly Input = Input;

  onRedirect() {
    this.router.navigate([EPage.Signup]);
  }

  onSignin() {
    this.router.navigate([EPage.Home]);
  }
}
