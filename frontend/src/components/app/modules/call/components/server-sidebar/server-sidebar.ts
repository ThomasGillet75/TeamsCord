import {Component, input, InputSignal, output} from '@angular/core';
import {Server} from '../../../../core/models/server.model';
import {ServerItem} from '../server-item/server-item';
import {AddIcon} from '../../../../shared/components/icons/add-icon/add-icon';
import {ModalContainer} from '../../../../shared/components/modal-container/modal-container';
import {ServerConfig} from '../server-config/server-config';

@Component({
  selector: 'tc-server-sidebar',
  imports: [
    ServerItem,
    AddIcon,
    ServerConfig,
    ModalContainer,
  ],
  templateUrl: './server-sidebar.html',
  styleUrl: './server-sidebar.css',
})
export class ServerSidebar {
  servers: InputSignal<ReadonlyArray<Server>> = input<ReadonlyArray<Server>>([]);
  selectedServer: InputSignal<Server|null> = input<Server|null>(null);
  onSelectServer = output<Server>();
  onAddServer = output<string>();
  show: boolean = false;

  isAddButtonHovered: boolean = false;

  onShowModal(): void {
    this.show = !this.show;
  }
}

