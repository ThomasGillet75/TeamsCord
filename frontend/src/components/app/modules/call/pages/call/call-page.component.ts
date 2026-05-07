import {Component, inject, OnInit, signal, WritableSignal} from '@angular/core';
import {Channel} from '../../components/channel/channel';
import {Member} from '../../components/member/member';
import {ChannelAddContainer} from '../../components/channel-add-container/channel-add-container';
import {Header} from '../../components/header/header';
import {ServerSidebar} from '../../components/server-sidebar/server-sidebar';
import {Server} from '../../../../core/models/server.model';
import {ServerService} from '../../../../core/services/server.service';
import {firstValueFrom} from 'rxjs';
import {ChannelModel} from '../../../../core/models/channel.model';
import {BackgroundShader} from '../../../../core/background-shader/background-shader';
import {Button} from '../../../../shared/components/button/button';
import {DropdownMenuContainer} from '../../components/dropdown-menu-container/dropdown-menu-container';
import {User} from '../../../../core/models/auth.model';
import {AuthService} from '../../../../core/services/auth.service';
import {EChannel} from '../../../../shared/enum/EChannel';
import {ChannelValidationData} from '../../components/channel-config/channel-config';

@Component({
  selector: 'app-call',
  imports: [
    Member,
    ChannelAddContainer,
    Header,
    ServerSidebar,
    Channel,
    BackgroundShader,
    DropdownMenuContainer,
  ],
  templateUrl: './call-page.component.html',
  styleUrl: './call-page.component.css',
})
export class CallPage implements OnInit {
  private readonly serverService: ServerService = inject(ServerService);
  private readonly authService: AuthService = inject(AuthService);

  readonly servers: WritableSignal<ReadonlyArray<Server>> = signal<ReadonlyArray<Server>>([]);
  readonly selectedServer: WritableSignal<Server | null> = signal<Server | null>(null);
  readonly currentUser: WritableSignal<User | null> = signal<User | null>(null)
  readonly channels: WritableSignal<ReadonlyArray<ChannelModel>> = signal<ReadonlyArray<ChannelModel>>([]);

  ngOnInit(): void {
    this.initData().then(() => {
      console.log('Data initialized successfully');
    }).catch((error) => {
      console.error('Data initialization failed:', error);
    });
  }

  private async initData(): Promise<void> {
    await this.loadServers();
    await this.loadChannels();
    await this.loadUser();
  }

  async loadUser(): Promise<void> {
    this.authService.getUser().subscribe((user:User) => {
      this.currentUser.set(user);
    })
  }

  async loadServers(): Promise<void> {
    const response = await firstValueFrom(this.serverService.getServers());
    this.servers.set(response.servers);

    if (this.selectedServer() === null && response.servers.length > 0) {
      this.selectedServer.set(response.servers[0]);
    }
  }

  async onServersChanged(): Promise<void> {
    const previousServerId = this.selectedServer()?.id;

    await this.loadServers();

    const stillExists = this.servers().some(s => s.id === previousServerId);

    if (!stillExists && this.servers().length > 0) {
      this.selectedServer.set(this.servers()[0]);
      await this.loadChannels();
    }
  }


  async loadChannels(): Promise<void> {
    const server: Server | null = this.selectedServer();
    if (server === null) {
      this.channels.set([]);
      return;
    }

    const response = await firstValueFrom(this.serverService.getChannels({serverId: server.id}));
    this.channels.set(response.channels);
  }

  async onAddChannel(channelValidationData: ChannelValidationData): Promise<void> {
    const server: Server | null = this.selectedServer();
    const trimmedName: string = channelValidationData.name.trim();

    if (trimmedName.length === 0 || server === null) {
      return;
    }

    try {
      await firstValueFrom(this.serverService.addChannel({name: trimmedName, serverId: server.id, type: channelValidationData.type}));
      await this.loadChannels();
    } catch (error: unknown) {
      console.error('Failed to add channel:', error);
    }
  }

  async onSelectServer(server: Server): Promise<void> {
    this.selectedServer.set(server);
    await this.loadChannels()

  }
}
