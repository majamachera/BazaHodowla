import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgControl, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Fdog } from 'src/app/_models/fdog';
import { Puppy } from 'src/app/_models/pup';
import { ActionService } from 'src/app/_services/action.service';
import { DogService } from 'src/app/_services/dog.service';

declare let alertify: any;
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  
  constructor(
              private dogservice: DogService,
              private route: ActivatedRoute,
              public actionService: ActionService,) { }
 
  alertify: any;
  x: any;
  fdog: Fdog;
  model: any = {};
  loadfdog: Fdog[];
  @ViewChild('editForm') editForm: NgForm;
  ngOnInit() {
   this.route.data.subscribe(data => {
     this.fdog = data.fdog;
   });
   this.loadFdog();
  }
  loadFdog() {
    this.dogservice.getFdogs().subscribe(
      (loadfdog: Fdog[]) => {
        this.loadfdog = loadfdog;
      },
      (error) => {
        alertify.error("error");
      }
    );
  }
  takeid(id) {
    this.actionService.takeid(id);
     }
  cancel() {
    this.actionService.iddopups = null;

    
  }
 //valid
  update() {

    this.actionService.updateFdog(this.actionService.iddopup, this.fdog)
   .subscribe(next => {  
    alertify.success('Dane zostały zaktualizowane');
    location.reload();
     }, error => {
    alertify.error(error);
    location.reload();
   });
  }
  
}
