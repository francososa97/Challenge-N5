import React,{useEffect,useContext} from 'react';
import { PermisionContext } from '../Context/PermisionContext.tsx';
import MenuItem from '@mui/material/MenuItem';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';

const SelectTypePermission = (props) => {

    const {typePermission,setTypePermission} = props;
    const {typeOfPermission}  = useContext(PermisionContext);
    const typePermisionDefault =typeOfPermission[typePermission];
    return(
      <FormControl sx={{ minWidth: 160 }}>
        <InputLabel id="demo-simple-select-helper-label">Type permission</InputLabel>
            <Select
                labelId="demo-simple-select-helper-label"
                id="demo-simple-select-helper"
                value={typePermission}
                label="Type permission"
                onChange={(e) => setTypePermission(e.target.value)}
                defaultValue={typePermisionDefault}
            >
                {typeOfPermission.map(typep =><MenuItem value={typep}>{typep}</MenuItem>)}
            </Select>
        </FormControl>
    )
}

export default SelectTypePermission;