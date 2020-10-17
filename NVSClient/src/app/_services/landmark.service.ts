import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class LandMarkService {
    constructor(private http: HttpClient){}

    SaveLandMark(landmark: any) {
        return this.http.post('https://localhost:5001/Landmark/SaveLandmark', landmark);
    }

    GetLandMarkById(landmarkId: number) {
        return this.http.get('https://localhost:5001/Landmark/GetLandMarks/' + landmarkId);
    }

    GetAllLandMarks() {
        return this.http.get('https://localhost:5001/Landmark/GetLandMarks');
    }
}