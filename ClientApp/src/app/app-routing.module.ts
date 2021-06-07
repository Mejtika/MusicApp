import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { MyComponentComponent } from './my-component/my-component.component';

const routes: Routes = [
  {
    path: 'home',
    component: MyComponentComponent,
    canActivate: [AuthorizeGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
