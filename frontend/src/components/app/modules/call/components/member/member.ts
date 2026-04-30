import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'tc-member',
  imports: [],
  templateUrl: './member.html',
  styleUrl: './member.css',
})
export class Member {
  memberName: InputSignal<string|undefined> =  input<string|undefined>("");
}
