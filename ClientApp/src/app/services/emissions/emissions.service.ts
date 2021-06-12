import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Emission, PagedResult } from './interfaces';
import { Subject, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmissionsService {
  constructor(private http: HttpClient) {}
  private pagedEmissions = new Subject<PagedResult>();
  private loadingEmissions = new BehaviorSubject<boolean>(false);
  public pagedEmissions$ = this.pagedEmissions.asObservable();
  public loadingEmissions$ = this.loadingEmissions.asObservable();

  public async get(params: string) {
    console.log(params);
    this.loadingEmissions.next(true);
    this.http
      .get<any>(`odata/emissions?${params}`)
      .subscribe((result) => {
        const pagedResult: PagedResult = {
          value: result.value,
          count: result['@odata.count'],
        };
        this.pagedEmissions.next(pagedResult);
        this.loadingEmissions.next(false);
      });
  }
}
