import React,{useEffect,useState,useContext} from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { getAllPermisosService } from '../Services/GetAllPermisosService.tsx';
import { Permiso } from '../sheared/Permiso.tsx';
import ModalToEdit from  './Modals/ModalToEdit.tsx';
import ModalToView from  './Modals/ModalToView.tsx';
import { PermisionContext } from '../Context/PermisionContext.tsx';

interface Column {
  id: 'name' | 'apellido' | 'typepermis' | 'datepermis' | 'actions';
  label: string;
  minWidth?: number;
  align?: 'right';
  format?: (value: number) => string;
}

const columns: readonly Column[] = [
  { 
    id: 'name', 
    label: 'First Name',
    minWidth: 170 
  },
  { 
    id: 'apellido',
    label: 'Last name',
    minWidth: 100 
  },
  {
    id: 'typepermis',
    label: 'Type permissions',
    minWidth: 170,
    format: (value: number) => value.toLocaleString('en-US'),
  },
  {
    id: 'datepermis',
    label: 'Date Permisions',
    minWidth: 170,
    format: (value: number) => value.toLocaleString('en-US'),
  },
  {
    id: 'actions',
    label: 'Actions',
    minWidth: 170,
    format: (value: number) => value.toFixed(2),
  },
];

 const Tablepermissions = () => {

  const {typeOfPermission}  = useContext(PermisionContext);
  const [permisos, setPermisos] = useState<Permiso[]>([]);

  useEffect(() => {

    const GetPermisos = async () => {
      try {
        const response = await getAllPermisosService.getAllPermisos();
        setPermisos(response.results);
      } catch (error) {
        console.error('Error fetching permisos:', error);
      }
    };

    GetPermisos();

  }, [permisos]);
  
  return (
    <Paper style={{ margin: '10' }} sx={{ width: '100%', overflow: 'hidden' }}>
      <TableContainer sx={{ maxHeight: 440 }}>
        <Table stickyHeader aria-label="sticky table">
          <TableHead>
            <TableRow>
              {columns.map((column) => (
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth }}
                >
                  {column.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
          {
            permisos.length > 0 
            ? permisos.map((permiso,index )=> {
              return (
                  <>
                    <TableRow key={index} hover role="checkbox" tabIndex={-1}>
                      <TableCell>{permiso.nombreEmpleado}</TableCell>
                      <TableCell>{permiso.apellidoEmpleado}</TableCell>
                      <TableCell>{typeOfPermission[permiso.tipoPermiso]}</TableCell>
                      <TableCell>{permiso.fechaPermiso.toString()}</TableCell>
                      <TableCell>
                        <ModalToEdit permiso ={permiso}/>
                        <ModalToView permiso ={permiso}/>
                      </TableCell>
                    </TableRow>
                  </>
              );
            })
            :null
          }
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
  );
}

export default Tablepermissions;