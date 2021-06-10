import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { User } from '../services/users/interfaces';
import { UsersService } from '../services/users/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  @ViewChild('dt') dt: Table | undefined;
  users: User[] = [];
  selectedUser: User | undefined;
  productDialog: boolean = false;
  createForm!: FormGroup;
  updateForm!: FormGroup;

  applyFilterGlobal($event: any, stringVal: any) {
    console.log(($event.target as HTMLInputElement).value);
    this.dt!.filterGlobal(
      ($event.target as HTMLInputElement).value,
      'contains'
    );
  }

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private usersService: UsersService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.usersService.all().subscribe((users) => {
      this.users = users;
    });

    this.createForm = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

    this.updateForm = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['']
    });
  }

  createUserSubmit(form: FormGroup) {
    let newUser: User = {
        userName: form.value.userName,
        email: form.value.email,
        password: form.value.password,
        emailConfirmed: true
    };
    this.usersService.create(newUser).subscribe((id) => {
      newUser.id = id;
      this.users = [...this.users, newUser];
      this.hideDialog();
    });
  }

  updateUserSubmit(form: FormGroup){
    const userToUpdate: User = {
      id: this.selectedUser?.id!,
      userName: form.value.userName,
      email: form.value.email,
      password: form.value.password,
      emailConfirmed: true
    };
    this.usersService.update(userToUpdate).subscribe((_) => {
      this.users = this.users.map((user) => {
        return user.id === userToUpdate.id
          ? {...user, ...userToUpdate}
          : user;
      });
      this.selectedUser = undefined;
      this.hideDialog();
    });
  }

  createUser() {
    this.productDialog = true;
  }

  hideDialog(){
    this.productDialog = false;
  }

  editUser(user: User) {
    console.log(user);
    this.selectedUser = user;
    this.updateForm.patchValue(user);
    this.productDialog = true;
  }

  deleteUser(user: User) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + user.email + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.usersService.delete(user).subscribe((_) => {
          this.users = this.users.filter((u) => u.id !== user.id);
        });
      },
    });
  }
}