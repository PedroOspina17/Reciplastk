import { TestBed } from '@angular/core/testing';

import { PayrollconfigService } from './payrollconfig.service';

describe('PayrollconfigService', () => {
  let service: PayrollconfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PayrollconfigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
