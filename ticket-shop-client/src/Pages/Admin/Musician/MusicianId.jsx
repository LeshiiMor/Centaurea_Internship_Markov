import React, {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom'
import UseService from "../../../Hooks/useService";
import MusicianService from "../../../Service/API/MusicianService";
import Loader from "../../../Components/UI/Loader/Loader";
import classes from './Musician.module.css'
import MusicGroupService from "../../../Service/API/MusicGroupService";

const MusicianId = () => {
    const params = useParams()
    const [groups,setGroups] = useState([])
    const [isLoadGR,loadGroup] = UseService(async ()=>{
        let service = new MusicGroupService()
        return await service.getAll()
    })
    const [musLoading,loadMusician] = UseService(async ()=>{
        let service = new MusicianService()
        let id = params.id
        if(id) return await service.Get(id)
        else return null;
    })
    const [editLoading,editMusician] = UseService(async ()=>{
        let service = new MusicianService()
        return await service.Edit(musician)
    })
    const [musician,setMusician] = useState({
        name:'',
        surname:'',
        nickname:'',
        musicGroupId:0,
        nameGroup:''
    })
    useEffect(()=>{
        LoadMusician()
        LoadGroups()
    },[])
    async function LoadMusician()
    {
        let response = await loadMusician()
        if(response.status === 200){
            let mus = response.data
            setMusician(mus)
        }
    }
    async function LoadGroups()
    {
        let response  =await loadGroup()
        if(response.status === 200){
            setGroups(response.data)
        }
    }
    async function EditMusician(e){
        e.preventDefault()
        let res  = await editMusician()
        if(res.status === 200){
            alert('Изменено')
        }
        else if(res.status === 400)
        {
            alert('ошибка при обновлении данных')
        }
    }
    return (
        <div className={'container'}>
            <div className="row">
                <div className="col">
                    {musLoading
                        ?<Loader/>
                        :<div className={classes.infoBlock}>
                            <h1 className={'text-center m-1'}>{musician.name}</h1>
                            <form className={'m-4'} method='post' onSubmit={EditMusician}>
                                <div className={'m-3'}>
                                    <label htmlFor={'nameInput'} className={'form-label'}>Имя</label>
                                    <input id={'nameInput'} type="text" className={'form-control'} value={musician.name} onChange={e=>setMusician({...musician,name: e.target.value})}/>
                                </div>
                                <div className={'m-3'}>
                                    <label htmlFor="surnameInput" className={'form-label'}>Фамилия</label>
                                    <input id={'surnameInput'} type="text" className={'form-control'} value={musician.surname} onChange={e=>setMusician({...musician,surname: e.target.value})}/>
                                </div>
                                <div className={'m-3'}>
                                    <label htmlFor="nicknameInput" className={'form-label'}>Псевдоним</label>
                                    <input id={'nicknameInput'} type="text" className={'form-control'} value={musician.nickname} onChange={e=>setMusician({...musician,nickname: e.target.value})}/>
                                </div>
                                <div className={'m-3'}>
                                    <label htmlFor="groupsSelect" className={'mb-3'}>Группа</label>
                                    <select id={'groupsSelect'} name="groups" className={'form-select'}
                                            value={musician.musicGroupId}
                                            onChange={e=>setMusician({...musician,musicGroupId: Number.parseInt(e.target.value)})}>
                                        {groups.map(group => <option value={group.id} key={group.id}>{group.name}</option>)}
                                    </select>
                                </div>
                                <div className={'m-3 d-flex justify-content-center'}>
                                    {editLoading
                                        ?<Loader/>
                                        :<button className={'btn btn-warning'}>Изменить</button>
                                    }
                                </div>
                            </form>
                        </div>
                    }
                </div>
            </div>
        </div>
    );
};

export default MusicianId;