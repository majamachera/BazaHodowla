import { ResourceLoader } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Puppy } from 'src/app/_models/pup';
import { ActionService } from 'src/app/_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-addpup',
  templateUrl: './addpup.component.html',
  styleUrls: ['./addpup.component.css']
})
export class AddpupComponent implements OnInit {
  constructor(public actionService: ActionService) { }
  model: any = {};
  pup: Puppy[];
  id = this.actionService.iddopup;
  ngOnInit() {
  }
  addpup() {
    this.actionService.addpup(this.model).subscribe(() => {
      this.pup.splice(this.pup.findIndex(p => p.id === this.model), 1);
      alertify.success('Utworzono nowego szczeniaka');
      location.reload();
    }, error => {
      alertify.error('Akcja nie powiodła się');
    });
    }
  canceladd() {
    console.log(this.actionService.iddopup);
    location.reload();
   }

}
