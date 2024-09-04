import { TestBed } from '@angular/core/testing';

import { CatalogServicesService } from './catalog-services.service';

describe('CatalogServicesService', () => {
  let service: CatalogServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CatalogServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
