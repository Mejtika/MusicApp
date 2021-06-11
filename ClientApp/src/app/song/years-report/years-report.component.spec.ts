/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { YearsReportComponent } from './years-report.component';

describe('YearReportComponent', () => {
  let component: YearsReportComponent;
  let fixture: ComponentFixture<YearsReportComponent>;
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YearsReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YearsReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
