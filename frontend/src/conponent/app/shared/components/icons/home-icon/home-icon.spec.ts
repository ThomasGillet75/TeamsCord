import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeIcon } from './home-icon';

describe('HomeIcon', () => {
  let component: HomeIcon;
  let fixture: ComponentFixture<HomeIcon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeIcon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeIcon);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
