import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Subject } from 'rxjs';
import { User, UserForCreate, UserForUpdate } from './interfaces';
import { UsersService } from './users.service';

@Injectable()
export class UsersFacade {
  private allUsers = new Subject<User[]>();
  private mutations = new Subject();
  allUsers$ = this.allUsers.asObservable();
  mutations$ = this.mutations.asObservable();

  constructor(private usersService: UsersService, private messageService: MessageService) {}

  reset(message: string) {
    this.mutations.next(true);
    this.messageService.add({severity:'success', summary: 'Sukces', detail: message});
  }

  loadUsers() {
    this.usersService
      .all()
      .subscribe((users: User[]) => this.allUsers.next(users));
  }

  createUser(user: UserForCreate) {
    this.usersService.create(user).subscribe((_) => this.reset("Pomyślnie utworzono nowego użytkownika."));
  }

  updateUser(user: UserForUpdate) {
    this.usersService.update(user).subscribe((_) => this.reset("Pomyślnie zaktualizowano dane użytkownika."));
  }

  deleteUser(user: User) {
    this.usersService.delete(user).subscribe((_) => this.reset("Pomyślnie usunięto użytkownika."));
  }
}
