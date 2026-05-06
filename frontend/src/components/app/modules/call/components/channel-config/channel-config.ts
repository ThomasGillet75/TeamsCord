import {Component, effect, output, signal} from '@angular/core';
import {Input} from '../../../../shared/components/input/input';
import {Button} from '../../../../shared/components/button/button';
import {IModal, Modal} from '../../../../shared/components/modal/modal';
import {FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'tc-channel-config',
  imports: [
    Input,
    Modal,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './channel-config.html',
  styleUrl: './channel-config.css',
})
export class ChannelConfig implements IModal {
  channelName = signal<string>('');
  onValidate = output<string>();
  onChange = output<void>();

  handleSubmit(): void {
    this.onValidate.emit(this.channelName());
    this.handleClose()
  }

  handleClose() : void {
    this.onChange.emit();
  }
}
