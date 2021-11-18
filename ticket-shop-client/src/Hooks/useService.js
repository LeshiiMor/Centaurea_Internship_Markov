import {useState} from 'react';
import AuthService from "../Service/AuthService";
import {AppBaseUrl} from "../Configuration/Configuration";
import {useHistory} from 'react-router-dom'

const UseService = (serviceFunction)=>{
    const [isLoading,setLoading] = useState(false)
    const [isBadReq,setBadReq]= useState(false)
    const [error,setError] = useState('')
    const history = useHistory()
    const usServ = async (...args)=>{
        try{
            setLoading(true)
            let response = await serviceFunction(...args)
            if(response)
            {
                if(response.status === 400){
                    setBadReq(true)
                }
                else if(response.status === 403)
                {
                    history.push('/forbidden')
                }
                else if(response.status === 401)
                {
                    let service = new AuthService()
                    service.Login()
                }
                return response
            }

        }
        catch (e) {
            console.log(e)
            setError(e)
        }
        finally {
            setLoading(false)
        }
    }
    return [isLoading,usServ,error]
};

export default UseService;