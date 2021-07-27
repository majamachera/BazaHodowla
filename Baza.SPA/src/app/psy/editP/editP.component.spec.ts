/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditPComponent } from './editP.component';

describe('EditPComponent', () => {
  let component: EditPComponent;
  let fixture: ComponentFixture<EditPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
