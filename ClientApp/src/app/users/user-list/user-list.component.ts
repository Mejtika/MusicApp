import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from 'src/app/services/users/interfaces';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  @Input() users: User[] = [];
  @Output() selectedForCreate = new EventEmitter();
  @Output() selectedForUpdate = new EventEmitter();
  @Output() selectedForDelete = new EventEmitter();

  constructor() {}

  ngOnInit() {}

  createUser() {
    this.selectedForCreate.emit();
  }

  updateUser(user: User) {
    this.selectedForUpdate.emit(user);
  }

  deleteUser(user: User) {
    this.selectedForDelete.emit(user);
  }
}
