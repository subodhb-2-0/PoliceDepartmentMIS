import MainCard from "../../components/MainCard";
import { Button, TextField } from '@mui/material';
import { useState, useEffect } from "react";
import { httpPut, httpGet } from '../../api/apiClient';
import { useNavigate, useParams } from 'react-router';
import { toast } from 'react-toastify';

export default function EditInmate(){

    const [firstName, setFirstName] = useState(""); 
    const [middleName, setMiddleName] = useState("");
    const [lastName, setLastName] = useState("");
    const [citizenshipNumber, setCitizenshipNumber] = useState("");
    const [dob, setDob] = useState(null);
    const baseURL = import.meta.env.VITE_WEB_API;
    const navigate = useNavigate();
    const { id } = useParams();

    const fetchData = async() => {
        const url = baseURL + '/Inmates/GetInmateById/'+id;
        const result = await httpGet(url);
        if(result.isSuccess){
            var data = result.data;
            setFirstName(data.firstName);
            setLastName(data.lastName);
            setMiddleName(data.middleName);
            setDob(data.dob.split('T')[0]);
            setCitizenshipNumber(data.citizenshipNumber);
        }
    }
    

   useEffect(()=>{
       fetchData();
   },[]);
    async function handleSubmit(){
        let isValidated = validateData();
        if(!isValidated){
            return;
        }

        let data = {
            firstName : firstName,
            middleName : middleName,
            lastName : lastName,
            dob: dob,
            citizenshipNumber : citizenshipNumber
        }
        const url = baseURL + "/Inmates/UpdateInamtes/"+id;
        var response = await httpPut(url, data);
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
        if(firstName == "") errors.push("First Name is mandatory");
        if(lastName == "") errors.push("Last Name is mandatory");
        if(citizenshipNumber == "") errors.push("Citizenship Number is mandatory");
        if(dob == null) errors.push("Date of Birth is mandatory");
        let errorMessage = errors.join("\n")
        if(errors.length > 0){
            alert(errorMessage);
            return false;
        }
        return true;
       }
    return(
        <>
            <MainCard title="Add Inmate">
                <div style={{marginTop:"0.9rem"}}>
                    <span>First Name</span>
                    <TextField id="outlined-basic" value={firstName} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setFirstName(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Middle Name</span>
                    <TextField id="outlined-basic" value={middleName} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setMiddleName(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Last Name</span>
                    <TextField id="outlined-basic" value={lastName} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setLastName(e?.target?.value)}/>
                </div>
                <div style={{marginTop:"0.9rem"}}>
                    <span>Date of Birth</span>
                    <TextField id="outlined-basic" type="date" value={dob} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setDob(e?.target?.value)}/>
                </div>

                <div style={{marginTop:"0.9rem"}}>
                    <span>Citizenship No</span>
                    <TextField id="outlined-basic" value={citizenshipNumber} variant="outlined" autoComplete='off' fullWidth onChange={(e)=> setCitizenshipNumber(e?.target?.value)}/>
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