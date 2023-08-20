import React, {useEffect, useState} from 'react';
import Backdrop from '@mui/material/Backdrop';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Fade from '@mui/material/Fade';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';

import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import Grid from '@mui/material/Grid';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import { putPermisosService } from '../Services/PutlPermisosService.tsx';
import { Permiso } from '../sheared/Permiso.js';

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 800,
  height: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

 const ModalToEdit = (props) => {
  
    const {permiso} = props;
    const [open, setOpen] = React.useState(false);
    const [age, setAge] = React.useState('');

    const [nombreEmpleado, setNombreEmpleado] = React.useState('');
    const [apellidoEmpleado, setApellidoEmpleado] = React.useState('');
    const [datePermission, setDatePermission] = React.useState('');
    const [typePermission, setTypePermission] = React.useState('');
    const [callServices, setCallServices] = React.useState('false');


    const BuildPermission = () => {
        return {Id:permiso.Id,nombreEmpleado,apellidoEmpleado,datePermission,typePermission}
    }
    
    useEffect(() => {
        //Validar que el build se creo correctamente
        const EditPermission = async (Id:Int16Array , newPermission: Permiso) => {
          try {
            const response = await putPermisosService.PutPermisosService(Id,newPermission);
            console.log('response', response );
          } catch (error) {
            console.error('Error fetching permisos:', error);
          }
        };
        let newPermission = BuildPermission();
        EditPermission(permiso.Id,newPermission);
      }, [callServices]);

// To do refactorizar
//Limpiar
//agregar validaciones.

    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const handleChange = (event) => {
        setAge(event.target.value as string);
        setTypePermission(event.target.value);
    }

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      email: data.get('email'),
      password: data.get('password'),
    });
  };

  return (
    <div>
    <IconButton onClick={handleOpen} color="secondary" aria-label="add an alarm">
        <EditIcon />
    </IconButton>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        open={open}
        onClose={handleClose}
        closeAfterTransition
        slots={{ backdrop: Backdrop }}
        slotProps={{
          backdrop: {
            timeout: 500,
          },
        }}
      >
        <Fade in={open}>
          <Box sx={style}>
            <Typography id="transition-modal-title" variant="h6" component="h2">
              Edit permission
            </Typography>

            <FormControl fullWidth>
            <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  autoComplete="given-name"
                  name="firstName"
                  required
                  fullWidth
                  id="firstName"
                  label="First Name"
                  autoFocus
                  defaultValue={permiso.nombreEmpleado}
                  onChange={(e) => setNombreEmpleado(e.target.value)}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="lastName"
                  label="Last Name"
                  name="lastName"
                  autoComplete="family-name"
                  defaultValue={permiso.apellidoEmpleado}
                  onChange={(e) => setApellidoEmpleado(e.target.value)}
                  
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                  autoComplete="email"
                  defaultValue={permiso.fechaPermiso}
                  onChange={(e) => setDatePermission(e.target.value)}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <InputLabel id="demo-simple-select-label">Age</InputLabel>
                <Select
                  labelId="demo-simple-select-label"
                  id="demo-simple-select"
                  value={age}
                  label="Age"
                  onChange={handleChange}
                  defaultValue={permiso.tipoPermiso}
                >
                  <MenuItem value={10}>Ten</MenuItem>
                  <MenuItem value={20}>Twenty</MenuItem>
                  <MenuItem value={30}>Thirty</MenuItem>
                </Select>
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              onClick={ () => setCallServices("true")}
            >
              Edit permission
            </Button>
          </Box>
            </FormControl>
          </Box>
        </Fade>
      </Modal>
    </div>
  );
}

export default ModalToEdit;