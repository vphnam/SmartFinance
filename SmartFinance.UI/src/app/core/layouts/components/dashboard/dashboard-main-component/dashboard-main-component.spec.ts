import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardMainComponent } from './dashboard-main-component';

describe('DashboardMainComponent', () => {
  let component: DashboardMainComponent;
  let fixture: ComponentFixture<DashboardMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardMainComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardMainComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
