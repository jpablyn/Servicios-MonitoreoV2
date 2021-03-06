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
    /// Class                   : Softv.DAO.SecutityData
    /// Generated by            : Class Generator (c) 2014
    /// Description             : Secutity Data Access Object
    /// File                    : SecutityDAO.cs
    /// Creation date           : 14/12/2015
    /// Creation time           : 11:51 a. m.
    ///</summary>
    public class SecutityData : SecutityProvider
    {
        /// <summary>
        ///</summary>
        /// <param name="Secutity"> Object Secutity added to List</param>
        public override int AddSecutity(SecutityEntity entity_Secutity)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityAdd", connection);

                AssingParameter(comandoSql, "@IdSecutity", null, pd: ParameterDirection.Output, IsKey: true);

                AssingParameter(comandoSql, "@Module", entity_Secutity.Module);

                AssingParameter(comandoSql, "@Action", entity_Secutity.Action);

                AssingParameter(comandoSql, "@Permision", entity_Secutity.Permision);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding Secutity " + ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
                result = (int)comandoSql.Parameters["@IdSecutity"].Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes a Secutity
        ///</summary>
        /// <param name="">  IdSecutity to delete </param>
        public override int DeleteSecutity(int? IdSecutity)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityDelete", connection);

                AssingParameter(comandoSql, "@IdSecutity", IdSecutity);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = ExecuteNonQuery(comandoSql);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting Secutity " + ex.Message, ex);
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
        /// Edits a Secutity
        ///</summary>
        /// <param name="Secutity"> Objeto Secutity a editar </param>
        public override int EditSecutity(SecutityEntity entity_Secutity)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityEdit", connection);

                AssingParameter(comandoSql, "@IdSecutity", entity_Secutity.IdSecutity);

                AssingParameter(comandoSql, "@Module", entity_Secutity.Module);

                AssingParameter(comandoSql, "@Action", entity_Secutity.Action);

                AssingParameter(comandoSql, "@Permision", entity_Secutity.Permision);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = int.Parse(ExecuteNonQuery(comandoSql).ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating Secutity " + ex.Message, ex);
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
        /// Gets all Secutity
        ///</summary>
        public override List<SecutityEntity> GetSecutity()
        {
            List<SecutityEntity> SecutityList = new List<SecutityEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGet", connection);
                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        SecutityList.Add(GetSecutityFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return SecutityList;
        }

        /// <summary>
        /// Gets all Secutity by List<int>
        ///</summary>
        public override List<SecutityEntity> GetSecutity(List<int> lid)
        {
            List<SecutityEntity> SecutityList = new List<SecutityEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {
                DataTable IdDT = BuildTableID(lid);

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetByIds", connection);
                AssingParameter(comandoSql, "@IdTable", IdDT);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql);

                    while (rd.Read())
                    {
                        SecutityList.Add(GetSecutityFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
            }
            return SecutityList;
        }

        /// <summary>
        /// Gets Secutity by
        ///</summary>
        public override SecutityEntity GetSecutityById(int? IdSecutity)
        {
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetById", connection);
                SecutityEntity entity_Secutity = null;


                AssingParameter(comandoSql, "@IdSecutity", IdSecutity);

                IDataReader rd = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    rd = ExecuteReader(comandoSql, CommandBehavior.SingleRow);
                    if (rd.Read())
                        entity_Secutity = GetSecutityFromReader(rd);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                return entity_Secutity;
            }

        }



        /// <summary>
        ///Get Secutity
        ///</summary>
        public override SoftvList<SecutityEntity> GetPagedList(int pageIndex, int pageSize)
        {
            SoftvList<SecutityEntity> entities = new SoftvList<SecutityEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetPaged", connection);

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
                        entities.Add(GetSecutityFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetSecutityCount();
                return entities ?? new SoftvList<SecutityEntity>();
            }
        }

        /// <summary>
        ///Get Secutity
        ///</summary>
        public override SoftvList<SecutityEntity> GetPagedList(int pageIndex, int pageSize, String xml)
        {
            SoftvList<SecutityEntity> entities = new SoftvList<SecutityEntity>();
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetPagedXml", connection);

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
                        entities.Add(GetSecutityFromReader(rd));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    if (rd != null)
                        rd.Close();
                }
                entities.totalCount = GetSecutityCount(xml);
                return entities ?? new SoftvList<SecutityEntity>();
            }
        }

        /// <summary>
        ///Get Count Secutity
        ///</summary>
        public int GetSecutityCount()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetCount", connection);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
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
        ///Get Count Secutity
        ///</summary>
        public int GetSecutityCount(String xml)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SoftvSettings.Settings.Secutity.ConnectionString))
            {

                SqlCommand comandoSql = CreateCommand("Softv_SecutityGetCountXml", connection);

                AssingParameter(comandoSql, "@xml", xml);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    result = (int)ExecuteScalar(comandoSql);


                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting data Secutity " + ex.Message, ex);
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
