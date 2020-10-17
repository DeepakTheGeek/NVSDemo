
import { Routes } from '@angular/router';
import { LandmarkEditComponent } from './app/landmark-edit/landmark-edit.component';
import { LandmarkListComponent } from './app/landmark-list/landmark-list.component';
export const appRoutes: Routes = [
  { path: '', component: LandmarkListComponent },
  { path: 'landmark', component: LandmarkEditComponent },
  { path: 'landmark/:id', component: LandmarkEditComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
