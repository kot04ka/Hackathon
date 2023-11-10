import React, { useEffect } from 'react';
import { OSM_MAP_TYPE } from './common/constants';
import { drawMakers } from './common/utils';

const App = () => {
  useEffect(() => {
    // Initialize the map
    const element = document.getElementById('map')!;
    const mapOptions = {
      center: new google.maps.LatLng(50.51658449947278, 30.602026160513276),
      zoom: 14,
      mapTypeId: OSM_MAP_TYPE,
      mapTypeControl: false,
      streetViewControl: false,
    };
    const map = new google.maps.Map(element, mapOptions);

    map.mapTypes.set(OSM_MAP_TYPE, new google.maps.ImageMapType({
      getTileUrl(coord, zoom) {
        // "Wrap" x (longitude) at 180th meridian properly
        // NB: Don't touch coord.x: because coord param is by reference, and changing its x property breaks something in Google's lib
        // eslint-disable-next-line no-bitwise
        const tilesPerGlobe = 1 << zoom;
        let x = coord.x % tilesPerGlobe;
        if (x < 0) {
          x = tilesPerGlobe + x;
        }
        // Wrap y (latitude) in a like manner if you want to enable vertical infinite scrolling

        return `https://tile.openstreetmap.org/${zoom}/${x}/${coord.y}.png`;
      },
      tileSize: new google.maps.Size(256, 256),
      name: 'OpenStreetMap',
      maxZoom: 18,
    }));

    drawMakers(map);
  }, []);

  return <div id="map" style={{ width: '100%', height: '100vh' }} />;
};

export default App;
