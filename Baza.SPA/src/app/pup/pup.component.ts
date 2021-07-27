import { Component, OnInit } from '@angular/core';
import { DogService } from '../_services/dog.service';
import { Puppy } from '../_models/pup';
import { Fdog } from '../_models/fdog';
import { FdogComponent } from '../fdog/fdog.component';
import { ActionService } from '../_services/action.service';
import { Sort } from '@angular/material/sort';
import { AppComponent } from '../app.component';
declare let alertify: any;
@Component({
  selector: 'app-pup',
  templateUrl: './pup.component.html',
  styleUrls: ['./pup.component.css']
})
export class PupComponent implements OnInit {

  constructor(private dogService: DogService,
              public actionService: ActionService, ) {
     }
  elements: any = [];
  pup: Puppy[];
  addMode = false;
  editMode = false;
  zprojektuid: any;
  sortedData: Puppy[];
  fdog: Fdog;
  iddopup = this.actionService.iddopup;
  ngOnInit() {
  this.loadPups();
  }
  
  addToggle() {
    this.addMode = true;
   }
  outToggle() {
    this.addMode = false;
   }
  editToggle() {
    this.editMode = true;
   }
  outeditToggle() {
    this.editMode = false;
   }
   canceleditMode(editMode: boolean) {
    this.editMode = editMode;
   }
  
  loadPups() {
    this.dogService.getPups().subscribe((pup: Puppy[]) => {
       this.pup = pup;
    }, error => {
    alertify.error('error');
    });
  }
  delatePup(id: number) {
    alertify.confirm('"Czy na pewno chcesz usunąć to zwierze z zestawienia?', () => {
      this.actionService.delatePup(id).subscribe(() => {
        this.pup.splice(this.pup.findIndex(p => p.id === id), 1);
        alertify.success('Zwierze zostało usunięte z zestawienia');
      }, error => {
        alertify.error('Błąd podczas usówania');
      });
    });

  }
  takeid(id) {
    this.actionService.takepupid(id);
    console.log("takepup");
     }
  loadPupsort(sort: Sort) {
    this.dogService.getPups().subscribe((pup: Puppy[]) => {
      this.pup = pup;
      const data = this.pup.slice();
      if (!sort.active || sort.direction === '') {
        this.pup = data;
        return;
      }
      this.pup = data.sort((a, b) => {
        const isAsc = sort.direction === 'asc';
        switch (sort.active) {
          case 'imie': return compare(a.imie, b.imie, isAsc);
          case 'plec': return compare(a.plec, b.plec, isAsc);
          case 'rasa': return compare(a.rasa, b.rasa, isAsc);
          case 'masc': return compare(a.masc, b.masc, isAsc);
          case 'dlugoscSiersci': return compare(a.dlugoscSiersci, b.dlugoscSiersci, isAsc);
          case 'rodowod': return compare(a.rodowod, b.rodowod, isAsc);
          case 'dataUrodzenia': return compare(a.dataUrodzenia, b.dataUrodzenia, isAsc);
          default: return 0;
        }
      });
    }, error => {
    alertify.error('error');
    });
  }
}
function compare(a: number | string | boolean, b: number | string | boolean, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}

