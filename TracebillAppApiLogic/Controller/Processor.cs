using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracebillAppApiLogic.Model;

namespace TracebillAppApiLogic.Controller
{
    public class Processor
    {
        DatabaseClass databaseClass = new DatabaseClass();
        NewConnection newConnection;
        RegisterNewCustomer registerUser;
        Login login;
        ElectronicBill electronicBill;
        Payments payments;
        HistoricalReadings historicalReadings;
        AccountStatement accountStatement;
        RetrieveComplaintStatus retrieveComplaintStatus;
        TrackNewConnection trackNewConnection;
        DataTable dataTable;
        Ticket ticket;

        public Processor(NewConnection newConnection)
        {
            this.newConnection = newConnection;
        }

        public Processor(RegisterNewCustomer registerUser) 
        {
            this.registerUser = registerUser;
        }

        public Processor(Login login)
        {
            this.login = login;
        }

        public Processor(ElectronicBill electronicBill)
        {
            this.electronicBill = electronicBill;
        }

       

        public Processor(HistoricalReadings historicalReadings)
        {
            this.historicalReadings = historicalReadings;
        }

        public Processor(Payments payments)
        {
            this.payments = payments;
        }

        public Processor(RetrieveComplaintStatus retrieveComplaintStatus)
        {
            this.retrieveComplaintStatus = retrieveComplaintStatus;
        }


        public Processor(AccountStatement accountStatement)
        {
            this.accountStatement = accountStatement;
        }

        public Processor(TrackNewConnection trackNewConnection)
        {
            this.trackNewConnection = trackNewConnection;
        }

        public Processor(Ticket ticket) 
        {
            this.ticket = ticket;
        }

