
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ActionService } from 'src/app/_services/action.service';
import { UserService } from 'src/app/_services/user.service';
import { Router } from '@angular/router';
import { DogService } from 'src/app/_services/dog.service';
declare let alertify: any;
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  model: any = {};
  constructor(private dogService: DogService,
              public actionService: ActionService,
              public userService: UserService,
              private router: Router) { }
  @Output() cancelAdd = new EventEmitter();
  ngOnInit() {
  }
  addFdog() {
    this.actionService.addfdog(this.model).subscribe(() => {
      alertify.success('Utworzono nowe zwierze');
      location.reload();
    }, error => {
      alertify.error('Akcja nie powiodła się');
    });
    }
  canceladd() {
    location.reload();
   }
}

