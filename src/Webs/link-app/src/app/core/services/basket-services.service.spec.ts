import { TestBed } from '@angular/core/testing';

import { BasketServicesService } from './basket-services.service';

describe('BasketServicesService', () => {
  let service: BasketServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BasketServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
