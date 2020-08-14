using System;
using System.Collections.Generic;
using TenmoClient.Data;
using TenmoClient.APIServcies;
using TenmoServer.Models;

namespace TenmoClient
{
    public class ConsoleService
    {
        private readonly AuthService authService = new AuthService();
        private readonly MoneyService moneyService = new MoneyService();

        public void Run()
        {

            while (true)
            {
                Console.WriteLine("Welcome to TEnmo!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.WriteLine("3: Exit");
                Console.Write("Please choose an option: ");

                int loginRegister = -1;

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out loginRegister))
                    {
                        Console.WriteLine("Invalid input. Please enter only a number.");
                    }

                    else if (loginRegister == 1)
                    {
                        LoginUser loginUser = PromptForLogin();
                        API_User user = authService.Login(loginUser);
                        if (user != null)
                        {
                            UserService.SetLogin(user);
                            MenuSelection();
                        }
                    }

                    else if (loginRegister == 2)
                    {
                        LoginUser registerUser = PromptForLogin();
                        bool isRegistered = authService.Register(registerUser);
                        if (isRegistered)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registration successful. You can now log in.");
                        }
                    }

                    else if (loginRegister == 3)
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message);
                }
            }
        }

        private void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers"); //view details through here
                Console.WriteLine("3: View your pending requests"); //ability to approve/reject through here
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Approve request for TE bucks");
                Console.WriteLine("7: View list of users");
                Console.WriteLine("8: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out menuSelection))
                    {
                        Console.WriteLine("Invalid input. Please enter only a number.");
                    }
                    else if (menuSelection == 1)
                    {
                        DisplayBalance();
                    }
                    else if (menuSelection == 2)
                    {
                        DisplayCompletedTransfers();
                    }
                    else if (menuSelection == 3)
                    {
                        DisplayPendingTransfers();
                    }
                    else if (menuSelection == 4)
                    {
                        SendTransfer();
                    }
                    else if (menuSelection == 5)
                    {
                        RequestTransfer();
                    }
                    else if (menuSelection == 6)
                    {
                        ApproveRequest();
                    }
                    else if (menuSelection == 7)
                    {
                        ListUsers();
                    }
                    else if (menuSelection == 8)
                    {
                        Console.WriteLine("");
                        UserService.SetLogin(new API_User()); //wipe out previous login info
                        return; //return to register/login menu
                    }
                    else if (menuSelection == 0)
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine("Please try again");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message);
                    Console.WriteLine();
                }
            }
        }

        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write("Please enter transfer ID to " + action + " (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int actionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return actionId;
            }
        }

        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");
            return pass;
        }

        private void DisplayBalance()
        {
            decimal balance = moneyService.GetBalance();
            Console.WriteLine("Your current balance is: " + balance.ToString("C"));
        }

        private void DisplayPendingTransfers()
        {
            List<TransferRecord> transfers = moneyService.GetTransfers();

            Dictionary<int, int> accountToUser = moneyService.GetAccountToUser();
            Dictionary<int, string> userToName = moneyService.GetUserToName();

            int userId = authService.LoggedinUserId;

            Console.WriteLine("".PadRight(40, '-'));
            Console.WriteLine("".PadRight(15) + "Pending Transfers");
            Console.WriteLine("Id".PadRight(6) + "From/To".PadRight(30) + "Amount");
            Console.WriteLine("".PadRight(40, '-'));
            foreach (TransferRecord transfer in transfers)
            {
                if (transfer.TransferStatusId == Status.PENDING)
                {
                    Console.Write(transfer.TransferId.ToString().PadRight(6));

                    int from_user = accountToUser[transfer.AccountFrom];
                    int to_user = accountToUser[transfer.AccountTo];

                    if (from_user == userId)
                    {
                        Console.Write("To: " + userToName[to_user].PadRight(26));
                    }
                    else
                    {
                        Console.Write("From: " + userToName[from_user].PadRight(24));
                    }

                    Console.WriteLine(transfer.Amount.ToString("C"));
                }
            }
            Console.WriteLine("".PadRight(40, '-'));

            Console.WriteLine();
            Console.Write("Please enter transfer ID to view details(0 to cancel): ");
            int detailId = int.Parse(Console.ReadLine());

            if (detailId == 0)
            {
                return;
            }

            DisplayTransferDetail(detailId, transfers, accountToUser, userToName);
        }

        private void DisplayCompletedTransfers()
        {
            List<TransferRecord> transfers = moneyService.GetTransfers();

            Dictionary<int, int> accountToUser = moneyService.GetAccountToUser();
            Dictionary<int, string> userToName = moneyService.GetUserToName();

            int userId = authService.LoggedinUserId;

            Console.WriteLine("".PadRight(40, '-'));
            Console.WriteLine("".PadRight(15) + "Approved Transfers");
            Console.WriteLine("Id".PadRight(6) + "From/To".PadRight(30) + "Amount");
            Console.WriteLine("".PadRight(40, '-'));
            foreach (TransferRecord transfer in transfers)
            {
                if (transfer.TransferStatusId == Status.APPROVED)
                {
                    Console.Write(transfer.TransferId.ToString().PadRight(6));

                    int from_user = accountToUser[transfer.AccountFrom];
                    int to_user = accountToUser[transfer.AccountTo];

                    if (from_user == userId)
                    {
                        Console.Write("To: " + userToName[to_user].PadRight(26));
                    }
                    else
                    {
                        Console.Write("From: " + userToName[from_user].PadRight(24));
                    }

                    Console.WriteLine(transfer.Amount.ToString("C"));
                }
            }
            Console.WriteLine("".PadRight(40, '-'));

            Console.WriteLine();
            Console.Write("Please enter transfer ID to view details(0 to cancel): ");
            int detailId = int.Parse(Console.ReadLine());

            if (detailId == 0)
            {
                return;
            }

            DisplayTransferDetail(detailId, transfers, accountToUser, userToName);
        }

        private void DisplayTransferDetail(int detailId, List<TransferRecord> transfers,
            Dictionary<int, int> accountToUser, Dictionary<int, string> userToName)
        {
            TransferRecord thisTransfer = null;

            foreach (TransferRecord transfer in transfers)
            {
                if (transfer.TransferId == detailId)
                {
                    thisTransfer = transfer;
                    break;
                }
            }

            Dictionary<int, string> type = moneyService.GetTypeToName();
            Dictionary<int, string> status = moneyService.GetStatusToName();

            if (thisTransfer != null)
            {
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("Transfer details"); ;
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("Id: " + thisTransfer.TransferId);
                Console.WriteLine("From: " + userToName[accountToUser[thisTransfer.AccountFrom]]);
                Console.WriteLine("To: " + userToName[accountToUser[thisTransfer.AccountTo]]);
                Console.WriteLine("Type: " + type[thisTransfer.TransferTypeId]);
                Console.WriteLine("Status: " + status[thisTransfer.TransferStatusId]);
                Console.WriteLine("Amount: " + thisTransfer.Amount.ToString("C"));
                Console.WriteLine("".PadRight(40, '-'));

                return;
            }

            //--------------------------------------------
            //Transfer Details
            //--------------------------------------------
            // Id: 23
            // From: Bernice
            // To: Me Myselfandi
            // Type: Send
            // Status: Approved
            // Amount: $903.14

        }

        private void RequestTransfer()
        {
            List<API_User> users = moneyService.GetUsers();

            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));
            Console.WriteLine("Users".PadRight(6));
            Console.WriteLine("Id".PadRight(6) + "Name".PadRight(20));
            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));

            //display users
            int me = UserService.GetUserId();

            foreach (API_User user in users)
            {
                //don't display myself
                if (user.UserId != me)
                {
                    Console.WriteLine(user.UserId.ToString().PadRight(6) + user.Username.PadRight(20));
                }
            }
            Console.WriteLine("".PadRight(6, '-'));

            Console.Write("Enter ID of user you are requesting from (0 to cancel): ");
            int source = int.Parse(Console.ReadLine());

            if (source == 0)
            {
                return;
            }

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            bool result = moneyService.TransferFrom(me, source, amount);

            if (result)
            {
                Console.WriteLine("Requested. Request must be approved.");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            return;
        }

        private void ApproveRequest()
        {
            List<TransferRecord> transfers = moneyService.GetTransfers();

            Dictionary<int, int> accountToUser = moneyService.GetAccountToUser();
            Dictionary<int, string> userToName = moneyService.GetUserToName();

            int userId = authService.LoggedinUserId;

            Console.WriteLine("".PadRight(40, '-'));
            Console.WriteLine("".PadRight(15) + "Pending Transfers");
            Console.WriteLine("Id".PadRight(6) + "From/To".PadRight(30) + "Amount");
            Console.WriteLine("".PadRight(40, '-'));
            foreach (TransferRecord transfer in transfers)
            {
                if (transfer.TransferStatusId == Status.PENDING)
                {
                    Console.Write(transfer.TransferId.ToString().PadRight(6));

                    int from_user = accountToUser[transfer.AccountFrom];
                    int to_user = accountToUser[transfer.AccountTo];

                    if (from_user == userId)
                    {
                        Console.Write("To: " + userToName[to_user].PadRight(26));
                    }
                    else
                    {
                        Console.Write("From: " + userToName[from_user].PadRight(24));
                    }

                    Console.WriteLine(transfer.Amount.ToString("C"));
                }
            }
            Console.WriteLine("".PadRight(40, '-'));

            Console.WriteLine();
            Console.Write("Please enter transfer ID to approve/reject(0 to cancel): ");
            int detailId = int.Parse(Console.ReadLine());

            if (detailId == 0)
            {
                return;
            }

            ApproveRequestDetail(detailId, transfers, accountToUser, userToName);
        }

        private void ApproveRequestDetail(int detailId, List<TransferRecord> transfers,
            Dictionary<int, int> accountToUser, Dictionary<int, string> userToName)
        {
            TransferRecord thisTransfer = null;

            foreach (TransferRecord transfer in transfers)
            {
                if (transfer.TransferId == detailId)
                {
                    thisTransfer = transfer;
                    break;
                }
            }

            Dictionary<int, string> type = moneyService.GetTypeToName();
            Dictionary<int, string> status = moneyService.GetStatusToName();

            if (thisTransfer != null)
            {
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("Transfer details"); ;
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine("Id: " + thisTransfer.TransferId);
                Console.WriteLine("From: " + userToName[accountToUser[thisTransfer.AccountFrom]]);
                Console.WriteLine("To: " + userToName[accountToUser[thisTransfer.AccountTo]]);
                Console.WriteLine("Type: " + type[thisTransfer.TransferTypeId]);
                Console.WriteLine("Status: " + status[thisTransfer.TransferStatusId]);
                Console.WriteLine("Amount: " + thisTransfer.Amount.ToString("C"));
                Console.WriteLine("".PadRight(40, '-'));
                Console.WriteLine();
                Console.WriteLine("1: Approve");
                Console.WriteLine("2: Reject");
                Console.WriteLine("0: Cancel (Don't approve or reject)");

                int selection = int.Parse(Console.ReadLine());

                if (selection == 0)
                {
                    return;
                }
                bool result = moneyService.AcceptRejectPending(thisTransfer, selection);

                if (result)
                {
                    if (selection == 1)
                    {
                        Console.WriteLine("Success. Transfer request is now approved");
                    }
                    else
                    {
                        Console.WriteLine("Success. Transfer request is now rejected");
                    }
                }
                else
                {
                    {
                        Console.WriteLine("Falied. Unable to set status.");
                    }
                }

            }
            else
            {
                Console.WriteLine("Not a valid transfer.");
            }
        }

        private void SendTransfer()
        {
            List<API_User> users = moneyService.GetUsers();

            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));
            Console.WriteLine("Users".PadRight(6));
            Console.WriteLine("Id".PadRight(6) + "Name".PadRight(20));
            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));

            //display users
            int me = UserService.GetUserId();

            foreach (API_User user in users)
            {
                //don't display myself
                if (user.UserId != me)
                {
                    Console.WriteLine(user.UserId.ToString().PadRight(6) + user.Username.PadRight(20));
                }
            }
            Console.WriteLine("".PadRight(6, '-'));

            Console.Write("Enter ID of user you are sending to (0 to cancel): ");
            int destination = int.Parse(Console.ReadLine());

            if (destination == 0)
            {
                return;
            }

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            bool result = moneyService.TransferTo(me, destination, amount);

            if (result)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            return;
        }

        private void ListUsers()
        {
            List<API_User> users = moneyService.GetUsers();

            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));
            Console.WriteLine("Users".PadRight(6));
            Console.WriteLine("Id".PadRight(6) + "Name".PadRight(20));
            Console.WriteLine("".PadRight(6, '-') + "".PadRight(20, '-'));

            //display users
            int me = UserService.GetUserId();

            foreach (API_User user in users)
            {
                //don't display myself
                if (user.UserId == me)
                {
                    Console.WriteLine(user.UserId.ToString().PadRight(6) + 
                        user.Username.PadRight(20) + " (Me)");
                }
                else
                {
                    Console.WriteLine(user.UserId.ToString().PadRight(6) +
                        user.Username.PadRight(20));
                }
            }
            Console.WriteLine("".PadRight(6, '-'));
        }

        private static class Status
        {
            public const int PENDING = 1;
            public const int APPROVED = 2;
            public const int REJECTED = 3;
        }
    }
}
