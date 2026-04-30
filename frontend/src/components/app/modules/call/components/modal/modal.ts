import {Component, input, InputSignal, output} from '@angular/core';
import {Button} from "../../../../shared/components/button/button";
import {FormGroup} from '@angular/forms';

export interface IModal{
  handleClose(): void;
  handleSubmit(form: FormGroup): void;
}

@Component({
  selector: 'tc-modal',
    imports: [
        Button
    ],
  templateUrl: './modal.html',
  styleUrl: './modal.css',
})

export class Modal {
  form = input<FormGroup | null>(null);
  submitButtonText:InputSignal<string> = input<string>('Valider');
  onSubmit = output<FormGroup>();
  onClose = output<void>();

  handleSubmit(): void {
    if (this.form() && this.form()!.valid) {
      this.onSubmit.emit(this.form()!);
    }
  }

  handleClose(): void {
    this.onClose.emit();
  }
}
