import { Injectable } from '@angular/core';
import { Router, CanLoad, Route, UrlSegment } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService } from './authorize.service';
import { tap } from 'rxjs/operators';
import { ApplicationPaths, QueryParameterNames } from './api-authorization.constants';

@Injectable({
  providedIn: 'root'
})
export class LazyAuthorizeGuard implements CanLoad {
  constructor(private authorize: AuthorizeService, private router: Router) {
  }

  canLoad(route: Route, segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return this.authorize.isAuthenticated()
    .pipe(tap(isAuthenticated => this.handleAuthorization(isAuthenticated, segments)));
  }

  private handleAuthorization(isAuthenticated: boolean, returnUrl: UrlSegment[]) {
    if (!isAuthenticated) {
      this.router.navigate(ApplicationPaths.LoginPathComponents, {
        queryParams: {
          [QueryParameterNames.ReturnUrl]: `${window.location.origin}/${returnUrl}`
        }
      });
    }
  }
}