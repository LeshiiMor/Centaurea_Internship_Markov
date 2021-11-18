import React from 'react';
import classes from "./Dropdown.module.css";
import {Link} from "react-router-dom";
import AuthService from "../../../Service/AuthService";

const Dropdown = ({username,logout,...props}) => {
    return (
        <div className={classes.dropdown}>
            <button className={classes.dropBtnToggle}>{username}</button>
            <div className={classes.dropdownContent}>
                <a className={classes.dropdownItem} href="/#">Настройки</a>
                <a className={classes.dropdownItem} href="/#">Корзина</a>
                {AuthService.IsInRole('admin') && <Link className={classes.dropdownItem} to="/admin">Админ панель</Link>}
                <hr className={classes.dropdownHR}/>
                <button className={classes.dropdownBtn} onClick={logout}>Выйти</button>
            </div>
        </div>
    );
};

export default Dropdown;