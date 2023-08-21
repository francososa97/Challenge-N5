import * as React from 'react';
import Box from '@mui/material/Box';
import AlertError from './AlertError.tsx';

const ErrorList = (props) => {

    const {errors} = props;
    debugger;
  return (
    <Box sx={{ width: '100%' }}>
        { 
            errors.map((error,index) => <AlertError key={index} error={error}/> )
        }
    </Box>
  );
}
export default  ErrorList;