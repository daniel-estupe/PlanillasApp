import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AreaResource } from '../models/empleado.model';

@Injectable({
  providedIn: 'root'
})
export class CatalogosService {

  constructor(private http: HttpClient) { }

  obtenerAreasConPuestosDisponibles() {
    return this.http.get<AreaResource[]>('https://localhost:7210/api/catalogos/puestos-disponibles-por-area');
  }
}
