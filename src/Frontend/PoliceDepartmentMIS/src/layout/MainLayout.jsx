import Navbar from "../pages/Layout/Navbar";
import Sidebar from "../pages/Layout/Sidebar";
import { Outlet } from 'react-router-dom';
import { Container, Box } from '@mui/material';

export default function MainLayout(){
    return (
        <>
        <Navbar />
        <Box sx={{ display: 'flex' }}>
            {/* Sidebar on the left */}
            <Sidebar />

            {/* Main content area */}
            <Container
            sx={{
                flexGrow: 1,
                padding: 3,
                // marginLeft: 240, // Add space to the left of content to accommodate the sidebar width
            }}
            >
             <Outlet />
            </Container>
        </Box>
        </>
    );
}