import React from 'react';
import {Route,Switch} from "react-router-dom";
import {Routes} from "../Router/Routers";

const AppRouter = () => {
    return (
        <Switch>
            {
                Routes.map(route=><Route path={route.path} component={route.component} exact={route.exact} key={route.path}/>)
            }
        </Switch>
    );
};

export default AppRouter;