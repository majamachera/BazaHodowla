import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { MatSortModule } from '@angular/material/sort';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { ActionService } from './_services/action.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { UserService } from './_services/user.service';
import { DogService } from './_services/dog.service';
import { FdogComponent } from './fdog/fdog.component';
import { PupComponent } from './pup/pup.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MenuComponent } from './menu/menu.component';
import { PsyComponent } from './psy/psy.component';
import { SukiComponent } from './suki/suki.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddpupComponent } from './pup/addpup/addpup.component';
import { FdogResolver } from './_resolvers/fdog.resolver';
import { PupResolver } from './_resolvers/pup.resolver';
import { FdogEditResolver } from './_resolvers/fdogeditresolver';
import { EditpupComponent } from './pup/editpup/editpup.component';
import { AddComponent } from './suki/add/add.component';
import { EditComponent } from './suki/edit/edit.component';
import { EditPComponent } from './psy/editP/editP.component';
import { AddPComponent } from './psy/addP/addP.component';
import { PuppyZabiegiComponent } from './puppyZabiegi/puppyZabiegi.component';
import { AddVaccinationPupComponent } from './puppyZabiegi/addVaccination/addVaccinationPup.component';
import { AddDewormingPupComponent } from './puppyZabiegi/addDeworming/addDewormingPup.component';
import { AddDewormingDogComponent } from './dogZabiegi/addDogDeworming/addDewormingDog.component';
import { DogZabiegiComponent } from './dogZabiegi/dogZabiegi.component';
import { AddVaccinationDogComponent } from './dogZabiegi/addVaccination/addVaccinationDog.component';


export function tokenG() {
   return localStorage.getItem('token');
}
@NgModule({
   declarations: [		
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      FdogComponent,
      PupComponent,
      MenuComponent,
      PsyComponent,
      SukiComponent,
      AddpupComponent,
      EditpupComponent,
      AddComponent,
      EditComponent,
      AddPComponent,
      EditPComponent,
      PuppyZabiegiComponent,
      AddVaccinationPupComponent,
      AddDewormingPupComponent,
      DogZabiegiComponent,
      AddDewormingDogComponent,
      AddVaccinationDogComponent,
      

   ],
   imports: [
      MatSortModule,
      BrowserModule,
      HttpClientModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenG,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
       }),
      FormsModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),


    ],
   providers: [
      ActionService,
      UserService,
      DogService,
      AuthGuard,
      PupResolver,
      FdogResolver,
      FdogEditResolver

   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {
 }
