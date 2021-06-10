import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { User } from './interfaces';
import { UsersService } from './users.service';

@Injectable()
export class UsersFacade {
  private allUsers = new Subject<User[]>();
  private selectedUser = new Subject<User>();
  private mutations = new Subject();

  allUsers$ = this.allUsers.asObservable();
  selectedUser$ = this.selectedUser.asObservable();
  mutations$ = this.mutations.asObservable();

  constructor(private usersService: UsersService) {}

  reset() {
    this.mutations.next(true);
  }

  selectUsers(widget: User) {
    this.selectedUser.next(widget);
  }

  loadUsers() {
    this.usersService
      .all()
      .subscribe((users: User[]) => this.allUsers.next(users));
  }

  saveUser(user: User) {
    if (user.id) {
      this.updateUser(user);
    } else {
      this.createUser(user);
    }
  }

  createUser(user: User) {
    this.usersService.create(user).subscribe((_) => this.reset());
  }

  updateUser(user: User) {
    this.usersService.update(user).subscribe((_) => this.reset());
  }

  deleteUser(user: User) {
    this.usersService.delete(user).subscribe((_) => this.reset());
  }
}
