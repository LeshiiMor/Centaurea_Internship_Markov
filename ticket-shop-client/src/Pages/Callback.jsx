import React, {useEffect} from 'react';
import {Redirect} from 'react-router-dom'
import AuthService from "../Service/AuthService";
import {AppBaseUrl} from "../Configuration/Configuration";

const Callback = () => {
    let authServ = new AuthService()
    useEffect(()=>{
        authServ.CallBack().then((user)=>{
            window.location.href=`${AppBaseUrl}/concert`
        })
    },[])
    return (
        <div>
            <h1>Call back page</h1>
        </div>
    );
};

export default Callback;