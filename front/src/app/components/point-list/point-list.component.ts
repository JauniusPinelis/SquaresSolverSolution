import { Component, OnInit } from '@angular/core';
import { Point } from 'src/app/models/Point';
import { PointService } from 'src/app/services/point.service';

@Component({
  selector: 'app-point-list',
  templateUrl: './point-list.component.html',
  styleUrls: ['./point-list.component.css']
})
export class PointListComponent implements OnInit {
  points: Point[];

  constructor(private pointService:PointService) { }

  ngOnInit() {
    this.pointService.getPoints().subscribe(points => {
      this.points = points;
    });
  }

}
