import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  CanLoad,
  Route,
  UrlSegment,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService } from './authorize.service';
import { tap, map, mergeMap } from 'rxjs/operators';
import {
  ApplicationPaths,
  QueryParameterNames,
} from './api-authorization.constants';

@Injectable({
  providedIn: 'root',
})
export class PermissionGuard implements CanLoad {
  constructor(private authorize: AuthorizeService, private router: Router) {}

  canLoad(
    route: Route,
    segments: UrlSegment[]
  ): Observable<boolean> | Promise<boolean> | boolean {
    console.log(segments);
    return this.authorize
      .havePermissions('Admin')
      .pipe(
        map(([isAuthenticated, isInRole]) =>
          this.handleAuthorization(isAuthenticated, isInRole, segments)
        )
      );
  }

  private handleAuthorization(
    isAuthenticated: boolean,
    isInRole: boolean,
    returnUrl: UrlSegment[]
  ) {
    if (!isAuthenticated) {
      this.router.navigate(ApplicationPaths.LoginPathComponents, {
        queryParams: {
          [QueryParameterNames.ReturnUrl]: `${window.location.origin}/${returnUrl}`,
        },
      });
      return false;
    }

    if (!isInRole) {
      this.router.navigateByUrl('/');
      return false;
    }

    return true;
  }
}
