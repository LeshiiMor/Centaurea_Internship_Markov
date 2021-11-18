import React from 'react';
import classes from './Musician.module.css'
import MusicianService from "../../../Service/API/MusicianService";
import UseService from "../../../Hooks/useService";
import {useHistory} from 'react-router-dom'

const MusicianTable = ({musicians,setMusician}) => {
    const history = useHistory()
    const [deleteLoading,delMusican] = UseService(async (id)=>{
        let musService = new MusicianService()
        return await musService.Delete(id)
    })
    if(musicians.length === 0 ){
        return <h1 className={'text-center m-5'}>Пусто</h1>
    }
    function EditMusician(id)
    {
        history.push(`/admin/musicians/${id}`)
    }
    async function RemoveFunction(event,id)
    {
        let response = await delMusican(id)
        if(response.status ===200) {
            setMusician(musicians.filter(p => p.id !== id))
            alert('Удалено')
        }
        else if(response.status === 404)
        {
            alert('Музыкант не найден')
            setMusician(musicians.filter(p => p.id !== id))
        }
        else if(response.status === 400)
        {
            alert('bar request')
        }
    }
    return (

            <table className={"table"}>
                <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Имя</th>
                    <th scope="col">Фамилия</th>
                    <th scope="col">Nickname</th>
                    <th scope="col">Группа</th>
                </tr>
                </thead>
                <tbody>
                    {musicians.map(musician =>
                            <tr key={musician.id}>
                                <th scope="row">{musician.id}</th>
                                <td>{musician.name}</td>
                                <td>{musician.surname}</td>
                                <td>{musician.nickname}</td>
                                <td>{musician.nameGroup? musician.nameGroup : '-'}</td>
                                <td>
                                    <button className={classes.btnTables} value={musician.id} onClick={(event)=>{RemoveFunction(event,musician.id)}}>
                                        <i className="material-icons">delete</i>
                                    </button>
                                    <button className={classes.btnTables} value={musician.id} onClick={(event)=>{EditMusician(musician.id)}}>
                                        <span className="material-icons">edit</span>
                                    </button>
                                </td>
                            </tr>
                        )}
                </tbody>
            </table>
    );
};

export default MusicianTable;