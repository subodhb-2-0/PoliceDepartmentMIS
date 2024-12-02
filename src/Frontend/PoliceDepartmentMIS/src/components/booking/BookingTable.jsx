import * as React from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { EditOutlined, DeleteOutlined } from '@mui/icons-material';
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import Swal from 'sweetalert2'

export default function BookingTable(){
    const baseURL = import.meta.env.VITE_WEB_API
    const columns = [
        { id: 'id', label: 'Id', minWidth: 50 },
        { id: 'inmateName', label: 'Inmate Name', minWidth: 100 },
        {
          id: 'bookingLocation',
          label: 'Booking Location',
          minWidth: 75,
          align: 'right',
        },
        {
          id: 'facilityName',
          label: 'Facility Name',
          minWidth: 75,
          align: 'right',
        },
        {
          id: 'bookedDate',
          label: 'Booked Date',
          minWidth: 75,
          align: 'right',
        },
        {
          id: 'releasedDate',
          label: 'Released Date',
          minWidth: 75,
          align: 'right',
        },
        {
          id: 'charges',
          label: 'Charges',
          minWidth: 100,
          align: 'right',
        },
        {
          id: 'releasedInformation',
          label: 'Released Information',
          minWidth: 100,
          align: 'right',
        },
        {
          id: "action",
          label: "Action",
           minWidth: 100,
          align: 'center',
        }
      ];
    const [page, setPage] = React.useState(0);
    const [pageSize, setPageSize] = React.useState(10);
    const [bookings, setBookings] = React.useState([]);
    const user = localStorage.getItem('user')||{};
    const token = JSON.parse(user);

    async function fetchBooking(){
        const url = baseURL + '/Booking/GetAllBookings/' ;
        const response = await fetch(url, {
            method:'GET',
            headers:{
                'Authorization' : 'Bearer '+ token
            }
        });
        if(!response.ok) toast.error("someting went wrong");
        const result = await response.json();
        setBookings(result.dataList);
    }
    React.useEffect(()=>{
        fetchBooking();
    }, [])

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setPageSize(+event.target.value);
        setPage(0);
    };
    const navigate = useNavigate();
    const editInformation = (row, column) => {
      navigate("/booking/edit/" + row.id);
    }
    const handleInmateClick = (row) => {
       navigate("/inmatebooking/"+row.inmateId)
      };
    const deleteInformation = async (row, column) => {
        const result = await Swal.fire({
            title: 'Are you sure?',
            text: "This action can't be undone!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'Cancel',
            reverseButtons: true,
          });
      
          if (result.isConfirmed) {
            const url = baseURL + '/Booking/DeleteBooking/'+row.id ;
            const response = await fetch(url, {
                method:'DELETE',
                headers:{
                    'Authorization' : 'Bearer '+ token
                }
            });
            if(!response.ok) Swal.fire('Error', 'Error occured while deleting item.', 'error');
            const result = await response.json();
            if(result.isSuccess){
                await fetchBooking();
                Swal.fire('Deleted!', result.message, 'success');
            }
            else{
                Swal.fire('Error', result.message, 'error');
            }
          } else {
            Swal.fire('Cancelled', 'Your file is safe :)', 'error');
          }
    };
    return(
        <>
            <Paper sx={{ width: '100%', overflow: 'hidden' }}>
                <TableContainer sx={{ maxHeight: 440 }}>
                    <Table stickyHeader aria-label="sticky table">
                    <TableHead>
                        <TableRow>
                        {columns.map((column) => (
                            <TableCell
                            key={column.id}
                            align={column.align}
                            style={{ minWidth: column.minWidth }}
                            >
                            {column.label}
                            </TableCell>
                        ))}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {bookings
                        .slice(page * pageSize, page * pageSize + pageSize)
                        .map((row) => {
                            return (
                            <TableRow hover role="checkbox" tabIndex={-1} key={row.id}>
                                {columns.map((column) => {
                                    const value = row[column.id];
                                    if(column.id == "inmateName"){
                                        return (
                                                <TableCell key={column.id}
                                                onClick={() => handleInmateClick(row)}
                                                align={column.align}>
                                                {column.format && typeof value === 'number'
                                                    ? column.format(value)
                                                    : value}
                                                </TableCell>
                                        )
                                    }
                                    if(column.id == "action"){
                                        return <TableCell key={column.id} align={column.align}>
                                            <EditOutlined onClick={()=>editInformation(row, column)} />
                                            <DeleteOutlined onClick={()=>deleteInformation(row, column)} />
                                        </TableCell>
                                    }
                                
                                return (
                                    <TableCell key={column.id} align={column.align}>
                                    {column.format && typeof value === 'number'
                                        ? column.format(value)
                                        : value}
                                    </TableCell>
                                );
                                })}
                            </TableRow>
                            );
                        })}
                    </TableBody>
                    </Table>
                </TableContainer>
                <TablePagination
                    rowsPerPageOptions={[10, 25, 100]}
                    component="div"
                    count={bookings.length}
                    rowsPerPage={pageSize}
                    page={page}
                    onPageChange={handleChangePage}
                    onRowsPerPageChange={handleChangeRowsPerPage}
                />
                </Paper>
        </>
    );
}