import React, {useEffect, useState} from 'react';
import classes from './Navbar.module.css'
import bootClass from '../../Styles/bootstrap/css/bootstrap.css'
import {Link} from "react-router-dom";
import AuthService from "../../Service/AuthService";

const Nav = () => {
    let authService = new AuthService()
    const [isAuth,setIsAuth]=useState(false)
    useEffect(()=>{
        authService.GetUser().then((user)=>{
            if(user) setIsAuth(true)
            else setIsAuth(false)
        })
    },[])
    function login() {
        authService.Login()
    }
    function Logout()
    {
        authService.Logout()
    }
    return (
        // <div className={classes.navbar}>
        //     <div className={classes.navbarBrand}>
        //         <h2>Ticket Shop</h2>
        //     </div>
        //     <div>
        //         <ul className={classes.navbarList}>
        //             <Link className={classes.navbarItem} to="/test">Тест</Link>
        //             <Link className={classes.navbarItem} to="/concert">Концерты</Link>
        //         </ul>
        //     </div>
        //     {isAuth?
        //         <div>
        //             User log in <br/>
        //             <button className={classes.navbarButton} onClick={Logout}>Log out</button>
        //         </div>
        //         :
        //         <div>
        //             <button className={classes.navbarButton} onClick={login}>Sign in</button>
        //         </div>
        //     }
        // </div>
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">Ticket shop</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link className="nav-link" to="/concert">Концерты</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/test">Test</Link>
                        </li>
                    </ul>
                </div>
                <div className="d-flex">
                    {isAuth?
                        <div>
                            <h5 className="text-white">user log in</h5><br/>
                            <button className="btn btn-danger rounded-pill" onClick={Logout}>Logout</button>
                        </div>
                        :
                        <button className="btn btn-success rounded-pill m-1" onClick={login}>Войти</button>
                    }
                </div>
            </div>
        </nav>
    );
};

export default Nav;