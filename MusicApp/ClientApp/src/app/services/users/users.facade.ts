import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { User, UserForCreate, UserForUpdate } from './interfaces';
import { UsersService } from './users.service';

@Injectable()
export class UsersFacade {
  private allUsers = new Subject<User[]>();
  private mutations = new Subject();
  allUsers$ = this.allUsers.asObservable();
  mutations$ = this.mutations.asObservable();

  constructor(private usersService: UsersService) {}

  reset() {
    this.mutations.next(true);
  }

  loadUsers() {
    this.usersService
      .all()
      .subscribe((users: User[]) => this.allUsers.next(users));
  }

  createUser(user: UserForCreate) {
    this.usersService.create(user).subscribe((_) => this.reset());
  }

  updateUser(user: UserForUpdate) {
    this.usersService.update(user).subscribe((_) => this.reset());
  }

  deleteUser(user: User) {
    this.usersService.delete(user).subscribe((_) => this.reset());
  }
}
