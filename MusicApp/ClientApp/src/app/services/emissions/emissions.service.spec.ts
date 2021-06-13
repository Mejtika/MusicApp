/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EmissionsService } from './emissions.service';

describe('Service: Emissions', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmissionsService]
    });
  });

  it('should ...', inject([EmissionsService], (service: EmissionsService) => {
    expect(service).toBeTruthy();
  }));
});
