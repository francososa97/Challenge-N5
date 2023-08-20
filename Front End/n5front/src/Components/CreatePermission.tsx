import React,{useEffect,useContext} from 'react';
import Backdrop from '@mui/material/Backdrop';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Fade from '@mui/material/Fade';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import FormControl from '@mui/material/FormControl';
import Grid from '@mui/material/Grid';
import { postPermisosService } from '../Services/PostPermisosService.tsx';
import SelectTypePermission from './SelectTypePermission.tsx';

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

const CreatePermission = () => {

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const [age, setAge] = React.useState('');
  const [nombreEmpleado, setNombreEmpleado] = React.useState('');
  const [apellidoEmpleado, setApellidoEmpleado] = React.useState('');
  const [datePermission, setDatePermission] = React.useState('');
  const [typePermission, setTypePermission] = React.useState('');
  const [callServices, setCallServices] = React.useState('false');


  const BuildPermission = () => {
      return {nombreEmpleado,apellidoEmpleado,datePermission,typePermission}
  }
  
  useEffect(() => {
      //Validar que el build se creo correctamente
      const CreatePermission = async (newPermission: Permiso) => {
        try {
          const response = await postPermisosService.PostPermisos(newPermission);
          console.log('response', response );
        } catch (error) {
          console.error('Error fetching permisos:', error);
        }
      };
      let newPermission = BuildPermission();
      CreatePermission(newPermission);
    }, [callServices]);

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
      <Button onClick={handleOpen}>Create permission</Button>
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
              Create permission
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
                  defaultValue={nombreEmpleado}
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
                  defaultValue={apellidoEmpleado}
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
                  defaultValue={datePermission}
                  onChange={(e) => setDatePermission(e.target.value)}
                />
              </Grid>
              <Grid item xs={12} sm={6}>

                  <SelectTypePermission typeOfPermission={typePermission} setTypePermission={setTypePermission} />

              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Create permission
            </Button>
          </Box>
            </FormControl>
          </Box>
        </Fade>
      </Modal>
    </div>
  );
}
export default CreatePermission;