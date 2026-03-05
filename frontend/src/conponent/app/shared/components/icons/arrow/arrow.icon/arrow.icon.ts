import {Component, input, InputSignal} from '@angular/core';
import {EDirection} from '../../../../enum/EDirection';

@Component({
  selector: 'app-arrow-icon',
  imports: [],
  templateUrl: './arrow.icon.html',
  styleUrl: './arrow.icon.css',
})

export class ArrowIcon {
  size: InputSignal<string | undefined> = input<string>()
  color: InputSignal<string | undefined> = input<string>()
  direction: InputSignal<EDirection | undefined> = input<EDirection | undefined>()
  filled: InputSignal<boolean | undefined> = input<boolean>()

  rotation() : string{
    const direction = this.direction()
    if (typeof direction == 'number'){
      return `rotation(${direction}deg)`
    }
    switch (direction){
      case EDirection.Up:
        return `rotate(0deg)`
      case EDirection.Down:
        return `rotate(180deg)`
      case EDirection.Left:
        return `rotate(270deg)`
      case EDirection.Right:
        return `rotate(90deg)`
      default:
        return `rotate(0deg)`
    }
  }
}
