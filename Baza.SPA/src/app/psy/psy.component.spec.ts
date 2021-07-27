/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PsyComponent } from './psy.component';

describe('SlowakluczoweComponent', () => {
  let component: PsyComponent;
  let fixture: ComponentFixture<PsyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PsyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PsyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
