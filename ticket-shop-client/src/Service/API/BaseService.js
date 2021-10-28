import axios from "axios";
import {ResBaseUrl} from "../../Configuration/Configuration";

class BaseService{
    constructor() {
        this.url=ResBaseUrl;
    }
    async Get(url){
        // try{
        //     let response = await axios.get(url)
        //     return response
        // }
        // catch(e)
        // {
        //     console.log(e)
        // }

        let response = await axios.get(url)
        return response

    }
    async Post(url){
        try{
            let response = await axios.post(url)
            return response.data
        }
        catch (e)
        {
            console.log(e)
        }

    }
}
export default BaseService;