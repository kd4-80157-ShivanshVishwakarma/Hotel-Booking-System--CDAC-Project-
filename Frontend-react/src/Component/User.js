import NavbarUser from "./NavbarUser";
import Hotel from './Hotel';
import { useLocation } from "react-router-dom/cjs/react-router-dom.min";


const UserDashboard = ()=>{
    const location = useLocation();
    const isHotelRoute = location.pathname === "/user";

    return (
        <>
            <NavbarUser />
            {isHotelRoute && <Hotel />}
        </>
    );
}
export default UserDashboard;