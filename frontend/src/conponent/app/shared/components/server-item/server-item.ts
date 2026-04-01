import {Component, input, InputSignal, output} from '@angular/core';

@Component({
  selector: 'tc-server-item',
  imports: [],
  templateUrl: './server-item.html',
  styleUrl: './server-item.css',
})
export class ServerItem {
  name: InputSignal<string> = input<string>('Serveur');
  isSelected: InputSignal<boolean> = input<boolean>(false);
  onSelect = output<void>();
}

