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



    //BEGIN Product 20161221
    public List<Product> GetAllProduct()
    {
        var items = new List<Product>();
        string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_DIN_PRODUCT";
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
                            var item = new Product();
                            item.noc_number        = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                            item.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
                            item.noc_br_brand_id   = dr["NOC_DP_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_BRAND_ID"]);
                            item.noc_br_din        = dr["NOC_DP_DIN"] == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessages = string.Format("DbConnection.cs - GetAllProduct()");
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

    public Product GetProductById(int id)
        {
            var product = new Product();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_DIN_PRODUCT WHERE NOC_DP_DIN_PRODUCT_ID = " + id;
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
                                product.noc_number = dr["NOC_NUMBER"]               == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                product.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
                                product.noc_br_brand_id = dr["NOC_DP_BRAND_ID"]     == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_BRAND_ID"]);
                                product.noc_br_din = dr["NOC_DP_DIN"]               == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetProductById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return product;
        }// END Product



        // BEGIN ProductRoute
        public List<ProductRoute> GetAllProductRoute()
        {
            var items          = new List<ProductRoute>();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_ROUTE";
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
                                var item = new ProductRoute();
                                item.noc_number            = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_pr_din_product_id = dr["NOC_PR_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PR_DIN_PRODUCT_ID"]);
                                item.noc_pr_route_eng_desc = dr["NOC_PR_ROUTE_ENG_DESC"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE_ENG_DESC"].ToString().Trim();
                                item.noc_pr_route_fr_desc  = dr["NOC_PR_ROUTE_FR_DESC"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE_FR_DESC"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllProductRoute()");
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

        public ProductRoute GetProductRouteById(int id)
        {
            var route = new ProductRoute();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_ROUTE WHERE NOC_DP_DIN_PRODUCT_ID = " + id;
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
                                route.noc_number            = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                route.noc_pr_din_product_id = dr["NOC_PR_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PR_DIN_PRODUCT_ID"]);
                                route.noc_pr_route_eng_desc = dr["NOC_PR_ROUTE_ENG_DESC"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE_ENG_DESC"].ToString().Trim();
                                route.noc_pr_route_fr_desc  = dr["NOC_PR_ROUTE_FR_DESC"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE_FR_DESC"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetProductById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return route;
        }

        // END of ProductRoute.

        // BEGIN of ProductForm
        public List<ProductForm> GetAllProductForm()
        {
            var items = new List<ProductForm>();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_FORM";
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
                                var item = new ProductForm();
                                item.noc_number            = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_pf_din_product_id = dr["NOC_PF_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PF_DIN_PRODUCT_ID"]);
                                item.noc_pf_form_eng_name  = dr["NOC_PF_FORM_ENG_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_ENG_NAME"].ToString().Trim();
                                item.noc_pf_form_fr_name   = dr["NOC_PF_FORM_FR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_FR_NAME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllProductForm()");
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

        public ProductForm GetProductFormById(int id)
        {
            var form = new ProductForm();
            string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_FORM WHERE NOC_PF_DIN_PRODUCT_ID = " + id;
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
                                form.noc_number            = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.noc_pf_din_product_id = dr["NOC_PF_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PF_DIN_PRODUCT_ID"]);
                                form.noc_pf_form_eng_name  = dr["NOC_PF_FORM_ENG_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_ENG_NAME"].ToString().Trim();
                                form.noc_pf_form_fr_name   = dr["NOC_PF_FORM_FR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_FR_NAME"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetProductById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return form;
        }

        // END of ProductForm




    } // END of DBConnection.
    
} // END of notice.
