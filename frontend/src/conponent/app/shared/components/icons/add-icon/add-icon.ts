import {Component, input} from '@angular/core';

@Component({
  selector: 'tc-add-icon',
  imports: [],
  templateUrl: './add-icon.html',
  styleUrl: './add-icon.css',
})
export class AddIcon {
  color = input<string>();
  isHovered = input<boolean>(false);
}
