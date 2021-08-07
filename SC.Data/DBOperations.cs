using SC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SC.Data
{
    public class DBOperations
    {
        SCContext db;
        SqlConnection con;
        SqlCommand cmd;

        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SearchContact"].ToString();


        public DBOperations()
        {
            db = new SCContext();
            con = new SqlConnection(ConnectionString);
        }

        public int InsertDumList(List<ContactsDump> dumlist, out string Message)
        {
            int vReturn = 1;
            Message = "";

            try
            {
                vReturn = ExeStoreProcedure("SP_TruncateTable", out Message);

                if (vReturn == 1)
                {
                    db.tblContactsDump.AddRange(dumlist);
                    db.SaveChanges();
                    vReturn = ExeStoreProcedure("SP_ProcessContactsData", out Message);
                }
            }
            catch (Exception ex)
            {

                vReturn = 0;
                Message = "InsertDumList : " + ex.Message + " Innser exp : " + ex.InnerException.Message.ToString();
            }


            return vReturn;


        }

        public int ExeStoreProcedure(string SPName, out string Error)
        {
            Error = "";
            int vReturn = 1;

            try
            {
                con.Open();
                cmd = new SqlCommand(SPName, con);
                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error = ex.Message + " Error on following SP" + SPName;
                vReturn = 0;
            }
            finally
            {
                con.Close();
            }


            return vReturn;
        }

        public DataTable GetDataTablebySP(string SPName, SqlParameter[] parameter, out int IsSuccess, out string Error)
        {
            Error = "";
            IsSuccess = 1;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                cmd.Parameters.AddRange(parameter);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                IsSuccess = 0;
            }
            finally
            {
                con.Close();
            }


            return dt;
        }

        public DataSet GetDataSetbySP(string SPName, SqlParameter[] parameter, out int IsSuccess, out string Error)
        {
            Error = "";
            IsSuccess = 1;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                cmd.Parameters.AddRange(parameter);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                IsSuccess = 0;
            }
            finally
            {
                con.Close();
            }


            return ds;
        }

        public List<Country> GetCountryList()
        {
            return db.tblCountry.ToList();
        }

        public List<State> GetStateList()
        {
            return db.tblState.OrderBy(a => a.Code).ToList();
        }

        public List<Postal> GetPostalList()
        {
            return db.tblPostal.OrderBy(a => a.Name).ToList();
        }


        public List<JobFunction> GetJobFunctionList()
        {
            return db.tblJobFunction.OrderBy(a => a.Name).ToList();
        }

        public List<Accuracy> GetAccuracyList()
        {
            return db.tblAccuracy.OrderBy(a => a.Name).ToList();
        }



        public List<Industries> GetIndustriesList()
        {
            return db.tblIndustries.OrderBy(a => a.Name).ToList();
        }

        public List<SIC> GetSICList()
        {
            return db.tblSIC.OrderBy(a => a.Code).ToList();
        }

        public List<Employees> GetEmployeesList()
        {
            return db.tblEmployees.OrderBy(a => a.Name).ToList();
        }

        public List<Revenue> GetRevenueList()
        {
            return db.tblRevenue.OrderBy(a => a.Name).ToList();
        }

        public List<County> GetCountylist(List<int> StateID)
        {

            return db.tblCounty.Where(a => StateID.Contains(a.StateID)).OrderBy(a => a.Name).Distinct().ToList(); ;
        }

        public List<City> GetCityList(List<int> StateID)
        {
            return db.tblCity.Where(a => StateID.Contains(a.StateID)).OrderBy(a => a.Name).ToList(); ;
        }


        public ContactResponseMaster GetContactList(string Title, string Email, string FirstName, string LastName, string Phone1, string Phone2, string Street, string Website, string Organization, string COrganization,
                                        string StateIds, string City, string County, string Postal, string JobFuntion, string Accuracy, string SICCode, string Industries, string Employees, string Revenue, int PageNo, int PerPage)
        {
            ContactResponseMaster contactResponseMaster = new ContactResponseMaster();
            int IsSuccess = 1;
            string ErrorMessage = "SP_SearchContact";

            SqlParameter[]
                parameter = new SqlParameter[] {
                new SqlParameter("@Title", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Title),
                new SqlParameter("@FirstName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, FirstName),
                new SqlParameter("@LastName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LastName),
                new SqlParameter("@Email", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Email),
                new SqlParameter("@Phone1", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Phone1),
                new SqlParameter("@Phone2", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Phone2),
                new SqlParameter("@Street", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Street),
                new SqlParameter("@Website", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Website),
                new SqlParameter("@Organization", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Organization),
                new SqlParameter("@CommonOrganizationName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, COrganization),

                new SqlParameter("@StateIds", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, StateIds),
                new SqlParameter("@City", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, City),
                new SqlParameter("@County", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, County),
                new SqlParameter("@Postal", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Postal),
                new SqlParameter("@JobFuntion", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, JobFuntion),
                new SqlParameter("@Accuracy", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Accuracy),
                new SqlParameter("@SICCode", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SICCode),
                new SqlParameter("@Industries", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Industries),
                new SqlParameter("@Employees", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Employees),
                new SqlParameter("@Revenue", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Revenue),

                new SqlParameter("@PageNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PageNo),
                new SqlParameter("@RowCountPerPage", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PerPage),
            };




            try

            {
                // fetching data from database
                DataSet ds = GetDataSetbySP("SP_SearchContact", parameter, out IsSuccess, out ErrorMessage);

                if (IsSuccess == 0)
                {
                    contactResponseMaster.IsSuccess = false;
                    contactResponseMaster.ErrorMessage = ErrorMessage;
                    contactResponseMaster.contactMaster = null;
                    contactResponseMaster.TotalContact = 0;
                }
                else
                {
                    contactResponseMaster.contactMaster = (from DataRow dr in ds.Tables[0].Rows
                                                           select new ContactMaster()
                                                           {
                                                               ContactID = Convert.ToInt32(dr["ContactID"]),
                                                               FirstName = dr["FirstName"].ToString(),
                                                               LastName = dr["LastName"].ToString(),
                                                               Title = dr["Title"].ToString(),
                                                               Email = dr["Email"].ToString(),
                                                               Phone1 = dr["Phone1"].ToString(),
                                                               Phone2 = dr["Phone2"].ToString(),
                                                               Street = dr["Street"].ToString(),
                                                               Website = dr["Website"].ToString(),
                                                               Organization = dr["Organization"].ToString(),
                                                               CommonOrganizationName = dr["CommonOrganizationName"].ToString(),
                                                               StateCode = dr["StateCode"].ToString(),
                                                               CityName = dr["CityName"].ToString(),
                                                               PostCode = dr["PostalCode"].ToString(),
                                                               JobFunctionName = dr["JobFunctionName"].ToString(),
                                                               AccuracyName = dr["AccuracyName"].ToString(),
                                                               SICDetails = dr["SICCode"].ToString() + " | " + dr["SICDes"].ToString(),
                                                               IndustriesName = dr["IndustriesName"].ToString(),
                                                               EmployeeName = dr["EmployeeName"].ToString(),
                                                               RevenueName = dr["RevenueName"].ToString(),
                                                               CountyName = dr["CountyName"].ToString(),
                                                           }).ToList();


                    contactResponseMaster.TotalContact = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);

                    contactResponseMaster.IsSuccess = true;
                    contactResponseMaster.ErrorMessage = ErrorMessage;

                }



            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
            }


            return contactResponseMaster;
        }

        public SelectedSearch SaveSelectedSearch(int ID, string Name, string Details)
        {
            SelectedSearch selectedSearch = new SelectedSearch();
            if (ID > 0)
            {
                selectedSearch = db.tblSelectedSearch.SingleOrDefault(rec => rec.ID == ID);
                selectedSearch.Details = Details;
                selectedSearch.cDate = DateTime.Now;
                db.SaveChanges();
            }
            if (ID == 0)
            {

                selectedSearch.Name = Name;
                selectedSearch.Details = Details;
                selectedSearch.cDate = DateTime.Now;
                db.tblSelectedSearch.Add(selectedSearch);
                db.SaveChanges();
            }

            return selectedSearch;
        }

        public List<SelectedSearch> GetSelectedSearchList()
        {
            return db.tblSelectedSearch.OrderByDescending(a => a.cDate).ToList();
        }

        public SelectedSearch DeleteSearchSelection(int ID)
        {
            SelectedSearch selectedSearch = new SelectedSearch();
            selectedSearch = db.tblSelectedSearch.SingleOrDefault(a => a.ID == ID);
            selectedSearch = db.tblSelectedSearch.Remove(selectedSearch);
            db.SaveChanges();
            return selectedSearch;
        }

        public SelectedSearch GetSelectedSearchByID(int ID)
        {
            SelectedSearch selectedSearch = new SelectedSearch();
            selectedSearch = db.tblSelectedSearch.SingleOrDefault(a => a.ID == ID);
            return selectedSearch;
        }

        public int GetTotalContacts()
        {
            return db.tblContact.Count();
        }

        public int DeleteContacts(List<Int64> ContactIDList)
        {

            List<Contact> contactlist = new List<Contact>();
            contactlist = db.tblContact.Where(a => ContactIDList.Contains(a.ContactID)).ToList();
            List<string> emails = new List<string>();
            foreach (var item in contactlist)
            {
                emails.Add(item.Email);
            }

            List<ContactsDump> contactsDumpsList = new List<ContactsDump>();
            contactsDumpsList = db.tblContactsDump.Where(a => emails.Contains(a.Email)).ToList();

            db.tblContact.RemoveRange(contactlist);
            db.tblContactsDump.RemoveRange(contactsDumpsList);
            db.SaveChanges();
            return 1;

        }


        //public List<ContactMaster> GetContactList(string Title, string Email, string FirstName, string LastName, string Phone1, string Phone2, string Street, string Website, string Organization, string COrganization,
        //                                Country country, State state, City city, Postal postal, JobFunction jobFunction, Accuracy accuracy, SIC sIC, Industries industries, Employees employees, Revenue revenue,
        //                                County county)
        //{
        //    List<ContactMaster> contactMaster = new List<ContactMaster>();

        //    var ObjectList = (from c in db.tblContact
        //                      join ctry in db.tblCountry on c.CountryID equals ctry.CountryID
        //                      join st in db.tblState on c.StateID equals st.StateID
        //                      join cty in db.tblCity on c.CityID equals cty.CityID
        //                      join po in db.tblPostal on c.PostalID equals po.ID
        //                      join jf in db.tblJobFunction on c.JobFunctionID equals jf.ID
        //                      join ac in db.tblAccuracy on c.AccuracyID equals ac.ID
        //                      join sic in db.tblSIC on c.SICID equals sic.ID
        //                      join indu in db.tblIndustries on c.IndustriesID equals indu.ID
        //                      join emp in db.tblEmployees on c.EmployeesID equals emp.ID
        //                      join rev in db.tblRevenue on c.RevenueID equals rev.ID
        //                      join count in db.tblCounty on c.COUNTYID equals count.ID
        //                      select new
        //                      {
        //                          c.Title,
        //                          c.Email,
        //                          c.FirstName,
        //                          c.LastName,
        //                          c.Phone1,
        //                          c.Phone2,
        //                          c.Street,
        //                          c.Website,
        //                          c.Organization,
        //                          c.CommonOrganizationName,
        //                          c.CountryID,
        //                          c.StateID,
        //                          c.CityID,
        //                          c.PostalID,
        //                          c.JobFunctionID,
        //                          c.AccuracyID,
        //                          c.SICID,
        //                          c.IndustriesID,
        //                          c.EmployeesID,
        //                          c.RevenueID,
        //                          c.COUNTYID,
        //                          CountryName = ctry.Name,
        //                          StateCode = st.Code,
        //                          CityName = cty.Name,
        //                          PostalCode = po.Name,
        //                          JobFunctionName = jf.Name,
        //                          AccuracyName = ac.Name,
        //                          SICCode = sic.Code,
        //                          SICDes = sic.Description,
        //                          IndustriesName = indu.Name,
        //                          EmployeeName = emp.Name,
        //                          RevenueName = rev.Name,
        //                          CountyName = count.Name

        //                      }
        //                      );


        //    if (Title != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Title.Contains(Title));
        //    }
        //    if (FirstName != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.FirstName.Contains(FirstName));
        //    }
        //    if (LastName != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.LastName.Contains(LastName));
        //    }
        //    if (Email != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Email.Contains(Email));
        //    }
        //    if (Phone1 != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Phone1.Contains(Phone1));
        //    }
        //    if (Phone2 != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Phone2.Contains(Phone2));
        //    }
        //    if (Street != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Street.Contains(Street));
        //    }
        //    if (Website != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Website.Contains(Website));
        //    }
        //    if (Organization != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.Organization.Contains(Organization));
        //    }
        //    if (COrganization != "")
        //    {
        //        ObjectList = ObjectList.Where(a => a.CommonOrganizationName.Contains(COrganization));
        //    }
        //    //if (country != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.CountryID == country.CountryID);
        //    //}
        //    //if (state != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.StateID == state.StateID);
        //    //}
        //    //if (city != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.CityID == city.CityID);
        //    //}
        //    //if (postal != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.PostalID == postal.ID);
        //    //}
        //    //if (jobFunction != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.JobFunctionID == jobFunction.ID);
        //    //}
        //    //if (accuracy != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.AccuracyID == accuracy.ID);
        //    //}
        //    //if (sIC != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.SICID == sIC.ID);
        //    //}
        //    //if (industries != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.IndustriesID == industries.ID);
        //    //}
        //    //if (employees != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.EmployeesID == employees.ID);
        //    //}
        //    //if (revenue != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.RevenueID == revenue.ID);
        //    //}
        //    //if (county != null)
        //    //{
        //    //    ObjectList = ObjectList.Where(a => a.COUNTYID == county.ID);
        //    //}



        //    ObjectList.ToList().ForEach(rec =>
        //    {
        //        contactMaster.Add(new ContactMaster()
        //        {
        //            Title = rec.Title,
        //            Email = rec.Email,
        //            FirstName = rec.FirstName,
        //            LastName = rec.LastName
        //        });
        //    });






        //    return contactMaster;
        //}


        public int BulkInsert(DataTable dt, out string ErrorMessage)
        {
            int vReturnVal = 1;
            int IsTruncated = 1;
            int IsFetchedMainTbl = 1;
            int IsProcessedData = 1;
            ErrorMessage = "";


            IsTruncated = ExeStoreProcedure("SP_TruncateTable", out ErrorMessage);
            vReturnVal = IsTruncated;

            if (IsTruncated == 1)
            {
                try
                {
                    SqlBulkCopy bulkCopy =
                            new SqlBulkCopy
                            (
                            con,
                            SqlBulkCopyOptions.TableLock |
                            SqlBulkCopyOptions.FireTriggers |
                            SqlBulkCopyOptions.UseInternalTransaction,
                            null
                            );

                    // set the destination table name
                    bulkCopy.DestinationTableName = "ContactsDumpmain";
                    con.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dt);
                    vReturnVal = 1;
                }
                catch (Exception ex)
                {
                    vReturnVal = 0;
                    ErrorMessage = ex.Message + "Eror while uploading in main table";
                }
                finally
                {
                    con.Close();
                }

            }


            if (vReturnVal == 1 && IsTruncated == 1)
            {
                IsFetchedMainTbl = ExeStoreProcedure("SP_GetContactsFromMainTable", out ErrorMessage);
                vReturnVal = IsFetchedMainTbl;
            }

            if (IsFetchedMainTbl == 1 && vReturnVal == 1 && IsTruncated == 1)
            {
                IsProcessedData = ExeStoreProcedure("SP_ProcessContactsData", out ErrorMessage);
                vReturnVal = IsProcessedData;


            }








            return vReturnVal;
        }

        public int GetProcessedData(out string Message)
        {
            int vretval = 1;
            string ErrorMessage = "";

            vretval = ExeStoreProcedure("SP_GetProcessedContactsData", out ErrorMessage);
            Message = ErrorMessage;
            return vretval;
        }







    }
}
