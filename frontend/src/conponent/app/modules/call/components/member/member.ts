import {Component, input, InputSignal} from '@angular/core';

@Component({
  selector: 'app-member',
  imports: [],
  templateUrl: './member.html',
  styleUrl: './member.css',
})
export class Member {
  memberName: InputSignal<string>=  input("");
}
