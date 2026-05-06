import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'tc-copy-icon',
  imports: [],
  templateUrl: './copy-icon.html',
  styleUrl: './copy-icon.css',
})
export class CopyIcon {
  size: InputSignal<string | undefined> = input<string>()
  color: InputSignal<string | undefined> = input<string>()
}
