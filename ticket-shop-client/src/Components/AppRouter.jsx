import {Redirect, Route, Switch} from "react-router-dom";

const AppRouter = ({routes,redirect,...props}) => {
    return (
        <Switch>
            {routes.map(route=><Route path={route.path} component={route.component} exact={route.exact} key={route.path}/>)}
            {redirect && <Redirect to={redirect}/>}
        </Switch>
    );
};

export default AppRouter;