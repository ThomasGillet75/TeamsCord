import {Component, EventEmitter, Output} from '@angular/core';
import { EMenuOption } from '../../enum/EMenuOption';

@Component({
  selector: 'tc-slide-menu',
  imports: [],
  templateUrl: './slide-menu.html',
  styleUrl: './slide-menu.css',
})
export class SlideMenu {
  readonly EMenuOption = EMenuOption;
  private selectedOption: EMenuOption = EMenuOption.LEFT;

  @Output() optionChanged = new EventEmitter<EMenuOption>();

  selectOption(option: EMenuOption): void {
    this.selectedOption = option;
    this.optionChanged.emit(option);
  }

  isSelected(option: EMenuOption): boolean {
    return this.selectedOption === option;
  }
}
