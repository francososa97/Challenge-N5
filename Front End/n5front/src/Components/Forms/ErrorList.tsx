import * as React from 'react';
import Box from '@mui/material/Box';
import AlertError from './AlertError.tsx';

const ErrorList = (props) => {

    const {errors} = props;

  return (
    <Box sx={{ width: '100%' }}>
        { 
            errors.map(error => <AlertError error={error}/> )
        }
    </Box>
  );
}
export default  ErrorList;