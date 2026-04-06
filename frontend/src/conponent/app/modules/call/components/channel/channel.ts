import {Component, input, InputSignal} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {ChannelModel} from '../../../../core/models/channel.model';

@Component({
  selector: 'app-channel',
  imports: [
    Button
  ],
  templateUrl: './channel.html',
  styleUrl: './channel.css',
})
export class Channel {
  channel : InputSignal<ChannelModel> = input<ChannelModel>({id : "-1", name : "Channel"});
  onClickJoin() : void{
    console.log("test");
  }
}
