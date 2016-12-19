using notice;
using nocWebApi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;

namespace notice
{
    public class DBConnection
    {

        private string _lang;
        public string Lang
        {
            get { return this._lang; }
            set { this._lang = value; }
        }

        public DBConnection(string lang)
        {
            this._lang = lang;
        }

        private string DpdDBConnection
        {
            get { return ConfigurationManager.ConnectionStrings["noc"].ToString(); }
        }




        public List<Brand> GetAllBrand()
        {
            var items = new List<Brand>();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_BRAND";
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Brand();
                                item.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_br_brand_id = dr["NOC_BR_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_BR_BRAND_ID"]);
                                item.noc_br_brandname = dr["NOC_BR_BRANDNAME"] == DBNull.Value ? string.Empty : dr["NOC_BR_BRANDNAME"].ToString().Trim();
                                
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllBrand()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Brand GetBrandById(int id)
        {
            var brand = new Brand();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_BRAND WHERE NOC_BR_BRAND_ID = " + id;
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                brand.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                brand.noc_br_brand_id = dr["NOC_BR_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_BR_BRAND_ID"]);
                                brand.noc_br_brandname = dr["NOC_BR_BRANDNAME"] == DBNull.Value ? string.Empty : dr["NOC_BR_BRANDNAME"].ToString().Trim();
                             }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetBrandById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return brand;
        }

    }

}
