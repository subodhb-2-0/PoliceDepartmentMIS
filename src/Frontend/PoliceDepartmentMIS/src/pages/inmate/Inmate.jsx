import MainCard from "../../components/MainCard";
import { Button } from '@mui/material';
import { useNavigate } from 'react-router';
import InmateTable from '../../components/inamte/InmateTable'

export default function Inmate(){

    const navigate = useNavigate();
    const navigateToAddInmate = () => {
        navigate("/inmate/add")
    }
    return(
        <>
            <MainCard title="Inmate">
                <div style={{display:"flex", alignItems:"center", justifyContent:"space-between", marginBottom:"1.3rem"}}>
                    <Button onClick={navigateToAddInmate} variant="contained" disableElevation>
                        Add New
                    </Button>
                </div>
                <InmateTable />
            </MainCard>
        </>
    );
}