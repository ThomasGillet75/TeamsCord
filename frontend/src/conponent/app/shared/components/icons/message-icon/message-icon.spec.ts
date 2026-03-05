import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageIcon } from './message-icon';

describe('MessageIcon', () => {
  let component: MessageIcon;
  let fixture: ComponentFixture<MessageIcon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MessageIcon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MessageIcon);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
