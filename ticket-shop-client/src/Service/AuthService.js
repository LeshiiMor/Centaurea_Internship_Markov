import {settings} from "../Configuration/Configuration";
import {UserManager} from "oidc-client";

class AuthService{
    constructor() {
        this.settings=settings
        this.userManager = new UserManager(this.settings)
        //this.IsAuthenticated=false;
    }
    IsAuthenticated()
    {
        this.userManager.getUser().then((user)=>{
            console.log('proverka')
            if(!user) return false;
            else return true;

        })
    }
    Login()
    {
        this.userManager.signinRedirect();
    }
    Logout(){
        this.userManager.signoutRedirect()
    }
    GetUser()
    {
        return this.userManager.getUser();
    }
    RefreshToken()
    {

    }
    CallBack()
    {
        return this.userManager.signinRedirectCallback()
    }
}
export default AuthService;