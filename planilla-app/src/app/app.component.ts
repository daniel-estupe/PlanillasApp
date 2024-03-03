import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmpleadosService } from './services/empleados.service';
import { EmpleadoResource } from './models/empleado.model';
import { CommonModule, NgFor, NgForOf } from '@angular/common';
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NuevoEmpleadoComponent } from './components/nuevo-empleado/nuevo-empleado.component';
import { VerRegistroComponent } from './components/ver-registro/ver-registro.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HttpClientModule, NgbModule],
  providers: [EmpleadosService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'planilla-app';
  empleados: EmpleadoResource[] = [];

  constructor(private empleadosService: EmpleadosService, private readonly modalService: NgbModal) {}

  ngOnInit(): void {
    this.empleadosService.obtenerEmpleados().subscribe((resp) => {
      this.empleados = resp;
    })
  }

  crearRegistroEmpleado() {
    const ref = this.modalService.open(NuevoEmpleadoComponent, {
      size: 'lg',
      backdrop: 'static'
    })
    ref.closed.subscribe((empleado) => {
      this.empleados.push(empleado);
    })
  }

  verRegistro(empleado: EmpleadoResource) {
    const ref = this.modalService.open(VerRegistroComponent, {
      size: 'lg',
      backdrop: 'static'
    })
    ref.componentInstance.obtenerEmpleado(empleado.id);
    ref.closed.subscribe((item: EmpleadoResource) => {
      let index = this.empleados.findIndex(e => e.id === item.id);
      this.empleados[index] = {...item};
    })
  }
}
