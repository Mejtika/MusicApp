import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, UserForCreate, UserForUpdate } from './interfaces';

@Injectable()
export class UsersService {
  constructor(private http: HttpClient) {}

  all() {
    return this.http.get<User[]>("api/users");
  }

  create(user: UserForCreate) {
    return this.http.post<string>("api/users", user);
  }

  update(user: UserForUpdate) {
    return this.http.put(`api/users/${user.id}`, user);
  }

  delete(user: User) {
    return this.http.delete(`api/users/${user.id}`);
  }
}
