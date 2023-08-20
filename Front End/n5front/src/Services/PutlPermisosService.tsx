import axios from 'axios';
import { Permiso } from '../sheared/Permiso';
import { Endpoints } from '../sheared/endpoints.tsx';

class PutPermisosService {
    PutPermisos = async (id: Int16Array ,permiso:Permiso): Promise<Permiso[]> => {
        try {
          console.log(Endpoints.putPermisos + id);
          console.log(permiso);
          debugger;
          const response = await axios.put<Permiso[]>(Endpoints.putPermisos + id, permiso);
          return response.data;
        } catch (error) {
          console.error('Error fetching permisos:', error);
          return [];
        }
      };
}

export const putPermisosService = new PutPermisosService();