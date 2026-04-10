import {Component, input, InputSignal} from '@angular/core';
import {NgOptimizedImage} from '@angular/common';

@Component({
  selector: 'app-profile-picture',
  imports: [
    NgOptimizedImage
  ],
  templateUrl: './profile-picture.html',
  styleUrl: './profile-picture.css',
})
export class ProfilePicture {
  pic: InputSignal<string | undefined> = input<string>()
}
