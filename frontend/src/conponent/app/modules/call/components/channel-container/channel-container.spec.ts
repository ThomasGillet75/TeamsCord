import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelContainer } from './channel-container';

describe('ChannelContainer', () => {
  let component: ChannelContainer;
  let fixture: ComponentFixture<ChannelContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChannelContainer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChannelContainer);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
