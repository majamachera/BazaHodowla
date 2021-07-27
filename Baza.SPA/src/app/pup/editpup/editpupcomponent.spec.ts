/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditpupComponent } from './editpup.component';

describe('EditPupComponent', () => {
  let component: EditpupComponent;
  let fixture: ComponentFixture<EditpupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditpupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditpupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
