using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;
using TenmoServer.Models;

namespace TenmoClient.APIServcies
{
    class MoneyService : AuthService
    {
        private readonly static string API_BASE_URL = "https://localhost:44315/money/";

        public decimal GetBalance()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "balance");
            IRestResponse<decimal> response = client.Get<decimal>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public List<API_User> GetUsers()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "users");
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public List<TransferRecord> GetTransfers()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "transfers");
            IRestResponse<List<TransferRecord>> response = client.Get<List<TransferRecord>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public bool TransferFrom(int toId, int fromId, decimal money)
        {
            RestRequest request = new RestRequest(API_BASE_URL + "transferfrom");
            Transfer transfer = new Transfer
            {
                FromUser = fromId,
                ToUser = toId,
                Amount = money
            };

            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Post<bool>(request);

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

        public bool TransferTo(int fromId, int toId, decimal money)
        {
            RestRequest request = new RestRequest(API_BASE_URL + "transferto");
            Transfer transfer = new Transfer
            {
                FromUser = fromId,
                ToUser = toId,
                Amount = money
            };

            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Post<bool>(request);

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

        public bool AcceptRejectPending(TransferRecord transfer, int selection)
        {
            RestRequest request = new RestRequest(API_BASE_URL + "acceptrejectpending/" + selection);
            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Put<bool>(request);

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

        public Dictionary<int, int> GetAccountToUser()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "accounttouser");
            IRestResponse<Dictionary<int, int>> response = client.Get<Dictionary<int, int>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public Dictionary<int, string> GetUserToName()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "usertoname");
            IRestResponse<Dictionary<int, string>> response = client.Get<Dictionary<int, string>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public Dictionary<int, string> GetTypeToName()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "typetoname");
            IRestResponse<Dictionary<int, string>> response = client.Get<Dictionary<int, string>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }

        public Dictionary<int, string> GetStatusToName()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "statustoname");
            IRestResponse<Dictionary<int, string>> response = client.Get<Dictionary<int, string>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                {
                    throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                return response.Data;
            }
        }
    }
}
