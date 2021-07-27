import { Component, OnInit } from '@angular/core';
import { ActionService } from './_services/action.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwthelper = new JwtHelperService();
  title: 'Hodowla Psów Rasowych';
  iddopup: any;
  constructor(private actionService: ActionService) {}
  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.actionService.decodedtoken = this.jwthelper.decodeToken(token);
    }
    this.actionService.savefdogid();
    this.actionService.savepupid();
  }
}
