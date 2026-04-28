import {Component, InputSignal, input, output} from '@angular/core';

type ButtonVariant = 'primary' | 'secondary' | 'square';

@Component({
  selector: 'tc-button',
  imports: [],
  templateUrl: './button.html',
  styleUrl: './button.css',
})
export class Button {
  variant: InputSignal<ButtonVariant> = input<ButtonVariant>('primary');
  onClick = output<void>();
}
