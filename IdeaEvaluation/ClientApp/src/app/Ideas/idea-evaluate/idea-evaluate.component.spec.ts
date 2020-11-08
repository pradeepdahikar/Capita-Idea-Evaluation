import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdeaEvaluateComponent } from './idea-evaluate.component';

describe('IdeaEvaluateComponent', () => {
  let component: IdeaEvaluateComponent;
  let fixture: ComponentFixture<IdeaEvaluateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IdeaEvaluateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IdeaEvaluateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
