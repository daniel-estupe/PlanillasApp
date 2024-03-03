import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmpleadoResource } from '../models/empleado.model';

@Injectable({
  providedIn: 'root',
  
})
export class EmpleadosService {

  constructor(private http: HttpClient) { }

  obtenerEmpleados() {
    return this.http.get<EmpleadoResource[]>('https://localhost:7210/api/empleados');
  }
}
