/* tslint:disable:no-unused-variable */

import { TestBed, inject } from '@angular/core/testing';
import { SongsService } from './songs.service';

describe('Service: Song', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SongsService]
    });
  });

  it('should ...', inject([SongsService], (service: SongsService) => {
    expect(service).toBeTruthy();
  }));
});
