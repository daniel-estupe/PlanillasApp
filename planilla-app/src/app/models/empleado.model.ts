export interface EmpleadoResource {
    id: number;
    nombres: string;
    apellidos: string;
    genero: string;
    estadoCivil: string;
    fechaNacimiento: string;
    cUI: string;
    nIT: string;
    pasaporte: string | null;
    afiliacionIGSS: string | null;
    afiliacionIRTRA: string | null;
    fechaAfiliacionIRTRA: string | null;
    contratos: ContratoResource[];
}

export interface ContratoResource {
    id: number;
    fechaInicio: string;
    fechaFinalizacion: string | null;
    salarioBase: number;
    bonificacion: number;
    puesto: PuestoResource;
}

export interface PuestoResource {
    id: number;
    descripcion: string;
    area: AreaResource;
}

export interface AreaResource {
    id: number;
    descripcion: string;
    puestos: PuestoResource[];
}

export interface NuevoEmpleado {
    nombres: string;
    apellidos: string;
    genero: string;
    estadoCivil: string;
    fechaNacimiento: string;
    cUI: string;
    nIT: string;
    pasaporte: string | null;
    afiliacionIGSS: string | null;
    afiliacionIRTRA: string | null;
    fechaAfiliacionIRTRA?: string;
    fechaInicioContrato: string;
    puestoId: number;
    salarioBase: number;
    bonificacion: number;
}

export interface ApiResult<T, R> {
    codigo: T;
    mensaje: string;
    data: R | null;
}

export enum ContratoResultType {
    Success = 0,
    ExcedeTechoSalarial = 1,
    NoExistePlazaDisponible = 2
}

