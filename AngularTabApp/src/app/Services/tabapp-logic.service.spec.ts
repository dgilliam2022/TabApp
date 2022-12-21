import { TestBed } from '@angular/core/testing';

import { TabappLogicService } from './tabapp-logic.service';

describe('TabappLogicService', () => {
  let service: TabappLogicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TabappLogicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
