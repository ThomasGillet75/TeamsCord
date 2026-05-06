import {Component, input, InputSignal, output} from '@angular/core';
import {Button} from "../button/button";
import {FormGroup, ReactiveFormsModule} from '@angular/forms';

export interface IModal{
  handleClose(): void;
  handleSubmit(): void;
}

@Component({
  selector: 'tc-modal',
  imports: [
    Button,
    ReactiveFormsModule
  ],
  templateUrl: './modal.html',
  styleUrl: './modal.css',
})

export class Modal {
  submitButtonText:InputSignal<string> = input<string>('Valider');
  onSubmit = output<void>();
  onClose = output<void>();

  handleSubmit(): void {
    this.onSubmit.emit();
  }

  handleClose(): void {
    this.onClose.emit();
  }
}
