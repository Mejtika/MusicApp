import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { YearReport, ChannelReport, Song, RankedSong } from './interfaces';

@Injectable()
export class SongsService {
  constructor(private http: HttpClient) {}
  private yearsReport = new Subject<YearReport[]>();
  private channelsReport = new Subject<ChannelReport[]>();
  private song = new Subject<Song | null>();
  private ranking = new Subject<RankedSong[]>();

  public yearsReport$ = this.yearsReport.asObservable();
  public channelsReport$ = this.channelsReport.asObservable();
  public song$ = this.song.asObservable();
  public ranking$ = this.ranking.asObservable();

  getYearsReport(id: number) {
    return this.http
      .get<YearReport[]>(`api/songs/${id}/yearsReport`)
      .subscribe((report: YearReport[]) => {
        this.yearsReport.next(report);
      });
  }

  getChannelsReport(id: number) {
    return this.http
      .get<ChannelReport[]>(`api/songs/${id}/channelsReport`)
      .subscribe((report: ChannelReport[]) => {
        this.channelsReport.next(report);
      });
  }

  getSong(id: number) {
    return this.http
      .get<Song>(`api/songs/${id}`)
      .subscribe((song: Song) => this.song.next(song));
  }

  getRanking() {
    return this.http
      .get<RankedSong[]>('api/songs/ranking')
      .subscribe((ranking) => this.ranking.next(ranking));
  }
}
