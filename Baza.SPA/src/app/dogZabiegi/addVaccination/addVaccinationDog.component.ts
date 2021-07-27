import { ResourceLoader } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { VaccinationDog } from 'src/app/_models/vaccinationDog';
import { ActionService } from 'src/app/_services/action.service';
declare let alertify: any;
@Component({
  selector: 'app-addVaccinationDog',
  templateUrl: './addVaccinationDog.component.html',
  styleUrls: ['./addVaccinationDog.component.css']
})
export class AddVaccinationDogComponent implements OnInit {
  constructor(public actionService: ActionService) { }
  model: any = {};
  vac: VaccinationDog[];
  id = this.actionService.iddopupedit;
  ngOnInit() {
  }
  addvac() {
    this.actionService.addVaccinationDog(this.model).subscribe(() => {
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
