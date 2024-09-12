import { TestBed } from '@angular/core/testing';

import { WineFormService } from './wine-form.service';

describe('WineFormService', () => {
  let service: WineFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WineFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
