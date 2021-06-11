import { Component, Input, OnInit } from '@angular/core';
import { ChannelReport } from '../../services/song/interfaces';

@Component({
  selector: 'app-channels-report',
  templateUrl: './channels-report.component.html',
  styleUrls: ['./channels-report.component.css'],
})
export class ChannelsReportComponent implements OnInit {
  @Input() channelsReport: ChannelReport[] = [];
  chartData: any;

  constructor() {}

  ngOnInit() {
    const channels = this.channelsReport.map(x => x.name);
    const values = this.channelsReport.map(x => x.count);
    const colors = channels.map(_ => this.getRandomColor());
    const dataSet = {
      data: values,
      backgroundColor: colors,
    };
    this.chartData = {
      labels: channels,
      datasets: [dataSet],
    };
  }

  getRandomColor() {
    let color = '#';
    for (var i = 0; i < 6; i++) {
      color += '0123456789ABCDEF'[Math.floor(Math.random() * 16)];
    }
    return color;
  }
}
