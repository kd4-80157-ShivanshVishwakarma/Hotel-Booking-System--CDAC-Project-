import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import NavbarUser from "./NavbarUser";
import React, { useEffect, useState } from 'react';
import { useLocation } from "react-router-dom/cjs/react-router-dom.min";
import ManagerNavbar from "./ManagerNavbar";


const EmptyComponent = ()=>{
    const location = useLocation();
    const id = sessionStorage.getItem('RoleId');
    const isContactRoute = location.pathname === "/contact";
    const isAboutRoute = location.pathname === "/about";
    const isManageAccount= location.pathname === "/manager/manage-acc";
    const isAddRoom = location.pathname === "/manager/addroom";

    return(<>
           {/* {(isContactRoute || isAboutRoute) && (id===2) && <NavbarUser />} */}
           {/* {(isContactRoute || isAboutRoute) && (id===1) && <ManagerNavbar />} */}
           {((isContactRoute || isAboutRoute) && id === '2') && <NavbarUser />}
        {((isContactRoute || isAboutRoute || isManageAccount || isAddRoom) && id === '1') && <ManagerNavbar />}
    </>)
}
export default EmptyComponent;