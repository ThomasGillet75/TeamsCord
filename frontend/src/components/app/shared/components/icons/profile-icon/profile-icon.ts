import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'app-profile-icon',
  imports: [],
  templateUrl: './profile-icon.html',
  styleUrl: './profile-icon.css',
})
export class ProfileIcon {
  size: InputSignal<string | undefined> = input<string>()
  color: InputSignal<string | undefined> = input<string>()
}
