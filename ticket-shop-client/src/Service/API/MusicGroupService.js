import AuthService from "../AuthService";
import {resAxios, ResBaseUrl} from "../../Configuration/Configuration";

class MusicGroupService{
    constructor() {
        this.url =ResBaseUrl +'/api/musicgroup'
    }
    async getAll()
    {
        let url = this.url +'/getall'
        let head = await this.getHeaders()
        let response = await resAxios.get(url,{headers:head})
        return response
    }
    async getHeaders()
    {
        const headers={
            Authorization:''
        }
        let authService= new AuthService()
        let user = await authService.GetUser()
        if(user)
        {
            headers.Authorization='Bearer '+user.access_token
        }
        return headers
    }
}
export default MusicGroupService;