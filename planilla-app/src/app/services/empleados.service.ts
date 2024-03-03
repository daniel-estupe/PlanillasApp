import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResult, ContratoResultType, EmpleadoResource, NuevoEmpleado } from '../models/empleado.model';

@Injectable({
  providedIn: 'root',
  
})
export class EmpleadosService {

  constructor(private http: HttpClient) { }

  obtenerEmpleados() {
    return this.http.get<EmpleadoResource[]>('https://localhost:7210/api/empleados');
  }

  crearEmpleado(empleado: NuevoEmpleado) {
    console.log(empleado);
    return this.http.post<ApiResult<ContratoResultType, EmpleadoResource>>("https://localhost:7210/api/empleados", empleado);
  }
}
