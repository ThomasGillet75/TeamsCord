import { Component } from '@angular/core';
import {Button} from '../../../../shared/components/button/button';
import {Channel} from '../../components/channel/channel';
import {Member} from '../../components/member/member';

@Component({
  selector: 'app-call',
  imports: [
    Channel,
    Member
  ],
  templateUrl: './call-page.component.html',
  styleUrl: './call-page.component.css',
})
export class CallPage {

}
