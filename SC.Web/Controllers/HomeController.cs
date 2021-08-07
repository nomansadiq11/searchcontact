using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SC.Business;
using Microsoft.VisualBasic.FileIO;
using SC.Models;
using System.Threading.Tasks;
using System.Threading;

namespace SC.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }



        [HttpPost]
        public JsonResult UploadData()
        {
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                DataTable dt = new DataTable();
                foreach (string upload in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[upload];


                    if (file == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                    else if (file.ContentLength > 0)
                    {
                        OleDbConnection oledbConn = new OleDbConnection();

                        var fileName = System.IO.Path.GetFileName(file.FileName);

                        var path = System.IO.Path.Combine(Server.MapPath("~/DataFile"), DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(fileName));
                        file.SaveAs(path);

                        responseMessage.RMessage = "File upload ";

                        if (System.IO.Path.GetExtension(path) == ".xls")
                        {
                            responseMessage.RMessage = "connector for excel xlls";
                            oledbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + path + "; Extended Properties =\"Excel 8.0;HDR=Yes;IMEX=2\"";

                        }
                        else if (System.IO.Path.GetExtension(path) == ".xlsx")
                        {
                            responseMessage.RMessage = "connec for xlsx";
                            oledbConn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'; ";

                        }
                        else if (System.IO.Path.GetExtension(path) == ".csv")
                        {
                            responseMessage.RMessage = "if system find path";

                            responseMessage.RCode = 1;
                            responseMessage.RMessage = path;

                            dt = GetDataTabletFromCSVFile(path);
                            responseMessage.RMessage = "get datatable from csv";

                        }


                        responseMessage.RMessage = "table count " + dt.Rows.Count.ToString();
                        BUpload bUpload = new BUpload();
                        responseMessage = bUpload.DumpData(dt);

                        //responseMessage.RMessage = "data dumped ";






                    }

                }

            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RException = ex.Message;
                responseMessage.RMessage = "Some error ";

            }






            return Json(responseMessage);
        }

        public ActionResult FindContact()
        {
            return View();
        }

        public JsonResult GetCountryList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetCountryList();

            return Json(responseMessage);
        }

        public JsonResult GetStateList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetStateList();

            return Json(responseMessage);
        }

        public JsonResult GetPostalList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetPostalList();

            return Json(responseMessage);
        }

        public JsonResult GetJobFunctionList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetJobfunctionList();

            return Json(responseMessage);
        }

        public JsonResult GetAccuracyList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetAccuracyList();

            return Json(responseMessage);
        }

        public JsonResult GetIndustriesList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetIndustriesList();

            return Json(responseMessage);
        }

        public JsonResult GetEmplooyesList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetEmployeesList();

            return Json(responseMessage);
        }

        public JsonResult GetRevenueList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetRevenueList();

            return Json(responseMessage);
        }

        public JsonResult GetSICList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetSICList();

            return Json(responseMessage);
        }

        public JsonResult GetCityList(string StateID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetCityList(StateID);

            return Json(responseMessage);
        }

        public JsonResult GetCountyList(string StateID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetCounty(StateID);

            return Json(responseMessage);
        }

        public JsonResult GetContactList(string Title, string Email, string FirstName, string LastName, string Phone1, string Phone2, string Street, string Website, string Organization, string COrganization,
                                       string StateIds, string City, string County, string Postal, string JobFuntion, string AccuracyIds, string SICCode, string Industries, string Employees, string Revenue, int PageNo, int PerPage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetContactList(Title, Email, FirstName, LastName, Phone1, Phone2, Street, Website, Organization, COrganization,
                                        StateIds, City, County, Postal, JobFuntion, AccuracyIds, SICCode, Industries, Employees, Revenue, PageNo, PerPage);

            var jsonResponse = Json(responseMessage, JsonRequestBehavior.AllowGet);
            jsonResponse.MaxJsonLength = int.MaxValue;

            return jsonResponse;
        }


        public JsonResult SaveSelection(int ID, string Name, string Details)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.SaveSelectedSearch(ID, Name, Details);

            return Json(responseMessage);
        }

        public JsonResult GetSelectedSearchList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetSelectedSearchList();

            return Json(responseMessage);
        }

        public JsonResult DeleteSearchCriteria(int ID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.DeleteSearchSelection(ID);
            return Json(responseMessage);
        }

        public JsonResult GetSelectedSearchByID(int ID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetSelectedSearchByID(ID);
            return Json(responseMessage);
        }

        public JsonResult GetTotalContactsCount()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.GetTotalContactCount();
            return Json(responseMessage);
        }

        public JsonResult DeleteContacts(string Contactids)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            BUpload bUpload = new BUpload();
            responseMessage = bUpload.DeleteContacts(Contactids);
            return Json(responseMessage);
        }

        public JsonResult ProcessedData()
        {

            ResponseMessage responseMessage = new ResponseMessage();

            BUpload bUpload = new BUpload();



            //Thread thread = new Thread(new ThreadStart(bUpload.GetProcessedData));
            //thread.IsBackground = true;
            //thread.Start();

            responseMessage = bUpload.GetProcessedData();



            return Json(responseMessage);

        }



    }

}