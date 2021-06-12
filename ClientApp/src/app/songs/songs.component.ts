import { Component, OnInit } from '@angular/core';
import { SongsService } from '../services/songs/songs.service';
import { Observable, Subscriber, Subscription } from 'rxjs';
import { ChannelReport, Song, YearReport } from '../services/songs/interfaces';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css'],
})
export class SongsComponent implements OnInit {
  private songIdSub: any;
  yearsReport$: Observable<YearReport[]> = this.songsService.yearsReport$;
  channelsReport$: Observable<ChannelReport[]> = this.songsService.channelsReport$;
  song$: Observable<Song | null> = this.songsService.song$;
  yearsReportLabels: string[] = [
    'Styczeń',
    'Luty',
    'Marzec',
    'Kwiecień',
    'Maj',
    'Czerwiec',
    'Lipiec',
    'Sierpień',
    'Wrzesień',
    'Październik',
    'Listopad',
    'Grudzień',
  ];

  constructor(private songsService: SongsService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.songIdSub = this.route.params.subscribe(params => {
      const id = +params['id']; 
      this.songsService.getYearsReport(id);
      this.songsService.getChannelsReport(id);
      this.songsService.getSong(id);
   });
  }

  ngOnDestroy() {
    this.songIdSub.unsubscribe();
  }
}
