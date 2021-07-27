
import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FdogComponent } from './fdog/fdog.component';
import { MenuComponent } from './menu/menu.component';
import { PupComponent } from './pup/pup.component';
import { PsyComponent } from './psy/psy.component';
import { SukiComponent } from './suki/suki.component';
import { AuthGuard } from './_guards/auth.guard';
import { FdogResolver } from './_resolvers/fdog.resolver';
import { PupResolver } from './_resolvers/pup.resolver';
import { FdogEditResolver } from './_resolvers/fdogeditresolver';
import { EditpupComponent } from './pup/editpup/editpup.component';
import { EditComponent } from './suki/edit/edit.component';
import { EditPComponent } from './psy/editP/editP.component';
import { DogZabiegiComponent } from './dogZabiegi/dogZabiegi.component';
import { PuppyZabiegiComponent } from './puppyZabiegi/puppyZabiegi.component';

export const appRoutes: Routes = [
{path: '', component: HomeComponent},
{path: '',
runGuardsAndResolvers: 'always',
canActivate: [AuthGuard],
children: [
    {path: 'matki', component: FdogComponent},
    {path: 'menu', component: MenuComponent},
    {path: 'puppy', component: PupComponent},
    {path: 'puppy/edit', component: EditpupComponent, resolve: {pup: PupResolver}},
    {path: 'psy', component: PsyComponent},
    {path: 'psy/edit', component: EditPComponent, resolve: {fdog: FdogEditResolver}},
    {path: 'suki', component: SukiComponent},
    {path: 'dog/zabiegi', component: DogZabiegiComponent, resolve: {fdog: FdogEditResolver}},
    {path: 'puppy/zabiegi', component: PuppyZabiegiComponent, resolve: {pup: PupResolver}},
    {path: 'suki/edit', component: EditComponent, resolve: {fdog: FdogEditResolver}},

   
]},

{path: '**', redirectTo: '', pathMatch: 'full' }
];

