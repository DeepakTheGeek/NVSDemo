import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LandmarkListComponent } from './landmark-list/landmark-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LandMarkService } from './_services/landmark.service';
import { HttpClientModule } from '@angular/common/http';
import { LandmarkEditComponent } from './landmark-edit/landmark-edit.component';
import { appRoutes } from 'src/routes';
import { AlertifyService } from './_services/alertify.service';

@NgModule({
  declarations: [
    AppComponent,
    LandmarkListComponent,
    LandmarkEditComponent
  ],
  imports: [
    HttpClientModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    LandMarkService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
