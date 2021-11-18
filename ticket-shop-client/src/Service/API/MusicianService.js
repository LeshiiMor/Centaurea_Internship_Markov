import {resAxios, ResBaseUrl} from "../../Configuration/Configuration";
import AuthService from "../AuthService";

class MusicianService{
    constructor() {
        this.url =ResBaseUrl +'/api/musician'
    }
    async Edit(musician)
    {
        let url = this.url +'/edit'
        let head = await this.getHeaders()
        let response = await resAxios.post(url,musician,{headers:head})
        return response
    }
    async GetAll(stringSearch=null,idGroup=0)
    {
        let url = this.url +'/getall'
        let head = await this.getHeaders()
        let response = await resAxios.get(url,{headers:head, params:{stringSearch:stringSearch,idGroup:idGroup}})
        return response
    }
    async Get(id)
    {
        let url = this.url +'/get/'+id
        let head = await this.getHeaders()
        let response = await resAxios.get(url,{headers:head})
        return response
    }
    async Create(musician)
    {
        let url = this.url+'/create'
        let head = await this.getHeaders()
        let response = await resAxios.post(url,musician,{headers:head})
        return response
    }
    async Delete(id)
    {
        let url = this.url+'/delete/'+id
        let head = await this.getHeaders()
        let response = await resAxios.post(url,null,{headers:head})
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
export default MusicianService;