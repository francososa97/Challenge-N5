import React,{useContext} from 'react';
import { PermisionContext } from '../../Context/PermisionContext.tsx';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';

const SelectTypePermission = (props) => {

    const {typePermission,setTypePermission} = props;
    const typeOfPermission = useContext(PermisionContext);

    const handleChange = ( value ) => {
        const typePermissionId = typeOfPermission.indexOf(value) + 1;
        setTypePermission(typePermissionId)
    };

    return(
      <FormControl sx={{ minWidth: 160 }}>
        <InputLabel id="demo-simple-select-helper-label">Type permission</InputLabel>
            <Select
                labelId="demo-simple-select-helper-label"
                id="demo-simple-select-helper"
                value={typeOfPermission[typePermission]}
                label="Type permission"
                onChange={(e) => handleChange(e.target.value)}
            >
                {typeOfPermission.map(typep =><MenuItem value={typep}>{typep}</MenuItem>)}
            </Select>
        </FormControl>
    )
}

export default SelectTypePermission;