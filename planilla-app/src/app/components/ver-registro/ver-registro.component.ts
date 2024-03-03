import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CatalogosService } from '../../services/catalogos.service';
import { EmpleadosService } from '../../services/empleados.service';
import { AreaResource, ContratoResultType, EmpleadoResource, PuestoResource } from '../../models/empleado.model';
import { Alert } from '../nuevo-empleado/nuevo-empleado.component';
import { catchError, of, tap } from 'rxjs';

@Component({
  selector: 'app-ver-registro',
  standalone: true,
  imports: [NgbModule, CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [CatalogosService, EmpleadosService],
  templateUrl: './ver-registro.component.html',
  styleUrl: './ver-registro.component.scss'
})
export class VerRegistroComponent {
  areas: AreaResource[] = [];
  areaSeleccionada: string | null = null;
  puestoSeleccionado: string | null = null;
  empleado: EmpleadoResource | null = null;
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

  obtenerEmpleado(empleadoId: number) {
    this.empleadosService.obtenerEmpleado(empleadoId).subscribe(item => {
      this.empleado = item;
      if (item.contratos.length > 0) {
        let contrato = item.contratos[item.contratos.length-1];
        this.areaSeleccionada = contrato.puesto.area.descripcion;
        this.puestoSeleccionado = contrato.puesto.descripcion;
        this.form.patchValue({
          apellidos: item.apellidos,
          bonificacion: contrato.bonificacion,
          cui: item.cui,
          estadoCivil: item.estadoCivil,
          fechaEmisionIrtra: !!item.fechaAfiliacionIRTRA ? item.fechaAfiliacionIRTRA.split('T')[0] : null,
          fechaInicioContrato: contrato.fechaInicio.split('T')[0],
          fechaFinContrato: !!contrato.fechaFinalizacion ? contrato.fechaFinalizacion.split('T')[0]: null,
          fechaNacimiento: item.fechaNacimiento.split('T')[0],
          genero: item.genero,
          igss: item.afiliacionIGSS,
          irtra: item.afiliacionIRTRA,
          nit: item.nit,
          nombres: item.nombres,
          pasaporte: item.pasaporte,
          salarioBase: contrato.salarioBase
        })
      }
      

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
    this.empleadosService.editarEmpleado({
      id: this.empleado?.id!,
      afiliacionIGSS: item.igss!,
      afiliacionIRTRA: item.irtra!,
      apellidos: item.apellidos!,
      cUI: item.cui!,
      estadoCivil: item.estadoCivil!,
      fechaAfiliacionIRTRA: item.fechaEmisionIrtra!,
      fechaNacimiento: item.fechaNacimiento!,
      genero: item.genero!,
      nIT: item.nit!,
      nombres: item.nombres!,
      pasaporte: item.pasaporte!,
      contrato: {
        bonificacion: item.bonificacion!,
        salarioBase: item.salarioBase!,
        fechaInicio: item.fechaInicioContrato!,
        fechaFinalizacion: item.fechaFinContrato!,
        id: this.empleado?.contratos[this.empleado?.contratos.length-1].id!
      }
    }).pipe(
      catchError(() => {
        this.alertas.push({ type: 'danger', message: "Ha ocurrido un error al enviar la petición." });
        return of(null)
      }),
      tap(() => {
        this.guardando = false;
      })
    ).subscribe((resp) => {
      if (resp === null) return;

      if (resp.codigo != ContratoResultType.Success) {
        this.alertas.push({ type: 'danger', message: resp.mensaje });
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
      fechaNacimiento: [<string | null>null, Validators.required],
      cui: ['', [Validators.required, Validators.maxLength(13)]],
      nit: ['', [Validators.required, Validators.maxLength(13)]],
      pasaporte: ['', [Validators.maxLength(20)]],
      igss: ['', [Validators.maxLength(20)]],
      irtra: ['', [Validators.maxLength(20)]],
      fechaEmisionIrtra: [<string | null>null],
      fechaInicioContrato: [<string | null>null, [Validators.required]],
      fechaFinContrato: [<string | null>null],
      salarioBase: [0, Validators.required],
      bonificacion: [0, Validators.required]
    })
  }
}
