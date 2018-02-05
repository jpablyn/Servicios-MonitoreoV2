﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Softv.Entities;
using Softv.Providers;
using SoftvConfiguration;
using Globals;

namespace Softv.DAO
{
    /// <summary>
    /// Class                   : Softv.DAO.ModuleData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Module Data Access Object
    /// File                    : ModuleDAO.cs
    /// Creation date           : 19/09/2015
    /// Creation time           : 03:47 p. m.
    ///</summary>
    public class ModuleData : ModuleProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="Module"> Object Module added to List</param>
        public override int AddModule(ModuleEntity entity_Module)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleAdd", connection);

                AssingParameter(comandoSql, "@IdModule", null, pd: ParameterDirection.Output, IsKey: true);

                AssingParameter(comandoSql, "@Description", entity_Module.Description);

                AssingParameter(comandoSql, "@ModulePath", entity_Module.ModulePath);

                AssingParameter(comandoSql, "@ModuleView", entity_Module.ModuleView);

                AssingParameter(comandoSql, "@ParentId", entity_Module.ParentId);

                AssingParameter(comandoSql, "@SortOrder", entity_Module.SortOrder);

                AssingParameter(comandoSql, "@OptAdd", entity_Module.OptAdd);

                AssingParameter(comandoSql, "@OptSelect", entity_Module.OptSelect);

                AssingParameter(comandoSql, "@OptUpdate", entity_Module.OptUpdate);

                AssingParameter(comandoSql, "@OptDelete", entity_Module.OptDelete);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding Module " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@IdModule"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a Module
        ///</summary>
        /// <param name="">  IdModule to delete </param>
        public override int DeleteModule(int? IdModule)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleDelete", connection);

                AssingParameter(comandoSql, "@IdModule", IdModule);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Edits a Module
        ///</summary>
        /// <param name="Module"> Objeto Module a editar </param>
        public override int EditModule(ModuleEntity entity_Module)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleEdit", connection);

                AssingParameter(comandoSql, "@IdModule", entity_Module.IdModule);

                AssingParameter(comandoSql, "@Description", entity_Module.Description);

                AssingParameter(comandoSql, "@ModulePath", entity_Module.ModulePath);

                AssingParameter(comandoSql, "@ModuleView", entity_Module.ModuleView);

                AssingParameter(comandoSql, "@ParentId", entity_Module.ParentId);

                AssingParameter(comandoSql, "@SortOrder", entity_Module.SortOrder);

                AssingParameter(comandoSql, "@OptAdd", entity_Module.OptAdd);

                AssingParameter(comandoSql, "@OptSelect", entity_Module.OptSelect);

                AssingParameter(comandoSql, "@OptUpdate", entity_Module.OptUpdate);

                AssingParameter(comandoSql, "@OptDelete", entity_Module.OptDelete);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all Module
        ///</summary>
        public override List<ModuleEntity> GetModule()
        {
            List<ModuleEntity> ModuleList = new List<ModuleEntity>();
            List<ModuleEntity> ModuleListOrdered = new List<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        ModuleList.Add(GetModuleFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }

                List<ModuleEntity> principales = ModuleList.Where(d => d.ParentId == 0 && d.Display == true).ToList();
                principales.OrderBy(z => z.Description).ToList().ForEach(a =>
                {
                    a.tipo = 1;
                    ModuleListOrdered.Add(a);
                    List<ModuleEntity> hijos = ModuleList.Where(p => p.ParentId == a.IdModule).OrderBy(r => r.Description).ToList();
                    hijos.ForEach(d =>
                    {


                        List<ModuleEntity> nietos = ModuleList.Where(p1 => p1.ParentId == d.IdModule).OrderBy(r1 => r1.Description).ToList();
                        d.tipo = (nietos.Count > 0) ? 4 : 2;
                        ModuleListOrdered.Add(d);
                        nietos.ForEach(m =>
                        {
                            m.tipo = 3;
                            ModuleListOrdered.Add(m);
                        });
                        ;
                    });

                });
            }
            return ModuleListOrdered;
        }

        /// <summary>
        /// Gets all Module by List<int>
        ///</summary>
        public override List<ModuleEntity> GetModule(List<int> lid)
        {
            List<ModuleEntity> ModuleList = new List<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        ModuleList.Add(GetModuleFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return ModuleList;
        }

        /// <summary>
        /// Gets Module by
        ///</summary>
        public override ModuleEntity GetModuleById(int? IdModule)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetById", connection);
                ModuleEntity entity_Module = null;


                AssingParameter(comandoSql, "@IdModule", IdModule);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_Module = GetModuleFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_Module;
            }

        }


        public override List<ModuleEntity> GetModuleByIdModule(int? IdModule)
        {
            List<ModuleEntity> ModuleList = new List<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetByIdModule", connection);

                AssingParameter(comandoSql, "@IdModule", IdModule);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        ModuleList.Add(GetModuleFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return ModuleList;
        }


        /// <summary>
        ///Get Module
        ///</summary>
        public override SoftvList<ModuleEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<ModuleEntity> entities = new SoftvList<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetPaged", connection);

                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@pageSize", pageSize);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetModuleFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetModuleCount();
                return entities ?? new SoftvList<ModuleEntity>();
            }
        }

        /// <summary>
        ///Get Module
        ///</summary>
        public override SoftvList<ModuleEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<ModuleEntity> entities = new SoftvList<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetPagedXml", connection);

                AssingParameter(comandoSql, "@pageSize", pageSize);
                AssingParameter(comandoSql, "@pageIndex", pageIndex);
                AssingParameter(comandoSql, "@xml", xml);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        entities.Add(GetModuleFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetModuleCount(xml);
                return entities ?? new SoftvList<ModuleEntity>();
            }
        }


        public override List<ModuleEntity> GetModulos_Permisos(int? idrol)
        {
            List<ModuleEntity> ModuleList = new List<ModuleEntity>();
            List<ModuleEntity> ModuleListOrdered = new List<ModuleEntity>();
            List<ModuleEntity> entities = new List<ModuleEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("GetModule_permisos", connection);

                AssingParameter(comandoSql, "@IdRol", idrol);                
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);
                    while (rd.Read())
                    {
                        ModuleList.Add(GetModule_permisosFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }

                List<ModuleEntity> principales = ModuleList.Where(d => d.ParentId == 0 && d.Display == true).ToList();
                principales.OrderBy(z => z.Description).ToList().ForEach(a =>
                {
                    a.tipo = 1;
                    ModuleListOrdered.Add(a);
                    List<ModuleEntity> hijos = ModuleList.Where(p => p.ParentId == a.IdModule).OrderBy(r => r.Description).ToList();
                    hijos.ForEach(d =>
                    {


                        List<ModuleEntity> nietos = ModuleList.Where(p1 => p1.ParentId == d.IdModule).OrderBy(r1 => r1.Description).ToList();
                        d.tipo = (nietos.Count > 0) ? 4 : 2;
                        ModuleListOrdered.Add(d);
                        nietos.ForEach(m =>
                        {
                            m.tipo = 3;
                            ModuleListOrdered.Add(m);
                        });
                        ;
                    });

                });
            }
            return ModuleListOrdered;




          
            


        }


        /// <summary>
        ///Get Count Module
        ///</summary>
        public int GetModuleCount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }


        /// <summary>
        ///Get Count Module
        ///</summary>
        public int GetModuleCount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Module.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_ModuleGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Module " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            return result;
        }

        #region Customs Methods

        #endregion
    }
}