        public GenericResponse NewApplicant()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.CreateCustomer(newConnection.applicationID, newConnection.applicationNumber, newConnection.firstNam, newConnection.lastName,
                    newConnection.otherName, newConnection.physicalAddress, newConnection.emailAddress, newConnection.ocupation, newConnection.workPlace, newConnection.telephone,
                    newConnection.countryId, newConnection.state, newConnection.constituency, newConnection.city, newConnection.street, newConnection.village, newConnection.zipCode,
                    newConnection.division, newConnection.IdNumber, newConnection.IdTypeID, newConnection.customerType, newConnection.connectionType, newConnection.optionID, newConnection.serviceID,
                    newConnection.classID, newConnection.statusID, newConnection.capturedBy, newConnection.applicationDate, newConnection.areaId, newConnection.branchId);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse RegisterNewCustomer()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.RegisterNewCustomer(registerUser.custRef, registerUser.firstNam, registerUser.lastName, registerUser.telephone, registerUser.emailAddress);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse Login()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.Login(login.custRef, login.password);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse ElectronicBill()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.ElectronicBill(electronicBill.custRef, electronicBill.period);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse Payments()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.Payments(payments.custRef);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse RetrieveComplaintStatus()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.ReportComplaint(retrieveComplaintStatus.ticketID);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public TicketSearch GetTickets()
        {
            TicketSearch ticketSearch = new TicketSearch();
            try
            {
                dataTable = databaseClass.GetTicketes();
                if (dataTable.Rows.Count > 0)
                {
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        Ticket ticket = new Ticket();
                        ticket.ticket_id = dr["ticket_id"].ToString();
                        ticket.ComplainantType = dr["ComplaintType"].ToString();
                        ticket.CustRef = dr["CustRef"].ToString();
                        ticket.CustName = dr["CustName"].ToString();
                        ticket.ComplaintSource = dr["ComplaintSource"].ToString();
                        ticket.ComplaintCategory = dr["ComplaintCategory"].ToString();
                        ticket.ComplaintSubCategory = dr["CompSubCategory"].ToString();
                        ticket.CustContact = dr["CustPhone"].ToString();
                        ticket.email_id = dr["email_id"].ToString();
                        ticket.prioprity = dr["prioprity"].ToString();
                        ticket.status = dr["status"].ToString();
                        ticket.posting_date = dr["posting_date"].ToString();

                        tickets.Add(ticket);
                    }
                    ticketSearch.tickets = tickets;
                    ticketSearch.IsSuccessful = true;
                    ticketSearch.ErrorMessage = "SUCCESS";
                }
                else
                {
                    ticketSearch.IsSuccessful = false;
                    ticketSearch.ErrorMessage = "NO TICKETS FOUND";

                }
            }
            catch (Exception ex)
            {
                databaseClass.LogError("GetTickets", "TicketProcessor", ex.Message, "LiquidCRM");
                ticketSearch.IsSuccessful = false;
                ticketSearch.ErrorMessage = ex.Message;
            }
            return ticketSearch;
        }
        public TicketSearch GetTicketById()
        {
            TicketSearch ticketSearch = new TicketSearch();
            try
            {
                dataTable = databaseClass.GetTicketById(ticket.ticket_id);
                if (dataTable.Rows.Count > 0)
                {
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        Ticket ticket = new Ticket();
                        ticket.ticket_id = dr["ticket_id"].ToString();
                        ticket.ComplainantType = dr["ComplaintType"].ToString();
                        ticket.CustRef = dr["CustRef"].ToString();
                        ticket.CustName = dr["CustName"].ToString();
                        ticket.ComplaintSource = dr["ComplaintSource"].ToString();
                        ticket.ComplaintCategory = dr["ComplaintCategory"].ToString();
                        ticket.ComplaintSubCategory = dr["CompSubCategory"].ToString();
                        ticket.CustContact = dr["CustPhone"].ToString();
                        ticket.email_id = dr["email_id"].ToString();
                        ticket.prioprity = dr["prioprity"].ToString();
                        ticket.TicketDetails = dr["TicketDetails"].ToString();
                        ticket.status = dr["status"].ToString();
                        ticket.posting_date = dr["posting_date"].ToString();
                        tickets.Add(ticket);
                    }
                    ticketSearch.tickets = tickets;
                    ticketSearch.IsSuccessful = true;
                    ticketSearch.ErrorMessage = "SUCCESS";
                }
                else
                {
                    ticketSearch.IsSuccessful = false;
                    ticketSearch.ErrorMessage = "NO TICKETS FOUND";

                }
            }
            catch (Exception ex)
            {
                databaseClass.LogError("GetTickets", "TicketProcessor", ex.Message, "TRACEBILLAPP");
                ticketSearch.IsSuccessful = false;
                ticketSearch.ErrorMessage = ex.Message;
            }
            return ticketSearch;
        }

        public TicketSearch GetTicketById(string ticketid)
        {
            TicketSearch ticketSearch = new TicketSearch();
            try
            {
                dataTable = databaseClass.GetTicketById(ticketid);
                if (dataTable.Rows.Count > 0)
                {
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        Ticket ticket = new Ticket();
                        ticket.ticket_id = dr["ticket_id"].ToString();
                        ticket.ComplainantType = dr["ComplaintType"].ToString();
                        ticket.CustRef = dr["CustRef"].ToString();
                        ticket.CustName = dr["CustName"].ToString();
                        ticket.ComplaintSource = dr["ComplaintSource"].ToString();
                        ticket.ComplaintCategory = dr["ComplaintCategory"].ToString();
                        ticket.ComplaintSubCategory = dr["CompSubCategory"].ToString();
                        ticket.CustContact = dr["CustPhone"].ToString();
                        ticket.email_id = dr["email_id"].ToString();
                        ticket.prioprity = dr["prioprity"].ToString();
                        ticket.TicketDetails = dr["TicketDetails"].ToString();
                        ticket.status = dr["status"].ToString();
                        ticket.posting_date = dr["posting_date"].ToString();
                        tickets.Add(ticket);
                    }
                    ticketSearch.tickets = tickets;
                    ticketSearch.IsSuccessful = true;
                    ticketSearch.ErrorMessage = "SUCCESS";
                }
                else
                {
                    ticketSearch.IsSuccessful = false;
                    ticketSearch.ErrorMessage = "NO TICKETS FOUND";

                }
            }
            catch (Exception ex)
            {
                databaseClass.LogError("GetTickets", "TicketProcessor", ex.Message, "LiquidCRM");
                ticketSearch.IsSuccessful = false;
                ticketSearch.ErrorMessage = ex.Message;
            }
            return ticketSearch;
        }

        public TicketResolutionSearch GetTicketResolutionDetails()
        {
            TicketResolutionSearch ticketResolutionSearch = new TicketResolutionSearch();
            try
            {
                dataTable = databaseClass.GetTicketResolutionDetails(ticket.ticket_id);
                if (dataTable.Rows.Count > 0)
                {
                    ticketResolutionSearch.IsSuccessful = true;
                    List<TicketResolution> ticketResolutions = new List<TicketResolution>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        TicketResolution ticketResolution = new TicketResolution();
                        ticketResolution.RecordDate = dr["RecordDate"].ToString();
                        ticketResolution.RecordId = dr["RecordId"].ToString();
                        ticketResolution.ResolutionDetails = dr["ResolutionDetails"].ToString();
                        ticketResolution.Status = dr["Status"].ToString();
                        ticketResolution.Ticket_id = dr["Ticket_id"].ToString();
                        ticketResolution.EscalatedTo = dr["EscalatedTo"].ToString();
                        ticketResolution.RecordedBy = dr["RecordedBy"].ToString();
                        ticketResolutions.Add(ticketResolution);

                    }
                    ticketResolutionSearch.ticketResolutions = ticketResolutions;
                }
                else
                {
                    ticketResolutionSearch.IsSuccessful = false;
                    ticketResolutionSearch.ErrorMessage = "NO RESOLUTION FOUND";
                }
            }
            catch (Exception ex)
            {
                ticketResolutionSearch.IsSuccessful = false;
                ticketResolutionSearch.ErrorMessage = ex.Message;
            }
            return ticketResolutionSearch;
        }
        public GenericResponse ResolveTicket()
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.Resolveticket(ticket.ticket_id, ticket.admin_remark, ticket.resolvedby);
                response.IsSuccessful = true;
                response.ErrorMessage = "SUCCESSFUL";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse RecordTicket()
        {
            GenericResponse response = new GenericResponse();
            try
            {

                dataTable = databaseClass.InsertTicket(ticket.ComplainantType, ticket.CustRef, ticket.CustName, ticket.ComplaintSource, ticket.ComplaintCategory,
                    ticket.ComplaintSubCategory, ticket.CustContact, ticket.email_id, ticket.prioprity, ticket.TicketDetails);
                if (dataTable.Rows.Count > 0)
                {
                    response.IsSuccessful = true;
                    response.ErrorMessage = "Ticket Created Successfully. Ticket Number " + dataTable.Rows[0]["ticket_id"].ToString();
                }
                else
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {

                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public ComplaintCategories GetComplaintCategoriesById(string categoryid)
        {
            ComplaintCategories complaintCategories = new ComplaintCategories();
            try
            {
                dataTable = databaseClass.GetComplaintCategoriesById(categoryid);
                if (dataTable.Rows.Count > 0)
                {
                    List<ComplaintCategory> complaints = new List<ComplaintCategory>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ComplaintCategory complaintCategory = new ComplaintCategory();
                        complaintCategory.CategoryId = dr["CategoryId"].ToString();
                        complaintCategory.Category = dr["Category"].ToString();
                        complaintCategory.RecordDate = dr["RecordDate"].ToString();
                        complaints.Add(complaintCategory);
                    }
                    complaintCategories.IsSuccessful = true;
                    complaintCategories.complaintCategories = complaints;
                    complaintCategories.ErrorMessage = "SUCCESSFUL";

                }
                else
                {
                    complaintCategories.IsSuccessful = false;
                    complaintCategories.ErrorMessage = "NO COMPLAINT CATEGORY FOUND";
                }
            }
            catch (Exception ex)
            {
                complaintCategories.IsSuccessful = false;
                complaintCategories.ErrorMessage = ex.Message;
            }
            return complaintCategories;
        }

        public ComplaintSubCategories GetComplaintSubCategoriesById(string subcategoryid)
        {
            ComplaintSubCategories complaintSubCategories = new ComplaintSubCategories();
            try
            {
                dataTable = databaseClass.GetComplaintSubCategoriesById(subcategoryid);
                if (dataTable.Rows.Count > 0)
                {
                    List<ComplaintSubCategory> complaintSubs = new List<ComplaintSubCategory>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ComplaintSubCategory complaintSubCategory = new ComplaintSubCategory();
                        complaintSubCategory.Category = dr["Category"].ToString();
                        complaintSubCategory.Status = (bool.Parse(dr["Status"].ToString()) == true) ? "ACTIVE" : "DISABLED";
                        complaintSubCategory.RecordDate = dr["RecordDate"].ToString();
                        complaintSubCategory.SubCategoryName = dr["SubCategoryName"].ToString();
                        complaintSubCategory.SubCategoryId = dr["SubCategoryId"].ToString();
                        complaintSubs.Add(complaintSubCategory);
                    }
                    complaintSubCategories.IsSuccessful = true;
                    complaintSubCategories.ErrorMessage = "SUCCESS";
                    complaintSubCategories.complaintSubCategories = complaintSubs;
                }
                else
                {
                    complaintSubCategories.IsSuccessful = false;
                    complaintSubCategories.ErrorMessage = "NO SUB CATEGORIES FOUND";
                }
            }
            catch (Exception ex)
            {
                complaintSubCategories.IsSuccessful = false;
                complaintSubCategories.ErrorMessage = ex.Message;
            }
            return complaintSubCategories;
        }

        public GenericResponse UpdateComplaintSubCategory(string subCategoryId, string subCategoryName)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.UpdateComplaintSubCategory(subCategoryId, subCategoryName);
                response.IsSuccessful = true;
                response.ErrorMessage = "Complaint Sub Category Updated Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GenericResponse UpdateComplaintCategory(string category, string categoryId)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.UpdateComplaintCategory(category, categoryId);
                response.IsSuccessful = true;
                response.ErrorMessage = "COMPLAINT CATEGORY UPDATED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public ComplaintCategories GetComplaintCategories()
        {
            ComplaintCategories complaintCategories = new ComplaintCategories();
            try
            {
                dataTable = databaseClass.GetComplaintCategories();
                if (dataTable.Rows.Count > 0)
                {
                    List<ComplaintCategory> complaints = new List<ComplaintCategory>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ComplaintCategory complaintCategory = new ComplaintCategory();
                        complaintCategory.CategoryId = dr["CategoryId"].ToString();
                        complaintCategory.Category = dr["Category"].ToString();
                        complaintCategory.RecordDate = dr["RecordDate"].ToString();
                        complaints.Add(complaintCategory);
                    }
                    complaintCategories.IsSuccessful = true;
                    complaintCategories.complaintCategories = complaints;
                    complaintCategories.ErrorMessage = "SUCCESSFUL";

                }
                else
                {
                    complaintCategories.IsSuccessful = false;
                    complaintCategories.ErrorMessage = "NO COMPLAINT CATEGORY FOUND";
                }
            }
            catch (Exception ex)
            {
                complaintCategories.IsSuccessful = false;
                complaintCategories.ErrorMessage = ex.Message;
            }
            return complaintCategories;
        }

        public GenericResponse RegisterComplaintSubCategory(ComplaintSubCategory subCategory)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                databaseClass.RegisterComplaintSubCategory(subCategory.CategoryId, subCategory.SubCategoryName);
                response.IsSuccessful = true;
                response.ErrorMessage = "COMPLAINT SUBCATEGORY RECORDED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public ComplaintSubCategories GetComplaintSubCategories()
        {
            ComplaintSubCategories complaintSubCategories = new ComplaintSubCategories();
            try
            {
                dataTable = databaseClass.GetComplaintSubCategories();
                if (dataTable.Rows.Count > 0)
                {
                    List<ComplaintSubCategory> complaintSubs = new List<ComplaintSubCategory>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ComplaintSubCategory complaintSubCategory = new ComplaintSubCategory();
                        complaintSubCategory.Category = dr["Category"].ToString();
                        complaintSubCategory.Status = (bool.Parse(dr["Status"].ToString()) == true) ? "ACTIVE" : "DISABLED";
                        complaintSubCategory.RecordDate = dr["RecordDate"].ToString();
                        complaintSubCategory.SubCategoryName = dr["SubCategoryName"].ToString();
                        complaintSubCategory.SubCategoryId = dr["SubCategoryId"].ToString();
                        complaintSubs.Add(complaintSubCategory);
                    }
                    complaintSubCategories.IsSuccessful = true;
                    complaintSubCategories.ErrorMessage = "SUCCESS";
                    complaintSubCategories.complaintSubCategories = complaintSubs;
                }
                else
                {
                    complaintSubCategories.IsSuccessful = false;
                    complaintSubCategories.ErrorMessage = "NO SUB CATEGORIES FOUND";
                }
            }
            catch (Exception ex)
            {
                complaintSubCategories.IsSuccessful = false;
                complaintSubCategories.ErrorMessage = ex.Message;
            }
            return complaintSubCategories;
        }



    }
}
