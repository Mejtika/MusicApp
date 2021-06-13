import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { PagedResult, Emission } from '../../services/emissions/interfaces';
import 'moment-duration-format';
import * as moment from 'moment';

@Component({
  selector: 'app-emissionsList',
  templateUrl: './emissionsList.component.html',
  styleUrls: ['./emissionsList.component.css'],
})
export class EmissionsListComponent {
  emissions: Emission[] = [];
  totalRecords: number = 0;
  duration: Date = new Date(0, 0, 0, 0, 0, 0, 0);
  @Input() set pagedEmissions(result: PagedResult) {
    this.emissions = result.value;
    this.totalRecords = result.count;
  }
  @Input() loading: boolean = false;
  @Input() textModeOptions: SelectItem[] = [];
  @Input() dateModeOptions: SelectItem[] = [];
  @Input() durationModeOptions: SelectItem[] = [];
  @Input() rows: number = 0;
  @Input() rowsPerPageOptions: number[] = [];
  @Input() excelLoader: boolean = false;
  @Output() loaded = new EventEmitter();
  @Output() rowSelected = new EventEmitter();
  @Output() exported = new EventEmitter();
  moment: any = moment;
  constructor() {}

  onLoad($event: any) {
    this.loaded.emit($event);
  }

  exportToExcel() {
    this.exported.emit();
  }
}
