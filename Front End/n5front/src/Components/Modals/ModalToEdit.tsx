import React,{useEffect} from 'react';
import Backdrop from '@mui/material/Backdrop';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Fade from '@mui/material/Fade';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import FormControl from '@mui/material/FormControl';
import Grid from '@mui/material/Grid';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import { putPermisosService } from '../../Services/PutlPermisosService.tsx';
import { Permiso } from '../../sheared/Permiso.tsx';
import SelectTypePermission from '../Forms/SelectTypePermission.tsx';
import Datepicker from '../Forms/Datepicker.tsx';
import ErrorList from '../Forms/ErrorList.tsx';
import Swal from 'sweetalert2'

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
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const [nombreEmpleado, setNombreEmpleado] = React.useState(permiso.nombreEmpleado);
    const [apellidoEmpleado, setApellidoEmpleado] = React.useState(permiso.apellidoEmpleado);
    const [datePermission, setDatePermission] = React.useState(permiso.fechaPermiso);
    const [typePermission, setTypePermission] = React.useState(permiso.tipoPermiso);
    const [callServices, setCallServices] = React.useState(false);
    const [errors, setErrors] = React.useState<string[]>([]);
    const [disableCreate, setDisableCreate] = React.useState(true);
  
    useEffect(() => {
      let isOkAbiableBtn = nombreEmpleado !== permiso.nombreEmpleado 
                          || apellidoEmpleado !== permiso.apellidoEmpleado 
                          || datePermission !== permiso.fechaPermiso 
                          || typePermission !== permiso.tipoPermiso;

      if(isOkAbiableBtn)
        setDisableCreate(false)
  
    }, [nombreEmpleado,apellidoEmpleado,datePermission,typePermission])

    //To do Agregar sweet alerts
    // To do refactorizar
    // To do Limpiar
    const BuildPermission = () => {
        return {id:permiso.id,nombreEmpleado,apellidoEmpleado,"FechaPermiso":datePermission,"TipoPermiso":typePermission}
    }

    const EditPermission = async (Id:Int16Array , newPermission: Permiso) => {
      try {
        const response = await putPermisosService.PutPermisos(Id,newPermission);
        Swal.fire(
          'Successful!',
          'successful edition!',
          'success'
        )
      } catch (error) {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'an error occurred while editing the permission!',
        })
      }
    };

    const validateDate = () => {
    //  To do agregar validaciones.
    debugger;
      let isOkValidate = true;
      if(nombreEmpleado === "")
      {
        let newErrors = [...errors,'Employee name is empty'];
        setErrors(newErrors);
        isOkValidate = false;
      }
      if(apellidoEmpleado === "")
      {
        let newErrors = [...errors,'the employee last name is empty'];
        setErrors(newErrors);
        isOkValidate = false;
      }
      if(datePermission === "")
      {
        let newErrors = [...errors,'The name employ is empty'];
        setErrors(newErrors);
        isOkValidate = false;
      }
      if(typePermission === "")
      {
        let newErrors = [...errors,'permission date is wrong'];
        setErrors(newErrors);
        isOkValidate = false;
      }
      //Validar que cambiamos algo si no dar el aviso
      return isOkValidate;
  }

    const HandleSubmit = () =>
    {
      setErrors([])
      if(validateDate())
      {
         let newPermission = BuildPermission();
         EditPermission(permiso.id,newPermission);
      }
    }


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
            {errors.length > 0 ? <ErrorList errors={errors}/> :null}
            <FormControl fullWidth>
            <Box component="form" noValidate onSubmit={() => HandleSubmit()} sx={{ mt: 3 }}>
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
                <Datepicker datePermission={datePermission}  setDatePermission={setDatePermission}/>
              </Grid>
              <Grid item xs={12} sm={6}>
                  <SelectTypePermission typePermission={typePermission} setTypePermission={setTypePermission} />
              </Grid>
            </Grid>
            <Grid item xs={12} sm={12}>
              <Button variant="text" onClick={()=>handleClose()}>Close</Button>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              onClick={ () => setCallServices(true)}
              disabled={disableCreate}
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