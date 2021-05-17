import { HttpEventType, HttpRequest } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PointService } from '../services/point.service';

@Component({
  selector: 'app-point-upload',
  templateUrl: './point-upload.component.html',
  styleUrls: ['./point-upload.component.css']
})
export class PointUploadComponent implements OnInit {

  constructor(private pointService: PointService) { }

  ngOnInit() {
  }

  upload(files) {
    this.pointService.uploadFile(files);
  }
}
