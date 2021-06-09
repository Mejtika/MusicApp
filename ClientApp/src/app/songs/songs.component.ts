import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import {
  FilterMatchMode,
  FilterService,
  LazyLoadEvent,
  PrimeNGConfig,
  SelectItem,
} from 'primeng/api';

export interface Country {
  name?: string;
  code?: string;
}

export interface Representative {
  name?: string;
  image?: string;
}

export interface Customer {
  id?: number;
  name?: string;
  country?: Country;
  company?: string;
  date?: string;
  status?: string;
  representative?: Representative;
}

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css'],
})
export class SongsComponent implements OnInit {
  customers: Customer[] = [
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1000,
      name: 'James Butt',
      country: {
        name: 'Algeria',
        code: 'dz',
      },
      company: 'Benton, John B Jr',
      date: '2015-09-13',
      status: 'unqualified',
      representative: {
        name: 'Ioni Bowcher',
        image: 'ionibowcher.png',
      },
    },
    {
      id: 1001,
      name: 'Josephine Darakjy',
      country: {
        name: 'Egypt',
        code: 'eg',
      },
      company: 'Chanay, Jeffrey A Esq',
      date: '2019-02-09',
      status: 'proposal',
      representative: {
        name: 'Amy Elsner',
        image: 'amyelsner.png',
      },
    },
    {
      id: 1002,
      name: 'Art Venere',
      country: {
        name: 'Panama',
        code: 'pa',
      },
      company: 'Chemel, James L Cpa',
      date: '2017-05-13',
      status: 'qualified',
      representative: {
        name: 'Asiya Javayant',
        image: 'asiyajavayant.png',
      },
    },
    {
      id: 1003,
      name: 'Lenna Paprocki',
      country: {
        name: 'Slovenia',
        code: 'si',
      },
      company: 'Feltz Printing Service',
      date: '2020-09-15',
      status: 'new',
      representative: {
        name: 'Xuxue Feng',
        image: 'xuxuefeng.png',
      },
    },
    {
      id: 1004,
      name: 'Donette Foller',
      country: {
        name: 'South Africa',
        code: 'za',
      },
      company: 'Printing Dimensions',
      date: '2016-05-20',
      status: 'proposal',
      representative: {
        name: 'Asiya Javayant',
        image: 'asiyajavayant.png',
      },
    },
    {
      id: 1005,
      name: 'Simona Morasca',
      country: {
        name: 'Egypt',
        code: 'eg',
      },
      company: 'Chapman, Ross E Esq',
      date: '2018-02-16',
      status: 'qualified',
      representative: {
        name: 'Ivan Magalhaes',
        image: 'ivanmagalhaes.png',
      },
    },
    {
      id: 1006,
      name: 'Mitsue Tollner',
      country: {
        name: 'Paraguay',
        code: 'py',
      },
      company: 'Morlong Associates',
      date: '2018-02-19',
      status: 'renewal',
      representative: {
        name: 'Ivan Magalhaes',
        image: 'ivanmagalhaes.png',
      },
    },
    {
      id: 1007,
      name: 'Leota Dilliard',
      country: {
        name: 'Serbia',
        code: 'rs',
      },
      company: 'Commercial Press',
      date: '2019-08-13',
      status: 'renewal',
      representative: {
        name: 'Onyama Limba',
        image: 'onyamalimba.png',
      },
    },
    {
      id: 1008,
      name: 'Sage Wieser',
      country: {
        name: 'Egypt',
        code: 'eg',
      },
      company: 'Truhlar And Truhlar Attys',
      date: '2018-11-21',
      status: 'unqualified',
      representative: {
        name: 'Ivan Magalhaes',
        image: 'ivanmagalhaes.png',
      },
    },
    {
      id: 1009,
      name: 'Kris Marrier',
      country: {
        name: 'Mexico',
        code: 'mx',
      },
      company: 'King, Christopher A Esq',
      date: '2015-07-07',
      status: 'proposal',
      representative: {
        name: 'Onyama Limba',
        image: 'onyamalimba.png',
      },
    },
    {
      id: 1010,
      name: 'Minna Amigon',
      country: {
        name: 'Romania',
        code: 'ro',
      },
      company: 'Dorl, James J Esq',
      date: '2018-11-07',
      status: 'qualified',
      representative: {
        name: 'Anna Fali',
        image: 'annafali.png',
      },
    },
  ];

  selectedCustomer: Customer = {};
  totalRecords: number = this.customers.length;
  loading: boolean = false;

  onRowSelect(event: any) {
    console.log(event.data);
    this.router.navigateByUrl('/ranking');
  }

  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.customers);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'customers');
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE =
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    FileSaver.saveAs(
      data,
      fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION
    );
  }

  selectedDate: Date = new Date();

  selectedTime: Date = new Date(0,0,0,0,0,0);  



  textModeOptions: SelectItem[] = [];
  dateModeOptions: SelectItem[] = [];
  durationModeOptions: SelectItem[] = [];


  constructor(
    private primengConfig: PrimeNGConfig,
    private router: Router,
    private filterService: FilterService
  ) {}

  ngOnInit() {

    this.textModeOptions = [
      { label: 'Nazwa zawiera', value: FilterMatchMode.CONTAINS },
      { label: 'Nazwa równa', value: FilterMatchMode.EQUALS },
    ];

    this.dateModeOptions = [
      { label: 'Data równa', value: FilterMatchMode.DATE_IS },
      { label: 'Data przed', value: FilterMatchMode.DATE_BEFORE },
      { label: 'Data po', value: FilterMatchMode.DATE_AFTER },
    ];

    this.durationModeOptions = [
      { label: 'Czas równy', value: FilterMatchMode.EQUALS },
      { label: 'Czas mniejszy', value: FilterMatchMode.LESS_THAN },
      { label: 'Czas większy', value: FilterMatchMode.GREATER_THAN },
    ];
  }

  loadCustomers(event: LazyLoadEvent) {
    console.log(event);
  }
}
