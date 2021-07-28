using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Controller
{
    public class DatabaseClass
    {
        private DbCommand command;
        DataTable returnData;
        Database billingdb;
        Database crmdb;

        internal DatabaseClass()
        {
            billingdb = DatabaseFactory.CreateDatabase("BILLING");
            crmdb = DatabaseFactory.CreateDatabase("CRM");
        }

        //New Connection Application
        internal void CreateCustomer(double applicationID, string applicationNumber, string firstNam, string lastName, string otherName, string physicalAddress, string emailAddress,
        string ocupation, string workPlace, string telephone, int countryId, string state, string constituency, string city,
        string street, string village, string zipCode, string division, string IdNumber, int IdTypeID, string customerType,
        int connectionType, int optionID, int serviceID, int classID, int statusID, int capturedBy, DateTime applicationDate, int areaId, int branchId)
        {
            command = billingdb.GetStoredProcCommand("Sp_SaveApplication", applicationID, applicationNumber, firstNam, lastName, otherName, physicalAddress, emailAddress,
          ocupation, workPlace, telephone, countryId, state, constituency, city, street, village, zipCode, division, IdNumber, IdTypeID, customerType,
          connectionType, optionID, serviceID, classID, statusID, capturedBy, applicationDate, areaId, branchId);
            billingdb.ExecuteNonQuery(command);
        }

        //Register New Customer
        internal void RegisterNewCustomer(string custRef, string firstNam, string lastName, string telephone, string emailAddress)
        {
            command = billingdb.GetStoredProcCommand("Mob_RegisterNewCustomer", custRef, firstNam, lastName, telephone, emailAddress);
            billingdb.ExecuteNonQuery(command);
        }

        //Raise Complaint
        internal void ReportComplaint(string custRef, string description, string priority, string subject, string ticketSource, string email_id, string attachment )
        {
            command = crmdb.GetStoredProcCommand("[InsertTicket]", custRef, description, priority, subject, ticketSource, email_id, attachment);
            billingdb.ExecuteNonQuery(command); 
       
        }

        //Retrieve Complaint Status
        internal void ReportComplaint(string ticketNo)
        {
            command = crmdb.GetStoredProcCommand("[GetTicketById]", ticketNo);
            billingdb.ExecuteNonQuery(command);

        }

        //Login
        internal void Login(string custRef, string password)
        {
            command = billingdb.GetStoredProcCommand("[Mob_Login]", custRef, password);
            billingdb.ExecuteNonQuery(command);
        }

        //E-Bill
        internal void ElectronicBill(string custRef, string period)
        {
            command = billingdb.GetStoredProcCommand("[Mob_GetElectronicBill]", custRef, period);
            billingdb.ExecuteNonQuery(command);
        }

        //Payments
        internal void Payments(string custRef)
        {
            command = billingdb.GetStoredProcCommand("[Mob_HistoricalPayments]", custRef);
            billingdb.ExecuteNonQuery(command);
        }

        //Readings
        internal void HistoricalReadings(string custRef)
        {
            command = billingdb.GetStoredProcCommand("[Mob_GetHistoricalReadings]", custRef);
            billingdb.ExecuteNonQuery(command);
        }

        //Account Statement
        internal void AccountStatement(string custRef, string startDate)
        {
            command = billingdb.GetStoredProcCommand("[Mob_GetAccountStatement]", custRef, startDate);
            billingdb.ExecuteNonQuery(command);
        }

        //Track New Connection
        internal void TrackNewConnection(string custRef, string startDate)
        {
            command = billingdb.GetStoredProcCommand("[Mob_GetAccountStatement]", custRef, startDate);
            billingdb.ExecuteNonQuery(command);
        }

        internal DataTable GetTicketes()
        {
            command = crmdb.GetStoredProcCommand("GetTickets");
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal DataTable GetTicketById(string ticket_id)
        {
            command = crmdb.GetStoredProcCommand("GetTicketById", ticket_id);
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal void LogError(string method, string Level, string error, string loggedby)
        {
            command = crmdb.GetStoredProcCommand("LogSystemError", method, Level, error, loggedby);
                crmdb.ExecuteNonQuery(command);
        }

        internal DataTable GetTicketResolutionDetails(string ticket_id)
        {
            command = crmdb.GetStoredProcCommand("GetTicketResolutionDetails", ticket_id);
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal void Resolveticket(string ticket_id, string admin_remark, string resolvedby)
        {
            command = crmdb.GetStoredProcCommand("Resolveticket", ticket_id, admin_remark, resolvedby);
            crmdb.ExecuteNonQuery(command);
        }

        internal DataTable InsertTicket(string complainantType, string custRef, string custName, string complaintSource, string complaintCategory, string complaintSubCategory, string custContact, string email_id, string prioprity, string ticketDetails)
        {
            command = crmdb.GetStoredProcCommand("InsertTicket", complainantType, custRef, custName, complaintSource, complaintCategory, complaintSubCategory, custContact, email_id, prioprity, ticketDetails);
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal DataTable GetComplaintCategoriesById(string categoryid)
        {
            command = crmdb.GetStoredProcCommand("GetComplaintCategoriesById", categoryid);
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal DataTable GetComplaintSubCategoriesById(string subcategoryid)
        {
            command = crmdb.GetStoredProcCommand("GetComplaintSubCategoriesById", subcategoryid);
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal void UpdateComplaintSubCategory(string subCategoryId, string subCategoryName)
        {
            command = crmdb.GetStoredProcCommand("UpdateComplaintSubCategory", subCategoryId, subCategoryName);
            crmdb.ExecuteNonQuery(command);
        }

        internal void UpdateComplaintCategory(string category, string categoryId)
        {
            command = crmdb.GetStoredProcCommand("UpdateComplaintCategory", category, categoryId);
            crmdb.ExecuteNonQuery(command);
        }

        internal DataTable GetComplaintCategories()
        {
            command = crmdb.GetStoredProcCommand("GetComplaintCategories");
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }

        internal void RegisterComplaintSubCategory(string categoryId, string subCategoryName)
        {
            command = crmdb.GetStoredProcCommand("RegisterComplaintSubCategory", categoryId, subCategoryName);
            crmdb.ExecuteNonQuery(command);
        }

        internal DataTable GetComplaintSubCategories()
        {
            command = crmdb.GetStoredProcCommand("GetComplaintSubCategories");
            returnData = crmdb.ExecuteDataSet(command).Tables[0];
            return returnData;
        }
    }
}
