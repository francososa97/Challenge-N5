import React from 'react';
import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';

function ChangeFormat(string) {
  var info = string.split('-');
  return info[2] + '/' + info[1] + '/' + info[0];
}

 const Datepicker = (props) => {
  
    const {disabled,datePermission,setDatePermission} = props;
    const [value, setValue] = React.useState<Dayjs | null>(dayjs(ChangeFormat(datePermission)));

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
        disabled={disabled}
        />
    </DemoContainer>
    </LocalizationProvider>
  );
}

export default Datepicker;