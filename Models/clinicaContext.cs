using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinica.Models
{
    public partial class clinicaContext : DbContext
    {
        public clinicaContext()
        {
        }

        public clinicaContext(DbContextOptions<clinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogin { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<DesReceta> DesReceta { get; set; }
        public virtual DbSet<DetalleFac> DetalleFac { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Enfermera> Enfermera { get; set; }
        public virtual DbSet<Expediente> Expediente { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<OrdenLab> OrdenLab { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<Signos> Signos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=clinica;user id=sa;password=Naruto10;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("pk_ad");

                entity.ToTable("admin_login");

                entity.HasIndex(e => e.Email)
                    .HasName("uq_email")
                    .IsUnique();

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAdmin)
                    .HasColumnName("nombre_admin")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Rol).HasColumnName("rol");
            });

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("pk_ci");

                entity.ToTable("cita");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fecha_final")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("fk_pa");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("pk_con");

                entity.ToTable("consulta");

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.Property(e => e.Asunto)
                    .HasColumnName("asunto")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");

                entity.Property(e => e.MontoCaja).HasColumnName("monto_caja");

                entity.Property(e => e.NombreCompania)
                    .HasColumnName("nombre_compania")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PolizaSeguro)
                    .HasColumnName("poliza_seguro")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Relacion)
                    .HasColumnName("relacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeguroMedico).HasColumnName("seguro_medico");

                entity.Property(e => e.TipoConsulta)
                    .HasColumnName("tipo_consulta")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("fk_doc");

                entity.HasOne(d => d.IdExpedienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdExpediente)
                    .HasConstraintName("fk_exp");
            });

            modelBuilder.Entity<DesReceta>(entity =>
            {
                entity.HasKey(e => e.IdDescripcion)
                    .HasName("pk_des");

                entity.ToTable("des_receta");

                entity.Property(e => e.IdDescripcion).HasColumnName("id_descripcion");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Dosis)
                    .HasColumnName("dosis")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.Property(e => e.Medicamento)
                    .HasColumnName("medicamento")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.DesReceta)
                    .HasForeignKey(d => d.IdReceta)
                    .HasConstraintName("fk_reset");
            });

            modelBuilder.Entity<DetalleFac>(entity =>
            {
                entity.HasKey(e => e.NumDetalle)
                    .HasName("pk_det");

                entity.ToTable("detalle_fac");

                entity.Property(e => e.NumDetalle).HasColumnName("num_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.NombreConsulta)
                    .HasColumnName("nombre_consulta")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumFactura).HasColumnName("num_factura");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.NumFacturaNavigation)
                    .WithMany(p => p.DetalleFac)
                    .HasForeignKey(d => d.NumFactura)
                    .HasConstraintName("fk_num");
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostico)
                    .HasName("pk_diag");

                entity.ToTable("diagnostico");

                entity.Property(e => e.IdDiagnostico).HasColumnName("id_diagnostico");

                entity.Property(e => e.IdCie)
                    .HasColumnName("id_cie")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Diagnostico)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("fk_consul");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("pk_doc");

                entity.ToTable("doctor");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.NoColegiado)
                    .HasColumnName("no_colegiado")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enfermera>(entity =>
            {
                entity.HasKey(e => e.IdEnfermera)
                    .HasName("pk_enf");

                entity.ToTable("enfermera");

                entity.Property(e => e.IdEnfermera).HasColumnName("id_enfermera");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.IdExpediente)
                    .HasName("pk_exp");

                entity.ToTable("expediente");

                entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");

                entity.Property(e => e.FechaGen)
                    .HasColumnName("fecha_gen")
                    .HasColumnType("date");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Expediente)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("fk_pac");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.NumFactura)
                    .HasName("pk_num");

                entity.ToTable("factura");

                entity.Property(e => e.NumFactura).HasColumnName("num_factura");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");

                entity.HasOne(d => d.IdExpedienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdExpediente)
                    .HasConstraintName("fk_expd");
            });

            modelBuilder.Entity<OrdenLab>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("pk_lab");

                entity.ToTable("orden_lab");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.Property(e => e.NombreExamen)
                    .HasColumnName("nombre_examen")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.OrdenLab)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("fk_cons");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("pk_pa");

                entity.ToTable("paciente");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.ApellidoCasada)
                    .HasColumnName("apellido_casada")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.NoId)
                    .HasColumnName("no_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEncargado)
                    .HasColumnName("nombre_encargado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTel)
                    .HasColumnName("numero_tel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEncargado)
                    .HasColumnName("tipo_encargado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("fk_ad");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.IdReceta)
                    .HasName("pk_rese");

                entity.ToTable("receta");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("fk_consulta");
            });

            modelBuilder.Entity<Signos>(entity =>
            {
                entity.HasKey(e => e.IdMedicion)
                    .HasName("pk_sig");

                entity.ToTable("signos");

                entity.Property(e => e.IdMedicion).HasColumnName("id_medicion");

                entity.Property(e => e.Estatura).HasColumnName("estatura");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.FrecCardiaca).HasColumnName("frec_cardiaca");

                entity.Property(e => e.FrecRespiratoria).HasColumnName("frec_respiratoria");

                entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");

                entity.Property(e => e.IdEnfermera).HasColumnName("id_enfermera");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.PresionArt).HasColumnName("presion_art");

                entity.Property(e => e.Pulso).HasColumnName("pulso");

                entity.Property(e => e.Temp).HasColumnName("temp");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Signos)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("fk_con");

                entity.HasOne(d => d.IdEnfermeraNavigation)
                    .WithMany(p => p.Signos)
                    .HasForeignKey(d => d.IdEnfermera)
                    .HasConstraintName("fk_enf");
            });
        }
    }
}
