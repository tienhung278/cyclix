import { TestBed } from '@angular/core/testing';

import { AnotherOptionService } from './another-option.service';

describe('AnotherOptionService', () => {
  let service: AnotherOptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AnotherOptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
