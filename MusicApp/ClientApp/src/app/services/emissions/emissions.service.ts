import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagedResult } from './interfaces';
import { Subject, BehaviorSubject } from 'rxjs';
import * as FileSaver from 'file-saver';
import 'moment-duration-format';
import * as moment from 'moment';

@Injectable()
export class EmissionsService {
  constructor(private http: HttpClient) {}
  private pagedEmissions = new Subject<PagedResult>();
  private loadingEmissions = new BehaviorSubject<boolean>(false);
  public pagedEmissions$ = this.pagedEmissions.asObservable();
  public loadingEmissions$ = this.loadingEmissions.asObservable();

  public get(params: string) {
    this.loadingEmissions.next(true);
    this.http.get<any>(`odata/emissions?${params}`).subscribe((result) => {
      const pagedResult: PagedResult = {
        value: result.value,
        count: result['@odata.count'],
      };
      this.pagedEmissions.next(pagedResult);
      this.loadingEmissions.next(false);
    });
  }

  public getForExcel(params: string) {
    return this.http.get<any>(`odata/emissions?${params}`);
  }

  public exportToExcel(emissions: any) {
    emissions = emissions.map((e: any) => {
      return {
        ...e,
        Duration: moment(e.Duration, [moment.ISO_8601, 'HH:mm:ss']).format(
          'HH:mm:ss'
        ),
      };
    });

    emissions = emissions.map((e: any) => {
      return {
        ...e,
        EmittedOn: moment(e.EmittedOn).format('MM/DD/YYYY HH:mm:ss'),
      };
    });
    const header = {
      header: [
        'EmissionId',
        'ChannelName',
        'SongId',
        'SongTitle',
        'EmittedOn',
        'Duration',
      ],
    };
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(emissions, header);
      const workbook = {
        Sheets: { data: worksheet },
        SheetNames: ['data'],
      };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'emissions');
    });
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE =
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    FileSaver.saveAs(
      data,
      fileName +
        '_export_' +
        moment().format('MM-DD-YYYY_hh:mm:ss').toString() +
        EXCEL_EXTENSION
    );
  }
}
