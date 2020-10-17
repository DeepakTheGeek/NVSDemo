import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { LandMarkService } from '../_services/landmark.service';

@Component({
  selector: 'app-landmark-edit',
  templateUrl: './landmark-edit.component.html',
  styleUrls: ['./landmark-edit.component.css'],
})
export class LandmarkEditComponent implements OnInit {
  landMarkForm: FormGroup;
  landmark: any;
  constructor(
    private fb: FormBuilder,
    private service: LandMarkService,
    private route: ActivatedRoute,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  ngOnInit(): void {
    if (this.route.snapshot.params.id != null) {
      this.GetLandMarkById(this.route.snapshot.params.id);
    }
    this.createLandMarkForm();
  }
  createLandMarkForm() {
    this.landMarkForm = this.fb.group({
      id: [0],
      landmarkName: ['', Validators.required],
      address: ['', Validators.required],
      latitude: ['', Validators.required],
      longitude: ['', Validators.required],
      description: [''],
      shortDescription: [''],
      isActive: ['', Validators.required],
    });
  }

  SaveLandMark() {
    const landmark = Object.assign({}, this.landMarkForm.value);
    this.service.SaveLandMark(this.landMarkForm.value).subscribe(
      (response) => {
        this.alertify.success(response as string);
        this.router.navigate(['/']);
      },
      (error) => {
        this.alertify.error(error.error);
      }
    );
  }

  GetLandMarkById(landmarkId: number) {
    this.service.GetLandMarkById(landmarkId).subscribe(
      (response) => {
        this.landmark = response;
        this.landMarkForm.setValue({
          id: this.landmark.id,
          landmarkName: this.landmark.landmarkName,
          address: this.landmark.address,
          latitude: this.landmark.latitude,
          longitude: this.landmark.longitude,
          description: this.landmark.description,
          shortDescription: this.landmark.shortDescription,
          isActive: this.landmark.isActive,
        });
      },
      (error) => {
        this.alertify.error(error.error);
        this.router.navigate(['/']);
      }
    );
  }
}
