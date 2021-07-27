import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, RouterModule, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ActionService } from '../_services/action.service';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private actionService: ActionService, private router: Router) {}
  canActivate(): boolean  {
    if (this.actionService.loggerin()){
      return true;
    }
    alertify.error('Nie masz uprawnień');
    this.router.navigate(['/home']);
    return false;
  }
}
