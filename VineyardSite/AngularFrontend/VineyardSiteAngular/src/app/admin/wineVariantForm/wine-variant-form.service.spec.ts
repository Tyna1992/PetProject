import { TestBed } from '@angular/core/testing';

import { WineVariantFormService } from './wine-variant-form.service';

describe('WineVariantFormService', () => {
  let service: WineVariantFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WineVariantFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
