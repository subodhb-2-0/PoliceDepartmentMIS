import MainCard from "../../components/MainCard";
import { Button } from '@mui/material';
import { useNavigate } from 'react-router';
import BokingTable from '../../components/booking/BookingTable'

export default function Booking(){
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
                <BokingTable />
            </MainCard>
        </>
    );
}