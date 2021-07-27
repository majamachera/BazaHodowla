import { from, Observable, of } from 'rxjs';
import {Injectable} from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Route, Router, RouterStateSnapshot } from '@angular/router';
import { Fdog } from '../_models/fdog';
import { ActionService } from '../_services/action.service';
import { DogService } from '../_services/dog.service';
import { catchError } from 'rxjs/operators';
import { UserService } from '../_services/user.service';
declare let alertify: any;

@Injectable()
export class FdogEditResolver implements Resolve<Fdog>{
    constructor(private actionService: ActionService,
                private dogservice: DogService,
                private router: Router,) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Fdog> {
        return this.dogservice.getFdog(this.actionService.iddopup).pipe(
            catchError(error => {
                alertify.error('Problem z pobraniem danych');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}