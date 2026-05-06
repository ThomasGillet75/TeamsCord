import {Component, inject, output} from '@angular/core';
import {IModal, Modal} from '../../../../shared/components/modal/modal';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Input} from "../../../../shared/components/input/input";
import {SlideMenu} from '../../../../shared/components/slide-menu/slide-menu';
import {EMenuOption} from '../../../../shared/enum/EMenuOption';
import {Text} from '../../../../shared/components/text/text';
import {ServerService} from '../../../../core/services/server.service';
import {firstValueFrom} from 'rxjs';

@Component({
  selector: 'tc-server-config',
  imports: [
    Modal,
    Input,
    SlideMenu,
    Text
  ],
  templateUrl: './server-config.html',
  styleUrl: './server-config.css',
})
export class ServerConfig implements IModal {
  private readonly  serverService : ServerService = inject(ServerService);

  serverForm: FormGroup;
  onShow = output<void>();
  onServerCreated = output<void>();
  inputText: string = "";
  selectedOption: EMenuOption = EMenuOption.LEFT;
  inputTitle: string = "Server Name";
  submitButtonLabel: string = "Create Server";

  constructor(private formBuilder: FormBuilder) {
    this.serverForm = this.formBuilder.group({
      serverName: ['', Validators.required]
    });
  }

  onOptionChanged(option: EMenuOption): void {
    this.selectedOption = option;

    if (option === EMenuOption.LEFT) {
      this.inputTitle="Server Name";
      this.submitButtonLabel="Create Server";
    } else {
      this.inputTitle = "Server Code";
      this.submitButtonLabel="Join Server";
    }
  }

  handleClose(): void {
    this.onShow.emit()
  }

  handleSubmit(): void {
    const trimmedInputText :string = this.inputText;
    if (trimmedInputText.length === 0) {
      return;
    }
    this.onAddServer(trimmedInputText);
  }

  async onAddServer(serverName: string): Promise<void> {
    try {
      if(this.selectedOption === EMenuOption.LEFT) {
        await firstValueFrom(this.serverService.addServer({name: serverName}));
      }
      else {
        await firstValueFrom(this.serverService.joinServer({name: serverName}));
      }

      this.onServerCreated.emit();
      this.handleClose();
    } catch (error: unknown) {
      console.error('Failed to add server:', error);
    }
  }
}
