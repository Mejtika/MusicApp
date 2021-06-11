import { Component, Input, OnInit } from '@angular/core';
import { Song } from '../../services/song/interfaces';

import 'moment-duration-format';
import * as moment from 'moment';

@Component({
  selector: 'app-song-details',
  templateUrl: './song-details.component.html',
  styleUrls: ['./song-details.component.css']
})
export class SongDetailsComponent implements OnInit {
  @Input() song: Song | undefined;
  moment: any = moment;
  constructor() { }

  ngOnInit() { 
    console.log(this.song);
       
  }

}
