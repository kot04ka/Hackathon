import React, { FC } from 'react';
import { useMapContext } from '../hooks';
import { LocationIcon } from './icons';
import { Position } from '../common/interfaces';

export const LocationButton: FC = () => {
  const { map, setCurrentUserPosition } = useMapContext();

  const onClick = () => {
    // Try HTML5 geolocation.
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position: GeolocationPosition) => {
          const pos: Position = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
          };
          map.setCenter(pos);
          setCurrentUserPosition(pos);
        },
        (positionError) => {
          console.error(positionError);
        },
      );
    } else {
      console.error("Browser doesn't support Geolocation");
    }
  };

  return (
    <button
      type="button"
      className="absolute bg-white z-50 bottom-[13rem] right-[0.7rem] w-[2.5rem] h-[2.5rem] rounded-[5rem] flex justify-center items-center"
      onClick={onClick}
    >
      <LocationIcon />
    </button>
  );
};
