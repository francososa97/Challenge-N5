import React, {useEffect, useState} from 'react';
import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';

 const Datepicker = (props) => {
  
    const {datePermission,setDatePermission} = props;
    const [value, setValue] = React.useState<Dayjs | null>(dayjs(datePermission));

    const handleChangeDate = (newValue) => {
        setValue(newValue);
        const date = dayjs(newValue,"DD/MM/YYYY");
        setDatePermission(date.$d.toLocaleDateString());
    }

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
    <DemoContainer components={['DateField']}>
        <DateField 
        label="Basic date field"
        value={value}
        onChange={(newValue) => handleChangeDate(newValue)}
        />
    </DemoContainer>
    </LocalizationProvider>
  );
}

export default Datepicker;