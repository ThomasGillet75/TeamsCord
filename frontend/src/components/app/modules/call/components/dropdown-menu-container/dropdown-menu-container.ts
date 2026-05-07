import {Component, inject, input, InputSignal, output, signal} from '@angular/core';
import {ArrowIcon} from '../../../../shared/components/icons/arrow/arrow.icon/arrow.icon';
import {EDirection} from '../../../../shared/enum/EDirection';
import {Button} from '../../../../shared/components/button/button';
import {ServerService} from '../../../../core/services/server.service';
import {Text} from '../../../../shared/components/text/text';
import {CopyIcon} from '../../../../shared/components/icons/copy-icon/copy-icon';
import {NgClass, NgStyle} from '@angular/common';

@Component({
  selector: 'tc-dropdown-menu-container',
  imports: [
    ArrowIcon,
    Button,
    Text,
    CopyIcon,
    NgClass,
  ],
  templateUrl: './dropdown-menu-container.html',
  styleUrl: './dropdown-menu-container.css',
})
export class DropdownMenuContainer {
  public direction:EDirection = EDirection.Down;
  public dropdownIsOpen = false;
  public name:InputSignal<string | undefined> = input<string | undefined>("");
  public serverId:InputSignal<string | undefined> = input<string | undefined>("");
  public updateServers = output<void>();
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

  public onCopyServerId(){
    navigator.clipboard.writeText(this.serverId() ?? "");
  }

  public onDeleteClick(): void {
    const id = this.serverId();
    if (id !== undefined) {
      this.serverService.deleteServer({ serverId: id }).subscribe({
        next: () => {
          this.updateServers.emit();
          this.toggleDropdown();
        },
      });
    }
  }
}
