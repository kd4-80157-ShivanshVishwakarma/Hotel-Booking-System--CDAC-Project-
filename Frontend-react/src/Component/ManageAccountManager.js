import React from 'react';
import '../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import { useState,useEffect } from 'react';
import axios from 'axios';
import '../Styles/common.css';
import Profile from './Profile';
import ChangePassword from './ChangePassword';
import ManagerNavbar from './ManagerNavbar';


function ManageAccountManager() {
                  return(<>
                    <Profile/>
                  <ChangePassword/>
                        </>    
                  )
            }
export default ManageAccountManager;