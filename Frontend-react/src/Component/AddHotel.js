import React from 'react'
import { useState, useEffect } from 'react';
import axios from "axios";
import '../Styles/AddHotel.css';
import { Link } from 'react-router-dom/cjs/react-router-dom.min';

const AddHotel = () => {  
    const[status,setStatus] = useState(false);

    const uId = parseInt(sessionStorage.getItem('UserId'));
    const url = "http://localhost:5024/hotel/";
    //for get Request 
    const [hotels,setHotels] = useState({hotelName : "" , description : "" , email : "" , pinCode : "" , state : "" , address : "",hotelId:"",hotelImageSrc:" "});

    // for adding hotel
    const [imgSrc,setImgSrc] = useState({ImgSrc:""});
    const [hotel,setHotel] = useState({HotelName : "" , Description : "" , Email : "" , PinCode : "" , State : "" , Address : "" , HotelImageFile :null,HotelImageSrc:null});

    const token = sessionStorage.getItem('jwttoken');
    const FetchData = async () => {
        try {
            const getUrl = "http://localhost:5024/hotel/getHotelByManagerId/" + uId;
            console.log(getUrl);
            debugger;
            const response = await axios.get(getUrl);
            if (response.data.length > 0) {
                debugger;
                setStatus(true);
                const hotelData = response.data[0]
                 setHotels(hotelData);
            }
            else{
                console.log("No response");
            }
        }catch (error) {
            console.error('Error fetching data:', error);
        }
    };
    const OnTextChanged=(e)=>{
        // debugger;
        // console.log(hotel);
        var copyOfHotel = {...hotel};
        copyOfHotel[e.target.name]=e.target.value;
        setHotel(copyOfHotel);
    }
    const AddOrEditRecord = async(e)=>{

        e.preventDefault();

        const formData = new FormData();
        formData.append('userId',uId);
        formData.append('HotelName', hotel.HotelName);
        formData.append('Description', hotel.Description);
        formData.append('EmailId', hotel.Email);
        formData.append('PinCode', hotel.PinCode);
        formData.append('State', hotel.State);
        formData.append('Address', hotel.Address);
        formData.append('HotelImageFile', hotel.HotelImageFile);
        formData.append('HotelImageSrc', hotel.HotelImageSrc);
        
      
        const postUrl = "http://localhost:5024/hotel/AddHotel";
        debugger;
        for (const pair of formData.entries()) {
            console.log( pair[0]+" : "+pair[1]);
          }
          console.log(hotel);
          debugger;
        await axios.post("http://localhost:5024/hotel/AddHotel",formData).then((result)=>{
           debugger;
            if(result.status == 201){
                FetchData();
                setHotel({userId : parseInt(uId,10) , HotelName : "" , Description : "" , Email : "" , PinCode : "" , State : "" , Address : "" , HotelImageFile :null,HotelImageSrc:null});                
                setImgSrc({ImgSrc:""});
                document.getElementById("image-file").value = null;
            }
        }).catch((err)=>{
             console.log(err);
        })}

       useEffect(()=>{
       debugger;
        FetchData();
       },[])
    

  const showPreview = (e)=>{
  
    if(e.target.files && e.target.files[0])
    {
        let imageFile = e.target.files[0];
        const reader = new FileReader();
        reader.onload = x =>{
            console.log(x);
            setHotel({
                ...hotel,
                HotelImageFile : imageFile,
            });
            setImgSrc({ImgSrc : x.target.result})
         }
        reader.readAsDataURL(imageFile);
    }
    else{
        setHotel({
            ...hotel,
            HotelImageFile:null,
            HotelImageSrc:""
        })
    }};

    


   const updateRecord = ()=>{
    // const [imgSrc,setImgSrc] = useState({ImgSrc:""});
    // const [hotel,setHotel] = useState({HotelName : "" , Description : "" , Email : "" , PinCode : "" , State : "" , Address : "" , HotelImageFile :null,HotelImageSrc:null});

    // setHotel
     

   }
  

  return (
    <>
    <form  onSubmit={AddOrEditRecord} >
    <div className="card login-form space" style={{marginLeft:"30%",marginTop:"100px",marginBottom:"100px",width:"40%"}}>
                <div className="card-body">
                    <h3 className="card-title text-center"><b>Add Hotel</b></h3>
                    
                    <div className="card-text form1">
                        
                            <div className="form-group">
                                <label>Hotel Name</label>
                                <input type="text" className="form-control form-control-sm mt-2" name='HotelName' value={hotel.HotelName} onChange={OnTextChanged}/>
                            </div>
                            <div className="form-group">
                                <label>State</label>
                                <input type="text" className="form-control form-control-sm mt-2" name='State' value={hotel.State} onChange={OnTextChanged} />
                            </div>
                            <div className="form-group">
                                <label>PinCode</label>
                                <input type="text" className="form-control form-control-sm mt-2" name='PinCode' value={hotel.PinCode} onChange={OnTextChanged} />
                            </div>
                            <div className="form-group">
                                <label>Address</label>
                                <input type="text" className="form-control form-control-sm mt-2" name='Address' value={hotel.Address} onChange={OnTextChanged} />
                            </div>
                            <div className="form-group">
                                <label>Email</label>
                                <input type="email" className="form-control form-control-sm mt-2" name='Email' value={hotel.Email} onChange={OnTextChanged} />
                            </div>
                            <div className="form-group">
                                <label>Description</label>
                                <textarea className='form-control' name='Description' value={hotel.Description} onChange={OnTextChanged}> </textarea>
                            </div> 
                            <div style={{marginTop:"5px"}}>
                            <label>Select Hotel Image </label>
                            <div className='card' style={{marginTop:"10px"}}>
                                <img style={{marginBottom:"10px"}} src={imgSrc.ImgSrc} className='card-img-top'></img>
                               <div className="form-group">
                                <input type="file" accept='image/*'id="image-file" className="form-control form-control-sm mt-2" name='HotelImageFile' onChange={showPreview} />
                               </div> 
                            </div>  
                            </div>               
                            <button className="btn btn-primary btn-block" style={{marginLeft:"40%"}}> Add Hotel </button>
                    </div>
                </div>
            </div>
             </form>
            {status === true && (
                <div className="card card1" style={{marginLeft:"150px"}}>
                <h5 className="card-header" style={{backgroundColor:"aqua",textAlign:"center"}}>Hotels</h5>
                <div className="card-body"></div>
             <div className="container">
                <div className="table-responsive">
            
                <table class="table table-bordered caption-top">
                   <thead>
                     <tr>
                       <th>Hotel Image</th>
                       <th>Hotel Name</th>
                       <th>State</th>
                       <th>PinCode</th>
                       <th>Address</th>
                       <th>Email</th>
                       <th>Description</th>
                       {/* <th>Description</th> */}
                     </tr>
                   </thead>
                   <tbody>
                     <tr>
                       <td> <img style={{marginBottom:"10px",width:"300px",height:"250px"}}  src={hotels.hotelImageSrc} ></img></td>
                       <td>{hotels.hotelName}</td>
                       <td>{hotels.state}</td>
                       <td>{hotels.pinCode}</td>
                       <td>{hotels.address}</td>
                       <td>{hotels.email}</td>
                       <td>{hotels.description}</td>
                       <td><button type="button" className='btn btn-primary' onClick={updateRecord} >Update Hotel</button></td>
                       <td><button type="button" className='btn btn-success'  ><a href='/manager/addRoom' style={{color:"white",textDecoration:"none"}}>Add Room</a></button></td>
                       

                     </tr>
                   </tbody>
                </table>
                 </div>
                </div>
             </div>
            ) } 
            
             </>
  )}
  export default AddHotel;