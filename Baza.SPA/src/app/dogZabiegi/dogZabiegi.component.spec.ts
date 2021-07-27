/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DogZabiegiComponent } from './dogZabiegi.component';

describe('DogZabiegiComponent', () => {
  let component: DogZabiegiComponent;
  let fixture: ComponentFixture<DogZabiegiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DogZabiegiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DogZabiegiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
