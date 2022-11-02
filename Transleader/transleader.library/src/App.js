import React from 'react'
import { NavMenu } from './NavMenu';
import { Route, Routes} from 'react-router-dom';
import AppRoutes from './AppRoutes';

export default function App() {
  return (
    <div>
      <NavMenu />
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
      </Routes>
    </div>
  )
}
