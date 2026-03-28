import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelAdd } from './channel-add';

describe('ChannelAdd', () => {
  let component: ChannelAdd;
  let fixture: ComponentFixture<ChannelAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChannelAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChannelAdd);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
