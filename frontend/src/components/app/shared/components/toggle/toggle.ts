import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'tc-toggle',
  imports: [],
  templateUrl: './toggle.html',
  styleUrl: './toggle.css',
})
export class Toggle {
  isToggled: boolean = false
  handleToggle() {
    this.isToggled = !this.isToggled;
  }
}
