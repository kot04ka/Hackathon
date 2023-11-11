import React, {
  createContext, ReactNode, ReactElement, useEffect, useState, useMemo, useRef, Dispatch, SetStateAction,
} from 'react';
import { OSM_MAP_TYPE } from '../common/constants';
import { Position } from '../common/interfaces';
import { Wrapper, Status } from "@googlemaps/react-wrapper";

export interface IMapContext {
  map: google.maps.Map;
  currentUserPosition: Position | null;
  setCurrentUserPosition: Dispatch<SetStateAction<Position | null>>;
}

export const MapContext = createContext<IMapContext>({} as IMapContext);

interface MapProviderProps {
  children: ReactNode;
}

// export async function getTestData() {
//   const response = await fetch('http://localhost:5000/api/Route/get?strLat=50.508698559953274&strLng=30.607253485200992&endLat=50.5091591184396&endLng=30.607178383350504',
//     {
//           mode: 'no-cors',
//           headers: {
//             "Access-Control-Allow-Origin": "*",
//           }
//         });

//   console.dir(response);
//   const data = await response.json();
//   return data;
// }

export const MapProvider = ({ children }: MapProviderProps): ReactElement => {
  const mapRef = useRef(null);
  const [mapValue, setMapValue] = useState<google.maps.Map | null>(null);
  const [currentUserPosition, setCurrentUserPosition] = useState<Position | null>(null);

  useEffect(() => {
    if (mapRef.current) {
      const mapOptions = {
        center: new google.maps.LatLng(50.51658449947278, 30.602026160513276),
        zoom: 14,
        // mapTypeId: OSM_MAP_TYPE,
        //mapTypeControl: false,
        // streetViewControl: false,
      };

      var directionsService = new google.maps.DirectionsService();
      var directionsRenderer = new google.maps.DirectionsRenderer();

      const map = new google.maps.Map(mapRef.current, mapOptions);

      setMapValue(map);
      directionsRenderer.setMap(map);

      // map.mapTypes.set(OSM_MAP_TYPE, new google.maps.ImageMapType({
      //   getTileUrl(coords, zoom) {
      //     // "Wrap" x (longitude) at 180th meridian properly
      //     // NB: Don't touch coord.x: because coord param is by reference, and changing its x property breaks something in Google's lib
      //     // eslint-disable-next-line no-bitwise
      //     const tilesPerGlobe = 1 << zoom;
      //     let x = coords.x % tilesPerGlobe;
      //     if (x < 0) {
      //       x = tilesPerGlobe + x;
      //     }
      //     // Wrap y (latitude) in a like manner if you want to enable vertical infinite scrolling

      //     return `https://tile.openstreetmap.org/${zoom}/${x}/${coords.y}.png`;
      //   },
      //   tileSize: new google.maps.Size(256, 256),
      //   name: 'OpenStreetMap',
      //   maxZoom: 18,
      // }));

      //setMapValue(map);

      // getTestData().then(resp => {
      //   alert(resp);
      //   directionsRenderer.setDirections(resp);
      // })

      // const response = await fetch('https://api.npms.io/v2/search?q=react');
      // const data = await response.json();

      var start = {
        lat: 50.508698559953274,
        lng: 30.607253485200992
      };
      var end = {
        lat: 50.51085762409171,
        lng: 30.61715486580857
      };
      var request = {
        origin:start,
        destination:end,
        travelMode: 'WALKING'
      }

      directionsService.route(request, function(response: any, status: string) {
        if (status == 'OK') {
          console.log("google")
          console.dir(response)
          
          directionsRenderer.setDirections(response);
        }
      });


      //fetch('http://localhost:5000/api/Route/get?strLat=50.508698559953274&strLng=30.607253485200992&endLat=50.5091591184396&endLng=30.607178383350504')
      fetch('http://localhost:5000/api/Route/get?strLat=50.508698559953274&strLng=30.607253485200992&endLat=50.51085762409171&endLng=30.61715486580857')
        .then(response => {
          var resp = response.json();
          return resp;
        })
        .then(data => {
          console.log("api")
          console.dir(data)
          var objectParsed = JSON.parse(data.RawJson);

          var respBound = objectParsed.routes[0].bounds;

          var Oa = {
            hi: respBound.northeast.lng,
            lo: respBound.southwest.lng
          };

          var mb = {
            hi: respBound.northeast.lat,
            lo: respBound.southwest.lat
          };


          var boundsToSet = {
            Oa: Oa,
            mb: mb
          }

          var listDest = data.request.Destination.String.split(",");
          var locationDest = {
            lat: parseFloat(listDest[0]),
            lng: parseFloat(listDest[1])
          }

          var destToSet = {
            location: locationDest
          }


          var listOrig = data.request.Origin.String.split(",");
          var locationOrig = {
            lat: parseFloat(listOrig[0]),
            lng: parseFloat(listOrig[1])
          }

          var origToSet = {
            location: locationOrig
          }

          var pathToSet = new Array();
          data.Routes[0].OverviewPath.Line.forEach(element => {
            var objToAdd = {
              lat: element.Latitude,
              lng: element.Longitude
            };
            pathToSet.push(objToAdd)
          });

          var requestToSet = {
            destination: destToSet,
            origin: origToSet,
            travelMode: "WALKING"
          }

          data.request.destination = destToSet;
          data.request.origin = origToSet;
          //data.request.travelMode = "WALKING";

          var objectToSet = {
            // request: requestToSet,
            request: data.request,
            geocoded_waypoints: objectParsed.geocoded_waypoints,
            routes: objectParsed.routes,
            status: "OK"
          };
         
          objectToSet.routes[0].overview_path = pathToSet;
          objectToSet.routes[0].bounds = null;
          // objectToSet.routes[0].bounds = boundsToSet;
          
          console.dir(objectToSet)
          if (data.Status == "0") {
            // console.log("api")
            // console.dir(data)
            directionsRenderer.setDirections(objectToSet);
          }
        });
    }
  }, []);

  return (
    // <Wrapper apiKey={"AIzaSyBP70Yds30-0rELR1lplMl1Pv3IR8Zut6g"}>
      <MapContext.Provider value={useMemo(() => ({
        map: mapValue!,
        currentUserPosition,
        setCurrentUserPosition,
      }), [mapValue, currentUserPosition, setCurrentUserPosition])}
      >
        <div ref={mapRef} id="map" />
        {children}
      </MapContext.Provider>
    // </Wrapper>
  );

  
};


