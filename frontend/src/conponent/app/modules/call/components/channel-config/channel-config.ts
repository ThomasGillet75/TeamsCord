import { Component } from '@angular/core';
import {Input} from '../../../../shared/components/input/input';
import {Button} from '../../../../shared/components/button/button';

@Component({
  selector: 'tc-channel-config',
  imports: [
    Input,
    Button
  ],
  templateUrl: './channel-config.html',
  styleUrl: './channel-config.css',
})
export class ChannelConfig {
  channelName: string = "";
}
