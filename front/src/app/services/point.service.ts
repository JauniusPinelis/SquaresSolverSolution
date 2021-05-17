import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Point } from '../models/Point';

@Injectable({
  providedIn: 'root'
})
export class PointService {

  pointsUrl:string = 'https://localhost:44387/Points';
  fileUrl:string = 'https://localhost:44387/TextFile';

  constructor(private http:HttpClient) { }
 
  getPoints():Observable<Point[]> {
    return this.http.get<Point[]>(`${this.pointsUrl}`);
  }

  uploadFile(files) {
    if (files.length === 0)
      return;
  
    const formData = new FormData();
  
    for (const file of files) {
      formData.append(file.name, file);
    }
  
    const uploadReq = new HttpRequest('POST', this.fileUrl, formData, {
      reportProgress: true,
    });
  
    this.http.request(uploadReq).subscribe(event => {
    });
  }
}
