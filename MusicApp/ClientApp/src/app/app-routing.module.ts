import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { LazyAuthorizeGuard } from 'src/api-authorization/lazy-authorize.guard';
import { PermissionGuard } from 'src/api-authorization/permission.guard';

const routes: Routes = [
  { path: '', redirectTo: 'emissions', pathMatch: 'full' },
  {
    path: 'emissions',
    canLoad: [LazyAuthorizeGuard],
    canActivate: [AuthorizeGuard],
    loadChildren: () =>
      import('./emissions/emissions.module').then((module) => module.EmissionsModule),
  },
  {
    path: 'songs/:id',
    canLoad: [LazyAuthorizeGuard],
    canActivate: [AuthorizeGuard],
    loadChildren: () =>
      import('./songs/songs.module').then((module) => module.SongsModule),
  },
  {
    path: 'ranking',
    canLoad: [LazyAuthorizeGuard],
    canActivate: [AuthorizeGuard],
    loadChildren: () =>
      import('./ranking/ranking.module').then((module) => module.RankingModule),
  },
  {
    path: 'users',
    canLoad: [PermissionGuard],
    canActivate: [AuthorizeGuard],
    loadChildren: () =>
      import('./users/users.module').then((module) => module.UsersModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
