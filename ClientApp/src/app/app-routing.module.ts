import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  { path: '', redirectTo: 'songs', pathMatch: 'full' },
  {
    path: 'songs',
    loadChildren: () =>
      import('./songs/songs.module').then((module) => module.SongsModule),
  },
  {
    path: 'songs/:id',
    loadChildren: () =>
      import('./song/song.module').then((module) => module.SongModule),
  },
  {
    path: 'ranking',
    loadChildren: () =>
      import('./ranking/ranking.module').then((module) => module.RankingModule),
  },
  {
    path: 'users',
    loadChildren: () =>
      import('./users/users.module').then((module) => module.UsersModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
