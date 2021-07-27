/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SukiComponent } from './suki.component';

describe('SukiComponent', () => {
  let component: SukiComponent;
  let fixture: ComponentFixture<SukiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SukiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SukiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
