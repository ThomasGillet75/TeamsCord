import { Component } from '@angular/core';
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
  protected readonly name : string = "Channel";
  onClickJoin() : void{
    console.log("test");
  }
}
