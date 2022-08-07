﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca_LINQ_SQL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BibliotecaApp")]
	public partial class DataLinqToSqlBibliotecaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertSala(Sala instance);
    partial void UpdateSala(Sala instance);
    partial void DeleteSala(Sala instance);
    partial void InsertLibro(Libro instance);
    partial void UpdateLibro(Libro instance);
    partial void DeleteLibro(Libro instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertTipoPersona(TipoPersona instance);
    partial void UpdateTipoPersona(TipoPersona instance);
    partial void DeleteTipoPersona(TipoPersona instance);
    #endregion
		
		public DataLinqToSqlBibliotecaDataContext() : 
				base(global::Biblioteca_LINQ_SQL.Properties.Settings.Default.BibliotecaLinqSql, mappingSource)
		{
			OnCreated();
		}
		
		public DataLinqToSqlBibliotecaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLinqToSqlBibliotecaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLinqToSqlBibliotecaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLinqToSqlBibliotecaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Sala> Sala
		{
			get
			{
				return this.GetTable<Sala>();
			}
		}
		
		public System.Data.Linq.Table<Libro> Libro
		{
			get
			{
				return this.GetTable<Libro>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<TipoPersona> TipoPersona
		{
			get
			{
				return this.GetTable<TipoPersona>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sala")]
	public partial class Sala : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDSala;
		
		private string _Sala1;
		
		private EntitySet<Libro> _Libro;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDSalaChanging(string value);
    partial void OnIDSalaChanged();
    partial void OnSala1Changing(string value);
    partial void OnSala1Changed();
    #endregion
		
		public Sala()
		{
			this._Libro = new EntitySet<Libro>(new Action<Libro>(this.attach_Libro), new Action<Libro>(this.detach_Libro));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDSala", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDSala
		{
			get
			{
				return this._IDSala;
			}
			set
			{
				if ((this._IDSala != value))
				{
					this.OnIDSalaChanging(value);
					this.SendPropertyChanging();
					this._IDSala = value;
					this.SendPropertyChanged("IDSala");
					this.OnIDSalaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Sala", Storage="_Sala1", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Sala1
		{
			get
			{
				return this._Sala1;
			}
			set
			{
				if ((this._Sala1 != value))
				{
					this.OnSala1Changing(value);
					this.SendPropertyChanging();
					this._Sala1 = value;
					this.SendPropertyChanged("Sala1");
					this.OnSala1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sala_Libro", Storage="_Libro", ThisKey="IDSala", OtherKey="ID_Sala")]
		public EntitySet<Libro> Libro
		{
			get
			{
				return this._Libro;
			}
			set
			{
				this._Libro.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Libro(Libro entity)
		{
			this.SendPropertyChanging();
			entity.Sala = this;
		}
		
		private void detach_Libro(Libro entity)
		{
			this.SendPropertyChanging();
			entity.Sala = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Libro")]
	public partial class Libro : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _IDLibro;
		
		private string _Titulo;
		
		private string _Ubicacion;
		
		private string _NumEdicion;
		
		private string _AñoEdicion;
		
		private byte _Volumen;
		
		private int _NumPaginas;
		
		private string _Observaciones;
		
		private string _ID_Sala;
		
		private string _ID_Categoria;
		
		private string _ID_Editorial;
		
		private EntityRef<Sala> _Sala;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDLibroChanging(string value);
    partial void OnIDLibroChanged();
    partial void OnTituloChanging(string value);
    partial void OnTituloChanged();
    partial void OnUbicacionChanging(string value);
    partial void OnUbicacionChanged();
    partial void OnNumEdicionChanging(string value);
    partial void OnNumEdicionChanged();
    partial void OnAñoEdicionChanging(string value);
    partial void OnAñoEdicionChanged();
    partial void OnVolumenChanging(byte value);
    partial void OnVolumenChanged();
    partial void OnNumPaginasChanging(int value);
    partial void OnNumPaginasChanged();
    partial void OnObservacionesChanging(string value);
    partial void OnObservacionesChanged();
    partial void OnID_SalaChanging(string value);
    partial void OnID_SalaChanged();
    partial void OnID_CategoriaChanging(string value);
    partial void OnID_CategoriaChanged();
    partial void OnID_EditorialChanging(string value);
    partial void OnID_EditorialChanged();
    #endregion
		
		public Libro()
		{
			this._Sala = default(EntityRef<Sala>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDLibro", DbType="VarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string IDLibro
		{
			get
			{
				return this._IDLibro;
			}
			set
			{
				if ((this._IDLibro != value))
				{
					this.OnIDLibroChanging(value);
					this.SendPropertyChanging();
					this._IDLibro = value;
					this.SendPropertyChanged("IDLibro");
					this.OnIDLibroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Titulo", DbType="NVarChar(130) NOT NULL", CanBeNull=false)]
		public string Titulo
		{
			get
			{
				return this._Titulo;
			}
			set
			{
				if ((this._Titulo != value))
				{
					this.OnTituloChanging(value);
					this.SendPropertyChanging();
					this._Titulo = value;
					this.SendPropertyChanged("Titulo");
					this.OnTituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ubicacion", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Ubicacion
		{
			get
			{
				return this._Ubicacion;
			}
			set
			{
				if ((this._Ubicacion != value))
				{
					this.OnUbicacionChanging(value);
					this.SendPropertyChanging();
					this._Ubicacion = value;
					this.SendPropertyChanged("Ubicacion");
					this.OnUbicacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumEdicion", DbType="VarChar(60) NOT NULL", CanBeNull=false)]
		public string NumEdicion
		{
			get
			{
				return this._NumEdicion;
			}
			set
			{
				if ((this._NumEdicion != value))
				{
					this.OnNumEdicionChanging(value);
					this.SendPropertyChanging();
					this._NumEdicion = value;
					this.SendPropertyChanged("NumEdicion");
					this.OnNumEdicionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AñoEdicion", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string AñoEdicion
		{
			get
			{
				return this._AñoEdicion;
			}
			set
			{
				if ((this._AñoEdicion != value))
				{
					this.OnAñoEdicionChanging(value);
					this.SendPropertyChanging();
					this._AñoEdicion = value;
					this.SendPropertyChanged("AñoEdicion");
					this.OnAñoEdicionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Volumen", DbType="TinyInt NOT NULL")]
		public byte Volumen
		{
			get
			{
				return this._Volumen;
			}
			set
			{
				if ((this._Volumen != value))
				{
					this.OnVolumenChanging(value);
					this.SendPropertyChanging();
					this._Volumen = value;
					this.SendPropertyChanged("Volumen");
					this.OnVolumenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumPaginas", DbType="Int NOT NULL")]
		public int NumPaginas
		{
			get
			{
				return this._NumPaginas;
			}
			set
			{
				if ((this._NumPaginas != value))
				{
					this.OnNumPaginasChanging(value);
					this.SendPropertyChanging();
					this._NumPaginas = value;
					this.SendPropertyChanged("NumPaginas");
					this.OnNumPaginasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Observaciones", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string Observaciones
		{
			get
			{
				return this._Observaciones;
			}
			set
			{
				if ((this._Observaciones != value))
				{
					this.OnObservacionesChanging(value);
					this.SendPropertyChanging();
					this._Observaciones = value;
					this.SendPropertyChanged("Observaciones");
					this.OnObservacionesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Sala", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ID_Sala
		{
			get
			{
				return this._ID_Sala;
			}
			set
			{
				if ((this._ID_Sala != value))
				{
					if (this._Sala.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_SalaChanging(value);
					this.SendPropertyChanging();
					this._ID_Sala = value;
					this.SendPropertyChanged("ID_Sala");
					this.OnID_SalaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Categoria", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ID_Categoria
		{
			get
			{
				return this._ID_Categoria;
			}
			set
			{
				if ((this._ID_Categoria != value))
				{
					this.OnID_CategoriaChanging(value);
					this.SendPropertyChanging();
					this._ID_Categoria = value;
					this.SendPropertyChanged("ID_Categoria");
					this.OnID_CategoriaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Editorial", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ID_Editorial
		{
			get
			{
				return this._ID_Editorial;
			}
			set
			{
				if ((this._ID_Editorial != value))
				{
					this.OnID_EditorialChanging(value);
					this.SendPropertyChanging();
					this._ID_Editorial = value;
					this.SendPropertyChanged("ID_Editorial");
					this.OnID_EditorialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sala_Libro", Storage="_Sala", ThisKey="ID_Sala", OtherKey="IDSala", IsForeignKey=true)]
		public Sala Sala
		{
			get
			{
				return this._Sala.Entity;
			}
			set
			{
				Sala previousValue = this._Sala.Entity;
				if (((previousValue != value) 
							|| (this._Sala.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Sala.Entity = null;
						previousValue.Libro.Remove(this);
					}
					this._Sala.Entity = value;
					if ((value != null))
					{
						value.Libro.Add(this);
						this._ID_Sala = value.IDSala;
					}
					else
					{
						this._ID_Sala = default(string);
					}
					this.SendPropertyChanged("Sala");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDUsuario;
		
		private string _Nombre;
		
		private string _A_Paterno;
		
		private string _A_Materno;
		
		private byte _Edad;
		
		private string _EscuelaProcedencia;
		
		private string _Ciudad;
		
		private string _Calle;
		
		private string _Telefono;
		
		private string _Email;
		
		private string _Observaciones;
		
		private int _ID_TipoPersona;
		
		private System.DateTime _FechaCreacion;
		
		private EntityRef<TipoPersona> _TipoPersona;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDUsuarioChanging(int value);
    partial void OnIDUsuarioChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnA_PaternoChanging(string value);
    partial void OnA_PaternoChanged();
    partial void OnA_MaternoChanging(string value);
    partial void OnA_MaternoChanged();
    partial void OnEdadChanging(byte value);
    partial void OnEdadChanged();
    partial void OnEscuelaProcedenciaChanging(string value);
    partial void OnEscuelaProcedenciaChanged();
    partial void OnCiudadChanging(string value);
    partial void OnCiudadChanged();
    partial void OnCalleChanging(string value);
    partial void OnCalleChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnObservacionesChanging(string value);
    partial void OnObservacionesChanged();
    partial void OnID_TipoPersonaChanging(int value);
    partial void OnID_TipoPersonaChanged();
    partial void OnFechaCreacionChanging(System.DateTime value);
    partial void OnFechaCreacionChanged();
    #endregion
		
		public Usuario()
		{
			this._TipoPersona = default(EntityRef<TipoPersona>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDUsuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDUsuario
		{
			get
			{
				return this._IDUsuario;
			}
			set
			{
				if ((this._IDUsuario != value))
				{
					this.OnIDUsuarioChanging(value);
					this.SendPropertyChanging();
					this._IDUsuario = value;
					this.SendPropertyChanged("IDUsuario");
					this.OnIDUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_A_Paterno", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string A_Paterno
		{
			get
			{
				return this._A_Paterno;
			}
			set
			{
				if ((this._A_Paterno != value))
				{
					this.OnA_PaternoChanging(value);
					this.SendPropertyChanging();
					this._A_Paterno = value;
					this.SendPropertyChanged("A_Paterno");
					this.OnA_PaternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_A_Materno", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string A_Materno
		{
			get
			{
				return this._A_Materno;
			}
			set
			{
				if ((this._A_Materno != value))
				{
					this.OnA_MaternoChanging(value);
					this.SendPropertyChanging();
					this._A_Materno = value;
					this.SendPropertyChanged("A_Materno");
					this.OnA_MaternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Edad", DbType="TinyInt NOT NULL")]
		public byte Edad
		{
			get
			{
				return this._Edad;
			}
			set
			{
				if ((this._Edad != value))
				{
					this.OnEdadChanging(value);
					this.SendPropertyChanging();
					this._Edad = value;
					this.SendPropertyChanged("Edad");
					this.OnEdadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EscuelaProcedencia", DbType="NVarChar(100)")]
		public string EscuelaProcedencia
		{
			get
			{
				return this._EscuelaProcedencia;
			}
			set
			{
				if ((this._EscuelaProcedencia != value))
				{
					this.OnEscuelaProcedenciaChanging(value);
					this.SendPropertyChanging();
					this._EscuelaProcedencia = value;
					this.SendPropertyChanged("EscuelaProcedencia");
					this.OnEscuelaProcedenciaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ciudad", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Ciudad
		{
			get
			{
				return this._Ciudad;
			}
			set
			{
				if ((this._Ciudad != value))
				{
					this.OnCiudadChanging(value);
					this.SendPropertyChanging();
					this._Ciudad = value;
					this.SendPropertyChanged("Ciudad");
					this.OnCiudadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Calle", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Calle
		{
			get
			{
				return this._Calle;
			}
			set
			{
				if ((this._Calle != value))
				{
					this.OnCalleChanging(value);
					this.SendPropertyChanging();
					this._Calle = value;
					this.SendPropertyChanged("Calle");
					this.OnCalleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefono", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(100)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Observaciones", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string Observaciones
		{
			get
			{
				return this._Observaciones;
			}
			set
			{
				if ((this._Observaciones != value))
				{
					this.OnObservacionesChanging(value);
					this.SendPropertyChanging();
					this._Observaciones = value;
					this.SendPropertyChanged("Observaciones");
					this.OnObservacionesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_TipoPersona", DbType="Int NOT NULL")]
		public int ID_TipoPersona
		{
			get
			{
				return this._ID_TipoPersona;
			}
			set
			{
				if ((this._ID_TipoPersona != value))
				{
					if (this._TipoPersona.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_TipoPersonaChanging(value);
					this.SendPropertyChanging();
					this._ID_TipoPersona = value;
					this.SendPropertyChanged("ID_TipoPersona");
					this.OnID_TipoPersonaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaCreacion", DbType="Date NOT NULL")]
		public System.DateTime FechaCreacion
		{
			get
			{
				return this._FechaCreacion;
			}
			set
			{
				if ((this._FechaCreacion != value))
				{
					this.OnFechaCreacionChanging(value);
					this.SendPropertyChanging();
					this._FechaCreacion = value;
					this.SendPropertyChanged("FechaCreacion");
					this.OnFechaCreacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TipoPersona_Usuario", Storage="_TipoPersona", ThisKey="ID_TipoPersona", OtherKey="IdTipoPersona", IsForeignKey=true)]
		public TipoPersona TipoPersona
		{
			get
			{
				return this._TipoPersona.Entity;
			}
			set
			{
				TipoPersona previousValue = this._TipoPersona.Entity;
				if (((previousValue != value) 
							|| (this._TipoPersona.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TipoPersona.Entity = null;
						previousValue.Usuario.Remove(this);
					}
					this._TipoPersona.Entity = value;
					if ((value != null))
					{
						value.Usuario.Add(this);
						this._ID_TipoPersona = value.IdTipoPersona;
					}
					else
					{
						this._ID_TipoPersona = default(int);
					}
					this.SendPropertyChanged("TipoPersona");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TipoPersona")]
	public partial class TipoPersona : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdTipoPersona;
		
		private string _Descripcion;
		
		private EntitySet<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdTipoPersonaChanging(int value);
    partial void OnIdTipoPersonaChanged();
    partial void OnDescripcionChanging(string value);
    partial void OnDescripcionChanged();
    #endregion
		
		public TipoPersona()
		{
			this._Usuario = new EntitySet<Usuario>(new Action<Usuario>(this.attach_Usuario), new Action<Usuario>(this.detach_Usuario));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdTipoPersona", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdTipoPersona
		{
			get
			{
				return this._IdTipoPersona;
			}
			set
			{
				if ((this._IdTipoPersona != value))
				{
					this.OnIdTipoPersonaChanging(value);
					this.SendPropertyChanging();
					this._IdTipoPersona = value;
					this.SendPropertyChanged("IdTipoPersona");
					this.OnIdTipoPersonaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(50)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this.OnDescripcionChanging(value);
					this.SendPropertyChanging();
					this._Descripcion = value;
					this.SendPropertyChanged("Descripcion");
					this.OnDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TipoPersona_Usuario", Storage="_Usuario", ThisKey="IdTipoPersona", OtherKey="ID_TipoPersona")]
		public EntitySet<Usuario> Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				this._Usuario.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Usuario(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.TipoPersona = this;
		}
		
		private void detach_Usuario(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.TipoPersona = null;
		}
	}
}
#pragma warning restore 1591
