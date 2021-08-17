using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SC.Models;
using SC.Data;

namespace SC.Business
{
    public class BUpload
    {

        public ResponseMessage DumpData(DataTable dt)
        {
            string ErrorMessage = "";
            ResponseMessage responseMessage = new ResponseMessage();

            try
            {
                DBOperations DO = new DBOperations();
                //List<ContactsDump> contactDumps = GetMapList(dt, out ErrorMessage);

                //if (contactDumps.Count > 0)
                //{
                //    responseMessage.RCode = DO.InsertDumList(contactDumps, out ErrorMessage);
                //    responseMessage.RMessage = ErrorMessage;
                //}

                // truncate both tables 


                if (dt.Rows.Count > 0)
                {
                    responseMessage.RCode = DO.BulkInsert(dt, out ErrorMessage);
                    responseMessage.RMessage = ErrorMessage;

                }

            }
            catch(Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RException = ex.Message;
                responseMessage.RMessage = "exception"; 

            }

            

            return responseMessage;

        }

        private List<ContactsDump> GetMapList(DataTable dt, out string Error)
        {
            Error = "";
            List<ContactsDump> contactDumps = new List<ContactsDump>();

            try
            {
                contactDumps = (from DataRow dr in dt.Rows
                                select new ContactsDump()
                                {
                                    FirstName = dr["First Name"].ToString(),
                                    LastName = dr["Last Name"].ToString(),
                                    //Title = dr["Title"].ToString(),
                                    //Email = dr["Email"].ToString(),
                                    //Phone1 = dr["Phone 1"].ToString(),
                                    //Phone2 = dr["Phone 2"].ToString(),
                                    //Organization = dr["Organization"].ToString(),
                                    //CommonOrganizationName = dr["Common Organization Name"].ToString(),
                                    //Street = dr["Street"].ToString(),
                                    //City = dr["City"].ToString(),
                                    //State = dr["State"].ToString(),
                                    //County = dr["County"].ToString(),
                                    //Postal = dr["Postal"].ToString(),
                                    //Country = dr["Country"].ToString(),
                                    //Website = dr["Website"].ToString(),
                                    //Revenue = dr["Revenue"].ToString(),
                                    //Employees = dr["Employees"].ToString(),
                                    //Industries = dr["Industries"].ToString(),
                                    //SICCode = dr["SIC Code"].ToString(),
                                    //SICDescription = dr["SIC Description"].ToString(),
                                    //Accuracy = dr["Accuracy"].ToString(),
                                    //JobFunction = dr["Job Function"].ToString(),

                                }).ToList();

            }
            catch (Exception ex)
            {
                Error = "GetMapList:" + ex.Message;

            }

            return contactDumps;


        }

