import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LandMarkService } from '../_services/landmark.service';

@Component({
  selector: 'app-landmark-list',
  templateUrl: './landmark-list.component.html',
  styleUrls: ['./landmark-list.component.css']
})
export class LandmarkListComponent implements OnInit {
  landMarkList: any[];
  constructor(private service: LandMarkService, private route: Router) { }

  ngOnInit(): void {
    this.GetAllLandMarks();
  }

  GetAllLandMarks() {
    this.service.GetAllLandMarks().subscribe((response: any[]) => {
      this.landMarkList = response;
    }
    , error => {
      console.log(error.error);
    });
  }

  GotoLandMark() {
    this.route.navigate(['/landmark']);
  }

}
