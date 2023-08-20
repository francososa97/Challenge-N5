import React,{useEffect,useState,useContext} from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { getAllPermisosService } from '../Services/GetAllPermisosService.tsx';
import { Permiso } from '../sheared/Permiso.js';
import ModalToEdit from  '../Components/ModalToEdit.tsx';
import ModalToView from  '../Components/ModalToView.tsx';
import { PermisionContext } from '../Context/PermisionContext.tsx';

interface Column {
  id: 'name' | 'apellido' | 'typepermis' | 'datepermis' | 'actions';
  label: string;
  minWidth?: number;
  align?: 'right';
  format?: (value: number) => string;
}

const columns: readonly Column[] = [
  { id: 'name', label: 'First Name', minWidth: 170 },
  { id: 'apellido', label: 'Last name', minWidth: 100 },
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

interface Data {
  name: string;
  code: string;
  population: number;
  size: number;
  density: number;
}

 const Tablepermissions = () => {


  const {typeOfPermission}  = useContext(PermisionContext);
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(10);
  const [permisos, setPermisos] = useState<Permiso[]>([]);

  useEffect(() => {
    const GetPermisos = async () => {
      try {
        const response = await getAllPermisosService.getAllPermisos();
        setPermisos(response);
      } catch (error) {
        console.error('Error fetching permisos:', error);
      }
    };
    GetPermisos();
  }, [permisos]);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

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
          {permisos.map((permiso,index )=> {
            return (
                <>
                  <TableRow hover role="checkbox" tabIndex={-1}>
                    <TableCell>{permiso.nombreEmpleado}</TableCell>
                    <TableCell>{permiso.apellidoEmpleado}</TableCell>
                    <TableCell>{typeOfPermission[permiso.tipoPermiso]}</TableCell>
                    <TableCell>{permiso.fechaPermiso.toString()}</TableCell>
                    <TableCell>
                      <ModalToEdit key={permiso.id} permiso ={permiso}/>
                      <ModalToView key={index} permiso ={permiso}/>
                    </TableCell>
                  </TableRow>
                </>
            );
          })}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component="div"
        count={permisos.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </Paper>
  );
}

export default Tablepermissions;