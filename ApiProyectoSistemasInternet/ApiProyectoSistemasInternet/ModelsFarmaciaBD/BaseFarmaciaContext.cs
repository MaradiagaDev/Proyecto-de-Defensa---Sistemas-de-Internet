using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class BaseFarmaciaContext : DbContext
    {
        public BaseFarmaciaContext()
        {
        }

        public BaseFarmaciaContext(DbContextOptions<BaseFarmaciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<ClienteNatural> ClienteNaturals { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; } = null!;
        public virtual DbSet<DevolucionCompra> DevolucionCompras { get; set; } = null!;
        public virtual DbSet<DevolucionVentum> DevolucionVenta { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Presentacion> Presentacions { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorTrabajador> ProveedorTrabajadors { get; set; } = null!;
        public virtual DbSet<Recibo> Recibos { get; set; } = null!;
        public virtual DbSet<Rubro> Rubros { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<Transaccion> Transaccions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GKTE05O\\SQLEXPRESS;Database=BaseFarmacia;UID=sa;PWD=123456;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10A128C786");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteNatural>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__ClienteN__D5946642B71549C8");

                entity.ToTable("ClienteNatural");

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__0A5CDB5C50CFFADF");

                entity.ToTable("Compra");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nfactura).HasColumnName("NFactura");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__DetalleC__E046CCBBD842D652");

                entity.ToTable("DetalleCompra");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<DevolucionCompra>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionCompra)
                    .HasName("PK__Devoluci__CA3D4B17652E8264");

                entity.ToTable("DevolucionCompra");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MotivoDevolucion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ndevolucion).HasColumnName("NDevolucion");
            });

            modelBuilder.Entity<DevolucionVentum>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionVenta)
                    .HasName("PK__Devoluci__9E78BF10A5A28450");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MotivoDevolucion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ndevolucion).HasColumnName("NDevolucion");

                entity.Property(e => e.Nrecibo).HasColumnName("NRecibo");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9E84B943D5");

                entity.ToTable("Empleado");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.LoginUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__C95634AF8816DA8C");

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Presentacion>(entity =>
            {
                entity.HasKey(e => e.IdPresentacion)
                    .HasName("PK__Presenta__6175A1CDFAC5E0C4");

                entity.ToTable("Presentacion");

                entity.Property(e => e.EstadoPresentacion).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210D7832BCC");

                entity.ToTable("Producto");

                entity.Property(e => e.Concentracion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFabricacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.MargenGanancias).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NombreProducto).HasMaxLength(100);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnidadMedida)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AF73A5C053");

                entity.ToTable("Proveedor");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimoPedido).HasColumnType("datetime");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.NombreCompania).HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProveedorTrabajador>(entity =>
            {
                entity.HasKey(e => e.IdTrabajador)
                    .HasName("PK__Proveedo__6FAFBCF048222164");

                entity.ToTable("ProveedorTrabajador");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionTrabajador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoTrabajador)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Recibo>(entity =>
            {
                entity.HasKey(e => e.Nrecibo)
                    .HasName("PK__Recibo__B4C2EEE9558DFEF7");

                entity.ToTable("Recibo");

                entity.Property(e => e.Nrecibo).HasColumnName("NRecibo");

                entity.Property(e => e.CostoProducto).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.HasKey(e => e.IdRubro)
                    .HasName("PK__Rubro__5355E1C147028324");

                entity.ToTable("Rubro");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PK__TipoProd__A974F920B5FF7D36");

                entity.ToTable("TipoProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion)
                    .HasName("PK__Transacc__334B1F77917F1D61");

                entity.ToTable("Transaccion");

                entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF978049AB92");

                entity.ToTable("Usuario");

                entity.Property(e => e.Rol)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__BC1240BD71C876D4");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Nrecibo).HasColumnName("NRecibo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
