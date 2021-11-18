import React, {useContext, useEffect} from 'react';
import AuthService from "../Service/AuthService";
import {AuthContext} from "../Configuration/Configuration";
import {useHistory} from 'react-router-dom'

const Callback = () => {
    const history = useHistory()
    const {isAuth,setIsAuth}= useContext(AuthContext)
    useEffect(()=>{
        let authServ = new AuthService()
        authServ.CallBack().then((user)=>{
            if(user)
            {
                localStorage.setItem('role',user.profile.role)
                setIsAuth(true)
            }
            history.push('/concert')
        })
    },[])
    return (
        <div className="container">
            <h1>Еще чуть-чуть...</h1>
        </div>
    );
};

export default Callback;