import React from 'react';
import "../../node_modules/bootstrap/dist/css/bootstrap.min.css";

const ContactForm = () => {
    return (
        <div className="card card1" style={{marginLeft:"300px",width:"60%"}}>
                <h5 className="card-header" style={{backgroundColor:"aqua",textAlign:"center"}}>Contact Us</h5>
                <div className="card-body">
        <div className='container'>
          <div className='row'>
            <div className='col-12 text-center'>
              <div className='contactForm'>
                <form id='contact-form' noValidate>
                <br/>
                  <div className='row formRow'>
                    <div className='col-6'>
                      <input
                        type='text'
                        name='name'
                        className='form-control formInput'
                        placeholder='Name'
                      ></input>
                    </div>
                    <div className='col-6'>
                      <input
                        type='email'
                        name='email'
                        className='form-control formInput'
                        placeholder='Email address'
                      ></input>
                    </div>
                  </div>
                  {/* Row 2 of form */}
                  <br/>
                  <div className='row formRow'>
                    <div className='col'>
                      <input
                        type='text'
                        name='subject'
                        className='form-control formInput'
                        placeholder='Subject'
                      ></input>
                    </div>
                  </div>
                  {/* Row 3 of form */}
                  <br/>
                  <div className='row formRow'>
                    <div className='col'>
                      <textarea
                        rows={3}
                        name='message'
                        className='form-control formInput'
                        placeholder='Message'
                      ></textarea>
                    </div>
                  </div>
                  <br/>
                  <button className='btn btn-primary' type='submit'>
                    Submit
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
        </div>
        </div>
    );
  };
  
  export default ContactForm;