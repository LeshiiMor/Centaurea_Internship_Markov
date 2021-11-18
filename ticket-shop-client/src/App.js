import Nav from "./Components/Navbar/Nav";
import './Styles/App.css';
import './Styles/bootstrap/css/bootstrap.css';
import AppRouter from "./Components/AppRouter";
import AuthService from "./Service/AuthService";
import {AdminRoutes, Routes} from "./Router/Routers";
import {useState} from "react";
import {AuthContext} from "./Configuration/Configuration";

function App() {
    const [isAuth,setIsAuth]=useState(false)
  return (
      <AuthContext.Provider value={{
          isAuth,
          setIsAuth
      }}>
          <div>
              <Nav/>
              <AppRouter routes={AuthService.IsInRole('admin')?Routes.concat(AdminRoutes):Routes}/>
          </div>
      </AuthContext.Provider>

  );
}

export default App;
