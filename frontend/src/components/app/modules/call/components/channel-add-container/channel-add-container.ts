import {Component, output} from '@angular/core';
import {ChannelAdd} from '../channel-add/channel-add';
import {ChannelConfig} from '../channel-config/channel-config';

@Component({
  selector: 'tc-channel-add-container',
  imports: [
    ChannelAdd,
    ChannelConfig
  ],
  templateUrl: './channel-add-container.html',
  styleUrl: './channel-add-container.css',
})
export class ChannelAddContainer {
  change:boolean = true;
  onValidate = output<string>();
  onChangeAdd() : void {
    this.change = !this.change;
  }
}
