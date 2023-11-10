import { FC } from 'react';
import { useMapContext } from '../hooks';
import icon from '../../public/vite.svg';
import { Position } from '../common/interfaces';

interface MarkerProps {
  position: Position | null;
}

export const Marker: FC<MarkerProps> = ({ position }) => {
  const { map } = useMapContext();

  const marker = new google.maps.Marker({
    position,
    map,
    icon: {
      url: icon,
      scaledSize: new google.maps.Size(40, 40),
    },
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

  return null;
};
