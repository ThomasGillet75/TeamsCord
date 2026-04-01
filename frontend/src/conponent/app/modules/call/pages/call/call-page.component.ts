import {Component, inject, OnInit} from '@angular/core';
import {Channel} from '../../components/channel/channel';
import {Member} from '../../components/member/member';
import {AuthService} from '../../../../core/services/auth.service';
import {ChannelAddContainer} from '../../components/channel-add-container/channel-add-container';
import {Header} from '../../components/header/header';
import {ServerSidebar} from '../../../../shared/components/server-sidebar/server-sidebar';
import {ServerSummary} from '../../../../core/models/server.model';

interface ServerWithChannels extends ServerSummary {
  channels: string[];
}

@Component({
  selector: 'app-call',
  imports: [
    Channel,
    Member,
    ChannelAddContainer,
    Header,
    ServerSidebar
  ],
  templateUrl: './call-page.component.html',
  styleUrl: './call-page.component.css',
})
export class CallPage implements OnInit {
    authService:AuthService = inject(AuthService);
    servers: ServerWithChannels[] = [
      { id: 1, name: 'Serveur', channels: ['General', 'Frontend'] },
      { id: 2, name: 'Gaming', channels: ['LFG', 'Clips'] }
    ];
    selectedServerId: number | null = this.servers[0]?.id ?? null;

    get channels(): string[] {
      const selectedServer: ServerWithChannels | undefined = this.servers.find(
        (server: ServerWithChannels) => server.id === this.selectedServerId
      );

      return selectedServer?.channels ?? [];
    }

    get selectedServerName(): string {
      const selectedServer: ServerWithChannels | undefined = this.servers.find(
        (server: ServerWithChannels) => server.id === this.selectedServerId
      );

      return selectedServer?.name ?? 'Serveur';
    }

    onAddChannel(name:string) : void
    {
      const trimmedName: string = name.trim();

      if (trimmedName.length === 0 || this.selectedServerId === null) {
        return;
      }

      this.servers = this.servers.map((server: ServerWithChannels) => {
        if (server.id !== this.selectedServerId) {
          return server;
        }

        return {
          ...server,
          channels: [...server.channels, trimmedName]
        };
      });
    }

    onSelectServer(serverId: number): void {
      this.selectedServerId = serverId;
    }

    onAddServer(serverName: string): void {
      const trimmedName: string = serverName.trim();

      if (trimmedName.length === 0) {
        return;
      }

      const maxServerId: number = this.servers.reduce(
        (maxId: number, server: ServerWithChannels) => Math.max(maxId, server.id),
        0
      );
      const nextServerId: number = maxServerId + 1;

      this.servers = [
        ...this.servers,
        {
          id: nextServerId,
          name: trimmedName,
          channels: []
        }
      ];
      this.selectedServerId = nextServerId;
    }

    ngOnInit():void {
      this.authService.getUser().subscribe({
        next: result => {
          console.log(result);
        },
        error: error => {
          console.log(error);
        }
      })
    }
}
