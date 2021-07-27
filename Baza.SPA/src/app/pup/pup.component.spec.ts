/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PupComponent } from './pup.component';

describe('PupComponent', () => {
  let component: PupComponent;
  let fixture: ComponentFixture<PupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
