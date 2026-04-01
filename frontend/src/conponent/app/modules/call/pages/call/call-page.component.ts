import {Component, inject} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {Channel} from '../../components/channel/channel';
import {Member} from '../../components/member/member';
import {AuthService} from '../../../../core/services/auth.service';
import {ChannelAdd} from '../../components/channel-add/channel-add';
import {ChannelConfig} from '../../components/channel-config/channel-config';
import {ChannelAddContainer} from '../../components/channel-add-container/channel-add-container';

@Component({
  selector: 'app-call',
  imports: [
    Channel,
    Member,
    ChannelAddContainer
  ],
  templateUrl: './call-page.component.html',
  styleUrl: './call-page.component.css',
})
export class CallPage {
    authService:AuthService = inject(AuthService);
    channels: string[] = [];
    onAddChannel(name:string) : void
    {
      console.log(name);
      this.channels.push(name);
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
