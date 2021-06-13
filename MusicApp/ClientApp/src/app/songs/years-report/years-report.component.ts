import { Component, Input, OnInit } from '@angular/core';
import { YearReport } from 'src/app/services/songs/interfaces';

@Component({
  selector: 'app-years-report',
  templateUrl: './years-report.component.html',
  styleUrls: ['./years-report.component.css'],
})
export class YearsReportComponent implements OnInit {
  @Input() yearsReport: YearReport[] = [];
  @Input() labels: string[] = [];
  years: number[] = [];
  defaultYear: string = '';
  chartData: any;
  options: any = {
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
            stepSize: 1
          },
        },
      ],
    },
  }

  constructor() {}

  ngOnInit() {
    if(this.yearsReport.length === 0){
      return;
    }
    this.years = this.yearsReport.map((x) => x.year);
    this.defaultYear = this.yearsReport.map((x) => x.year)[0].toString();
    this.display(this.defaultYear);
  }

  display(year: string): any {
    const parsedYear = parseInt(year);
    var yearReport = this.yearsReport.find((x) => x.year === parsedYear);
    if (!yearReport) {
      return this.display(this.defaultYear);
    }

    const newDataSet = Object.assign({}, this.chartData, {
      label: `Liczba odtworzeń w ${year}`,
      borderColor: '#e1423a',
      fill: true,
      backgroundColor: '#18161580',
      data: yearReport.months,
    });

    this.chartData = {
      labels: this.labels,
      datasets: [newDataSet],
    };
  }
}
