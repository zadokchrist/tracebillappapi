using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracebillAppApiLogic.Model;

namespace TracebillAppApiLogic.Controller
{
    public class TicketProcessor
    {
        Ticket ticket;
        DatabaseClass dh = new DatabaseClass();
        DataTable dataTable;
        public TicketProcessor(Ticket ticket)
        {
            this.ticket = ticket;
        }
        public TicketProcessor()
        { }

        public TicketSearch GetTickets()
        {
            TicketSearch ticketSearch = new TicketSearch();
            try
            {
                dataTable = dh.GetTicketes();
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
                dh.LogError("GetTickets", "TicketProcessor", ex.Message, "LiquidCRM");
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
                dataTable = dh.GetTicketById(ticket.ticket_id);
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
                dh.LogError("GetTickets", "TicketProcessor", ex.Message, "TRACEBILLAPP");
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
                dataTable = dh.GetTicketById(ticketid);
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
                dh.LogError("GetTickets", "TicketProcessor", ex.Message, "LiquidCRM");
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
                dataTable = dh.GetTicketResolutionDetails(ticket.ticket_id);
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
                dh.Resolveticket(ticket.ticket_id, ticket.admin_remark, ticket.resolvedby);
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

                dataTable = dh.InsertTicket(ticket.ComplainantType, ticket.CustRef, ticket.CustName, ticket.ComplaintSource, ticket.ComplaintCategory,
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
                dataTable = dh.GetComplaintCategoriesById(categoryid);
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
                dataTable = dh.GetComplaintSubCategoriesById(subcategoryid);
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
                dh.UpdateComplaintSubCategory(subCategoryId, subCategoryName);
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
                dh.UpdateComplaintCategory(category, categoryId);
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
                dataTable = dh.GetComplaintCategories();
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
                dh.RegisterComplaintSubCategory(subCategory.CategoryId, subCategory.SubCategoryName);
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
                dataTable = dh.GetComplaintSubCategories();
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
