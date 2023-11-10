import React from 'react';

export const LocationButton = ({ map }: { map: google.maps.Map }) => {
  const onClick = () => {
    const infoWindow = new google.maps.InfoWindow();
    // Try HTML5 geolocation.
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position: GeolocationPosition) => {
          const pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
          };

          infoWindow.setPosition(pos);
          infoWindow.setContent('Location found.');
          infoWindow.open(map);
          map.setCenter(pos);
        },
        () => {
          // handleLocationError(true, infoWindow, map.getCenter()!);
          console.error(infoWindow, map.getCenter()!);
        },
      );
    } else {
      console.error(infoWindow, map.getCenter());
      // Browser doesn't support Geolocation
      // handleLocationError(false, infoWindow, map.getCenter()!);
    }
  };

  return <button type="button" onClick={onClick}>Current location</button>;
};
