import { Component, InputSignal, input } from '@angular/core';

type ButtonVariant = 'primary' | 'secondary';

@Component({
  selector: 'app-button',
  imports: [],
  templateUrl: './button.html',
  styleUrl: './button.css',
})
export class Button {
  variant: InputSignal<ButtonVariant> = input<ButtonVariant>('primary');
}
