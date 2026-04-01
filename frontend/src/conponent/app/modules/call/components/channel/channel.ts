import {Component, input, InputSignal} from '@angular/core';
import {Button} from '../../../../shared/components/button/button';

@Component({
  selector: 'app-channel',
  imports: [
    Button
  ],
  templateUrl: './channel.html',
  styleUrl: './channel.css',
})
export class Channel {
  name : InputSignal<string> = input<string>("Channel");
  onClickJoin() : void{
    console.log("test");
  }
}
