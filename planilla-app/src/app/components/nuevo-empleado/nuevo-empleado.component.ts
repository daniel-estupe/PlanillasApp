import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AreaResource, PuestoResource } from '../../models/empleado.model';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CatalogosService } from '../../services/catalogos.service';

@Component({
  selector: 'app-nuevo-empleado',
  standalone: true,
  imports: [NgbModule, CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [CatalogosService],
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

  constructor(public activeModal: NgbActiveModal, 
    private readonly catalogosService: CatalogosService,
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
    console.log(this.form.value);
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
