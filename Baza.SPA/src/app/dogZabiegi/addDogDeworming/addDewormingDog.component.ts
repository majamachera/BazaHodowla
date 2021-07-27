import { Component, OnInit } from '@angular/core';
import { DewormingDog } from 'src/app/_models/dewormingDog';
import { DewormingPuppy } from 'src/app/_models/dewormingPuppy';
import { Puppy } from 'src/app/_models/pup';
import { VaccinationPuppy } from 'src/app/_models/vaccinationPuppy';
import { ActionService } from 'src/app/_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-addDewormingDog',
  templateUrl: './addDewormingDog.component.html',
  styleUrls: ['./addDewormingDog.component.css']
})
export class AddDewormingDogComponent implements OnInit {
  constructor(public actionService: ActionService) { }
  model: any = {};
  dew: DewormingDog[];
  id = this.actionService.iddopupedit;
  ngOnInit() {
  }
  adddew() {
    this.actionService.addDewormingDog(this.model).subscribe(() => {
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
