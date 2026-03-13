import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'tc-input',
  imports: [],
  templateUrl: './input.html',
  styleUrl: './input.css',
})
export class Input {
  type:InputSignal<string> = input<string>("text");
  placeholder:InputSignal<string> = input<string>("Enter text");
}
