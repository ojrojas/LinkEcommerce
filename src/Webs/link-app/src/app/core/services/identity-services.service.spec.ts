import { TestBed } from '@angular/core/testing';

import { IdentityServicesService } from './identity-services.service';

describe('IdentityServicesService', () => {
  let service: IdentityServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IdentityServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
