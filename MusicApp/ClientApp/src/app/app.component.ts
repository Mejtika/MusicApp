import { Component } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { SessionStorageKey } from '../api-authorization/api-authorization.constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title = 'musicapp';

  public isAdmin(): boolean {
    const userInfo: string | null = window.sessionStorage.getItem(SessionStorageKey);
    if(userInfo){
      return JSON.parse(userInfo).profile.role === "Admin";
    }
    return false;
  }
}
