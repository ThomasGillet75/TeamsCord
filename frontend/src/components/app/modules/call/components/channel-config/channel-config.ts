import {Component, output, signal} from '@angular/core';
import {Input} from '../../../../shared/components/input/input';
import {IModal, Modal} from '../../../../shared/components/modal/modal';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {Text} from '../../../../shared/components/text/text';
import {SlideMenu} from '../../../../shared/components/slide-menu/slide-menu';
import {EMenuOption} from '../../../../shared/enum/EMenuOption';
import {EChannel} from '../../../../shared/enum/EChannel';

export interface ChannelValidationData {
  name: string;
  type: EChannel;
}
@Component({
  selector: 'tc-channel-config',
  imports: [
    Input,
    Modal,
    ReactiveFormsModule,
    FormsModule,
    Text,
    SlideMenu,
  ],
  templateUrl: './channel-config.html',
  styleUrl: './channel-config.css',
})
export class ChannelConfig implements IModal {
  channelName = signal<string>('');
  onValidate = output<ChannelValidationData>();
  onChange = output<void>();
  selectedOption: EMenuOption = EMenuOption.LEFT;

  onOptionChanged(option: EMenuOption): void {
    this.selectedOption = option;
  }

  handleSubmit(): void {
    let channelType: EChannel = EChannel.Text;
    if (this.selectedOption === EMenuOption.LEFT) {
      channelType = EChannel.Vocal;
    }
    this.onValidate.emit({
      name: this.channelName(),
      type: channelType
    });
    this.handleClose()
  }

  handleClose(): void {
    this.onChange.emit();
  }
}
