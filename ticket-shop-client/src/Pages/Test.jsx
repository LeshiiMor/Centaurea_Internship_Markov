import React, {useState} from 'react';
import TestService from "../Service/API/TestService";
import Loader from "../Components/UI/Loader/Loader";
import UseAxios from "../Hooks/useAxios";
import AuthService from "../Service/AuthService";
import axios from "axios";

const Test = () => {
    const [message,setMessage]= useState('')
    const [number,setNumber] = useState(0)
    const [fetchTest,isLoading,error] = UseAxios(async ()=>{
        let service =new  TestService()
        const response = await service.Get()
        if(response) {
            if (response.status === 200) {
                setNumber(response.data)
            } else {
                setNumber(0)
                setMessage(response.statusText)
                console.log(response)
            }
        }
        else {
            setMessage(error)
            console.log(`darova -->${message}`)
        }
    })
    async function GetTest()
    {
        //fetchTest()
        new AuthService().GetUser().then((user)=>{
            if(user)
            {
                let url = new TestService().url
                const headers = {
                    Accept: 'application/json',
                    Authorization: 'Bearer ' + user.access_token
                };
                axios.get(`https://localhost:44324/api/test/number`,{headers}).then((data)=>{
                    setNumber(data.data)
                })
            }
            else {
                fetchTest()
            }

            // setMessage(user.access_token)
        })
    }
    return (
        <div>
            <h1>test</h1>
            <button onClick={GetTest}>GET NUMBER</button>
            <h4>Число полученное от сервера :{isLoading?<Loader/>:number}</h4>
            <p>
                {message}
            </p>
        </div>
    );
};

export default Test;