import React, {useState} from 'react';
import Backdrop from '@mui/material/Backdrop';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Fade from '@mui/material/Fade';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import FormControl from '@mui/material/FormControl';
import Grid from '@mui/material/Grid';
import IconButton from '@mui/material/IconButton';
import VisibilityIcon from '@mui/icons-material/Visibility';
import SelectTypePermission from '../Forms/SelectTypePermission.tsx';
import Button from '@mui/material/Button';
import Datepicker from '../Forms/Datepicker.tsx';


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

const ModalToView = (props) => {

  const {permiso} = props;
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <div>
        <IconButton onClick={handleOpen} color="secondary" aria-label="add an alarm">
            <VisibilityIcon />
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
              View permission
            </Typography>

            <FormControl fullWidth>
            <Box component="form" noValidate sx={{ mt: 3 }}>
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

                />
              </Grid>
              <Grid item xs={8} sm={6}>
                <Datepicker datePermission={permiso.fechaPermiso}/>
              </Grid>
              <Grid item xs={2} sm={6}>
                <SelectTypePermission typePermission={permiso.tipoPermiso}/>
              </Grid>
              <Grid item xs={12} sm={12}>
              <Button variant="text" onClick={()=>handleClose()}>Close</Button>
              </Grid>
            </Grid>
          </Box>
            </FormControl>
          </Box>
        </Fade>
      </Modal>
    </div>
  );
}
export default ModalToView;