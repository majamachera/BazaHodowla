import { ResourceLoader } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Puppy } from 'src/app/_models/pup';
import { VaccinationPuppy } from 'src/app/_models/vaccinationPuppy';
import { ActionService } from 'src/app/_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-addVaccinationPup',
  templateUrl: './addVaccinationPup.component.html',
  styleUrls: ['./addVaccinationPup.component.css']
})
export class AddVaccinationPupComponent implements OnInit {
  constructor(public actionService: ActionService) { }
  model: any = {};
  vac: VaccinationPuppy[];
  id = this.actionService.iddopupedit;
  ngOnInit() {
  }
  addvac() {
    this.actionService.addVaccinationPuppy(this.model).subscribe(() => {
      this.vac.splice(this.vac.findIndex(p => p.id === this.model), 1);
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
