import car from '../../../public/vite.svg';

export const drawMakers = (map: google.maps.Map) => {
  // Create markers
  const vehiclePositions = [
    { lat: 50.51658449947278, lng: 30.602026160513276 }, // Example marker 1
  ];

  const carIcon = {
    url: car,
    scaledSize: new google.maps.Size(40, 40),
  };

  vehiclePositions.forEach((position) => {
    const marker = new google.maps.Marker({
      position,
      map,
      icon: carIcon,
    });
    const tooltipContent = 'Car information goes here';
    const infoWindow = new google.maps.InfoWindow({
      content: tooltipContent,
    });

    marker.addListener('mouseover', () => {
      infoWindow.open(map, marker);
    });

    marker.addListener('mouseout', () => {
      infoWindow.close();
    });
  });
};
