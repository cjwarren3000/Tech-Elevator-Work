using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIService
{
    class AccountsAPIService : AuthService
    {
        //get all users
        public List<API_User> GetUsers()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Accounts/User");
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
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
        //get all accounts
        public List<Account> AccountInfo()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Accounts");
            IRestResponse<List<Account>> response = client.Get<List<Account>>(request);
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
        //get account for logged in user
        public Account GetUsersAccount()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Accounts/User/Account");
            IRestResponse<Account> response = client.Get<Account>(request);
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
        //update the balance of an account
        public bool UpdateAccountBalance(Account accountToUpdate)
        {
            bool result = false;
            RestRequest request = new RestRequest(API_BASE_URL + "Accounts");
            request.AddJsonBody(accountToUpdate);
            IRestResponse<Account> response = client.Put<Account>(request);
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
