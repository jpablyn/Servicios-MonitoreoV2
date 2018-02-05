﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Linq;
using Softv.Providers;
using Softv.Entities;
using Globals;

/// <summary>
/// Class                   : Softv.BAL.Client.cs
/// Generated by            : Class Generator (c) 2014
/// Description             : UsuarioSystemBussines
/// File                    : UsuarioSystemBussines.cs
/// Creation date           : 18/02/2017
/// Creation time           : 01:32 p. m.
///</summary>
namespace Softv.BAL
{

    [DataObject]
    [Serializable]
    public class UsuarioSystem
    {

        #region Constructors
        public UsuarioSystem() { }
        #endregion

        /// <summary>
        ///Adds UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int Add(UsuarioSystemEntity objUsuarioSystem)
        {
            int result = ProviderSoftv.UsuarioSystem.AddUsuarioSystem(objUsuarioSystem);
            return result;
        }

        /// <summary>
        ///Delete UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int Delete(int? IdUsuario)
        {
            int resultado = ProviderSoftv.UsuarioSystem.DeleteUsuarioSystem(IdUsuario);
            return resultado;
        }

        /// <summary>
        ///Update UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Edit(UsuarioSystemEntity objUsuarioSystem)
        {
            int result = ProviderSoftv.UsuarioSystem.EditUsuarioSystem(objUsuarioSystem);
            return result;
        }

        /// <summary>
        ///Get UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<UsuarioSystemEntity> GetAll()
        {
            List<UsuarioSystemEntity> entities = new List<UsuarioSystemEntity>();
            entities = ProviderSoftv.UsuarioSystem.GetUsuarioSystem();

            //List<TipoUsuarioEntity> lTipoUsuario = ProviderSoftv.TipoUsuario.GetTipoUsuario(entities.Where(x => x.IdTipoUsuario.HasValue).Select(x => x.IdTipoUsuario.Value).ToList());
            //lTipoUsuario.ForEach(XTipoUsuario => entities.Where(x => x.IdTipoUsuario.HasValue).Where(x => x.IdTipoUsuario == XTipoUsuario.IdTipoUsuario).ToList().ForEach(y => y.TipoUsuario = XTipoUsuario));

            //List<DetalleTicketEntity> lDetalleTicket = ProviderSoftv.DetalleTicket.GetDetalleTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).ToList());
            //lDetalleTicket.ForEach(XDetalleTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XDetalleTicket.IdUsuario).ToList().ForEach(y => y.DetalleTicket = XDetalleTicket));

            //List<MovimientoEntity> lMovimiento = ProviderSoftv.Movimiento.GetMovimiento(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).ToList());
            //lMovimiento.ForEach(XMovimiento => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XMovimiento.IdUsuario).ToList().ForEach(y => y.Movimiento = XMovimiento));

            //List<TicketEntity> lTicket = ProviderSoftv.Ticket.GetTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).ToList());
            //lTicket.ForEach(XTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XTicket.IdUsuario).ToList().ForEach(y => y.Ticket = XTicket));

            return entities ?? new List<UsuarioSystemEntity>();
        }

        /// <summary>
        ///Get UsuarioSystem List<lid>
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<UsuarioSystemEntity> GetAll(List<int> lid)
        {
            List<UsuarioSystemEntity> entities = new List<UsuarioSystemEntity>();
            entities = ProviderSoftv.UsuarioSystem.GetUsuarioSystem(lid);
            return entities ?? new List<UsuarioSystemEntity>();
        }

        /// <summary>
        ///Get UsuarioSystem By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static UsuarioSystemEntity GetOne(int? IdUsuario)
        {
            UsuarioSystemEntity result = ProviderSoftv.UsuarioSystem.GetUsuarioSystemById(IdUsuario);

            //if (result.IdTipoUsuario != null)
            //    result.TipoUsuario = ProviderSoftv.TipoUsuario.GetTipoUsuarioById(result.IdTipoUsuario);

            //if (result.IdUsuario != null)
            //    result.DetalleTicket = ProviderSoftv.DetalleTicket.GetDetalleTicketById(result.IdUsuario);

            //if (result.IdUsuario != null)
            //    result.Movimiento = ProviderSoftv.Movimiento.GetMovimientoById(result.IdUsuario);

            //if (result.IdUsuario != null)
            //    result.Ticket = ProviderSoftv.Ticket.GetTicketById(result.IdUsuario);

            return result;
        }

        /// <summary>
        ///Get UsuarioSystem By Id
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static UsuarioSystemEntity GetOneDeep(int? IdUsuario)
        {
            UsuarioSystemEntity result = ProviderSoftv.UsuarioSystem.GetUsuarioSystemById(IdUsuario);

            //if (result.IdTipoUsuario != null)
            //    result.TipoUsuario = ProviderSoftv.TipoUsuario.GetTipoUsuarioById(result.IdTipoUsuario);

            //if (result.IdUsuario != null)
            //    result.DetalleTicket = ProviderSoftv.DetalleTicket.GetDetalleTicketById(result.IdUsuario);

            //if (result.IdUsuario != null)
            //    result.Movimiento = ProviderSoftv.Movimiento.GetMovimientoById(result.IdUsuario);

            //if (result.IdUsuario != null)
            //    result.Ticket = ProviderSoftv.Ticket.GetTicketById(result.IdUsuario);

            return result;
        }

