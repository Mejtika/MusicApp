import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css'],
})
export class SongComponent implements OnInit {
  data: any;
  dataPerYear: Record<number, number[]> = {};
  years: number[] = [];
  selectedYear: number = 0;
  labels: string[] = [
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

  getDefaultDataset(year: number, data: any) {
    return {
      label: `Liczba odtworzeń w ${year}`,
      borderColor: '#e1423a',
      data: data,
    };
  }

  changeYear(year: string) {
    const parsedYear = parseInt(year);
    const newDataSet = Object.assign({}, this.data, {
      label: `Liczba odtworzeń w ${year}`,
      borderColor: '#e1423a',
      data: this.dataPerYear[parsedYear],
    });
    this.data = {
      labels: this.labels,
      datasets: [newDataSet],
    };
  }

  constructor() {}

  ngOnInit() {
    this.dataPerYear = {
      2019: [65, 59, 80, 81, 56, 55, 40, 60, 70, 80, 90, 10],
      2020: [41, 39, 50, 34, 51, 98, 41, 34, 54, 86, 10, 25],
      2021: [13, 53, 43, 12, 42, 32, 45, 70, 78, 80, 10, 90],
    };

    this.years = Object.keys(this.dataPerYear).map((x) => parseInt(x));
    this.selectedYear = this.years[0];
    const defaultDataSet = this.getDefaultDataset(this.selectedYear, this.dataPerYear[this.selectedYear]);
    this.data = {
      labels: this.labels,
      datasets: [defaultDataSet],
    };

    const dataPerChannel = {
      "Eska": 300,
      "Radio Zet": 200,
      "Złote przeboje": 100,
      "Internetowe": 50,
      "Eska rock": 120
    }

    const channels = Object.keys(dataPerChannel);
    const values = Object.values(dataPerChannel);
    const colors = channels.map(x => this.getRandomColor());
    const dataSet = {
      data: values,
      backgroundColor: colors
    }
    
    this.pieData = {
      labels: channels,
      datasets: [dataSet]
    };

  }

  // dataPerChannel: Record<string, number> = {};
  pieData: any = {};
  getRandomColor() {
    let color = '#';
    for (var i = 0; i < 6; i++) {
        color += '0123456789ABCDEF'[Math.floor(Math.random() * 16)];
    }
    return color;
}
 
}
