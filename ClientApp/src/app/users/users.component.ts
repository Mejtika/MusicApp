import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Customer } from '../songs/songs.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  @ViewChild('dt') dt: Table | undefined;

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(
      ($event.target as HTMLInputElement).value,
      'contains'
    );
  }

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

  customer: Customer = {};
  productDialog: boolean = false;
  submitted: boolean = false;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {}

  openNew() {
    this.customer = {};
    this.submitted = false;
    this.productDialog = true;
  }

  counter = 10000;

  editProduct(customer: Customer) {
    this.customer = { ...customer };
    this.productDialog = true;
  }

  findIndexById(id: number): number {
    let index = -1;
    for (let i = 0; i < this.customers.length; i++) {
      if (this.customers[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  saveCustomer() {
    this.submitted = true;

    if (this.customer.id) {
      this.customers[this.findIndexById(this.customer.id)] = this.customer;
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'Product Updated',
        life: 3000,
      });
    } else {
      this.customer.id =
        this.customers[this.customers.length - 1].id ?? this.counter++;
      this.customers.push(this.customer);
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'Product Created',
        life: 3000,
      });
    }

    this.customers = [...this.customers];
    this.productDialog = false;
    this.customer = {};
  }

  hideDialog() {
    this.productDialog = false;
    this.submitted = false;
  }

  deleteProduct(customer: Customer) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + customer.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.customers = this.customers.filter((val) => val.id !== customer.id);
        this.customer = {};
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Customer Deleted',
          life: 3000,
        });
      },
    });
  }
}
