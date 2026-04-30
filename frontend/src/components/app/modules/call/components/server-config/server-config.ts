import {Component, output} from '@angular/core';
import {Button} from "../../../../shared/components/button/button";
import {IModal, Modal} from '../modal/modal';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'tc-server-config',
  imports: [
    Modal
  ],
  templateUrl: './server-config.html',
  styleUrl: './server-config.css',
})
export class ServerConfig implements IModal {
  serverForm: FormGroup;
  onShow = output<void>();
  onValidate =output<string>();

  constructor(private formBuilder: FormBuilder) {
    this.serverForm = this.formBuilder.group({
      serverName: ['', Validators.required]
    });
  }

  handleClose(): void {
    this.onShow.emit()

  }

  handleSubmit(form: FormGroup): void {
    if (form.valid) {
      this.onValidate.emit(form.get('serverName')?.value);
    }
  }
}
