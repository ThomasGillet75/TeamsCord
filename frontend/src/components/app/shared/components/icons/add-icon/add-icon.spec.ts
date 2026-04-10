import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIcon } from './add-icon';

describe('AddIcon', () => {
  let component: AddIcon;
  let fixture: ComponentFixture<AddIcon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddIcon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddIcon);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
