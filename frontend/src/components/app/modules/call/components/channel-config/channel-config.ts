import {Component, output} from '@angular/core';
import {Input} from '../../../../shared/components/input/input';
import {Button} from '../../../../shared/components/button/button';
import {Modal} from '../modal/modal';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'tc-channel-config',
  imports: [
    Input,
    Modal
  ],
  templateUrl: './channel-config.html',
  styleUrl: './channel-config.css',
})
export class ChannelConfig {
  channelForm: FormGroup;
  channelName: string = "";
  onValidate = output<string>();
  onChange = output<void>();

  constructor(private formBuilder: FormBuilder) {
    this.channelForm = this.formBuilder.group({
      channelName: ['', Validators.required]
    });
  }

  handleSubmit(form: FormGroup): void {
    if (form.valid) {
      this.onValidate.emit(form.get('channelName')?.value);
    }
  }
  handleClose() : void {
    this.onChange.emit();
  }

}
