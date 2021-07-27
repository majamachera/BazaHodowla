import { Injectable } from '@angular/core';
import { Component, OnInit, Input } from '@angular/core';
import { Fdog } from 'src/app/_models/fdog';
import { ActionService } from 'src/app/_services/action.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';
import { DogService } from 'src/app/_services/dog.service';
import { UserService } from 'src/app/_services/user.service';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
})
};


declare let alertify: any;
@Component({
  selector: 'app-fdog',
  templateUrl: './fdog.component.html',
  styleUrls: ['./fdog.component.css']
})
export class FdogComponent implements OnInit {
  model: any = {};
  linkinumber: 0;
  fdog: Fdog[];
  decodedtoken: any;
  @Input()fdogs: Fdog[];
  constructor(private dogService: DogService,
              public actionService: ActionService,
              public userService: UserService,
              private router: ActivatedRoute) { }

    ngOnInit() {
    this.loadFdog();
    this.decodedtoken = this.actionService.decodedtoken;
    }
    loadFdog() {
      this.dogService.getFdogs().subscribe((fdog: Fdog[]) => {
        this.fdog = fdog;
      }, error => {
      alertify.error('error');
      });
    }
    loggerIn() {
      return this.actionService.loggerin();
    }
    takeid(id) {
    this.actionService.takeid(id);
     }
     takeidtoedit(id){
        this.actionService.takeid(id);
     }
  }
