import {Component, input, InputSignal, model, ModelSignal} from '@angular/core';

@Component({
  selector: 'tc-input',
  imports: [],
  templateUrl: './input.html',
  styleUrl: './input.css',
})
export class Input {
  type:InputSignal<string> = input<string>("text");
  title:InputSignal<string> = input<string>("Enter text");
  value:ModelSignal<string> = model<string>("");

  onInput(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.value.set(target.value ?? "");
  }
}
