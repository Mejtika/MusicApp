import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongComponent } from './song.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
      path: "",
      component: SongComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [SongComponent]
})
export class SongModule { }
