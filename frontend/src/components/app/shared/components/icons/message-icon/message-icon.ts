import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'app-message-icon',
  imports: [],
  templateUrl: './message-icon.html',
  styleUrl: './message-icon.css',
})
export class MessageIcon {
  size: InputSignal<string | undefined> = input<string>()
  color: InputSignal<string | undefined> = input<string>()
}
