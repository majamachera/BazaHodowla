/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FdogComponent } from './fdog.component';

describe('FdogComponent', () => {
  let component: FdogComponent;
  let fixture: ComponentFixture<FdogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FdogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FdogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
