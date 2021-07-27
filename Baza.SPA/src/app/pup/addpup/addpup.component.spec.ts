/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddpupComponent } from './addpup.component';

describe('AddpupComponent', () => {
  let component: AddpupComponent;
  let fixture: ComponentFixture<AddpupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddpupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddpupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
