import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { DewormingDog } from "../_models/dewormingDog";
import { DewormingPuppy } from "../_models/dewormingPuppy";
import { Puppy } from "../_models/pup";
import { ActionService } from "../_services/action.service";
import { Sort } from "@angular/material/sort";
import { DogService } from "../_services/dog.service";
import { VaccinationPuppy } from "../_models/vaccinationPuppy";
import { VaccinationDog } from "../_models/vaccinationDog";
import { Fdog } from "../_models/fdog";
declare let alertify: any;
@Component({
  selector: "app-dogZabiegi",
  templateUrl: "./dogZabiegi.component.html",
  styleUrls: ["./dogZabiegi.component.css"],
})
export class DogZabiegiComponent implements OnInit {
  constructor(
    public actionService: ActionService,
    private route: ActivatedRoute,
    public dogService: DogService
  ) {}
  dew: DewormingDog[];
  vac: VaccinationDog[];
  model: any = {};
  iddopupedit = this.actionService.iddopupedit;
  dog: Fdog;
  addModeV = false;
  addModeD = false;
  sortedData: DewormingDog[];
  sortedDataVac: VaccinationDog[];
  @Output() cancelAdd = new EventEmitter();
  ngOnInit() {
    this.loadDew();
    this.loadVac();
  }
  addToggleV() {
    this.addModeV = true;
   }
   addToggleD() {
    this.addModeD = true;
   }
  outToggleV() {
    this.addModeV = false;
   }
   outToggleD() {
    this.addModeD = false;
   }
   delateDew(id: number) {
    alertify.confirm('"Czy na pewno chcesz usunąć odrobaczenie z zestawienia?', () => {
      this.actionService.deleteDewormingDog(id).subscribe(() => {
        this.dew.splice(this.dew.findIndex(p => p.id === id), 1);
        alertify.success('Odrobaczenie zostało usunięte z zestawienia');
      }, error => {
        alertify.error('Błąd podczas usówania');
      });
    });

  }
  delateVac(id: number) {
    alertify.confirm('Czy na pewno chcesz usunąć szczepienie z zestawienia?', () => {
      this.actionService.deleteVaccinationDog(id).subscribe(() => {
        this.vac.splice(this.vac.findIndex(p => p.id === id), 1);
        alertify.success('Szczepienie zostało usunięte z zestawienia');
      }, error => {
        alertify.error('Błąd podczas usówania');
      });
    });

  }
   
  loadDew() {
    this.dogService.getDewormingsDog().subscribe(
      (dew: DewormingDog[]) => {
        this.dew = dew;
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
  loadVac() {
    this.dogService.getVaccinationsDog().subscribe(
      (vac: VaccinationDog[]) => {
        this.vac = vac;
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
  loadDewsort(sort: Sort) {
    this.dogService.getDewormingsDog().subscribe((dew: DewormingDog[]) => {
        this.dew = dew;
        const data = this.dew.slice();
        if (!sort.active || sort.direction === "") {
          this.dew = data;
          return;
        }
        this.dew = data.sort((a, b) => {
          const isAsc = sort.direction === "asc";
          switch (sort.active) {
            case "preparat":
              return compare(a.preparat, b.preparat, isAsc);
            case "data":
              return compare(a.data, b.data, isAsc);
            case "fdogId":
              return compare(a.fdogId, b.fdogId, isAsc);
            default:
              return 0;
          }
        });
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
  loadVacsort(sort: Sort) {
    this.dogService.getVaccinationsDog().subscribe((vac: VaccinationDog[]) => {
        this.vac = vac;
        const data = this.vac.slice();
        if (!sort.active || sort.direction === "") {
          this.vac = data;
          return;
        }
        this.vac = data.sort((a, b) => {
          const isAsc = sort.direction === "asc";
          switch (sort.active) {
            case "nazwa":
              return compare(a.nazwa, b.nazwa, isAsc);
            case "seria":
              return compare(a.seria, b.seria, isAsc);
            case "data":
              return compare(a.data, b.data, isAsc);
            case "waznosc":
              return compare(a.waznosc, b.waznosc, isAsc);
            case "fdogId":
              return compare(a.fdogId, b.fdogId, isAsc);
            default:
              return 0;
          }
        });
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
}
function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
