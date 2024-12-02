import React, { useState } from 'react';
import { AppBar, Toolbar, Typography, IconButton, Menu, MenuItem, Avatar } from '@mui/material';
import { AccountCircle } from '@mui/icons-material';
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';


export default function Navbar() {
  const [anchorEl, setAnchorEl] = useState(null);

  // Handle opening and closing of the profile menu
  const handleMenuOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
  };
  const navigate = useNavigate();
  // Handle logout action
  const handleLogout = () => {
    toast.success("Logout Successfully");
    localStorage.removeItem("user");
    navigate("/login");
    handleMenuClose();
    // Implement actual logout logic here
  };

  return (
    <>
      <AppBar 
        position="sticky" 
        sx={{ 
          backgroundColor: '#e3f2fd',  // Light grey background
          boxShadow: 0,  // Optional: remove shadow for a flat look
        }}
      >
        <Toolbar sx={{ padding: 0 }}>  {/* Remove padding for tight alignment */}
          <Typography variant="h6" component="div" sx={{ flexGrow: 1, color: '#000' }}>
            PDMIS
          </Typography>

          {/* Profile icon at the end of the navbar */}
          <IconButton color="inherit" onClick={handleMenuOpen}>
            <AccountCircle sx={{ fontSize: 40 }} /> {/* Use AccountCircle icon */}
          </IconButton>

          <Menu
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={handleMenuClose}
          >
            <MenuItem onClick={handleLogout}>Logout</MenuItem>
          </Menu>
        </Toolbar>
      </AppBar>
    </>
  );
}
