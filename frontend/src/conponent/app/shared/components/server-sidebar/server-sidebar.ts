import {Component, input, InputSignal, output} from '@angular/core';
import {Button} from '../button/button';
import {ServerSummary} from '../../../core/models/server.model';
import {ServerItem} from '../server-item/server-item';

@Component({
  selector: 'tc-server-sidebar',
  imports: [
    Button,
    ServerItem
  ],
  templateUrl: './server-sidebar.html',
  styleUrl: './server-sidebar.css',
})
export class ServerSidebar {
  servers: InputSignal<ReadonlyArray<ServerSummary>> = input<ReadonlyArray<ServerSummary>>([]);
  selectedServerId: InputSignal<number | null> = input<number | null>(null);
  onSelectServer = output<number>();
  onAddServer = output<string>();

  newServerName: string = '';

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
}

