import {Component, input, InputSignal} from '@angular/core';
import {DropdownMenuContainer} from '../dropdown-menu-container/dropdown-menu-container';

@Component({
  selector: 'tc-header',
  imports: [
    DropdownMenuContainer
  ],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
  serverName: InputSignal<string|undefined> = input<string|undefined>("Server");
}
