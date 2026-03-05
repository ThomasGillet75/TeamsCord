import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'app-home-icon',
  imports: [],
  templateUrl: './home-icon.html',
  styleUrl: './home-icon.css',
})
export class HomeIcon {
  size: InputSignal<string | undefined> = input<string>()
  color: InputSignal<string | undefined> = input<string>()
}
