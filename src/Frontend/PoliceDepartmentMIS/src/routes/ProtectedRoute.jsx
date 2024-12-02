import React, { useEffect } from 'react';
import { Navigate } from 'react-router-dom';

const ProtectedRoute = ({ children }) => {
  const [authenticated, _] = React.useState(Boolean(localStorage.getItem("user")));
  useEffect(()=>{},[authenticated])
  if (!authenticated) {
    // Redirect them to the login page if they are not authenticated
    return <Navigate to="/login" />;
  }

  // If authenticated, render the children
  return children;
};

export default ProtectedRoute;

