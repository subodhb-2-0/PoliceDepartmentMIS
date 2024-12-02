import { RouterProvider } from 'react-router-dom'
import router from './routes';
import ScrollTop from './components/ScrollTop';
import './App.css'
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <>
        <ScrollTop>
            <RouterProvider router={router} />
        </ScrollTop>
        <ToastContainer />
    </>
  );
}

export default App
