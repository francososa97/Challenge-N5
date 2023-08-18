import axios from 'axios';
import { Permiso } from '../sheared/Permiso';
import { Endpoints } from '../sheared/endpoints';

class GetAllPermisosService {
    getAllPermisos = async (): Promise<Permiso[]> => {
        try {
          const response = await axios.get<Permiso[]>(Endpoints.getAllPermisos);
          return response.data;
        } catch (error) {
          console.error('Error fetching permisos:', error);
          return [];
        }
      };
}


export const getAllPermisosService = new GetAllPermisosService();