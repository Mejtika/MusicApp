/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UsersFacade } from './users.facade';


describe('UsersFacade', () => {
  let component: UsersFacade;
  let fixture: ComponentFixture<UsersFacade>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersFacade ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersFacade);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
