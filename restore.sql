create table admin_login(
    id_admin int IDENTITY(1,1) not null,
    nombre_admin VARCHAR(250),
    email VARCHAR(250),
    pass varchar(250),
    rol int,

    CONSTRAINT pk_ad PRIMARY KEY(id_admin),
    CONSTRAINT uq_email UNIQUE(email),
)


create table paciente(
    id_paciente int IDENTITY (1,1)  not null,
    primer_nombre varchar(50),
    segundo_nombre varchar(50),
    primer_apellido varchar(50),
    segundo_apellido varchar(50),
    apellido_casada varchar(50),
    genero char(1),
    fecha_nacimiento date,
    no_id varchar(50),
    tipo_encargado varchar(50),
    nombre_encargado varchar(50),
    numero_tel varchar(20),
    id_admin int,

    CONSTRAINT pk_pa PRIMARY KEY(id_paciente),
    CONSTRAINT fk_ad FOREIGN KEY(id_admin) REFERENCES admin_login(id_admin) ON DELETE CASCADE,
)


create table cita(

    id_cita int IDENTITY (1,1) not null,
    id_paciente int,
    estado varchar(20),
    fecha_inicio DATETIME,
    fecha_final DATETIME,

    CONSTRAINT pk_ci PRIMARY KEY(id_cita),
    CONSTRAINT fk_pa FOREIGN KEY(id_paciente) REFERENCES paciente(id_paciente) ON DELETE CASCADE
)

create table doctor(
    id_doctor int IDENTITY(1,1) not null,
    no_colegiado varchar(250),
    nombre varchar(350),

    CONSTRAINT pk_doc PRIMARY KEY(id_doctor)
)

CREATE table enfermera(
    id_enfermera int IDENTITY(1,1) not null,
    nombre varchar(350),
    estado char(1),

    CONSTRAINT pk_enf PRIMARY KEY(id_enfermera)
)

create table expediente(
    id_expediente int IDENTITY(1,1) not null,
    fecha_gen date,
    id_paciente int,
    estado int,
    CONSTRAINT pk_exp PRIMARY KEY(id_expediente),
    CONSTRAINT fk_pac FOREIGN KEY(id_paciente) REFERENCES paciente(id_paciente) ON DELETE CASCADE,
)

CREATE table consulta(
    id_consulta int IDENTITY(1,1),
    id_doctor int,
    asunto varchar(450),
    monto_caja FLOAT,
    fecha datetime,
    tipo_consulta varchar(100),
    id_expediente int,
    seguro_medico int,
    nombre_compania varchar(500),
    poliza_seguro varchar(250),
    relacion varchar(50),

    CONSTRAINT pk_con PRIMARY KEY(id_consulta),
    CONSTRAINT fk_doc FOREIGN KEY(id_doctor) REFERENCES doctor(id_doctor) ON DELETE CASCADE,
    CONSTRAINT fk_exp FOREIGN KEY(id_expediente) REFERENCES expediente(id_expediente) ON DELETE CASCADE,
)

create table signos(
    id_medicion int IDENTITY(1,1) not null, 
    estatura FLOAT,
    peso FLOAT,
    temp FLOAT,
    pulso FLOAT,
    presion_art FLOAT,
    frec_cardiaca FLOAT,
    frec_respiratoria FLOAT,
    id_enfermera int,
    fecha date,
    id_consulta int,
    
    CONSTRAINT pk_sig PRIMARY KEY(id_medicion),
    CONSTRAINT fk_enf FOREIGN KEY(id_enfermera) REFERENCES enfermera(id_enfermera) ON DELETE CASCADE,
    CONSTRAINT fk_con FOREIGN KEY(id_consulta) REFERENCES consulta(id_consulta) ON DELETE CASCADE,
)

CREATE TABLE diagnostico(
    id_diagnostico int IDENTITY(1,1) not null,
    id_cie VARCHAR(250),
    id_consulta int,
    
    CONSTRAINT pk_diag PRIMARY KEY(id_diagnostico),
    CONSTRAINT fk_consuk FOREIGN KEY (id_consulta) REFERENCES consulta(id_consulta) ON DELETE CASCADE,
)

create table orden_lab(
    id_orden int IDENTITY(1,1) not null,
    nombre_examen VARCHAR(250),
    id_consulta int,
    CONSTRAINT pk_lab PRIMARY KEY(id_orden),
    CONSTRAINT fk_cons FOREIGN KEY(id_consulta) REFERENCES consulta(id_consulta) ON DELETE CASCADE,
)

create table factura(
    num_factura int IDENTITY(1,1) not null,
    fecha date,
    id_expediente int,
    
    CONSTRAINT pk_num PRIMARY KEY(num_factura),
    CONSTRAINT fk_expd FOREIGN KEY(id_expediente) REFERENCES expediente(id_expediente) ON DELETE CASCADE,
)

create table detalle_fac(
    num_detalle int IDENTITY(1,1) not null,
    num_factura int,
    nombre_consulta varchar(250),
    cantidad int,
    precio FLOAT

    CONSTRAINT pk_det PRIMARY KEY(num_detalle),
    CONSTRAINT fk_num FOREIGN KEY(num_factura) REFERENCES factura(num_factura) ON DELETE CASCADE,
)

CREATE table receta(
    id_receta int IDENTITY(1,1) not null,
    id_consulta int,

    CONSTRAINT pk_rese PRIMARY KEY(id_receta),
    CONSTRAINT fk_consulta FOREIGN KEY(id_consulta) REFERENCES consulta(id_consulta) ON DELETE CASCADE,
)

create table des_receta(
    id_descripcion int IDENTITY(1,1) not null,
    id_receta int,
    medicamento varchar(250),
    cantidad float,
    dosis varchar(250),

    CONSTRAINT pk_des PRIMARY KEY(id_descripcion),
    CONSTRAINT fk_reset FOREIGN KEY(id_receta) REFERENCES receta(id_receta) ON DELETE CASCADE,
)

 