import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { EmissionsService } from '../services/emissions/emissions.service';
import { Emission } from '../services/emissions/interfaces';
import {
  FilterMatchMode,
  FilterMetadata,
  LazyLoadEvent,
  SelectItem,
} from 'primeng/api';
import 'moment-duration-format';
import * as moment from 'moment';

@Component({
  selector: 'app-emissions',
  templateUrl: './emissions.component.html',
  styleUrls: ['./emissions.component.css'],
})
export class EmissionsComponent {
  pagedEmissions$ = this.emissionsService.pagedEmissions$;
  loadingEmissions$ = this.emissionsService.loadingEmissions$;
  textModeOptions: SelectItem[] = [
    { label: 'Nazwa równa', value: 'eq' },
    { label: 'Nazwa zawiera', value: FilterMatchMode.CONTAINS },
  ];
  dateModeOptions: SelectItem[] = [
    { label: 'Data równa', value: 'eq' },
    { label: 'Data przed', value: FilterMatchMode.LESS_THAN },
    { label: 'Data po', value: FilterMatchMode.GREATER_THAN },
  ];
  durationModeOptions: SelectItem[] = [
    { label: 'Czas mniejszy', value: FilterMatchMode.LESS_THAN },
    { label: 'Czas większy', value: FilterMatchMode.GREATER_THAN },
  ];
  rowsPerPageOptions: number[] = [5, 10, 15];
  rows: number = 10;
  filters: string = '';
  excelLoader: boolean = false;

  constructor(
    private router: Router,
    private emissionsService: EmissionsService
  ) {}

  ngOnInit() {
    const initialValue = `$skip=0&$top=${this.rows}&count=true`;
    this.emissionsService.get(initialValue);
  }

  onRowSelect(event: any) {
    this.router.navigateByUrl(`/songs/${event.data.SongId}`);
  }

  loadEmissions($event: LazyLoadEvent) {
    this.emissionsService.get(this.getQueryParams($event));
  }

  exportExcel() {
    this.excelLoader = true;
    this.emissionsService.getForExcel(this.filters).subscribe((result) => {
      const emissions: Emission[] = result.value;
      import('xlsx').then((xlsx) => {
        const worksheet = xlsx.utils.json_to_sheet(emissions);
        const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = xlsx.write(workbook, {
          bookType: 'xlsx',
          type: 'array',
        });
        this.saveAsExcelFile(excelBuffer, 'customers');
      });
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE =
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    this.excelLoader = false;
    FileSaver.saveAs(
      data,
      fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION
    );
  }

  private getQueryParams($event: LazyLoadEvent) {
    const filters = (this.filters = this.createFilters($event.filters));
    const paging: string = `$skip=${$event.first}&$top=${$event.rows}`;
    const ordering: string = this.createOrdering($event);
    const result = `${filters}&${paging}&${ordering}`;
    return result;
  }

  private createFilters(filters: any): string {
    if (filters == null) {
      return '';
    }
    const initialValue = '$filter=';
    let combinedFilters = initialValue;

    var emissionProperties = Object.keys(filters);

    for (const property of emissionProperties) {
      var filterData = filters[property][0];
      switch (property) {
        case 'ChannelName':
        case 'SongTitle':
          combinedFilters += this.createTextFilter(property, filterData);
          break;
        case 'EmittedOn':
          combinedFilters += this.createDateFilter(property, filterData);
          break;
        case 'Duration':
          combinedFilters += this.createDurationFilter(property, filterData);
          break;
        default:
          break;
      }
    }

    if (combinedFilters === initialValue) {
      return '';
    }

    return combinedFilters.slice(0, -4);
  }

  private createOrdering($event: LazyLoadEvent): string {
    const orderBy =
      $event.sortField != null ? `$orderBy=${$event.sortField}` : '';
    let ascDesc = '';
    if ($event.sortOrder != null) {
      ascDesc = $event.sortOrder === 1 ? 'asc' : 'desc';
    }
    return `${orderBy} ${ascDesc}&$count=true`;
  }

  private createTextFilter(property: string, filterData: FilterMetadata) {
    if (filterData.value == null) {
      return '';
    }

    if (filterData.matchMode === 'startsWith') {
      return `${property} eq '${filterData.value}' and `;
    }

    if (filterData.matchMode === 'contains') {
      return `contains(${property},'${filterData.value}') and `;
    }
    return '';
  }

  private createDateFilter(property: string, filterData: any) {
    if (filterData.value == null) {
      return '';
    }

    const formattedDate = moment(filterData.value).format('YYYY-MM-DD');
    if (filterData.matchMode === 'dateIs') {
      return `${property} eq ${formattedDate} and `;
    }

    return `${property} ${filterData.matchMode} ${formattedDate} and `;
  }

  private createDurationFilter(property: string, filterData: any) {
    if (filterData.value == null) {
      return '';
    }

    const correctFormat = new RegExp(/^\d{2}:\d{2}:\d{2}$/i);
    if (!correctFormat.test(filterData.value)) {
      return '';
    }

    if (filterData.matchMode === 'equals') {
      return `${property} lt ${filterData.value} and`;
    }

    return `${property} ${filterData.matchMode} ${filterData.value} and`;
  }
}
