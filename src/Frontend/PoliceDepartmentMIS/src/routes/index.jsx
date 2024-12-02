import React, { useContext } from 'react';
import { createBrowserRouter } from 'react-router-dom';
import MainRoutes from './MainRoutes';
import LoginRoutes from './LoginRoutes';


const isAuthenticated = localStorage.getItem('user') !== null; // Or use a context or state for this check
console.log(localStorage.getItem('user'));
const router = createBrowserRouter([MainRoutes({ isAuthenticated }), LoginRoutes], { basename: "/" });

export default router;
