import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './interfaces';

@Injectable()
export class UsersService {
  constructor(private http: HttpClient) {}

  all() {
    return this.http.get<User[]>("api/users");
  }

  create(user: User) {
    return this.http.post<string>("api/users", user);
  }

  update(user: User) {
    return this.http.put(`api/users/${user.id}`, user);
  }

  delete(user: User) {
    return this.http.delete(`api/users/${user.id}`);
  }
}