        public static List<UsuarioSystemEntity> GetUsuarioSystemByIdTipoUsuario(int? IdTipoUsuario)
        {
            List<UsuarioSystemEntity> entities = new List<UsuarioSystemEntity>();
            entities = ProviderSoftv.UsuarioSystem.GetUsuarioSystemByIdTipoUsuario(IdTipoUsuario);
            return entities ?? new List<UsuarioSystemEntity>();
        }

        //public static List<UsuarioSystemEntity> GetUsuarioSystemByIdUsuario(int? IdUsuario)
        //{
        //    List<UsuarioSystemEntity> entities = new List<UsuarioSystemEntity>();
        //    entities = ProviderSoftv.UsuarioSystem.GetUsuarioSystemByIdUsuario(IdUsuario);
        //    return entities ?? new List<UsuarioSystemEntity>();
        //}



        /// <summary>
        ///Get UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<UsuarioSystemEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<UsuarioSystemEntity> entities = new SoftvList<UsuarioSystemEntity>();
            entities = ProviderSoftv.UsuarioSystem.GetPagedList(pageIndex, pageSize);

            //List<TipoUsuarioEntity> lTipoUsuario = ProviderSoftv.TipoUsuario.GetTipoUsuario(entities.Where(x => x.IdTipoUsuario.HasValue).Select(x => x.IdTipoUsuario.Value).Distinct().ToList());
            //lTipoUsuario.ForEach(XTipoUsuario => entities.Where(x => x.IdTipoUsuario.HasValue).Where(x => x.IdTipoUsuario == XTipoUsuario.IdTipoUsuario).ToList().ForEach(y => y.TipoUsuario = XTipoUsuario));

            //List<DetalleTicketEntity> lDetalleTicket = ProviderSoftv.DetalleTicket.GetDetalleTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lDetalleTicket.ForEach(XDetalleTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XDetalleTicket.IdUsuario).ToList().ForEach(y => y.DetalleTicket = XDetalleTicket));

            //List<MovimientoEntity> lMovimiento = ProviderSoftv.Movimiento.GetMovimiento(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lMovimiento.ForEach(XMovimiento => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XMovimiento.IdUsuario).ToList().ForEach(y => y.Movimiento = XMovimiento));

            //List<TicketEntity> lTicket = ProviderSoftv.Ticket.GetTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lTicket.ForEach(XTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XTicket.IdUsuario).ToList().ForEach(y => y.Ticket = XTicket));

            return entities ?? new SoftvList<UsuarioSystemEntity>();
        }

        /// <summary>
        ///Get UsuarioSystem
        ///</summary>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SoftvList<UsuarioSystemEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<UsuarioSystemEntity> entities = new SoftvList<UsuarioSystemEntity>();
            entities = ProviderSoftv.UsuarioSystem.GetPagedList(pageIndex, pageSize, xml);

            //List<TipoUsuarioEntity> lTipoUsuario = ProviderSoftv.TipoUsuario.GetTipoUsuario(entities.Where(x => x.IdTipoUsuario.HasValue).Select(x => x.IdTipoUsuario.Value).Distinct().ToList());
            //lTipoUsuario.ForEach(XTipoUsuario => entities.Where(x => x.IdTipoUsuario.HasValue).Where(x => x.IdTipoUsuario == XTipoUsuario.IdTipoUsuario).ToList().ForEach(y => y.TipoUsuario = XTipoUsuario));

            //List<DetalleTicketEntity> lDetalleTicket = ProviderSoftv.DetalleTicket.GetDetalleTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lDetalleTicket.ForEach(XDetalleTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XDetalleTicket.IdUsuario).ToList().ForEach(y => y.DetalleTicket = XDetalleTicket));

            //List<MovimientoEntity> lMovimiento = ProviderSoftv.Movimiento.GetMovimiento(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lMovimiento.ForEach(XMovimiento => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XMovimiento.IdUsuario).ToList().ForEach(y => y.Movimiento = XMovimiento));

            //List<TicketEntity> lTicket = ProviderSoftv.Ticket.GetTicket(entities.Where(x => x.IdUsuario.HasValue).Select(x => x.IdUsuario.Value).Distinct().ToList());
            //lTicket.ForEach(XTicket => entities.Where(x => x.IdUsuario.HasValue).Where(x => x.IdUsuario == XTicket.IdUsuario).ToList().ForEach(y => y.Ticket = XTicket));

            return entities ?? new SoftvList<UsuarioSystemEntity>();
        }


    }




    #region Customs Methods

    #endregion
}