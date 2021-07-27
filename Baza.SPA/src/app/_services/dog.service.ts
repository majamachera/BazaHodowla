import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { Observable } from 'rxjs';
import { Fdog } from '../_models/fdog';
import { Puppy } from '../_models/pup';
import { ActionService } from './action.service';
import { VaccinationDog } from '../_models/vaccinationDog';
import { DewormingPuppy} from '../_models/dewormingPuppy';
import { VaccinationPuppy } from '../_models/vaccinationPuppy';
import { DewormingDog } from '../_models/dewormingDog';

@Injectable({
  providedIn: 'root'
})
export class DogService {

  constructor(private http: HttpClient, public actionService: ActionService) { }
  baseUrl = environment.apiUrl;
 
  getFdog(idp: number): Observable<Fdog> {
    return this.http.get<Fdog>(this.baseUrl + 'fdog/' + idp);
  }
  getFdogVac(idp: number): Observable<Fdog> {
    return this.http.get<Fdog>(this.baseUrl + 'dogwith/vac/' + idp);
  }
  getFdogDew(idp: number): Observable<Fdog> {
    return this.http.get<Fdog>(this.baseUrl + 'dogwith/dew/' + idp);
  }
  getFdogs(): Observable<Fdog[]> {
    return this.http.get<Fdog[]>(this.baseUrl + 'fdog');
  }
  getPups(): Observable<Puppy[]> {
    return this.http.get<Puppy[]>(this.baseUrl + 'puppy');
  
  }
  getPup(idp: number): Observable<Puppy> {
    return this.http.get<Puppy>(this.baseUrl + 'puppy/' + idp);
  }
  getPuppyVac(idp: number): Observable<Puppy> {
    return this.http.get<Puppy>(this.baseUrl + 'puppywith/vac/' + idp);
  }
  getPuppyDew(idp: number): Observable<Puppy> {
    return this.http.get<Puppy>(this.baseUrl + 'puppywith/dew/' + idp);
  }
  getVaccinationDog(id: number): Observable<VaccinationDog> {
    return this.http.get<VaccinationDog>(this.baseUrl + 'vaccinationdog/' + id);
  }
  getVaccinationsDog(): Observable<VaccinationDog[]> {
    return this.http.get<VaccinationDog[]>(this.baseUrl + 'vaccinationdog');
  }
  getVaccinationPuppy(id: number): Observable<VaccinationPuppy> {
    return this.http.get<VaccinationPuppy>(this.baseUrl + 'vaccinationpuppy/' + id);
  }
  getVaccinationsPuppy(): Observable<VaccinationPuppy[]> {
    return this.http.get<VaccinationPuppy[]>(this.baseUrl + 'vaccinationpuppy');
  }
  getDewormingsDog(): Observable<DewormingDog[]> {
    return this.http.get<DewormingDog[]>(this.baseUrl + 'dewormingdog');
  
  }
  getDewormingDog(id: number): Observable<DewormingDog> {
    return this.http.get<DewormingDog>(this.baseUrl + 'dewormingdog/' + id);
  }
  getDewormingsPuppy(): Observable<DewormingPuppy[]> {
    return this.http.get<DewormingPuppy[]>(this.baseUrl + 'dewormingpuppy');
  
  }
  getDewormingPuppy(id: number): Observable<DewormingPuppy> {
    return this.http.get<DewormingPuppy>(this.baseUrl + 'dewormingpuppy/' + id);
  }
}
