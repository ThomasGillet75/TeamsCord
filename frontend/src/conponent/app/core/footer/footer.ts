import { Component } from '@angular/core';
import {HomeIcon} from '../../shared/components/icons/home-icon/home-icon';
import {ProfileIcon} from '../../shared/components/icons/profile-icon/profile-icon';
import {MessageIcon} from '../../shared/components/icons/message-icon/message-icon';
import {Button} from '../../shared/components/button/button';
import {Router} from '@angular/router';
import {EPage} from '../../shared/enum/EPage';

@Component({
  selector: 'app-footer',
  imports: [HomeIcon, ProfileIcon, MessageIcon, Button],
  templateUrl: './footer.html',
  styleUrl: './footer.css',
})
export class Footer {
  constructor(private router: Router) {}
  onClickHome(): void {
    this.router
      .navigateByUrl('/')
      .then(ok => console.log('navigation Home success:', ok))
      .catch(err => console.error('navigation Home error:', err));
  }

  onClickProfile(): void {
    this.router
      .navigateByUrl('/profile')
      .then(ok => console.log('navigation Profile success:', ok))
      .catch(err => console.error('navigation Profile error:', err));
  }
}
