import React, {
  createContext, ReactNode, ReactElement, useEffect, useState, useMemo, useRef, Dispatch, SetStateAction,
} from 'react';
import { OSM_MAP_TYPE } from '../common/constants';
import { Position } from '../common/interfaces';

export interface IMapContext {
  map: google.maps.Map;
  currentUserPosition: Position | null;
  setCurrentUserPosition: Dispatch<SetStateAction<Position | null>>;
}

export const MapContext = createContext<IMapContext>({} as IMapContext);

interface MapProviderProps {
  children: ReactNode;
}

export const MapProvider = ({ children }: MapProviderProps): ReactElement => {
  const mapRef = useRef(null);
  const [mapValue, setMapValue] = useState<google.maps.Map | null>(null);
  const [currentUserPosition, setCurrentUserPosition] = useState<Position | null>(null);

  useEffect(() => {
    if (mapRef.current) {
      const mapOptions = {
        center: new google.maps.LatLng(50.51658449947278, 30.602026160513276),
        zoom: 14,
        mapTypeId: OSM_MAP_TYPE,
        mapTypeControl: false,
        // streetViewControl: false,
      };

      const map = new google.maps.Map(mapRef.current, mapOptions);

      map.mapTypes.set(OSM_MAP_TYPE, new google.maps.ImageMapType({
        getTileUrl(coords, zoom) {
          // "Wrap" x (longitude) at 180th meridian properly
          // NB: Don't touch coord.x: because coord param is by reference, and changing its x property breaks something in Google's lib
          // eslint-disable-next-line no-bitwise
          const tilesPerGlobe = 1 << zoom;
          let x = coords.x % tilesPerGlobe;
          if (x < 0) {
            x = tilesPerGlobe + x;
          }
          // Wrap y (latitude) in a like manner if you want to enable vertical infinite scrolling

          return `https://tile.openstreetmap.org/${zoom}/${x}/${coords.y}.png`;
        },
        tileSize: new google.maps.Size(256, 256),
        name: 'OpenStreetMap',
        maxZoom: 18,
      }));

      setMapValue(map);
    }
  }, []);

  return (
    <MapContext.Provider value={useMemo(() => ({
      map: mapValue!,
      currentUserPosition,
      setCurrentUserPosition,
    }), [mapValue, currentUserPosition, setCurrentUserPosition])}
    >
      <div ref={mapRef} id="map" />
      {children}
    </MapContext.Provider>
  );
};
