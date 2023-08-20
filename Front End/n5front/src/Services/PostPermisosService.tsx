import axios from 'axios';
import { Permiso } from '../sheared/Permiso';
import { Endpoints } from '../sheared/endpoints.tsx';

class PostPermisosService {
    PostPermisos = async (nuevoPermiso: Permiso): Promise<Permiso[]> => {
        try {
          const response = await axios.post<Permiso[]>(Endpoints.postPermisos, nuevoPermiso);
          return response.data;
        } catch (error) {
          console.error('Error fetching permisos:', error);
          return [];
        }
      };
}

export const postPermisosService = new PostPermisosService();