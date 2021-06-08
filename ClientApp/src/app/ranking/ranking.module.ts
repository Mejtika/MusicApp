import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RankingComponent } from './ranking.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
      path: "",
      component: RankingComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [RankingComponent]
})
export class RankingModule { }
