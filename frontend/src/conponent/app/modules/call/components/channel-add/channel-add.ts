import {Component, input, Input, InputSignal} from '@angular/core';
import {AddIcon} from '../../../../shared/components/icons/add-icon/add-icon';

@Component({
  selector: 'tc-channel-add',
  imports: [
    AddIcon
  ],
  templateUrl: './channel-add.html',
  styleUrl: './channel-add.css',
})
export class ChannelAdd {
  hoverState: boolean = false;
  isClicked: boolean = false;
  addChannel = () :void => {
    this.isClicked = !this.isClicked;
  }
}
