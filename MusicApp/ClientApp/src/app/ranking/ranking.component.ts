import { Component, OnInit } from '@angular/core';
import { SongsService } from '../services/songs/songs.service';
import { RankedSong } from '../services/songs/interfaces';
import { Router } from '@angular/router';
@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css'],
})
export class RankingComponent implements OnInit {
  cols: any[] = [];
  ranking$ = this.songsService.ranking$;

  constructor(private songsService: SongsService, private router: Router) {}

  ngOnInit() {
    this.songsService.getRanking();
    this.cols = [
      { field: 'place', header: 'Miejsce' },
      { field: 'title', header: 'Tytuł' },
      { field: 'count', header: 'Odtworzenia' },
    ];
  }

  selectedRank(rank: RankedSong) {
    this.router.navigateByUrl(`/songs/${rank.songId}`);
  }
}
