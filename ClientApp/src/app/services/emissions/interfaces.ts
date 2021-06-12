export interface Emission {
  EmissionId: number;
  ChannelName: string;
  EmittedOn: Date;
  Duration: any;
  SongId: number;
  SongTitle: string;
}

export interface PagedResult {
  value: Emission[];
  count: number;
}
