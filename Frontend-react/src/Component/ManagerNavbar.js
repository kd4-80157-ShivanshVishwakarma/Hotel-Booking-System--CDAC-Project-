import React from 'react'
import { useState } from 'react'
import { Link } from 'react-router-dom'
import '../Styles/Navbar.css'
import { Dropdown } from 'react-bootstrap'
import { Navbar } from 'react-bootstrap'

const ManagerNavbar = () => {
    const name = sessionStorage.getItem('UserName');
  const [showLinks, setShowLinks] = useState(false);
  function Click(){
    setShowLinks(!showLinks);
   }
  return (
    <>
      <div className="navbar">
        <div className='container'>
        <div className="leftside" id={showLinks ? "open" : "close"}> 
        </div>
        <div className="rightside">
          <Link className="links" to="/hotelmanager">Home</Link>
          <Link className="links" to="/about">About</Link>
          <Link className="links" to="/contact">Contact</Link>
          <Dropdown>
          <Dropdown.Toggle style={{marginTop:"1px",color:"black",fontWeight:"bold"}} variant="success" id="dropdown-basic">
                Hi {name}         
            </Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item href="/manager/manage-acc">Manage Account</Dropdown.Item>
                    <Dropdown.Item href="/logout">Logout</Dropdown.Item>
                </Dropdown.Menu>
          </Dropdown>
        </div>
        </div>
    </div>
      </>
  )
}

export default ManagerNavbar;