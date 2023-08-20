import React,{useEffect,useContext} from 'react';
import { PermisionContext } from '../Context/PermisionContext.tsx';
import MenuItem from '@mui/material/MenuItem';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import InputLabel from '@mui/material/InputLabel';

const SelectTypePermission = (props) => {

    const {typePermission,setTypePermission} = props;
    const {typeOfPermission}  = useContext(PermisionContext);

    return(
        <>
            <InputLabel id="demo-simple-select-label">Type of permission</InputLabel>
            <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={typePermission}
                label="Age"
                onChange={(e) => setTypePermission(e.target.value)}
            >
                {typeOfPermission.map(typep =><MenuItem value={typep}>{typep}</MenuItem>)}
            </Select>
        </>
    )
}

export default SelectTypePermission;