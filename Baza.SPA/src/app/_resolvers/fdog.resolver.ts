import { from, Observable, of } from 'rxjs';
import {Injectable} from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Route, Router, RouterStateSnapshot } from '@angular/router';
import { Fdog } from '../_models/fdog';
import { ActionService } from '../_services/action.service';
import { DogService } from '../_services/dog.service';
import { catchError } from 'rxjs/operators';
import { UserService } from '../_services/user.service';
import { User } from '../_models/user';
declare let alertify: any;
@Injectable()
export class FdogResolver implements Resolve<User>{
    constructor(private actionService: ActionService,
                private userservice: UserService,
                private router: Router, ) {}
    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userservice.getUser(this.actionService.decodedtoken).pipe(
            catchError(error => {
                alertify.error('Problem z pobraniem danych');
                return of(null);
            })
        )
    }

}

