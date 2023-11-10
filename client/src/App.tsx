import React, { FC } from 'react';

import { MapProvider } from './providers';
import { MapContainer } from './components/MapContainer.tsx';

const App: FC = () => (
  <div className="relative w-full h-[100vh]">
    <MapProvider>
      <MapContainer />
    </MapProvider>
  </div>
);

export default App;
