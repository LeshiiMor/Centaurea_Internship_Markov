import React from 'react';
import {Link} from "react-router-dom";
import AppRouter from "../../../Components/AppRouter";
import {AdminPanelRoutes} from "../../../Router/Routers";
import classes from './AdminPanel.module.css'

const AdminPanel = () => {
    return (
            <div className={classes.adminCont +" container-fluid"}>
                <div className={"row " + classes.maxHeight}>
                    <div className={classes.zeroPadding+" col-2"}>
                        <div className={classes.navContainer + " bg-dark"}>
                            <ul className={classes.navList}>
                                <li><Link to='/admin/main'  className={classes.navListLink}>Главная</Link></li>
                                <li><Link to='/admin/musicians' className={classes.navListLink}>Исполнители</Link></li>
                                <li><Link to='/admin/musicgroup' className={classes.navListLink}>Группы</Link></li>
                                <li><Link to='/admin/concert' className={classes.navListLink}>Концерты</Link></li>
                            </ul>
                        </div>
                    </div>
                    <div className={classes.zeroPadding+" col "+classes.cont}>
                        <AppRouter routes={AdminPanelRoutes} redirect="/admin/main"/>
                    </div>
                </div>
            </div>

    );
};

export default AdminPanel;