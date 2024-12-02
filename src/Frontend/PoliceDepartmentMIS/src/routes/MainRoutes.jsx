import { lazy } from 'react';

import Loadable from '../components/Loadable';
import MainLayout from '../layout/MainLayout';
import ProtectedRoute from './ProtectedRoute';

const DashboardDefault = Loadable(lazy(() => import('../components/Dashboard')));
const Inmate = Loadable(lazy(() => import('../pages/inmate/Inmate')));
const Booking = Loadable(lazy(() => import("../pages/booking/Booking")));
const InmateBooking = Loadable(lazy(() => import("../pages/booking/InmateBooking")));
const AddInmate = Loadable(lazy(() => import("../pages/inmate/AddInmate")));
const EditInmate = Loadable(lazy(() => import("../pages/inmate/EditInmate")));
const AddBooking = Loadable(lazy(() => import("../pages/booking/AddBooking")));
const EditBooking = Loadable(lazy(() => import("../pages/booking/EditBooking")));

const MainRoutes = ({ isAuthenticated }) => {
  return {
    path: '/',
    element: <MainLayout />,
    children: [
      {
        path: '/',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <DashboardDefault />
          </ProtectedRoute>
        ),
      },
      {
        path: '/inmate',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <Inmate />
          </ProtectedRoute>
        ),
      },
      {
        path: '/booking',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <Booking />
          </ProtectedRoute>
        ),
      },
      {
        path: '/inmatebooking/:id',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <InmateBooking />
          </ProtectedRoute>
        ),
      },
      {
        path: '/inmate/add',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <AddInmate />
          </ProtectedRoute>
        ),
      },
      {
        path: '/inmate/edit/:id',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <EditInmate />
          </ProtectedRoute>
        ),
      },
      {
        path: '/booking/edit/:id',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <EditBooking />
          </ProtectedRoute>
        ),
      },
      {
        path: '/booking/add',
        element: (
          <ProtectedRoute isAuthenticated={isAuthenticated}>
            <AddBooking />
          </ProtectedRoute>
        ),
      },
    ],
  };
};

export default MainRoutes;