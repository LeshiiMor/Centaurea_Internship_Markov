import React, {useState} from 'react';
import classes from "./Musician.module.css";

const MusicianFiltr = ({musicGroups,loadMusician,...props}) => {
    const [visibleFilr,setVisibleFilr]= useState(false)
    function filtrBlock()
    {
        if(visibleFilr) setVisibleFilr(false)
        else setVisibleFilr(true)
    }
    function LoadByGroup()
    {
        let value = document.getElementById('groupSelect').value
        loadMusician(null,value)
    }
    return (
        <div className={classes.filtrBlock}>
            <button className={classes.btnFiltr} onClick={filtrBlock}>Фильтры</button>
            {visibleFilr &&
                <div>
                    <div className="m-2">
                        <label htmlFor={"groupSelect"} className={"form-label"}>Группа</label><br/>
                        <select id={'groupSelect'} className={'form-select'}>
                            <option value="0">Нет</option>
                            {musicGroups.map(group=> <option value={group.id} key={group.id}>{group.name}</option>)}
                        </select>
                    </div>
                    <button className={'btn btn-info'} onClick={LoadByGroup}>Показать</button>
                </div>
            }
        </div>
    );
};

export default MusicianFiltr;