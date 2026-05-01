import {Component, output} from '@angular/core';
import {IModal, Modal} from '../../../../shared/components/modal/modal';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Input} from "../../../../shared/components/input/input";

@Component({
  selector: 'tc-server-config',
  imports: [
    Modal,
    Input
  ],
  templateUrl: './server-config.html',
  styleUrl: './server-config.css',
})
export class ServerConfig implements IModal {
  serverForm: FormGroup;
  onShow = output<void>();
  onValidate =output<string>();
  serverName: string = "";

  constructor(private formBuilder: FormBuilder) {
    this.serverForm = this.formBuilder.group({
      serverName: ['', Validators.required]
    });
  }

  handleClose(): void {
    this.onShow.emit()
  }

  handleSubmit(): void {
    const trimmedServerName :string = this.serverName;
    if (trimmedServerName.length === 0) {
      return;
    }
    this.onValidate.emit(trimmedServerName);
  }
}
