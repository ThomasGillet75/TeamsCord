import {Component, input, InputSignal, signal, WritableSignal} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {ChannelModel} from '../../../../core/models/channel.model';
import {EChannel} from '../../../../shared/enum/EChannel';

@Component({
  selector: 'tc-channel',
  imports: [
    Button
  ],
  templateUrl: './channel.html',
  styleUrl: './channel.css',
})
export class Channel {
  channel : InputSignal<ChannelModel> = input<ChannelModel>({id : "-1", name : "Channel", type: EChannel.Text});
  isExpanded: WritableSignal<boolean> = signal(false);
  onClickJoin(): void {
    console.log('onClickJoin');
  }

  protected readonly EChannel = EChannel;
}
