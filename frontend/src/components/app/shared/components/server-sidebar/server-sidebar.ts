import {Component, input, InputSignal, output} from '@angular/core';
import {Button} from '../button/button';
import {Server} from '../../../core/models/server.model';
import {ServerItem} from '../server-item/server-item';
import {AddIcon} from '../icons/add-icon/add-icon';
import {ServerConfig} from '../../../modules/call/components/server-config/server-config';

@Component({
  selector: 'tc-server-sidebar',
  imports: [
    Button,
    ServerItem,
    AddIcon,
    ServerConfig,
  ],
  templateUrl: './server-sidebar.html',
  styleUrl: './server-sidebar.css',
})
export class ServerSidebar {
  servers: InputSignal<ReadonlyArray<Server>> = input<ReadonlyArray<Server>>([]);
  selectedServer: InputSignal<Server|null> = input<Server|null>(null);
  onSelectServer = output<Server>();
  onAddServer = output<string>();

  newServerName: string = '';
  show: boolean = false;

  onServerNameInput(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.newServerName = target.value ?? '';
  }

  onCreateServer(): void {
    const serverName: string = this.newServerName.trim();
    if (serverName.length === 0) {
      return;
    }
    this.onAddServer.emit(serverName);
    this.newServerName = '';
  }

  onShowModal(): void {
    this.show = !this.show;
  }
}

