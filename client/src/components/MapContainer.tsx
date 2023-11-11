import React, { FC, PropsWithChildren } from 'react';
import { Marker } from './Marker.tsx';
import { LocationButton } from './LocationButton.tsx';
import { SearchBar } from './SearchBar.tsx';

export const MapContainer: FC<PropsWithChildren> = ({ children }) => {
  const mockPositions = [
    { lat: 50.51658449947278, lng: 30.602026160513276 }, // Example marker 1
  ];

  return (
    <>
      {mockPositions.map((position, index) => (
        <Marker position={position} key={index} />
      ))}
      <SearchBar/>
      <LocationButton />
      {children}
    </>
  );
};
