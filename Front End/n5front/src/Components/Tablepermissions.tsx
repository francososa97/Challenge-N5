import React,{useEffect,useState} from 'react';
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

function createData(
  name: string,
  code: string,
  population: number,
  size: number,
): Data {
  const density = population / size;
  return { name, code, population, size};
}

const rows = [
  createData('India', 'IN', 1324171354, 3287263),
  createData('China', 'CN', 1403500365, 9596961),
  createData('Italy', 'IT', 60483973, 301340),
  createData('United States', 'US', 327167434, 9833520),
  createData('Canada', 'CA', 37602103, 9984670),
  createData('Australia', 'AU', 25475400, 7692024),
  createData('Germany', 'DE', 83019200, 357578),
  createData('Ireland', 'IE', 4857000, 70273),
  createData('Mexico', 'MX', 126577691, 1972550),
  createData('Japan', 'JP', 126317000, 377973),
  createData('France', 'FR', 67022000, 640679),
  createData('United Kingdom', 'GB', 67545757, 242495),
  createData('Russia', 'RU', 146793744, 17098246),
  createData('Nigeria', 'NG', 200962417, 923768),
  createData('Brazil', 'BR', 210147125, 8515767),
];

export default function Tablepermissions() {
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
          {permisos.map(permiso => {
            return (
                <>
                  <TableRow hover role="checkbox" tabIndex={-1}>
                    <TableCell>{permiso.nombreEmpleado}</TableCell>
                    <TableCell>{permiso.apellidoEmpleado}</TableCell>
                    <TableCell>{permiso.tipoPermiso}</TableCell>
                    <TableCell>{permiso.fechaPermiso.toString()}</TableCell>
                    <TableCell>
                        <IconButton color="secondary" aria-label="add an alarm">
                            <EditIcon />
                        </IconButton>
                        <IconButton color="primary" aria-label="add to shopping cart">
                            <VisibilityIcon />
                        </IconButton>
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
        count={rows.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </Paper>
  );
}