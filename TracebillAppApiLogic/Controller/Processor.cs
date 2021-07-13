using System;
using System.Collections.Generic;
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

       

    }
}
