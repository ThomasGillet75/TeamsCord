import {Component, inject} from '@angular/core';
import {Banner} from "../../../../shared/components/banner/banner";
import {Button} from "../../../../shared/components/button/button";
import {Input} from '../../../../shared/components/input/input';
import {EPage} from '../../../../shared/enum/EPage';
import {Router} from '@angular/router';

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
  onSignUp() {
    this.router.navigate([EPage.Signin]);
  }
}
