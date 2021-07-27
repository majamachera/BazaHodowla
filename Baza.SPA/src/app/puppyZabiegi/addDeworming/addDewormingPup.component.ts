import { Component, OnInit } from '@angular/core';
import { DewormingPuppy } from 'src/app/_models/dewormingPuppy';
import { Puppy } from 'src/app/_models/pup';
import { VaccinationPuppy } from 'src/app/_models/vaccinationPuppy';
import { ActionService } from 'src/app/_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-addDewormingPup',
  templateUrl: './addDewormingPup.component.html',
  styleUrls: ['./addDewormingPup.component.css']
})
export class AddDewormingPupComponent implements OnInit {
  constructor(public actionService: ActionService) { }
  model: any = {};
  dew: DewormingPuppy[];
  id = this.actionService.iddopupedit;
  ngOnInit() {
  }
  adddew() {
    this.actionService.addDewormingPuppy(this.model).subscribe(() => {
      this.dew.splice(this.dew.findIndex(p => p.id === this.model), 1);
      alertify.success('Utworzono nowe szczepienie');
      location.reload();
    }, error => {
      alertify.error('Akcja nie powiodła się');
    });
    }
  canceladdV() {
    location.reload();
   }

}
