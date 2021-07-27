import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { registerLocaleData } from '@angular/common';

import { ActionService } from '../_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  constructor(private actionService: ActionService) { }
  @Output() cancelRegister = new EventEmitter();
  ngOnInit() {}
    register() {
      this.actionService.register(this.model).subscribe(() => {
        alertify.success('Rejestracja powiodła się');
      }, error => {
        alertify.error('Rejestracja nie powiodła się');
      });
    }
  cancel() {
    this.cancelRegister.emit(false);
    console.log('Anulowane');
  }

}
