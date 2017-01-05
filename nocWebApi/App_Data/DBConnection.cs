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
            var items = new List<ProductRoute>();
            string commandText = "SELECT NOC_NUMBER, NOC_PR_DIN_PRODUCT_ID, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PR_ROUTE_FR_DESC AS NOC_PR_ROUTE";
            }
            else {
                commandText += " NOC_PR_ROUTE_ENG_DESC AS NOC_PR_ROUTE";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_ROUTE";


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
                                item.noc_pr_route          = dr["NOC_PR_ROUTE"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE"].ToString().Trim();

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
            //ORIGINAL - string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_ROUTE WHERE NOC_DP_DIN_PRODUCT_ID = " + id;
            string commandText = "SELECT NOC_NUMBER, NOC_PR_DIN_PRODUCT_ID, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PR_ROUTE_FR_DESC AS NOC_PR_ROUTE";
            }
            else {
                commandText += " NOC_PR_ROUTE_ENG_DESC AS NOC_PR_ROUTE";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_ROUTE";

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
                                route.noc_pr_route          = dr["NOC_PR_ROUTE"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE"].ToString().Trim();
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

            string commandText = "SELECT NOC_NUMBER, NOC_PF_DIN_PRODUCT_ID, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PF_FORM_FR_NAME AS NOC_PF_FORM_NAME";
            }
            else {
                commandText += " NOC_PF_FORM_ENG_NAME AS NOC_PF_FORM_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_FORM";


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
                                item.noc_pf_form_name      = dr["NOC_PF_FORM_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_NAME"].ToString().Trim();
                                
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
            
            string commandText = "SELECT NOC_NUMBER, NOC_PR_DIN_PRODUCT_ID, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PF_FORM_FR_NAME AS NOC_PF_FORM_NAME";
            }
            else {
                commandText += " NOC_PF_FORM_ENG_NAME AS NOC_PF_FORM_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_FORM";

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
                                form.noc_number            = dr["NOC_NUMBER"]            == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.noc_pf_din_product_id = dr["NOC_PF_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PF_DIN_PRODUCT_ID"]);
                                form.noc_pf_form_name      = dr["NOC_PF_FORM_NAME"]  == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_NAME"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetProductFormById()");
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

        // BEGIN of VetSpecies
        public List<VetSpecies> GetAllVetSpecies()
        {
            var items = new List<VetSpecies>();
            
            string commandText = "SELECT NOC_NUMBER, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " VET_SPECIES_FR_DESC AS VET_SPECIES_DESC";
            }
            else {
                commandText += " VET_SPECIES_DESC AS VET_SPECIES_DESC";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_VET_SPECIES";


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
                                var item = new VetSpecies();
                                item.noc_number = dr["NOC_NUMBER"]                   == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.vet_species_desc = dr["VET_SPECIES_DESC"]       == DBNull.Value ? string.Empty : dr["VET_SPECIES_DESC"].ToString().Trim();
                               
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllVetSpecies()");
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
        public VetSpecies GetVetSpeciesById(int id)
        {
            var form = new VetSpecies();
            //ORIGINAL string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_VET_SPECIES WHERE NOC_PF_DIN_PRODUCT_ID = " + id;

            string commandText = "SELECT NOC_NUMBER, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " VET_SPECIES_FR_DESC AS VET_SPECIES_DESC";
            }
            else {
                commandText += " VET_SPECIES_DESC AS VET_SPECIES_DESC";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_VET_SPECIES";

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
                                form.noc_number = dr["NOC_NUMBER"]                   == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.vet_species_desc = dr["VET_SPECIES_DESC"]       == DBNull.Value ? string.Empty : dr["VET_SPECIES_DESC"].ToString().Trim();
                                //form.vet_species_fr_desc = dr["VET_SPECIES_FR_DESC"] == DBNull.Value ? string.Empty : dr["VET_SPECIES_FR_DESC"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetVetSpeciesById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return form;
        } // END of VetSpecies

        // BEGIN of ProductIngredient


        public List<ProductIngredient> GetAllProductIngredient()
        {
            var items = new List<ProductIngredient>();

            string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, NOC_PI_BASE, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PI_MEDIC_INGR_FR_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            else {
                commandText += " NOC_PI_MEDIC_INGR_ENG_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_INGREDIENT";

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
                                var item = new ProductIngredient();
                                item.noc_number                  = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_pi_din_product_id       = dr["NOC_PI_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_DIN_PRODUCT_ID"]);
                                item.noc_pi_medic_ingr_name      = dr["NOC_PI_MEDIC_INGR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PI_MEDIC_INGR_NAME"].ToString().Trim();
                                item.noc_pi_strength             = dr["NOC_PI_STRENGTH"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_STRENGTH"]);
                                item.noc_pi_unit                 = dr["NOC_PI_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_UNIT"].ToString().Trim();
                                item.noc_pi_basic_unit           = dr["NOC_PI_BASIC_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASIC_UNIT"].ToString().Trim();
                                item.noc_pi_base                 = dr["NOC_PI_BASE"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASE"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllProductIngredient()");
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

        public ProductIngredient GetProductIngredientById(int id)
        {
            var form = new ProductIngredient();
           string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, NOC_PI_BASE, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PI_MEDIC_INGR_FR_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            else {
                commandText += " NOC_PI_MEDIC_INGR_ENG_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_INGREDIENT";


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
                                form.noc_number                  = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.noc_pi_din_product_id       = dr["NOC_PI_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_DIN_PRODUCT_ID"]);
                                form.noc_pi_medic_ingr_name      = dr["NOC_PI_MEDIC_INGR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PI_MEDIC_INGR_NAME"].ToString().Trim();
                                form.noc_pi_strength             = dr["NOC_PI_STRENGTH"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_STRENGTH"]);
                                form.noc_pi_unit                 = dr["NOC_PI_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_UNIT"].ToString().Trim();
                                form.noc_pi_basic_unit           = dr["NOC_PI_BASIC_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASIC_UNIT"].ToString().Trim();
                                form.noc_pi_base                 = dr["NOC_PI_BASE"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASE"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetProductIngredientById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return form;
        }// END of ProductIngredient.


    } // END of DBConnection.

} // END of notice.
