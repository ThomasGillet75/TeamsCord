import {Component, inject, input, InputSignal, signal} from '@angular/core';
import {ArrowIcon} from '../../../../shared/components/icons/arrow/arrow.icon/arrow.icon';
import {EDirection} from '../../../../shared/enum/EDirection';
import {Button} from '../../../../shared/components/button/button';
import {ServerService} from '../../../../core/services/server.service';

@Component({
  selector: 'tc-dropdown-menu-container',
  imports: [
    ArrowIcon,
    Button,
  ],
  templateUrl: './dropdown-menu-container.html',
  styleUrl: './dropdown-menu-container.css',
})
export class DropdownMenuContainer {
  public direction:EDirection = EDirection.Down;
  public dropdownIsOpen = false;
  public name:InputSignal<string | undefined> = input<string | undefined>("");
  public serverId:InputSignal<string | undefined> = input<string | undefined>("");
  private readonly serverService: ServerService = inject(ServerService);

  public toggleDropdown(): void {
    this.dropdownIsOpen = !this.dropdownIsOpen;
    if(this.dropdownIsOpen){
      this.direction = EDirection.Up;
    }
    else {
      this.direction = EDirection.Down;
    }
  }

  public onDeleteClick(): void {
    const id = this.serverId();
    if (id !== undefined) {
      this.serverService.deleteServer({ serverId: id }).subscribe({});
    }
    this.toggleDropdown();
  }
}
