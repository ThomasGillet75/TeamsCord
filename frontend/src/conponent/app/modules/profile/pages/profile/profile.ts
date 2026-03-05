import { Component } from '@angular/core';
import {ProfilePicture} from '../../../../shared/components/profile-picture/profile-picture';

@Component({
  selector: 'app-profile',
  imports: [
    ProfilePicture
  ],
  templateUrl: './profile.html',
  styleUrl: './profile.css',
})

export class ProfilePage {
}
