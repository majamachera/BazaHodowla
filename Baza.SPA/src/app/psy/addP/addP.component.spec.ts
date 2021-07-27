/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddPComponent } from './addP.component';

describe('AddComponent', () => {
  let component: AddPComponent;
  let fixture: ComponentFixture<AddPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
