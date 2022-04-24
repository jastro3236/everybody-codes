import { Component, OnInit } from '@angular/core';
import { Camera } from './model/camera';
import { CameraTableModel } from './model/camera-table-model';
import { CameraService } from './services/camera.service';
import { isDivisibleBy3, isDivisibleBy5 } from './utils/divisibility';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public cameras: Camera[] = [];
  public cameraTableModels: CameraTableModel[] = [];

  constructor(private cameraService: CameraService) {
  }

  ngOnInit(): void {
    this.cameraService.getCameras().subscribe((cameras: Camera[]) => {
      this.cameras = cameras;
      this.determineCamerasDivisibility();
    })
  }

  determineCamerasDivisibility(): void {
    let cameraTableModels: CameraTableModel[] = [];
    this.cameras.forEach(camera => {
      let cameraTableModel: CameraTableModel = {
        camera: camera,
        isDivisibleBy3: isDivisibleBy3(camera.number),
        isDivisibleBy5: isDivisibleBy5(camera.number)
      }
      cameraTableModels.push(cameraTableModel)
    });

    this.cameraTableModels = cameraTableModels;
  }

  public getCamerasFirstColumn =
    (): CameraTableModel[] => this.cameraTableModels.filter(c => c.isDivisibleBy3 && !c.isDivisibleBy5);

  public getCamerasSecondColumn =
    (): CameraTableModel[] => this.cameraTableModels.filter(c => !c.isDivisibleBy3 && c.isDivisibleBy5);

  public getCamerasThirdColumn =
    (): CameraTableModel[] => this.cameraTableModels.filter(c => c.isDivisibleBy3 && c.isDivisibleBy5);

  public getCamerasFourthColumn =
    (): CameraTableModel[] => this.cameraTableModels.filter(c => !c.isDivisibleBy3 && !c.isDivisibleBy5);

}
