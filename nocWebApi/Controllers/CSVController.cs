using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using notice;

namespace nocWebApi.Controllerss
{
    public class CSVController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DownloadCSV(string dataType, string lang)
        {
            DBConnection dbConnection = new DBConnection(lang);
            var jsonResult = string.Empty;
            var fileNameDate = string.Format("{0}{1}{2}",
                           DateTime.Now.Year.ToString(),
                           DateTime.Now.Month.ToString().PadLeft(2, '0'),
                           DateTime.Now.Day.ToString().PadLeft(2, '0'));
            var fileName = string.Format(dataType + "_{0}.csv", fileNameDate);
            byte[] outputBuffer = null;
            string resultString = string.Empty;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            var json = string.Empty;

            switch (dataType)
            {
                case "drugProduct":
                    var brand = dbConnection.GetAllDrugProduct().ToList();
                    if (brand.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(brand);

                    }
                    break;

                case "nocci":   //notice of compliance complete information
                    var nocci = dbConnection.GetAllNoticeOfComplianceMain().ToList();
                    if (nocci.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(nocci);

                    }
                    break;

                //case "product":
                //    var product = dbConnection.GetAllProduct().ToList();
                //    if (product.Count > 0)
                //    {
                //        json = JsonConvert.SerializeObject(product);

                //    }
                //    break;

                case "dosageForm":
                    var dosageForm = dbConnection.GetAllDosageForm().ToList();
                    if (dosageForm.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(dosageForm);

                    }
                    break;

                case "medicinalIngredient":
                    var productIngredient = dbConnection.GetAllMedicinalIngredient().ToList();
                    if (productIngredient.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(productIngredient);

                    }
                    break;

                case "route":
                    var route = dbConnection.GetAllRoute().ToList();
                    if (route.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(route);

                    }
                    break;

                case "vetSpecies":
                    var vetSpecies = dbConnection.GetAllVetSpecies().ToList();
                    if (vetSpecies.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(vetSpecies);

                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(json))
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                if (dt.Rows.Count > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            UtilityHelper.WriteDataTable(dt, writer, true);
                            outputBuffer = stream.ToArray();
                            resultString = Encoding.UTF8.GetString(outputBuffer, 0, outputBuffer.Length);
                        }
                    }
                    result.Content = new StringContent(resultString);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                }
            }

            return result;
        }
    }
}
