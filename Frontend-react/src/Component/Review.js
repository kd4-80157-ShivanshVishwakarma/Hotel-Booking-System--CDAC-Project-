import axios from "axios";
import "../Styles/inputField.css";
import { useState } from "react";

function Review() {

    const userId = sessionStorage.getItem('userId');
    const [reviewData,setReviewData] = useState({hotelRating:"",hotelComment:"",userId:userId});
    
   const handleFormSubmit = (e)=>{
    e.preventDefault();
    console.log(reviewData);
    axios.post("http://localhost:5024/AddHotelReview",reviewData)
    .then((response=>{
        console.log(response.data);
    }))
    .catch((error)=>{
        console.log(error);
    })

    setReviewData({hotelRating:"",hotelComment:"",userId:""});
   }

   const onTextChange = (e)=>{
    
     const copy = {...reviewData};
     copy[e.target.name] = e.target.value;

    setReviewData(copy);
   }



    return (  
        <div className="container cont-space">

             <div className="">
             <center><h1>Add Review</h1></center>
            </div>
            <hr/>

        <form noValidate  method="post" className="margin-space" onSubmit={handleFormSubmit}>

            <div className="col-lg-4 offset-lg-4 space">
                <label className="form-label">Enter your ratings:</label>
                <input className="form-control" type="number" min="1" max="5" name="hotelRating" value={reviewData.hotelRating}
                onChange={onTextChange}
                placeholder="Enter ratings "/>
            </div>


 

            <div className="col-lg-4 offset-lg-4 space">
                <label className="form-label">Enter your comments:</label>
                <textarea className="form-control" name="hotelComment" value={reviewData.hotelComment} rows={4} cols={30} onChange={onTextChange}/>
                
            </div>

            <div className="col-lg-4 offset-lg-4 btn-space btn-space">
                  <button className="btn btn-primary">Submit</button>
            </div>
                  
        </form>
            </div>
    )
    }

    export default Review;