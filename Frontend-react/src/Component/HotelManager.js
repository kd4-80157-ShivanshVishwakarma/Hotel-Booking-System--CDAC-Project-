// import { Link, useHistory } from 'react-router-dom';
// import { Dropdown } from 'react-bootstrap'
// import { toast } from 'react-toastify';
// import Navbar from './Navbar';

import AddHotel from './AddHotel';
import Hotel from './Hotel';
import ManagerNavbar from './ManagerNavbar';
import { useLocation } from 'react-router-dom/cjs/react-router-dom.min';

const HotelManager = () => {

    const location = useLocation();
    const isHotelRoute = location.pathname === "/hotelmanager";
    
    return(<>
            <ManagerNavbar/>
            {isHotelRoute && <AddHotel/>}
    </>)

  };

  export default HotelManager;