        public ResponseMessage GetCountryList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetCountryList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetStateList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetStateList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetCityList(string StateID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                List<string> words = StateID.TrimEnd(',').Split(',').ToList();
                List<int> stateIds = new List<int>();
                foreach (var item in words)
                {
                    stateIds.Add(Convert.ToInt32(item));
                }

                DBOperations dBOperations = new DBOperations();
                List<CityMaster> cityMasterList = new List<CityMaster>();
                List<City> cityList = dBOperations.GetCityList(stateIds);

                cityList.ForEach(rec =>
                {
                    cityMasterList.Add(new CityMaster()
                    {
                        Name = rec.Name,
                        StateID = rec.StateID
                    });
                });


                responseMessage.classobject = cityMasterList.Select(rec => new { rec.Name, rec.StateID }).Distinct().ToList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetCounty(string StateID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                List<string> words = StateID.TrimEnd(',').Split(',').ToList();
                List<int> stateIds = new List<int>();
                foreach (var item in words)
                {
                    stateIds.Add(Convert.ToInt32(item));
                }

                DBOperations dBOperations = new DBOperations();
                List<CountyMaster> countyMasterList = new List<CountyMaster>();
                List<County> cityList = dBOperations.GetCountylist(stateIds);
                cityList.ForEach(rec =>
                {
                    countyMasterList.Add(new CountyMaster()
                    {
                        Name = rec.Name,
                        StateID = rec.StateID
                    });
                });

                responseMessage.classobject = countyMasterList.Select(rec => new { rec.Name, rec.StateID }).Distinct().ToList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetPostalList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetPostalList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetJobfunctionList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetJobFunctionList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetAccuracyList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetAccuracyList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetIndustriesList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetIndustriesList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetEmployeesList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetEmployeesList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetRevenueList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetRevenueList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetSICList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetSICList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }


        public ResponseMessage GetContactList(string Title, string Email, string FirstName, string LastName, string Phone1, string Phone2, string Street, string Website, string Organization, string COrganization,
                                         string StateIds, string City, string County, string Postal, string JobFuntion, string AccuracyIds, string SICCode, string Industries, string Employees, string Revenue, int PageNo, int PerPage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                StateIds = StateIds.TrimEnd(',');
                DBOperations dBOperations = new DBOperations();
                List<int> stateIds = new List<int>();

                if (StateIds != "")
                {
                    // Get city id or state id 
                    List<string> words = StateIds.TrimEnd(',').Split(',').ToList();

                    foreach (var item in words)
                    {
                        stateIds.Add(Convert.ToInt32(item));
                    }
                }




                Postal = Postal.TrimEnd(',');
                JobFuntion = JobFuntion.TrimEnd(',');
                AccuracyIds = AccuracyIds.TrimEnd(',');
                SICCode = SICCode.TrimEnd(',');
                Industries = Industries.TrimEnd(',');
                Employees = Employees.TrimEnd(',');
                Revenue = Revenue.TrimEnd(',');


                string CityIds = string.Join(",", dBOperations.GetCityList(stateIds).Select(rec => rec.CityID).ToList());
                string CountryIds = string.Join(",", dBOperations.GetCountylist(stateIds).Select(rec => rec.ID).ToList());

                ContactResponseMaster contactResponseMaster = dBOperations.GetContactList(Title, Email, FirstName, LastName, Phone1, Phone2, Street, Website, Organization, COrganization,
                                        StateIds, CityIds, CountryIds, Postal, JobFuntion, AccuracyIds, SICCode, Industries, Employees, Revenue, PageNo, PerPage);

                if (contactResponseMaster.IsSuccess == true)
                {
                    responseMessage.RCode = 1;
                    responseMessage.RMessage = contactResponseMaster.ErrorMessage;

                    responseMessage.classobject = contactResponseMaster;
                }
                if (contactResponseMaster.IsSuccess == false)
                {
                    responseMessage.RCode = 0;
                    responseMessage.RMessage = contactResponseMaster.ErrorMessage;
                }


            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage SaveSelectedSearch(int ID, string Name, string Details)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.SaveSelectedSearch(ID, Name, Details);
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetSelectedSearchList()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetSelectedSearchList();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage DeleteSearchSelection(int ID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.DeleteSearchSelection(ID);
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetSelectedSearchByID(int ID)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetSelectedSearchByID(ID);
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }


        public ResponseMessage GetTotalContactCount()
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.GetTotalContacts();
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }


        public ResponseMessage DeleteContacts(string ContactsIds)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                ContactsIds = ContactsIds.TrimEnd(',');

                List<Int64> vContactsIds = new List<Int64>();

                if (ContactsIds != "")
                {
                    // Get city id or state id 
                    List<string> words = ContactsIds.TrimEnd(',').Split(',').ToList();

                    foreach (var item in words)
                    {
                        vContactsIds.Add(Convert.ToInt32(item));
                    }
                }


                DBOperations dBOperations = new DBOperations();
                responseMessage.classobject = dBOperations.DeleteContacts(vContactsIds);
            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;
        }

        public ResponseMessage GetProcessedData()
        {

            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.RCode = 1;
            try
            {
                DBOperations dBOperations = new DBOperations();
                string errormessage = "";
                responseMessage.RCode = dBOperations.GetProcessedData(out errormessage);
                responseMessage.RMessage = errormessage;

            }
            catch (Exception ex)
            {
                responseMessage.RCode = 0;
                responseMessage.RMessage = ex.Message;
            }

            return responseMessage;





        }

    }
}
