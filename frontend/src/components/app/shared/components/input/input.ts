import {Component, input, InputSignal, model, ModelSignal} from '@angular/core';
import {NgClass} from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';

type InputVariant = 'primary' | 'secondary';

@Component({
  selector: 'tc-input',
  imports: [
    NgClass,
    ReactiveFormsModule
  ],
  templateUrl: './input.html',
  styleUrl: './input.css',
})

export class Input {
  type:InputSignal<string> = input<string>("text");
  title:InputSignal<string> = input<string>("Enter text");
  value:ModelSignal<string> = model<string>("");
  variant: InputSignal<InputVariant> = input<InputVariant>('primary');

  onInput(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.value.set(target.value ?? "");
  }
}
