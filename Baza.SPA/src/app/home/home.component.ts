import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActionService } from '../_services/action.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  constructor(private http: HttpClient, private actionService: ActionService) { }

  ngOnInit() {
  }
  registerToggle() {
   this.registerMode = true;
  }
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
  loggerIn() {
    return this.actionService.loggerin();
  }
  logout() {
    localStorage.removeItem('token');
    console.log('Zostałeś wylogowany');
  }
}
