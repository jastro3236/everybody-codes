export function createGoogleMarker(map: google.maps.Map, label: string, position: google.maps.LatLngLiteral): google.maps.Marker {
    let marker = new google.maps.Marker({
        map: map,
        position: position,
        optimized: true,
        icon: {
            url: '/assets/video-camera-icon.png',
            scaledSize: new google.maps.Size(25, 25),
        }
    });

    return marker;
}