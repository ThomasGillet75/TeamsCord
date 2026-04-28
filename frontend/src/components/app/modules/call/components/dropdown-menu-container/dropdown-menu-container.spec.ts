import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownMenuContainer } from './dropdown-menu-container';

describe('DropdownMenuContainer', () => {
  let component: DropdownMenuContainer;
  let fixture: ComponentFixture<DropdownMenuContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DropdownMenuContainer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DropdownMenuContainer);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
