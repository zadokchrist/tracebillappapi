using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TracebillAppApiLogic.Model;
using TracebillAppApiLogic.Controller;
using TraceBillAppApi.Filters;

namespace TraceBillAppApi.Controllers
{
    [LogAction]
    public class TraceBillAppApiController : ApiController
    {
        [HttpPost]
        [Route("api/NewApplicant")]
        public GenericResponse NewApplicant(NewConnection newConnection)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(newConnection);
                response = processor.NewApplicant();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/RegisterNewCustomer")]
        public GenericResponse RegisterNewCustomer(RegisterNewCustomer registerUser)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(registerUser);
                response = processor.RegisterNewCustomer();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/Login")]
        public GenericResponse Login(Login login)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(login);
                response = processor.Login();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/ElectronicBill")]
        public GenericResponse ElectronicBill(ElectronicBill electronicBill)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(electronicBill);
                response = processor.ElectronicBill();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/Payments")]
        public GenericResponse Payments(Payments payments)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(payments);
                response = processor.Payments();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/AccountStatement")]
        public GenericResponse AccountStatement(AccountStatement accountstatement)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(accountstatement);
                response = processor.Login();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/HistoricalReadings")]
        public GenericResponse HistoricalReadings(HistoricalReadings historicalReadings)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(historicalReadings);
                response = processor.Login();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("api/TrackComplaintStatus")]
        public GenericResponse RetrieveComplaintStatus(RetrieveComplaintStatus retrieveCompliantStatus)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(retrieveCompliantStatus);
                response = processor.RetrieveComplaintStatus();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }


        /*[HttpPost]
        [Route("api/TrackNewConnection")]
        public GenericResponse TrackNewConnection(TrackNewConnection trackNewConnection)
        {
            GenericResponse response = new GenericResponse();
            try
            {
                Processor processor = new Processor(trackNewConnection);
                response = processor.TrackNewConnection();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }*/

        
    }
}