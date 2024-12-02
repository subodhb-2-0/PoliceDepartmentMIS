import MainCard from "../../components/MainCard";
import { Button } from '@mui/material';
import { useNavigate } from 'react-router';
import InmateBookingTable from '../../components/booking/InmateBookingTable'

export default function InmateBooking(){
    const navigate = useNavigate();
    const navigateToAddBooking = () => {
        navigate("/booking/add")
    }
    return(
        <>
            <MainCard title="Inmate">
                <div style={{display:"flex", alignItems:"center", justifyContent:"space-between", marginBottom:"1.3rem"}}>
                    <Button onClick={navigateToAddBooking} variant="contained" disableElevation>
                        Add New
                    </Button>
                </div>
                <InmateBookingTable />
            </MainCard>
        </>
    );
}