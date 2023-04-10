import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OmiljeneStavkeComponent } from './omiljene-stavke.component';

describe('OmiljeneStavkeComponent', () => {
  let component: OmiljeneStavkeComponent;
    let fixture: ComponentFixture<OmiljeneStavkeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OmiljeneStavkeComponent ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OmiljeneStavkeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
