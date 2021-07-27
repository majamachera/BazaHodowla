import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgControl, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Puppy } from 'src/app/_models/pup';
import { ActionService } from 'src/app/_services/action.service';
import { DogService } from 'src/app/_services/dog.service';
declare let alertify: any;
@Component({
  selector: 'app-editpup',
  templateUrl: './editpup.component.html',
  styleUrls: ['./editpup.component.css']
})
export class EditpupComponent implements OnInit {
  
  constructor(public actionService: ActionService, private route: ActivatedRoute, public dogService: DogService) { }
  pup: Puppy;
  model: any = {};
  loadpup: Puppy[];
  @ViewChild('editForm') editForm: NgForm;
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.pup = data.pup;
    });
    this.loadPups();
  }
  
  loadPups() {
    this.dogService.getPups().subscribe((loadpup: Puppy[]) => {
      this.loadpup = loadpup;
      }, error => {
        alertify.error('error');
        });
      }
  update(){
    this.actionService.updatePup(this.actionService.iddopupedit, this.pup)
      .subscribe(next => {
        alertify.success("Zmiany zostały zapisane");
        location.reload();
        }, error => {
       alertify.error("Nie dodano żadnych zmian");
       console.log(this.pup);
       location.reload();
      });
      
     }
}
