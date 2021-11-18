import {settings} from "../Configuration/Configuration";
import {UserManager} from "oidc-client";

class AuthService{
    constructor() {
        this.settings=settings
        this.userManager = new UserManager(this.settings)
    }
    async IsAuthenticated()
    {
        let User = await this.userManager.getUser()
        if(User){
            return true;
        }
        else
            return false;
    }
    Login()
    {
        this.userManager.signinRedirect();
    }
    Logout(){
        this.userManager.signoutRedirect()
    }
    async GetUser()
    {
        return await this.userManager.getUser();
    }
    async GetUserRole()
    {
        let user = await this.userManager.getUser()
        if(user)
        {
            return user.profile.role
        }
        else return null;
    }
    RefreshToken()
    {

    }
    CallBack()
    {
        return this.userManager.signinRedirectCallback()
    }
    static IsInRole(nameRole)
    {
       let role = localStorage.getItem('role')
        if(role)
        {
            return role===nameRole
        }
        else return false;
    }
}
export default AuthService;