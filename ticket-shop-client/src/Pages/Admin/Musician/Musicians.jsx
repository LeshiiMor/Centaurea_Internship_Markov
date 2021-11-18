import React, {useEffect, useState} from 'react';
import classes from './Musician.module.css'
import MusicianTable from "./MusicianTable";
import MusicianFiltr from "./MusicianFiltr";
import MusicianCreate from "./MusicianCreate";
import UseService from "../../../Hooks/useService";
import MusicianService from "../../../Service/API/MusicianService";
import Loader from "../../../Components/UI/Loader/Loader";
import MusicGroupService from "../../../Service/API/MusicGroupService";

const Musicians = () => {
    const [musicians,setMusicians] = useState([])
    const [musGroups,setGroups] = useState([])
    const [isCreatedMod,setCreatedMod] = useState(false)
    const [musicianLoading,loadMusicians] = UseService(async(searchString=null,idGroup=0)=>{
        let service = new MusicianService()
        let res = service.GetAll(searchString,idGroup)
        return res
    })
    const [isGroupLoad,loadGroups] = UseService(async ()=>{
        let service = new MusicGroupService()
        let response = service.getAll()
        return response
    })
    useEffect(()=>[
        LoadMusicians(),
        LoadGroups()
    ],[])

    async function LoadMusicians(searchString=null,idGroup=0)
    {
        let response = await loadMusicians(searchString,idGroup);
        if(response) {
            setMusicians(response.data)
        }
    }
    async function LoadGroups()
    {
        let response = await loadGroups()
        if(response.status === 200){
            setGroups(response.data)
        }
    }
    function createdMod()
    {
        if(isCreatedMod) {
            document.getElementById('crmod-btn').textContent='Создать'
            setCreatedMod(false)
        }
        else {
            document.getElementById('crmod-btn').textContent='Назад'
            setCreatedMod(true)
        }
    }
    async function SearchEv(e){
        let value = e.target.value
        let res = await loadMusicians(value)
        if(res.status === 200)
        {
            setMusicians(res.data)
        }
    }
    return (
        <div className={classes.cont}>
            <div className="container">
                <div className="row">
                    <div className="col">
                        <h1 className={'mt-4'}>Исполнители</h1>
                    </div>
                </div>
               <div className="row">
                   {!isCreatedMod &&
                       <div className="col">
                           <input type="text" placeholder="Search" className={"form-control rounded-pill w-50"} onChange={(e)=>{LoadMusicians(e.target.value)}}/>
                       </div>
                   }
                   <div className="col d-flex justify-content-end">
                       <button className={'btn btn-success'} id = "crmod-btn" onClick={createdMod}>Создать</button>
                   </div>
               </div>
               <div className="row">
                   <div className={classes.contTable}>
                       {isCreatedMod
                           ?<MusicianCreate groups={musGroups} loadMusicians={LoadMusicians}/>
                           :
                           <div>
                               <MusicianFiltr musicGroups={musGroups} loadMusician={LoadMusicians}/>
                               {musicianLoading
                                   ?<Loader/>
                                   :<MusicianTable musicians={musicians} setMusician={setMusicians}/>
                               }
                           </div>
                       }
                   </div>
               </div>
            </div>
        </div>
    );
};

export default Musicians;