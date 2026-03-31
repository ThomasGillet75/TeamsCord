import {Component, input, Input, InputSignal, output} from '@angular/core';
import {AddIcon} from '../../../../shared/components/icons/add-icon/add-icon';
import {delay} from 'rxjs';

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
  onClick =  output<void>();
  addChannel = () :void => {
    this.isClicked = !this.isClicked;
    window.setTimeout((): void => {
      this.onClick.emit();
    }, 0);
  }
}
