import React from 'react';
import { Box, List, ListItem, ListItemButton, ListItemText, Divider, ListItemIcon } from '@mui/material';
import { Dashboard, People, Event } from '@mui/icons-material';

import { NavLink } from 'react-router-dom';

export default function Sidebar() {
  return (
    <Box
      sx={{
        position: 'fixed', // Fix the sidebar to the left of the screen
        top: '64px',  // Set the top position to below the Navbar (assuming Navbar height is 64px)
        left: 0,
        width: 240,
        backgroundColor: '#f0f0f0',  // Light blue background (complementary to the light grey navbar)
        height: '100%',  // Make the sidebar extend the full height of the screen
        zIndex: 1,  // Ensure it's above other content
      }}
    >
      <List>
        {/* Dashboard */}
        <NavLink className={(e)=>{return e.isActive ? "linkActive" : ""}} to="/">
          <ListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Dashboard />
              </ListItemIcon>
              <ListItemText primary="Dashboard" />
            </ListItemButton>
          </ListItem>
        </NavLink>
        

        {/* Inmates */}
        <NavLink className={(e)=>{return e.isActive ? "linkActive" : ""}} to="/inmate">
          <ListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <People />
              </ListItemIcon>
              <ListItemText primary="Inmates" />
            </ListItemButton>
          </ListItem>
        </NavLink>

        {/* Bookings */}
        <NavLink className={(e)=>{return e.isActive ? "linkActive" : ""}} to="/booking">
          <ListItem disablePadding>
            <ListItemButton>
              <ListItemIcon>
                <Event />
              </ListItemIcon>
              <ListItemText primary="Bookings" />
            </ListItemButton>
          </ListItem>
        </NavLink>
      </List>
      {/* <Divider /> */}
    </Box>
  );
}
