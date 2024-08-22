// ***********************************************************************
// Assembly         : Infraestructure.Core
// Author           : Victor Andrade
// Created          : 01-09-2022
//
// 
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="Infraestructure.Core">
//     Copyright (c) Softgic SAS. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Infraestructura.Core.UnitOfWork
{
    using Common.Utils.Utils.Interface;

    using Infraestructura.Core.Context.SQLServer;
    using Infraestructura.Core.Repository;
    using Infraestructura.Core.UnitOfWork.Interface;
    using Infraestructura.Entity.Entities;


    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Class UnitOfWork.
    /// Implements the <see cref="Infraestructura.Core.UnitOfWork.Interface.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="Infraestructura.Core.UnitOfWork.Interface.IUnitOfWork" />
    /// <remarks>Jhoel Aicardi</remarks>
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes

        /// <summary>
        /// The context
        /// </summary>
        private readonly ContextSql _context;

        /// <summary>
        /// The binnacle
        /// </summary>
        private readonly IBinnacle _binnacle;
       
        private Repository<CiudadesEntity> ciudadesRepository;
        private Repository<TipoDocumentoEntity> tipoDocumentoRepository;
        private Repository<TipoHabitacionEntity> tipoHabitacionRepository;
        private Repository<GenerosEntity> generosRepository;
        private Repository<HabitacionesEntity> habitacionesRepository;
        private Repository<HotelEntity> hotelRepository;
        private Repository<OcupacionEntity> ocupacionRepository;
        private Repository<ReservasEntity> reservasRepository;
        private Repository<DetalleReservaEntity> detalleReservaRepository;







        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="binnacle">The binnacle.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public UnitOfWork(ContextSql context, IBinnacle binnacle)
        {
            this._context = context;
             this._binnacle = binnacle;
        }

        #endregion Constructor



        #region Members



        /// <summary>
        /// Gets the categories repository.
        /// </summary>
        /// <value>The categories repository.</value>
        /// <remarks>Jhoel Aicardi</remarks>
       
        public Repository<CiudadesEntity> CiudadesRepository
        {
            get
            {
                if (this.ciudadesRepository == null)
                    this.ciudadesRepository = new Repository<CiudadesEntity>(_context, _binnacle);

                return ciudadesRepository;
            }
        }

        public Repository<TipoDocumentoEntity> TipoDocumentoRepository
        {
            get
            {
                if (this.tipoDocumentoRepository == null)
                    this.tipoDocumentoRepository = new Repository<TipoDocumentoEntity>(_context, _binnacle);

                return tipoDocumentoRepository;
            }
        }

        public Repository<DetalleReservaEntity> DetalleReservaRepository
        {
            get
            {
                if (this.detalleReservaRepository == null)
                    this.detalleReservaRepository = new Repository<DetalleReservaEntity>(_context, _binnacle);

                return detalleReservaRepository;
            }
        }


        public Repository<GenerosEntity> GenerosRepository
        {
            get
            {
                if (this.generosRepository == null)
                    this.generosRepository = new Repository<GenerosEntity>(_context, _binnacle);

                return generosRepository;
            }
        }


        public Repository<HabitacionesEntity> HabitacionesRepository
        {
            get
            {
                if (this.habitacionesRepository == null)
                    this.habitacionesRepository = new Repository<HabitacionesEntity>(_context, _binnacle);

                return habitacionesRepository;
            }
        }

        public Repository<HotelEntity> HotelRepository
        {
            get
            {
                if (this.hotelRepository == null)
                    this.hotelRepository = new Repository<HotelEntity>(_context, _binnacle);

                return hotelRepository;
            }
        }

        public Repository<OcupacionEntity> OcupacionRepository
        {
            get
            {
                if (this.ocupacionRepository == null)
                    this.ocupacionRepository = new Repository<OcupacionEntity>(_context, _binnacle);

                return ocupacionRepository;
            }
        }

        public Repository<ReservasEntity> ReservasRepository
        {
            get
            {
                if (this.reservasRepository == null)
                    this.reservasRepository = new Repository<ReservasEntity>(_context, _binnacle);

                return reservasRepository;
            }
        }

        public Repository<TipoHabitacionEntity> TipoHabitacionRepository
        {
            get
            {
                if (this.tipoHabitacionRepository == null)
                    this.tipoHabitacionRepository = new Repository<TipoHabitacionEntity>(_context, _binnacle);

                return tipoHabitacionRepository;
            }
        }


        #endregion Members

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public int Save()
        {
            EntityState state = EntityState.Unchanged;
            Dictionary<string, List<object>> changes = GetChanged(ref state);
            int result = _context.SaveChanges();
            //var binnacleSave = _context.ConfigurationParameterEntities.FirstOrDefault(x => x.ParameterName == Enums.BinnacleOptions.Audit.GetDisplayName())?.Value;
            //var binnacleResult = Convert.ToInt32(binnacleSave);
            /*
            if (Convert.ToBoolean(binnacleResult))
            {
                ProcessInformationToAudit(changes, state);
            }
            */
            return result;
        }

        /// <summary>
        /// Execute store procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>the fields of the DTO must be the same fields of the query</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        /*
        public IEnumerable<T> ExecuteSqlStoreProcedure<T>(string storeProcedureName, Dictionary<string, object> parameters)
        {
           
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storeProcedureName;

                Dictionary<Type, DbType> typeMap = GetTypes();

                foreach (var parameter in parameters)
                {
                    DbParameter dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = parameter.Key;
                    dbParameter.DbType = typeMap[parameter.Value.GetType()];
                    dbParameter.Value = parameter.Value;
                    command.Parameters.Add(dbParameter);
                }

                _context.Database.OpenConnection();
                using (var record = command.ExecuteReader())
                {
                    List<T> items = new List<T>();
                    T obj = default(T);
                    while (record.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {
                            if (!object.Equals(record[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, record[prop.Name], null);
                            }
                        }
                        items.Add(obj);
                    }
                    _context.Database.CloseConnection();
          
                    return items;
                }
            }
        }
        */

        /// <summary>
        /// Map DbType from System.Type
        /// </summary>
        /// <returns>Dictionary&lt;Type, DbType&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        private Dictionary<Type, DbType> GetTypes()
        {
            Dictionary<Type, DbType> typeMap = new Dictionary<Type, DbType>();
            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;

            return typeMap;
        }

        #region Audit Log

        /// <summary>
        /// This method prepate information to save audit
        /// </summary>
        /// <param name="changes">The changes.</param>
        /// <param name="state">The state.</param>
        /// <remarks>Jhoel Aicardi</remarks>
        public void ProcessInformationToAudit(Dictionary<string, List<object>> changes, EntityState state)
        {

            foreach (var change in changes.Values)
            {
                foreach (var listValue in change)
                {
                    _binnacle.SaveAudit($"Process: {state}", Convert.ToInt32(!string.IsNullOrEmpty(_binnacle.GetPk(listValue))
                            ? listValue.GetType().GetProperty(_binnacle.GetPk(listValue)).GetValue(listValue, null)
                            : 0),
                            state.ToString(),
                            listValue,
                            changes.FirstOrDefault().Key);
                }
            }
        }

        /// <summary>
        /// This method get a changes context
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>Dictionary&lt;System.String, List&lt;System.Object&gt;&gt;.</returns>
        /// <remarks>Jhoel Aicardi</remarks>
        public Dictionary<string, List<object>> GetChanged(ref EntityState state)
        {
            Dictionary<string, List<object>> keyValues = new Dictionary<string, List<object>>();
            IEnumerable<EntityEntry> changes = from e in _context.ChangeTracker.Entries().AsEnumerable()
                                               where e.State != EntityState.Unchanged
                                               select e;

            foreach (var change in changes)
            {
                var entity = change.Entity;
                state = change.State;
                Assembly assembly = Assembly.Load(entity.GetType().Assembly.FullName);
                Type tipo = assembly.GetType(entity.GetType().FullName);
                object _entity = Convert.ChangeType(entity, tipo);

                if (keyValues.ContainsKey(entity.GetType().Name))
                {
                    keyValues[entity.GetType().Name].Add(_entity);
                }
                else
                {
                    keyValues.Add(entity.GetType().Name, new List<object>() { _entity });
                }
            }

            return keyValues;
        }

        #endregion Audit Log
    }
}