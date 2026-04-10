import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackgroundShader } from './background-shader';

describe('BackgroundShader', () => {
  let component: BackgroundShader;
  let fixture: ComponentFixture<BackgroundShader>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BackgroundShader]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BackgroundShader);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
