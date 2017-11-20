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




        public List<DrugProduct> GetAllDrugProduct()
        {
            var items = new List<DrugProduct>();
            //string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_BRAND";
            string commandText = "SELECT A.NOC_DP_DIN_PRODUCT_ID, A.NOC_DP_DIN, B.* FROM QRY_NOC_DIN_PRODUCT A, QRY_NOC_BRAND B";
                   commandText+=" WHERE A.NOC_DP_BRAND_ID = B.NOC_BR_BRAND_ID AND A.NOC_NUMBER = B.NOC_NUMBER";
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
                                var item = new DrugProduct();
                                //if (lang.Equals("fr"))
                                //{
                                //    item.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                //    item.noc_br_brand_id = dr["NOC_BR_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_BR_BRAND_ID"]);
                                //    item.noc_br_brandname = dr["NOC_BR_BRANDNAME_FR"] == DBNull.Value ? string.Empty : dr["NOC_BR_BRANDNAME_FR"].ToString().Trim();

                                //}
                                //else
                                //{
                                    item.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                    item.noc_br_brand_id = dr["NOC_BR_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_BR_BRAND_ID"]);
                                    item.noc_br_brandname = dr["NOC_BR_BRANDNAME"] == DBNull.Value ? string.Empty : dr["NOC_BR_BRANDNAME"].ToString().Trim();
                                    item.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
                                    item.noc_br_din = dr["NOC_DP_DIN"] == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();
                                
                                //}


                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllDrugProduct()");
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

        public List<DrugProduct> GetDrugProductById(int id)
        {
            //var brand = new Brand();
            var items = new List<DrugProduct>();
            //string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_BRAND WHERE NOC_NUMBER = " + id;
            string commandText = "SELECT A.NOC_DP_DIN_PRODUCT_ID, A.NOC_DP_DIN, B.* FROM QRY_NOC_DIN_PRODUCT A, QRY_NOC_BRAND B";
            commandText += " WHERE A.NOC_DP_BRAND_ID = B.NOC_BR_BRAND_ID AND A.NOC_NUMBER = B.NOC_NUMBER";
            commandText += " AND B.NOC_NUMBER = " + id;
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
                                var brand = new DrugProduct();
                                brand.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                brand.noc_br_brand_id = dr["NOC_BR_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_BR_BRAND_ID"]);
                                brand.noc_br_brandname = dr["NOC_BR_BRANDNAME"] == DBNull.Value ? string.Empty : dr["NOC_BR_BRANDNAME"].ToString().Trim();
                                brand.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
                                brand.noc_br_din = dr["NOC_DP_DIN"] == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();
                                items.Add(brand);
                             }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductById()");
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



    //BEGIN Product 20161221
    //public List<Product> GetAllProduct()
    //{
    //    var items = new List<Product>();
    //    string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_DIN_PRODUCT";
    //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
    //    {
    //        OracleCommand cmd = new OracleCommand(commandText, con);
    //        try
    //        {
    //            con.Open();
    //            using (OracleDataReader dr = cmd.ExecuteReader())
    //            {
    //                if (dr.HasRows)
    //                {
    //                    while (dr.Read())
    //                    {
    //                        var item = new Product();
    //                        item.noc_number        = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
    //                        item.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
    //                        item.noc_br_brand_id   = dr["NOC_DP_BRAND_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_BRAND_ID"]);
    //                        item.noc_br_din        = dr["NOC_DP_DIN"] == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();

    //                        items.Add(item);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string errorMessages = string.Format("DbConnection.cs - GetAllProduct()");
    //            ExceptionHelper.LogException(ex, errorMessages);
    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //        }
    //    }
    //    return items;
    // }

    //public List<Product> GetProductById(int id)
    //    {
    //        //var product = new Product();
    //        var items = new List<Product>();
    //        string commandText = "SELECT * FROM NOC_ONLINE_OWNER.QRY_NOC_DIN_PRODUCT WHERE NOC_NUMBER = " + id;
    //        using (OracleConnection con = new OracleConnection(DpdDBConnection))
    //        {
    //            OracleCommand cmd = new OracleCommand(commandText, con);
    //            try
    //            {
    //                con.Open();
    //                using (OracleDataReader dr = cmd.ExecuteReader())
    //                {
    //                    if (dr.HasRows)
    //                    {
    //                        while (dr.Read())
    //                        {
    //                            var product = new Product();
    //                            product.noc_number = dr["NOC_NUMBER"]               == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
    //                            product.noc_br_product_id = dr["NOC_DP_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_DIN_PRODUCT_ID"]);
    //                            product.noc_br_brand_id = dr["NOC_DP_BRAND_ID"]     == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_DP_BRAND_ID"]);
    //                            product.noc_br_din = dr["NOC_DP_DIN"]               == DBNull.Value ? string.Empty : dr["NOC_DP_DIN"].ToString().Trim();
    //                            items.Add(product);
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                string errorMessages = string.Format("DbConnection.cs - GetProductById()");
    //                ExceptionHelper.LogException(ex, errorMessages);
    //            }
    //            finally
    //            {
    //                if (con.State == ConnectionState.Open)
    //                    con.Close();
    //            }
    //        }
    //        return items;
    //    }// END Product



        // BEGIN ProductRoute
        public List<Route> GetAllRoute()
        {
            var items = new List<Route>();
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
                                var item = new Route();
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
                    string errorMessages = string.Format("DbConnection.cs - GetAllRoute()");
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

        public List<Route> GetRouteById(int id)
        {
            
            var items = new List<Route>();
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
            commandText += " WHERE NOC_NUMBER = " + id;

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
                                var route = new Route();
                                route.noc_number            = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                route.noc_pr_din_product_id = dr["NOC_PR_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PR_DIN_PRODUCT_ID"]);
                                route.noc_pr_route          = dr["NOC_PR_ROUTE"] == DBNull.Value ? string.Empty : dr["NOC_PR_ROUTE"].ToString().Trim();
                                items.Add(route);
                            }
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetRouteById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            //return route;
            return items;
        }

        // END of ProductRoute.

        // BEGIN of ProductForm
        public List<DosageForm> GetAllDosageForm()
        {
            var items = new List<DosageForm>();

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
                                var item = new DosageForm();
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
                    string errorMessages = string.Format("DbConnection.cs - GetAllDosageForm()");
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

        public List<DosageForm> GetDosageFormById(int id)
        {
            // var form = new ProductForm();
            var items = new List<DosageForm>();

            string commandText = "SELECT NOC_NUMBER, NOC_PF_DIN_PRODUCT_ID, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PF_FORM_FR_NAME AS NOC_PF_FORM_NAME";
            }
            else {
                commandText += " NOC_PF_FORM_ENG_NAME AS NOC_PF_FORM_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_FORM";
            commandText += " WHERE NOC_NUMBER = " + id;

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
                                var form = new DosageForm();
                                form.noc_number            = dr["NOC_NUMBER"]            == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.noc_pf_din_product_id = dr["NOC_PF_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PF_DIN_PRODUCT_ID"]);
                                form.noc_pf_form_name      = dr["NOC_PF_FORM_NAME"]  == DBNull.Value ? string.Empty : dr["NOC_PF_FORM_NAME"].ToString().Trim();
                                items.Add(form);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDosageFormById()");
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
        public List<VetSpecies> GetVetSpeciesById(int id)
        {
            //var form = new VetSpecies();
            var items = new List<VetSpecies>();
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
            commandText += " WHERE NOC_NUMBER = " + id;

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
                                var form = new VetSpecies();
                                form.noc_number = dr["NOC_NUMBER"]                   == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.vet_species_desc = dr["VET_SPECIES_DESC"]       == DBNull.Value ? string.Empty : dr["VET_SPECIES_DESC"].ToString().Trim();
                                //form.vet_species_fr_desc = dr["VET_SPECIES_FR_DESC"] == DBNull.Value ? string.Empty : dr["VET_SPECIES_FR_DESC"].ToString().Trim();
                                items.Add(form);
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
            return items;
        } // END of VetSpecies

        // BEGIN of ProductIngredient


        public List<MedicinalIngredient> GetAllMedicinalIngredient()
        {
            var items = new List<MedicinalIngredient>();

            //string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, NOC_PI_BASE, ";
            string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, ";

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
                                var item = new MedicinalIngredient();
                                item.noc_number                  = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_pi_din_product_id       = dr["NOC_PI_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_DIN_PRODUCT_ID"]);
                                item.noc_pi_medic_ingr_name      = dr["NOC_PI_MEDIC_INGR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PI_MEDIC_INGR_NAME"].ToString().Trim();
                                item.noc_pi_strength             = dr["NOC_PI_STRENGTH"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_STRENGTH"]);
                                item.noc_pi_unit                 = dr["NOC_PI_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_UNIT"].ToString().Trim();
                                item.noc_pi_basic_unit           = dr["NOC_PI_BASIC_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASIC_UNIT"].ToString().Trim();
                                //item.noc_pi_base                 = dr["NOC_PI_BASE"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASE"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllMedicinalIngredient()");
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

        public List<MedicinalIngredient> GetMedicinalIngredientById(int id)
        {
            //var form = new ProductIngredient();
            var items = new List<MedicinalIngredient>();
            //string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, NOC_PI_BASE, ";
            string commandText = "SELECT NOC_NUMBER, NOC_PI_DIN_PRODUCT_ID, NOC_PI_STRENGTH, NOC_PI_UNIT, NOC_PI_BASIC_UNIT, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += " NOC_PI_MEDIC_INGR_FR_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            else {
                commandText += " NOC_PI_MEDIC_INGR_ENG_NAME AS NOC_PI_MEDIC_INGR_NAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_PRODUCT_INGREDIENT";
            commandText += " WHERE NOC_NUMBER = " + id;

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
                                var item = new MedicinalIngredient();
                                item.noc_number                  = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_pi_din_product_id       = dr["NOC_PI_DIN_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_DIN_PRODUCT_ID"]);
                                item.noc_pi_medic_ingr_name      = dr["NOC_PI_MEDIC_INGR_NAME"] == DBNull.Value ? string.Empty : dr["NOC_PI_MEDIC_INGR_NAME"].ToString().Trim();
                                item.noc_pi_strength             = dr["NOC_PI_STRENGTH"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_PI_STRENGTH"]);
                                item.noc_pi_unit                 = dr["NOC_PI_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_UNIT"].ToString().Trim();
                                item.noc_pi_basic_unit           = dr["NOC_PI_BASIC_UNIT"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASIC_UNIT"].ToString().Trim();
                                //form.noc_pi_base                 = dr["NOC_PI_BASE"] == DBNull.Value ? string.Empty : dr["NOC_PI_BASE"].ToString().Trim();
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetMedicinalIngredientById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }// END of ProductIngredient.
         // BEGIN of NoticeOfComplianceMain
        public List<NoticeOfComplianceMain> GetAllNoticeOfComplianceMain()
        {
            var items = new List<NoticeOfComplianceMain>();

            string commandText = "SELECT NOC_NUMBER, NOC_DATE, NOC_SUBMISSION_NUMBER, NOC_MANUFACTURER_NAME, NOC_STATUS_WITH_CONDITIONS, NOC_IS_SUPPLIMENT, NOC_IS_ADMIN, NOC_FILE_NUMBER, NOC_CRP_PRODUCT_NAME, NOC_CRP_COMPANY_NAME, NOC_ACTIVE_STATUS, NOC_SCANNED_PAGE, NOC_NOTES_ENTRY_DATE, NOC_LAST_UPDATE_DATE, NOC_ENTRY_DATE, ";
            //string commandText = "SELECT NOC_NUMBER, NOC_DATE, NOC_MANUFACTURER_NAME, NOC_STATUS_WITH_CONDITIONS, NOC_IS_SUPPLIMENT, NOC_IS_ADMIN, NOC_CRP_PRODUCT_NAME, NOC_CRP_COMPANY_NAME, NOC_ACTIVE_STATUS, NOC_LAST_UPDATE_DATE, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += "NOC_CRP_COUNTRY_FR_NAME AS NOC_CRP_COUNTRY_NAME, ";
                commandText += "NOC_QN_FRENCH_FNAME AS NOC_QN_FNAME, ";
                commandText += "NOC_DHCPL_FRENCH_FNAME AS NOC_DHCPL_FNAME, ";
                commandText += "NOC_FACTSHEET_FRENCH_FNAME AS NOC_FACTSHEET_FNAME, ";
                commandText += "NOC_FR_SUBMISSION_TYPE AS NOC_ON_SUBMISSION_TYPE, ";
                commandText += "NOC_FR_SUBMISSION_CLASS AS NOC_SUBMISSION_CLASS, ";
                commandText += "NOC_FR_PRODUCT_TYPE AS NOC_PRODUCT_TYPE, ";
                commandText += "NOC_FR_REASON_SUPPLEMENT AS NOC_REASON_SUPPLEMENT, ";
                commandText += "NOC_FR_REASON_SUBMISSION AS NOC_REASON_SUBMISSION, ";
                commandText += "NOC_FR_THERAPEUTIC_CLASS AS NOC_THERAPEUTIC_CLASS, ";
                commandText += "NOC_FR_NOTES AS NOC_NOTES, ";
                commandText += "NOC_SBD_FRENCH_FNAME AS NOC_SBD_FNAME, ";
                commandText += "NOC_ND_FRENCH_FNAME AS NOC_ND_FNAME,";
                commandText += "NOC_CI_PART_III_FRENCH_FNAME AS NOC_CI_PART_III_FNAME, ";
                commandText += "NOC_PM_FRENCH_FNAME AS NOC_PM_FNAME";

                //DEBUGGED CODE 20170123 Above and below.
            }
            else {
                commandText += "NOC_CRP_COUNTRY_ENG_NAME AS NOC_CRP_COUNTRY_NAME, ";
                commandText += "NOC_QN_ENGLISH_FNAME AS NOC_QN_FNAME, ";
                commandText += "NOC_DHCPL_ENGLISH_FNAME AS NOC_DHCPL_FNAME, ";
                commandText += "NOC_FACTSHEET_ENGLISH_FNAME AS NOC_FACTSHEET_FNAME, ";
                commandText += "NOC_ENG_SUBMISSION_TYPE AS NOC_ON_SUBMISSION_TYPE, ";
                commandText += "NOC_ENG_SUBMISSION_CLASS AS NOC_SUBMISSION_CLASS, ";
                commandText += "NOC_ENG_PRODUCT_TYPE AS NOC_PRODUCT_TYPE, ";
                commandText += "NOC_ENG_REASON_SUPPLEMENT AS NOC_REASON_SUPPLEMENT, ";
                commandText += "NOC_ENG_REASON_SUBMISSION AS NOC_REASON_SUBMISSION, ";
                commandText += "NOC_ENG_THERAPEUTIC_CLASS AS NOC_THERAPEUTIC_CLASS, ";
                commandText += "NOC_ENG_NOTES AS NOC_NOTES, ";
                commandText += "NOC_SBD_ENGLISH_FNAME AS NOC_SBD_FNAME, ";
                commandText += "NOC_ND_ENGLISH_FNAME AS NOC_ND_FNAME,";
                commandText += "NOC_CI_PART_III_ENGLISH_FNAME AS NOC_CI_PART_III_FNAME, ";
                commandText += "NOC_PM_ENGLISH_FNAME AS NOC_PM_FNAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_MAIN";

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
                                //
                                //
                                // 20170124 BARRYM Below is the corrected SQL query.
                                var item = new NoticeOfComplianceMain();
                                item.noc_number                 = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                item.noc_date                   = dr["NOC_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_DATE"]);
                                //item.noc_submission_number      = dr["NOC_SUBMISSION_NUMBER"] == DBNull.Value ? string.Empty : dr["NOC_SUBMISSION_NUMBER"].ToString().Trim();
                                item.noc_manufacturer_name      = dr["NOC_MANUFACTURER_NAME"] == DBNull.Value ? string.Empty : dr["NOC_MANUFACTURER_NAME"].ToString().Trim();
                                item.noc_status_with_conditions = dr["NOC_STATUS_WITH_CONDITIONS"] == DBNull.Value ? string.Empty : dr["NOC_STATUS_WITH_CONDITIONS"].ToString().Trim();
                                //item.noc_qn_fname               = dr["NOC_QN_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_QN_FNAME"].ToString().Trim();        
                                item.noc_crp_country_name       = dr["NOC_CRP_COUNTRY_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_COUNTRY_NAME"].ToString().Trim();
                                //item.noc_dhcpl_fname            = dr["NOC_DHCPL_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_DHCPL_FNAME"].ToString().Trim();
                                //item.noc_factsheet_fname        = dr["NOC_FACTSHEET_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_FACTSHEET_FNAME"].ToString().Trim();
                                item.noc_on_submission_type     = dr["NOC_ON_SUBMISSION_TYPE"] == DBNull.Value ? string.Empty : dr["NOC_ON_SUBMISSION_TYPE"].ToString().Trim();
                                item.noc_is_suppliment          = dr["NOC_IS_SUPPLIMENT"] == DBNull.Value ? string.Empty : dr["NOC_IS_SUPPLIMENT"].ToString().Trim();
                                item.noc_submission_class       = dr["NOC_SUBMISSION_CLASS"] == DBNull.Value ? string.Empty : dr["NOC_SUBMISSION_CLASS"].ToString().Trim();
                                item.noc_is_admin               = dr["NOC_IS_ADMIN"] == DBNull.Value ? string.Empty : dr["NOC_IS_ADMIN"].ToString().Trim();
                                item.noc_product_type           = dr["NOC_PRODUCT_TYPE"] == DBNull.Value ? string.Empty : dr["NOC_PRODUCT_TYPE"].ToString().Trim();
                                //item.noc_file_number            = dr["NOC_FILE_NUMBER"] == DBNull.Value ? string.Empty : dr["NOC_FILE_NUMBER"].ToString().Trim();
                                item.noc_crp_product_name       = dr["NOC_CRP_PRODUCT_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_PRODUCT_NAME"].ToString().Trim();
                                item.noc_crp_company_name       = dr["NOC_CRP_COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_COMPANY_NAME"].ToString().Trim();
                                item.noc_active_status          = dr["NOC_ACTIVE_STATUS"] == DBNull.Value ? string.Empty : dr["NOC_ACTIVE_STATUS"].ToString().Trim();
                                //item.noc_scanned_page           = dr["NOC_SCANNED_PAGE"] == DBNull.Value ? string.Empty : dr["NOC_SCANNED_PAGE"].ToString().Trim();
                                item.noc_reason_supplement      = dr["NOC_REASON_SUPPLEMENT"] == DBNull.Value ? string.Empty : dr["NOC_REASON_SUPPLEMENT"].ToString().Trim();
                                item.noc_reason_submission      = dr["NOC_REASON_SUBMISSION"] == DBNull.Value ? string.Empty : dr["NOC_REASON_SUBMISSION"].ToString().Trim();
                                item.noc_therapeutic_class      = dr["NOC_THERAPEUTIC_CLASS"] == DBNull.Value ? string.Empty : dr["NOC_THERAPEUTIC_CLASS"].ToString().Trim();
                                //item.noc_notes                  = dr["NOC_NOTES"] == DBNull.Value ? string.Empty : dr["NOC_NOTES"].ToString().Trim();
                                //item.noc_notes_entry_date       = dr["NOC_NOTES_ENTRY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_NOTES_ENTRY_DATE"]);
                                item.noc_last_update_date       = dr["NOC_LAST_UPDATE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_LAST_UPDATE_DATE"]);
                                //item.noc_entry_date             = dr["NOC_ENTRY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_ENTRY_DATE"]);
                                //item.noc_sbd_fname              = dr["NOC_SBD_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_SBD_FNAME"].ToString().Trim();
                                //item.noc_nd_fname               = dr["NOC_ND_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_ND_FNAME"].ToString().Trim();
                                //item.noc_ci_part_iii_fname      = dr["NOC_CI_PART_III_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_CI_PART_III_FNAME"].ToString().Trim();
                                //item.noc_pm_fname               = dr["NOC_PM_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_PM_FNAME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllNoticeOfComplianceMain()");
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
        public NoticeOfComplianceMain GetNoticeOfComplianceMainById(int id)
        {
            var form = new NoticeOfComplianceMain();
            //string commandText = "SELECT NOC_NUMBER, NOC_DATE, NOC_SUBMISSION_NUMBER, NOC_MANUFACTURER_NAME, NOC_STATUS_WITH_CONDITIONS, NOC_IS_SUPPLIMENT, NOC_IS_ADMIN, NOC_FILE_NUMBER, NOC_CRP_PRODUCT_NAME, NOC_CRP_COMPANY_NAME, NOC_ACTIVE_STATUS, NOC_SCANNED_PAGE, NOC_NOTES_ENTRY_DATE, NOC_LAST_UPDATE_DATE, NOC_ENTRY_DATE, ";
            string commandText = "SELECT NOC_NUMBER, NOC_DATE, NOC_MANUFACTURER_NAME, NOC_STATUS_WITH_CONDITIONS, NOC_IS_SUPPLIMENT, NOC_IS_ADMIN, NOC_CRP_PRODUCT_NAME, NOC_CRP_COMPANY_NAME, NOC_ACTIVE_STATUS, NOC_LAST_UPDATE_DATE, ";

            if (this.Lang.Equals("fr"))
            {
                commandText += "NOC_CRP_COUNTRY_FR_NAME AS NOC_CRP_COUNTRY_NAME, ";
                commandText += "NOC_QN_FRENCH_FNAME AS NOC_QN_FNAME, ";
                commandText += "NOC_DHCPL_FRENCH_FNAME AS NOC_DHCPL_FNAME, ";
                commandText += "NOC_FACTSHEET_FRENCH_FNAME AS NOC_FACTSHEET_FNAME, ";
                commandText += "NOC_FR_SUBMISSION_TYPE AS NOC_ON_SUBMISSION_TYPE, ";
                commandText += "NOC_FR_SUBMISSION_CLASS AS NOC_SUBMISSION_CLASS, ";
                commandText += "NOC_FR_PRODUCT_TYPE AS NOC_PRODUCT_TYPE, ";
                commandText += "NOC_FR_REASON_SUPPLEMENT AS NOC_REASON_SUPPLEMENT, ";
                commandText += "NOC_FR_REASON_SUBMISSION AS NOC_REASON_SUBMISSION, ";
                commandText += "NOC_FR_THERAPEUTIC_CLASS AS NOC_THERAPEUTIC_CLASS, ";
                commandText += "NOC_FR_NOTES AS NOC_NOTES, ";
                commandText += "NOC_SBD_FRENCH_FNAME AS NOC_SBD_FNAME, ";
                commandText += "NOC_ND_FRENCH_FNAME AS NOC_ND_FNAME,";
                commandText += "NOC_CI_PART_III_FRENCH_FNAME AS NOC_CI_PART_III_FNAME, ";
                commandText += "NOC_PM_FRENCH_FNAME AS NOC_PM_FNAME";


                //DEBUGGED CODE 20170123 Above and below.
            }
            else {
                commandText += "NOC_CRP_COUNTRY_ENG_NAME AS NOC_CRP_COUNTRY_NAME, ";
                commandText += "NOC_QN_ENGLISH_FNAME AS NOC_QN_FNAME, ";
                commandText += "NOC_DHCPL_ENGLISH_FNAME AS NOC_DHCPL_FNAME, ";
                commandText += "NOC_FACTSHEET_ENGLISH_FNAME AS NOC_FACTSHEET_FNAME, ";
                commandText += "NOC_ENG_SUBMISSION_TYPE AS NOC_ON_SUBMISSION_TYPE, ";
                commandText += "NOC_ENG_SUBMISSION_CLASS AS NOC_SUBMISSION_CLASS, ";
                commandText += "NOC_ENG_PRODUCT_TYPE AS NOC_PRODUCT_TYPE, ";
                commandText += "NOC_ENG_REASON_SUPPLEMENT AS NOC_REASON_SUPPLEMENT, ";
                commandText += "NOC_ENG_REASON_SUBMISSION AS NOC_REASON_SUBMISSION, ";
                commandText += "NOC_ENG_THERAPEUTIC_CLASS AS NOC_THERAPEUTIC_CLASS, ";
                commandText += "NOC_ENG_NOTES AS NOC_NOTES, ";
                commandText += "NOC_SBD_ENGLISH_FNAME AS NOC_SBD_FNAME, ";
                commandText += "NOC_ND_ENGLISH_FNAME AS NOC_ND_FNAME,";
                commandText += "NOC_CI_PART_III_ENGLISH_FNAME AS NOC_CI_PART_III_FNAME, ";
                commandText += "NOC_PM_ENGLISH_FNAME AS NOC_PM_FNAME";
            }
            commandText += " FROM NOC_ONLINE_OWNER.QRY_NOC_MAIN";
            commandText += " WHERE NOC_NUMBER = " + id;

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
                                form.noc_number = dr["NOC_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NOC_NUMBER"]);
                                form.noc_date = dr["NOC_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_DATE"]);
                                //form.noc_submission_number = dr["NOC_SUBMISSION_NUMBER"] == DBNull.Value ? string.Empty : dr["NOC_SUBMISSION_NUMBER"].ToString().Trim();
                                form.noc_manufacturer_name = dr["NOC_MANUFACTURER_NAME"] == DBNull.Value ? string.Empty : dr["NOC_MANUFACTURER_NAME"].ToString().Trim();
                                form.noc_status_with_conditions = dr["NOC_STATUS_WITH_CONDITIONS"] == DBNull.Value ? string.Empty : dr["NOC_STATUS_WITH_CONDITIONS"].ToString().Trim();
                                //form.noc_qn_fname = dr["NOC_QN_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_QN_FNAME"].ToString().Trim();
                                form.noc_crp_country_name = dr["NOC_CRP_COUNTRY_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_COUNTRY_NAME"].ToString().Trim();
                                //form.noc_dhcpl_fname = dr["NOC_DHCPL_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_DHCPL_FNAME"].ToString().Trim();
                                //form.noc_factsheet_fname = dr["NOC_FACTSHEET_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_FACTSHEET_FNAME"].ToString().Trim();
                                form.noc_on_submission_type = dr["NOC_ON_SUBMISSION_TYPE"] == DBNull.Value ? string.Empty : dr["NOC_ON_SUBMISSION_TYPE"].ToString().Trim();
                                form.noc_is_suppliment = dr["NOC_IS_SUPPLIMENT"] == DBNull.Value ? string.Empty : dr["NOC_IS_SUPPLIMENT"].ToString().Trim();
                                form.noc_submission_class = dr["NOC_SUBMISSION_CLASS"] == DBNull.Value ? string.Empty : dr["NOC_SUBMISSION_CLASS"].ToString().Trim();
                                form.noc_is_admin = dr["NOC_IS_ADMIN"] == DBNull.Value ? string.Empty : dr["NOC_IS_ADMIN"].ToString().Trim();
                                form.noc_product_type = dr["NOC_PRODUCT_TYPE"] == DBNull.Value ? string.Empty : dr["NOC_PRODUCT_TYPE"].ToString().Trim();
                                //form.noc_file_number = dr["NOC_FILE_NUMBER"] == DBNull.Value ? string.Empty : dr["NOC_FILE_NUMBER"].ToString().Trim();
                                form.noc_crp_product_name = dr["NOC_CRP_PRODUCT_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_PRODUCT_NAME"].ToString().Trim();
                                form.noc_crp_company_name = dr["NOC_CRP_COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["NOC_CRP_COMPANY_NAME"].ToString().Trim();
                                form.noc_active_status = dr["NOC_ACTIVE_STATUS"] == DBNull.Value ? string.Empty : dr["NOC_ACTIVE_STATUS"].ToString().Trim();
                                //form.noc_scanned_page = dr["NOC_SCANNED_PAGE"] == DBNull.Value ? string.Empty : dr["NOC_SCANNED_PAGE"].ToString().Trim();
                                form.noc_reason_supplement = dr["NOC_REASON_SUPPLEMENT"] == DBNull.Value ? string.Empty : dr["NOC_REASON_SUPPLEMENT"].ToString().Trim();
                                form.noc_reason_submission = dr["NOC_REASON_SUBMISSION"] == DBNull.Value ? string.Empty : dr["NOC_REASON_SUBMISSION"].ToString().Trim();
                                form.noc_therapeutic_class = dr["NOC_THERAPEUTIC_CLASS"] == DBNull.Value ? string.Empty : dr["NOC_THERAPEUTIC_CLASS"].ToString().Trim();
                                //form.noc_notes = dr["NOC_NOTES"] == DBNull.Value ? string.Empty : dr["NOC_NOTES"].ToString().Trim();
                                //form.noc_notes_entry_date = dr["NOC_NOTES_ENTRY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_NOTES_ENTRY_DATE"]);
                                form.noc_last_update_date = dr["NOC_LAST_UPDATE_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_LAST_UPDATE_DATE"]);
                                //form.noc_entry_date = dr["NOC_ENTRY_DATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NOC_ENTRY_DATE"]);
                                //form.noc_sbd_fname = dr["NOC_SBD_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_SBD_FNAME"].ToString().Trim();
                                //form.noc_nd_fname = dr["NOC_ND_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_ND_FNAME"].ToString().Trim();
                                //form.noc_ci_part_iii_fname = dr["NOC_CI_PART_III_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_CI_PART_III_FNAME"].ToString().Trim();
                                //form.noc_pm_fname = dr["NOC_PM_FNAME"] == DBNull.Value ? string.Empty : dr["NOC_PM_FNAME"].ToString().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetNoticeOfComplianceMainById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return form;
        }// END of NoticeOfComplianceMain

    } // END of DBConnection.

} // END of notice.
