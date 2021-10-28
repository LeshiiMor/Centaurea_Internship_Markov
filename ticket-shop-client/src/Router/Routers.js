import Test from "../Pages/Test";
import Concert from "../Pages/Concert";
import Callback from "../Pages/Callback";

export const Routes = [
    {path:'/test',component:Test, exact:true},
    {path:'/concert',component:Concert, exact:true},
    {path:'/callback',component:Callback, exact:true}
]

export const sourceAPI = 'http://localhost:24322'