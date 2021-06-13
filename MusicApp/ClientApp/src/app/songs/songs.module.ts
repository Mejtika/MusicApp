import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongsComponent } from './songs.component';
import { RouterModule, Routes } from '@angular/router';
import { ChartModule } from 'primeng/chart';
import { SongsService } from '../services/songs/songs.service';
import { YearsReportComponent } from './years-report/years-report.component';
import { ChannelsReportComponent } from './channels-report/channels-report.component';
import { PanelModule } from 'primeng/panel';
import { TabViewModule } from 'primeng/tabview';
import { SongDetailsComponent } from './song-details/song-details.component';

const routes: Routes = [
  {
    path: '',
    component: SongsComponent,
  },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ChartModule,
    PanelModule,
    TabViewModule,
  ],
  declarations: [
    SongsComponent,
    YearsReportComponent,
    ChannelsReportComponent,
    SongDetailsComponent,
  ],
  providers: [SongsService],
})
export class SongsModule {}
