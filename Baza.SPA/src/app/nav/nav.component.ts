import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActionService } from '../_services/action.service';
import { HttpClient } from '@angular/common/http';
declare let alertify: any;
import { DebugElement } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  @ViewChild('loginForm') loginForm: NgForm;
  constructor(public actionService: ActionService, private router: Router) {}

  ngOnInit() {
  }
  login() {
  
    this.actionService.login(this.model).subscribe(next => {
    alertify.success('Jesteś zalogowany');
  }, error => {
    alertify.error('Logowanie nie powiodło się');
  }, () => {
    this.router.navigate(['/menu']);
  });
  }
  loggerIn() {
    return this.actionService.loggerin();
  }
  logout() {
    localStorage.removeItem('token');
    alertify.message('Zostałeś wylogowany');
    this.router.navigate(['/home']);
  }
}

