import React, {useState} from 'react';

const UseAxios = (callback) => {
    const [isLoading,setIsLoading]= useState(false)
    const [error,setError]= useState('')
    const fetch =async (...args)=>{
        try{
            setIsLoading(true)
            await callback(...args)
        }
        catch(e)
        {
            setError(e.message)
        }
        finally {
            setIsLoading(false)
        }
    }
    return [fetch,isLoading,error]
};

export default UseAxios;