import { Component, Input, OnInit } from '@angular/core';
import { Loader } from '@googlemaps/js-api-loader';
import { Camera } from 'src/app/model/camera';
import { createGoogleMarker } from 'src/app/utils/marker';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {

  constructor() { }
  public map!: google.maps.Map;
  @Input() cameras!: Camera[];

  ngOnInit(): void {
    let loader = new Loader({
      apiKey: "AIzaSyD3WuRYBLbYfk7uLCcYzImSFZhcHnZjEcQ"
    });

    loader.load().then(() => {
      this.map = new google.maps.Map(document.getElementById("map") as HTMLElement, {
        center: { lat: 52.0914, lng: 5.1115 },
        zoom: 16
      })

      this.createMarkers();
    });
  }
  createMarkers() {
    this.cameras.forEach(camera => {
      const pos = { lat: camera.latitude, lng: camera.longitude } as google.maps.LatLngLiteral;
      const newMarker = createGoogleMarker(this.map, camera.number.toString(), pos);
    });
  }

}
