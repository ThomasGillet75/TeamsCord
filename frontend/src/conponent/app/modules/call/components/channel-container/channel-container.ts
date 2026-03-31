import { Component } from '@angular/core';
import {ChannelAdd} from '../channel-add/channel-add';
import {ChannelConfig} from '../channel-config/channel-config';

@Component({
  selector: 'tc-channel-container',
  imports: [
    ChannelAdd,
    ChannelConfig
  ],
  templateUrl: './channel-container.html',
  styleUrl: './channel-container.css',
})
export class ChannelContainer {
  change:boolean = true;
  onChangeAdd() : void {
    this.change = !this.change;
  }
}
