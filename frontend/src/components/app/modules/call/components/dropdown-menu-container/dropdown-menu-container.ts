import {Component, input, InputSignal} from '@angular/core';
import {ArrowIcon} from '../../../../shared/components/icons/arrow/arrow.icon/arrow.icon';
import {EDirection} from '../../../../shared/enum/EDirection';
import {Button} from '../../../../shared/components/button/button';

@Component({
  selector: 'tc-dropdown-menu-container',
  imports: [
    ArrowIcon,
    Button
  ],
  templateUrl: './dropdown-menu-container.html',
  styleUrl: './dropdown-menu-container.css',
})
export class DropdownMenuContainer {
  protected readonly EDirection = EDirection;
  public name:InputSignal<string | undefined> = input<string | undefined>("");
}
