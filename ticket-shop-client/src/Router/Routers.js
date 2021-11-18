import Concert from "../Pages/Concert";
import Callback from "../Pages/Callback";
import AdminPanel from "../Pages/Admin/MainPanel/AdminPanel";
import Main from "../Pages/Admin/Main/Main";
import AdminConcert from "../Pages/Admin/Concert/AdminConcert";
import MusicGroup from "../Pages/Admin/Musicgroup/MusicGroup";
import Musicians from "../Pages/Admin/Musician/Musicians";
import Forbidden from "../Pages/Forbidden";
import MusicianId from "../Pages/Admin/Musician/MusicianId";

export const Routes = [
    {path:'/',component:Concert, exact:true},
    {path:'/concert',component:Concert, exact:true},
    {path:'/callback',component:Callback, exact:true},
    {path:'/forbidden',component:Forbidden,exact: true}
]
export const AdminRoutes =[
    {path:'/admin',component:AdminPanel}
]
export const AdminPanelRoutes = [
    {path:'/admin/main', component:Main,exact:false},
    {path:'/admin/concert', component:AdminConcert,exact:false},
    {path:'/admin/musicgroup', component:MusicGroup,exact:false},
    {path:'/admin/musicians', component:Musicians,exact:true},
    {path:'/admin/musicians/:id', component:MusicianId,exact:true}
]
