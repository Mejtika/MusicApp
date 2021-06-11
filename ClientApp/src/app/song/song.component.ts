import { Component, OnInit } from '@angular/core';
import { SongService } from '../services/song/song.service';
import { Observable, Subscriber, Subscription } from 'rxjs';
import { ChannelReport, Song, YearReport } from '../services/song/interfaces';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css'],
})
export class SongComponent implements OnInit {
  private songIdSub: any;
  yearsReport$: Observable<YearReport[]> = this.songService.yearsReport$;
  channelsReport$: Observable<ChannelReport[]> = this.songService.channelsReport$;
  song$: Observable<Song | null> = this.songService.song$;
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

  constructor(private songService: SongService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.songIdSub = this.route.params.subscribe(params => {
      const id = +params['id']; 
      this.songService.getYearsReport(id);
      this.songService.getChannelsReport(id);
      this.songService.getSong(id);
   });
  }

  ngOnDestroy() {
    this.songIdSub.unsubscribe();
  }
}
