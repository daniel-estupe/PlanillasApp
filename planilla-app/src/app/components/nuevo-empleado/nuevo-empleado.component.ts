import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AreaResource, ContratoResultType, PuestoResource } from '../../models/empleado.model';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CatalogosService } from '../../services/catalogos.service';
import { EmpleadosService } from '../../services/empleados.service';
import { catchError, of, tap } from 'rxjs';

interface Alert {
	type: string;
	message: string;
}

@Component({
  selector: 'app-nuevo-empleado',
  standalone: true,
  imports: [NgbModule, CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [CatalogosService, EmpleadosService],
  templateUrl: './nuevo-empleado.component.html',
  styleUrl: './nuevo-empleado.component.scss'
})
export class NuevoEmpleadoComponent implements OnInit {
  areas: AreaResource[] = [];
  areaSeleccionada: AreaResource | null = null;
  puestoSeleccionado: PuestoResource | null = null;
  form = this.createForm();
  frmEnviado = false;
  generos: string[] = ['Masculino', 'Femenino', 'Otro'];
  estadoCivilListado: string[] = ['Soltero', 'Casado', 'Divorciado', 'Otro'];
  alertas: Alert[] = [];
  guardando = false;

  constructor(public activeModal: NgbActiveModal,
    private readonly catalogosService: CatalogosService,
    private readonly empleadosService: EmpleadosService,
    private readonly fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.catalogosService.obtenerAreasConPuestosDisponibles().subscribe(resp => {
      this.areas = resp;
    })
  }

  get frm() {
    return this.form.controls;
  }

  guardarFormulario() {
    this.frmEnviado = true;
    if (this.form.invalid) return;
    let item = this.form.value;
    this.guardando = true;
    this.empleadosService.crearEmpleado({
      afiliacionIGSS: item.igss!,
      afiliacionIRTRA: item.irtra!,
      apellidos: item.apellidos!,
      bonificacion: item.bonificacion!,
      cUI: item.cui!,
      estadoCivil: item.estadoCivil!,
      fechaAfiliacionIRTRA: item.fechaEmisionIrtra!,
      fechaInicioContrato: item.fechaInicioContrato!,
      fechaNacimiento: item.fechaNacimiento!,
      genero: item.genero!,
      nIT: item.nit!,
      nombres: item.nombres!,
      pasaporte: item.pasaporte!,
      puestoId: this.puestoSeleccionado?.id!,
      salarioBase: item.salarioBase!,
    }).pipe(
      catchError(() => {
        this.alertas.push({type: 'danger', message: "Ha ocurrido un error al enviar la petición."});
        return of(null)
      }),
      tap(() => {
        this.guardando = false;
      })
    ).subscribe((resp) => {
      if (resp === null) return;
      
      if (resp.codigo != ContratoResultType.Success) {
        this.alertas.push({type: 'danger', message: resp.mensaje});
        return;
      }
      this.activeModal.close(resp.data);
    });
  }

  closeAlert(alert: Alert) {
    this.alertas.splice(this.alertas.indexOf(alert), 1);
  }

  private createForm() {
    return this.fb.group({
      nombres: ['', [Validators.required, Validators.maxLength(50)]],
      apellidos: ['', [Validators.required, Validators.maxLength(50)]],
      genero: ['', Validators.required],
      estadoCivil: ['', Validators.required],
      fechaNacimiento: [null, Validators.required],
      cui: ['', [Validators.required, Validators.maxLength(13)]],
      nit: ['', [Validators.required, Validators.maxLength(13)]],
      pasaporte: ['', [Validators.maxLength(20)]],
      igss: ['', [Validators.maxLength(20)]],
      irtra: ['', [Validators.maxLength(20)]],
      fechaEmisionIrtra: [null],
      fechaInicioContrato: [null, [Validators.required]],
      salarioBase: [0, Validators.required],
      bonificacion: [0, Validators.required]
    })
  }
}
