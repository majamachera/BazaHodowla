import { Injectable } from "@angular/core";
import { Component, OnInit, Input } from "@angular/core";
import { Fdog } from "src/app/_models/fdog";
import { ActionService } from "src/app/_services/action.service";
import { ActivatedRoute } from "@angular/router";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { RouterModule, Router } from "@angular/router";
import { DogService } from "src/app/_services/dog.service";
import { UserService } from "src/app/_services/user.service";
import { Sort } from '@angular/material/sort';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: "Bearer " + localStorage.getItem("token"),
  }),
};

declare let alertify: any;

@Component({
  selector: 'app-psy',
  templateUrl: './psy.component.html',
  styleUrls: ['./psy.component.css']
})
export class PsyComponent implements OnInit {
  model: any = {};
  linkinumber: 0;
  fdog: Fdog[];
  decodedtoken: any;

  addMode = false;
  editMode = false;
  @Input() fdogs: Fdog[];

  constructor(
    private dogService: DogService,
    public actionService: ActionService,
    public userService: UserService,
    private router: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadFdog();
    this.decodedtoken = this.actionService.decodedtoken;
  }
  loadFdog() {
    this.dogService.getFdogs().subscribe(
      (fdog: Fdog[]) => {
        this.fdog = fdog;
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
  delateFdog(id: number) {
    alertify.confirm("Czy na pewno chcesz usunąć to zwierze z zestawienia?", () => {
      this.actionService.delateFdog(id).subscribe(
        () => {
          alertify.success("Zwierze zostało usunięte z zestawienia");
        },
        (error) => {
          alertify.error("błąd podczas usówania");
        }
      );
      location.reload();
    });
  }
  loggerIn() {
    return this.actionService.loggerin();
  }
  takeid(id) {
    this.actionService.takeid(id);
  }
  addToggle() {
    this.addMode = true;
  }
  takeidtoedit(id) {
    this.actionService.takeid(id);
    this.editToggle();
  }
  editToggle() {
    this.editMode = true;
    console.log("działa");
  }

  outToggle() {
    this.addMode = false;
  }
  editoutToggle() {
    this.editMode = false;
  }
  canceladdMode(addMode: boolean) {
    this.addMode = addMode;
  }
  canceleditMode(editMode: boolean) {
    this.editMode = editMode;
  }
  loadFdogsort(sort: Sort) {
    this.dogService.getFdogs().subscribe((fdog: Fdog[]) => {
      this.fdog = fdog;
      const data = this.fdog.slice();
      if (!sort.active || sort.direction === '') {
        this.fdog = data;
        return;
      }
      this.fdog = data.sort((a, b) => {
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