import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelAddContainer } from './channel-add-container';

describe('ChannelAddContainer', () => {
  let component: ChannelAddContainer;
  let fixture: ComponentFixture<ChannelAddContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChannelAddContainer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChannelAddContainer);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
