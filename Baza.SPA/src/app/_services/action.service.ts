import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { identifierModuleUrl } from '@angular/compiler';
import { pipe } from 'rxjs';
import { Fdog } from '../_models/fdog';
import { Puppy } from '../_models/pup';
@Injectable({
  providedIn: 'root'
})
export class ActionService {
  baseUrl = environment.apiUrl ;
  decodedtoken: any;
  iddopup: any;
  iddopupedit: any;
  jwthelper = new JwtHelperService();
  iddopups: any;
  iddopupsedit: any;
  constructor(private http: HttpClient) {}
  login(model: any) {
    return this.http.post(this.baseUrl + 'auth/login', model)
      .pipe(map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedtoken = this.jwthelper.decodeToken(user.token);
          console.log(this.decodedtoken);
        }
      }));
  }
  addfdog(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.decodedtoken.nameid + '/fdogs', model);
  }
  addpup(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.iddopup + '/puppy', model);
  }
  deleteDewormingDog(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.iddopup + '/dewormingd/'+ id);
  }
  deleteDewormingPuppy(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.iddopupedit + '/dewormingp/'+ id);
  }
  deleteVaccinationDog(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.iddopup + '/vaccinationd/'+ id);
  }
  deleteVaccinationPuppy(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.iddopupedit + '/vaccinationp/'+ id);
  }
  addDewormingDog(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.iddopup + '/dewormingd', model);
  }
  addDewormingPuppy(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.iddopupedit + '/dewormingp', model);
  }
  addVaccinationDog(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.iddopup + '/vaccinationd', model);
  }
  addVaccinationPuppy(model: any) {
    return this.http.post(this.baseUrl + 'user/' + this.iddopupedit + '/vaccinationp', model);
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'auth/register', model);
  }
  loggerin() {
    const token = localStorage.getItem('token');
    return !this.jwthelper.isTokenExpired(token);

  }
  delatePup(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.iddopup + '/puppy/' + id);
  }
  delateFdog(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + this.decodedtoken.nameid + '/fdogs/' + id);
  }
  takeid(id) {
    this.iddopups = id;
    localStorage.setItem('iddopups', this.iddopups);
    console.log(this.iddopups);
    this.savefdogid();
  }
  takepupid(id) {
    this.iddopupsedit = id;
    localStorage.setItem('iddopupsedit', this.iddopupsedit);
    console.log(this.iddopupedit);
    this.savepupid();
  }
  savefdogid() {
    this.iddopup = localStorage.getItem('iddopups');
    console.log(this.iddopup);

  }
  savepupid() {
    this.iddopupedit = localStorage.getItem('iddopupsedit');
    console.log(this.iddopupedit);

  }
  updateFdog(id = this.iddopup, model: any) {
    return this.http.put(this.baseUrl + 'user/' + this.decodedtoken.nameid + '/fdogs/' + id, model);
  }
  updatePup(id= this.iddopupedit, pup: any) {
    return this.http.put(this.baseUrl + 'user/' + this.decodedtoken.nameid + '/puppy/' + id, pup);
  }
}

