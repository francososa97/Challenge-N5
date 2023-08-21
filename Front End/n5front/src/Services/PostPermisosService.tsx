import axios from 'axios';
import { Permiso } from '../sheared/Permiso';
import { Endpoints } from '../sheared/endpoints.tsx';
import Swal from 'sweetalert2'

class PostPermisosService {
    PostPermisos = async (nuevoPermiso: Permiso): Promise<Permiso[]> => {
        try {
          await axios.post<Permiso[]>(Endpoints.postPermisos, nuevoPermiso)
          .then(response => {
            Swal.fire(
              'Successful!',
              'successful create permission!',
              'success'
            )
            return response.data
         })
          .catch(function (error) {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'an error occurred while create the permission!'+error,
            })
          });
        } catch (error) {
          console.error('Error fetching permisos:', error);
          return [];
        }
      };
}

export const postPermisosService = new PostPermisosService();