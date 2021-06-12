export interface Artist {
  artistId: number;
  name: string;
  pseudonym: string;
  born: Date;
}

export interface Song {
  songId: number;
  title: string;
  version: string;
  duration: any;
  artists: Artist[];
}

export interface YearReport {
  year: number;
  months: number[];
}

export interface ChannelReport {
  name: string;
  count: number;
}
