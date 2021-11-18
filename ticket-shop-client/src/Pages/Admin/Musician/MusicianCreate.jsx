import React, {useState} from 'react';
import classes from './Musician.module.css'
import UseService from "../../../Hooks/useService";
import MusicianService from "../../../Service/API/MusicianService";
import Loader from "../../../Components/UI/Loader/Loader";

const MusicianCreate = ({groups,loadMusicians}) => {
    const [isLoading,createdFunct] = UseService(async ()=>{
        let musServ = new MusicianService()
        let res = await musServ.Create(musician)
        return res
    })
    const [musician,setMusician] = useState({
        name:'',
        surname:'',
        nickname:'',
        musicGroupId:0,
        nameGroup:''
    })
    async function  OnSubmit(event)
    {
        event.preventDefault()
        let data = await createdFunct()
        if(data) {
            loadMusicians()
        }
    }
    function Change(event)
    {
        let id = event.target.value
        if(id!==-1) {
            setMusician({...musician, musicGroupId:Number.parseInt(id)})
        }
        else {
            setMusician({...musician,musicGroupId: 0})
        }
    }
    return (
        <div>
            <h1 className={'text-center mt-4 mb-2'}>Добавление исполнителя</h1>
            <form action="" onSubmit={OnSubmit} className={classes.formCreated}>
                <div className={'m-3'}>
                    <label htmlFor="name" className={'form-label'}>Имя</label>
                    <input type="text" id={'name'} className={'form-control'} value={musician.name} onChange={e=>setMusician({...musician,name:e.target.value})}/>
                </div>
                <div className={'m-3'}>
                    <label htmlFor="name" className={'form-label'}>Фамилия</label>
                    <input type="text" id={'name'} className={'form-control'} value={musician.surname} onChange={e=>setMusician({...musician,surname:e.target.value})}/>
                </div>
                <div className={'m-3'}>
                    <label htmlFor="name" className={'form-label'}>Псевдоним</label>
                    <input type="text" id={'name'} className={'form-control'} value={musician.nickname} onChange={e=>setMusician({...musician,nickname:e.target.value})}/>
                </div>
                <div className={'m-3'}>
                    <label htmlFor="musGroupSelect">Музыкальная группа</label>
                    <select name="musicgroup" id="musGroupSelect" className={'form-select'} onChange={Change}>
                        <option value="-1">Без группы</option>
                        {groups.map(group => <option value={group.id} key={group.id}>{group.name}</option>)}
                    </select>
                </div>
                <div className={'m-3 d-flex justify-content-center'}>
                    {isLoading?<Loader/>:<button className={'btn btn-success rounded-pill'}>Создать</button>}
                </div>
            </form>
        </div>
    );
};

export default MusicianCreate;