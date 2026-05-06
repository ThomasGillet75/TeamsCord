import {Component, input, InputSignal} from '@angular/core';

type TextColorVariant = 'dark' | 'light';


@Component({
  selector: 'tc-text',
  imports: [],
  templateUrl: './text.html',
  styleUrl: './text.css',
})
export class Text {
  color: InputSignal<TextColorVariant> = input<TextColorVariant>('dark');
}
