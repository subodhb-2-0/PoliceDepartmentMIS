import React, { useState } from 'react';
import { TextField, Button, Container, Typography, Box } from '@mui/material';
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';


export default function LoginForm() {
  // Individual state for each form field
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const baseURL = import.meta.env.VITE_WEB_API;
  const navigate = useNavigate();

  // Handle email change
  const handleUserNameChange = (e) => {
    setUserName(e.target.value);
  };

  // Handle password change
  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
    let data = {
      'UserName': userName,
      'Password': password
    }
    const loginUrl = baseURL + '/ApplicationUser/AuthenticateAsync';
    const response = await fetch(loginUrl,{
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body:  JSON.stringify(data)
    });
    if(!response.ok){
      toast.error("Failed to Authenticate!")
      return;
    }

    const result = await response.json();
    if(result.isSuccess){
      toast.success(result.message);
      localStorage.setItem('user', JSON.stringify(result.data));
      await navigate("/");
    }
    else{
      toast.error(result.message)
      return;
    }
  };

  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          padding: 2,
          boxShadow: 3,
          borderRadius: 2,
          marginTop: 20
        }}
      >
        <Typography variant="h5" gutterBottom>
          Log In
        </Typography>
        <form onSubmit={handleSubmit}>

          {/* Email */}
          <TextField
            label="UserName"
            variant="outlined"
            fullWidth
            margin="normal"
            type="text"
            value={userName}
            onChange={handleUserNameChange}
            required
          />

          {/* Password */}
          <TextField
            label="Password"
            variant="outlined"
            fullWidth
            margin="normal"
            type="password"
            value={password}
            onChange={handlePasswordChange}
            required
          />

          {/* Submit Button */}
          <Button
            type="submit"
            variant="contained"
            color="primary"
            fullWidth
            sx={{ marginTop: 2 }}
          >
            Submit
          </Button>
        </form>
      </Box>
    </Container>
  );
};
