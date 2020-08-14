using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIService
{
    class TransfersAPIService : AuthService
    {
        //Get all transfers that the logged in user is a part of
        public List<Transfer> GetTransfersForUser()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Transfers");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {

                throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
        //Get all pending transfers that the logged in user needs to approve/decline
        public List<Transfer> GetPendingTransfersForUser()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Transfers/Pending");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {

                throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
        //Update a pending transfer
        public bool UpdatePendingTeRequest(Transfer transfer)
        {
            bool result = false;
            RestRequest request = new RestRequest(API_BASE_URL + "Transfers/Pending");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Put<Transfer>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {

                throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            else
            {
                result = true;
            }
            return result;
        }
        //Create a transfer between two users
        public bool CreateTransfer(Transfer newTransfer)
        {
            bool result = false;
            RestRequest request = new RestRequest(API_BASE_URL + "Transfers");
            request.AddJsonBody(newTransfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {

                throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
