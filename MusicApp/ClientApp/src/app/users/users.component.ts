import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Observable } from 'rxjs';
import { User } from '../services/users/interfaces';
import { CreateUserComponent } from './create-user/create-user.component';
import { UsersFacade } from '../services/users/users.facade';
import { UpdateUserComponent } from './update-user/update-user.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  users$: Observable<User[]> = this.usersFacade.allUsers$;
  productDialog: boolean = false;

  constructor(
    private usersFacade: UsersFacade,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.reset();
    this.usersFacade.mutations$.subscribe((_) => this.reset());
  }

  reset() {
    this.usersFacade.loadUsers();
  }

  createUser() {
    const modalRef = this.modalService.open(CreateUserComponent, {
      centered: true,
    });
    modalRef.result.then(
      (result) => {
        this.usersFacade.createUser(result);
      },
      (_) => _
    );
  }

  editUser(user: User) {
    const modalRef = this.modalService.open(UpdateUserComponent, {
      centered: true,
    });
    modalRef.componentInstance.user = user;
    modalRef.result.then(
      (result) => {
        this.usersFacade.updateUser(result);
      },
      (_) => _
    );
  }

  deleteUser(user: User) {
    const modalRef = this.modalService.open(DeleteUserComponent, {
      centered: true,
    });
    modalRef.componentInstance.user = user;
    modalRef.result.then(
      (_) => {
        this.usersFacade.deleteUser(user);
      },
      (_) => _
    );
  }
}
