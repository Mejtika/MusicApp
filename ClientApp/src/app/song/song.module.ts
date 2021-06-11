import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongComponent } from './song.component';
import { RouterModule, Routes } from '@angular/router';
import { ChartModule } from 'primeng/chart';
import { SongService } from '../services/song/song.service';
import { YearsReportComponent } from './years-report/years-report.component';
import { ChannelsReportComponent } from './channels-report/channels-report.component';
import { PanelModule } from 'primeng/panel';
import { TabViewModule } from 'primeng/tabview';
import { SongDetailsComponent } from './song-details/song-details.component';

const routes: Routes = [
  {
    path: '',
    component: SongComponent,
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
    SongComponent,
    YearsReportComponent,
    ChannelsReportComponent,
    SongDetailsComponent,
  ],
  providers: [SongService],
})
export class SongModule {}
