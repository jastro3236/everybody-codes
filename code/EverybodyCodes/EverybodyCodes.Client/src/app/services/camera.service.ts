import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Camera } from '../model/camera';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CameraService {

  constructor(private http: HttpClient) { }

  public getCameras(): Observable<Camera[]> {
    return this.http.get<Camera[]>(`${environment.api}cameras`);
  }
}
