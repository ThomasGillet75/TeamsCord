import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChannelConfig } from './channel-config';

describe('ChannelConfig', () => {
  let component: ChannelConfig;
  let fixture: ComponentFixture<ChannelConfig>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChannelConfig]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChannelConfig);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
