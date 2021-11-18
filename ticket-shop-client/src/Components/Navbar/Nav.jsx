import React, {useContext, useEffect, useState} from 'react';
import {Link} from "react-router-dom";
import AuthService from "../../Service/AuthService";
import Dropdown from "../UI/Dropdown/Dropdown";
import {AuthContext} from "../../Configuration/Configuration";

const Nav = () => {
    const {isAuth, setIsAuth}=useContext(AuthContext)
    const [nameUser,setNameUser]= useState('')
    useEffect( ()=>{
        let authService = new AuthService()
        authService.GetUser().then((user)=>{
            if(user)
            {
                setIsAuth(true)
                setNameUser(user.profile.nameUs)
            }
            else {
                setIsAuth(false)
            }
        })

    },[isAuth])
    function login() {
        let authService = new AuthService()
        authService.Login()
    }
    function Logout()
    {
        let authService = new AuthService()
        authService.Logout()
    }
    return (
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Ticket shop</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link className="nav-link active" to="/concert">Концерты</Link>
                        </li>
                    </ul>
                </div>
                <div className="d-flex">
                    {isAuth?
                        <Dropdown username={nameUser} logout={Logout}/>
                        :
                        <button className="btn btn-success rounded-pill m-1" onClick={login}>Войти</button>
                    }
                </div>
            </div>
        </nav>
    );
};

export default Nav;