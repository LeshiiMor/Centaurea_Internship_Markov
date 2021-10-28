import {BrowserRouter} from "react-router-dom";
import Nav from "./Components/Navbar/Nav";
import './Styles/App.css'
import AppRouter from "./Components/AppRouter";

function App() {
  return (
      <BrowserRouter>
          <Nav/>
          <div className="container">
              <AppRouter/>
          </div>
      </BrowserRouter>
  );
}

export default App;
