import {Component, inject} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {Channel} from '../../components/channel/channel';
import {Member} from '../../components/member/member';
import {AuthService} from '../../../../core/services/auth.service';
import {ChannelAdd} from '../../components/channel-add/channel-add';

@Component({
  selector: 'app-call',
  imports: [
    Channel,
    Member,
    ChannelAdd
  ],
  templateUrl: './call-page.component.html',
  styleUrl: './call-page.component.css',
})
export class CallPage {
    authService:AuthService = inject(AuthService);
    channels: string[] = [];
    onAddChannel() : void
    {
      console.log(this.channels);
      this.channels.push("Channel");
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
