import MainCard from "../../components/MainCard";
import { Button, TextField } from '@mui/material';
import { useState, useEffect } from "react";
import { httpPost, httpGet } from '../../api/apiClient';
import { useNavigate, useParams } from 'react-router';
import { toast } from 'react-toastify';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';


    const ITEM_HEIGHT = 48;
    const ITEM_PADDING_TOP = 8;

    const MenuProps = {
        PaperProps: {
            style: {
            maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
            width: 250,
            },
        },
    };
export default function AddBooking(){
    const [inmateId, setInmateId] = useState(0); 
    const [bookingLocation, setBookingLocation] = useState("");
    const [facilityName, setFacilityName] = useState("");
    const [charges, setCharges] = useState("");
    const [releasedInformation, setReleasedInformation] = useState("");
    const [bookedDate, setBookedDate] = useState(null);
    const [releasedDate, setReleasedDate] = useState(null);
    
    const [inmates, setInmates] = useState([]);

    const baseURL = import.meta.env.VITE_WEB_API;
    const navigate = useNavigate();


    const handleReleasedDateChange = (e) => {
        const newReleasedDate = e.target.value;
        if (newReleasedDate >= bookedDate || !newReleasedDate) {
          setReleasedDate(newReleasedDate);
        } else {
            setReleasedDate(null);
            toast.error('Released Date cannot be earlier than Booked Date');
        }
      };
      const handleBookingDateChange = (e) => {
        const newBookedDate = e.target.value;
        if (newBookedDate < releasedDate || !newBookedDate) {
          setBookedDate(newBookedDate);
        } else {
            setBookedDate(null);
            toast.error('Released Date cannot be earlier than Booked Date');
        }
      };
    async function fetchInmates(){
        const url = baseURL + '/Inmates/GetAllInmates/' ;
        const response = await httpGet(url);
        setInmates(response.dataList);
    }
    useEffect(()=>{
        fetchInmates();
    }, [])

    async function handleSubmit(){
        let isValidated = validateData();
        if(!isValidated){
            return;
        }

        let data = {
            inmateId : inmateId,
            bookingLocation : bookingLocation,
            facilityName : facilityName,
            charges : charges,
            releasedInformation : releasedInformation,
            bookedDate : bookedDate,
            releasedDate : releasedDate
        }
        const url = baseURL + "/Booking/InsertBooking";
        var response = await httpPost(url, data);
        if(response.isSuccess){
            toast.success(response.message);
            navigate(-1);
        }
        else{
            toast.error(response.message);
        }
    }
    const validateData = () => {
        let errors = [];
        if(inmateId == "" || inmateId == 0) errors.push("Inmate is mandatory");
        if(bookingLocation == "") errors.push("Booking Location is mandatory");
        if(facilityName == "") errors.push("Facility Name is mandatory");
        if(charges == "") errors.push("Charges is mandatory");
        if(bookedDate == null) errors.push("Booked Date is mandatory");
        let errorMessage = errors.join("\n")
        if(errors.length > 0){
            alert(errorMessage);
            return false;
        }
        return true;
       }
    return(
        <>
            <MainCard title="Add Booking">
                <div style={{marginTop:"0rem"}}>
                    <FormControl sx={{ m: 0, minWidth: 120 }} size="small">
                        <div style={{display:"flex", justifyContent:"center", alignItems:"center"}}>

                            <p style={{marginRight:"2rem"}}>Inmate</p>
                            <Select
                                labelId="demo-select-small-label"
                                id="demo-select-small"
                                value={Number(inmateId)}
                                width="300px"
                                placeholder='Choose Inmate'
                                MenuProps={MenuProps}
                                onChange={(e)=> {setInmateId(Number(e?.target?.value));}}
                            >
                                <MenuItem  value="">
                                <em>None</em>
                                </MenuItem>
                                {
                                    inmates?.map((each)=>{
                                        return <MenuItem key={each?.id} value={each?.id}>
                                                {each?.inmateName} 
                                            </MenuItem>
                                    })
                                }
                            </Select>
                        </div>
                        </FormControl> 
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Booking Location</span>
                    <TextField id="outlined-basic" value={bookingLocation} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setBookingLocation(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Faculty Name</span>
                    <TextField id="outlined-basic" value={facilityName} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setFacilityName(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Charges</span>
                    <TextField id="outlined-basic" value={charges} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setCharges(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Booked Date</span>
                    <TextField id="outlined-basic" type="date" value={bookedDate} variant="outlined" autoComplete='off' fullWidth onChange={handleBookingDateChange}/>
                </div>

                <div style={{marginTop:"0.9rem"}}>
                    <span>Released Date</span>
                    <TextField id="outlined-basic" type="date" value={releasedDate} variant="outlined" autoComplete='off' fullWidth onChange={handleReleasedDateChange}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Released Information</span>
                    <TextField id="outlined-basic" value={releasedInformation} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setReleasedInformation(e?.target?.value)}/>
                </div>

                <div style={{marginTop:"0.9rem"}}>
                    <Button variant="contained" onClick={()=> handleSubmit()}>
                        Save Changes
                    </Button>
                </div>
            </MainCard>
        </>
    );
}