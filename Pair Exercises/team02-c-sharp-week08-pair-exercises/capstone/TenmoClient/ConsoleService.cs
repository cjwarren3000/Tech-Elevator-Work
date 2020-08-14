using System;
using System.Collections.Generic;
using TenmoClient.APIService;
using TenmoClient.Data;
using System.Linq;

namespace TenmoClient
{
    public class ConsoleService
    {
        //Initialize API services
        private static readonly AuthService authService = new AuthService();
        private static readonly AccountsAPIService accountsAPIService = new AccountsAPIService();
        private static readonly TransfersAPIService transfersAPIService = new TransfersAPIService();

        public void Run()
        {
            //Menu for login and registration
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
        //menu to navigave application
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
                Console.WriteLine("6: View list of users");
                Console.WriteLine("7: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out menuSelection))
                    {
                        Console.WriteLine("Invalid input. Please enter only a number.");
                    }
                    //Show account balance
                    else if (menuSelection == 1)
                    {
                        Account usersAccount = accountsAPIService.GetUsersAccount();
                        Console.WriteLine($"\nYour current Account balance is {usersAccount.AccountBalance} TE bucks.");

                    }
                    //view past transfers
                    else if (menuSelection == 2)
                    {
                        List<Transfer> transfers = transfersAPIService.GetTransfersForUser();
                        if (transfers.Count == 0)
                        {
                            Console.WriteLine("No transfers to display.");
                        }
                        else
                        {
                            DisplayUsersTransfers(transfers);
                            TransferDetailsMenu(transfers);
                        }
                        
                    }
                    //view pending transfers
                    else if (menuSelection == 3)
                    {
                        List<Transfer> pendingTransfers = transfersAPIService.GetPendingTransfersForUser();
                        if (pendingTransfers.Count == 0)
                        {
                            Console.WriteLine("No pending transfers to display.");
                        }
                        else
                        {
                            DisplayUsersTransfers(pendingTransfers);
                            selectPendingTransferMenu(pendingTransfers);
                        }
                    }
                    //Send TE bucks to a user
                    else if (menuSelection == 4)
                    {
                        SendTeBucks();
                    }
                    //Request TE bucks from a user
                    else if (menuSelection == 5)
                    {
                        DisplayUsers();
                        List<API_User> users = accountsAPIService.GetUsers();
                        RequestTeBucksMenu(users);
                    }
                    //show list of users
                    else if (menuSelection == 6)
                    {
                        DisplayUsers();
                    }
                    //change logged in user
                    else if (menuSelection == 7)
                    {
                        Console.WriteLine("");
                        UserService.SetLogin(new API_User()); //wipe out previous login info
                        return; //return to register/login menu
                    }
                    //exit menu
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
            Console.Write("Please enter transfer ID to " + action + " (0 to cancel/exit): ");
            if (!int.TryParse(Console.ReadLine(), out int transferId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return transferId;
            }
        }
        public int PromptForUserID(string action, string toFrom)
        {
            Console.WriteLine("");
            Console.Write("Enter ID of user you are " + action + " " + toFrom + " (0 to cancel/exit): ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return userId;
            }
        }

        public decimal PromptForMoneyAmount()
        {
            Console.WriteLine("");
            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal moneyAmount) || moneyAmount < 0)
            {
                return 0;
            }
            else
            {
                return moneyAmount;
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

        public void DisplayUsers()
        {
            List<API_User> users = accountsAPIService.GetUsers();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("List of Users");
            Console.WriteLine("ID".PadRight(10) + "Name".PadRight(15));
            Console.WriteLine("-------------------------------------------------------");
            foreach (API_User user in users)
            {
                Console.WriteLine(user.UserId.ToString().PadRight(10) + user.Username.PadRight(15));
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void SendTeBucks()
        {
            DisplayUsers();

            int toUserId = PromptForUserID("sending", "to");
            if (toUserId == 0)
            {

            }
            else
            {
                decimal amountToSend = PromptForMoneyAmount();
                List<Account> accountList = accountsAPIService.AccountInfo();
                bool enoughToSend = false;
                bool successfulSend = false;
                Transfer sendBucks = new Transfer();
                sendBucks.transferStatusId = 2;
                sendBucks.transferTypeId = 2;
                Account fromAccount = new Account();
                Account toAccount = new Account();
                //check if valid amount to send
                if (amountToSend == 0)
                {
                    Console.WriteLine("Invalid amount");
                }
                else
                {
                    //find current logged in user and 
                    foreach (Account item in accountList)
                    {
                        if (item.IsLoggedInUser)
                        {
                            if (item.AccountBalance >= amountToSend)
                            {
                                enoughToSend = true;
                                item.AccountBalance -= amountToSend;
                                sendBucks.accountFrom = item.AccountID;
                                fromAccount = item;
                            }
                            else
                            {
                                Console.WriteLine("You do not have enough TE bucks to send.");
                            }
                        }
                    }
                    if (enoughToSend == true)
                    {
                        //find in selected user to transfer money to
                        foreach (Account item in accountList)
                        {
                            if (item.UserID == toUserId && !item.IsLoggedInUser)
                            {
                                item.AccountBalance += amountToSend;
                                successfulSend = true;
                                sendBucks.accountTo = item.AccountID;
                                toAccount = item;
                            }
                        }
                        //log transactions if everything is appropriate
                        if (successfulSend)
                        {
                            sendBucks.amount = amountToSend;
                            if (transfersAPIService.CreateTransfer(sendBucks) && accountsAPIService.UpdateAccountBalance(fromAccount) && accountsAPIService.UpdateAccountBalance(toAccount))
                            {
                                Console.WriteLine("You have sent user " + toUserId + " " + amountToSend + " TE bucks.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid user selection");
                        }
                    }
                }
            }
            
        }

        public void DisplayUsersTransfers(List<Transfer> transfers)
        {
            Account usersAccount = accountsAPIService.GetUsersAccount();
            Console.WriteLine("-------------------------------------------------------");
            if (transfers[0].transferStausDesc == "Pending")
            {
                Console.WriteLine("List of Pending Transfers");
            }
            else
            {
                Console.WriteLine("List of Transfers");
            }
            Console.WriteLine("ID".PadRight(10) + "Transfer Type".PadRight(15) + "From/To".PadRight(20) + "Amount".PadRight(10));
            Console.WriteLine("-------------------------------------------------------");
            foreach (Transfer transfer in transfers)
            {
                Console.Write(transfer.transferId.ToString().PadRight(10));
                Console.Write(transfer.transferTypeDesc.PadRight(15));
                //determine what to show in menu (whether a request/money was sent to you, or you sent money/request to someone)
                if (transfer.accountFrom == usersAccount.AccountID)
                {
                    Console.Write(("To: " + transfer.accountToName).PadRight(20));
                }
                else
                {
                    Console.Write(("From: " + transfer.accountFromName).PadRight(20));
                }
                Console.WriteLine(transfer.amount.ToString().PadRight(10));
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void TransferDetailsMenu(List<Transfer> transfers)
        {
            bool done = false;
            while (!done)
            {
                int selectedID = PromptForTransferID("view details");
                Transfer selectedTransfer = transfers.Find(t => t.transferId == selectedID);
                if (selectedID == 0)
                {
                    done = true;
                }
                else if (selectedTransfer == null)
                {
                    Console.WriteLine("Please enter a valid selection or 0 to exit/cancel.");
                }
                else
                {
                    DisplayTransferDetails(selectedTransfer);
                    done = true;
                }
            }
        }

        public void DisplayTransferDetails(Transfer selectedTransfer)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Transfer Details");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Id: " + selectedTransfer.transferId.ToString());
            Console.WriteLine("From: " + selectedTransfer.accountFromName);
            Console.WriteLine("To: " + selectedTransfer.accountToName);
            Console.WriteLine("Type: " + selectedTransfer.transferTypeDesc);
            Console.WriteLine("Status " + selectedTransfer.transferStausDesc);
            Console.WriteLine("Amount: " + selectedTransfer.amount.ToString());
        }

        public void selectPendingTransferMenu(List<Transfer> transfers)
        {
            bool done = false;
            int selectedID = -1;
            while (!done)
            {
                selectedID = PromptForTransferID("see details or approve/reject");
                Transfer selectedTransfer = transfers.Find(t => t.transferId == selectedID);
                if (selectedID == 0)
                {
                    done = true;
                }
                else if (selectedTransfer == null)
                {
                    Console.WriteLine("Please enter a valid selection or 0 to exit/cancel.");
                }
                else
                {
                    Account usersAccount = accountsAPIService.GetUsersAccount();
                    if (usersAccount.AccountID == selectedTransfer.accountFrom)
                    {
                        DisplayTransferDetails(selectedTransfer);
                    }
                    else
                    {
                        PendingTransferApprovalMenu(selectedTransfer);
                    }
                    
                    done = true;
                }
            }
        }

        public void PendingTransferApprovalMenu(Transfer selectedTransfer)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("1: Approve");
                Console.WriteLine("2: Reject");
                Console.WriteLine("0: Neither Approve or Reject");
                Console.WriteLine("---------");
                Console.WriteLine($"Please choose an option for Transfer {selectedTransfer.transferId}: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedOption))
                {
                    Console.WriteLine("Please enter a valid selection or 0 to exit/cancel.");
                }
                if (selectedOption == 1)
                {
                    Account usersAccount = accountsAPIService.GetUsersAccount();
                    if (usersAccount.AccountBalance < selectedTransfer.amount)
                    {
                        Console.WriteLine("\nCannot Approve Transfer. Requested amount is greater than current balance.");
                    }
                    else
                    {
                        List<Account> ListOfAccounts = accountsAPIService.AccountInfo();
                        Account fromAccount = ListOfAccounts.Find(a => a.AccountID == selectedTransfer.accountFrom);
                        fromAccount.AccountBalance += selectedTransfer.amount;
                        Account toAccount = ListOfAccounts.Find(a => a.AccountID == selectedTransfer.accountTo);
                        toAccount.AccountBalance -= selectedTransfer.amount;
                        selectedTransfer.transferStatusId = 2;
                        accountsAPIService.UpdateAccountBalance(fromAccount);
                        accountsAPIService.UpdateAccountBalance(toAccount);
                        bool transferUpdated = transfersAPIService.UpdatePendingTeRequest(selectedTransfer);
                        if (transferUpdated)
                        {
                            Console.WriteLine($"Transfer {selectedTransfer.transferId} has been Approved.");
                        }
                        
                    }
                    
                    done = true;

                }
                else if (selectedOption == 2)
                {
                    selectedTransfer.transferStatusId = 3;
                    bool transferUpdated = transfersAPIService.UpdatePendingTeRequest(selectedTransfer);
                    if (transferUpdated)
                    {
                        Console.WriteLine($"Transfer {selectedTransfer.transferId} has been rejected.");
                    }
                    done = true;
                }
                else if (selectedOption == 0)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection or 0 to exit/cancel.");
                }
            }
        }

        public void RequestTeBucksMenu(List<API_User> users)
        {
            bool done = false;
            while(!done)
            {
                int selectedId = PromptForUserID("requesting", "from");
                API_User selectedUser = users.Find(u => u.UserId == selectedId);
                if (selectedId == 0)
                {
                    done = true;
                }
                else if(selectedUser == null)
                {
                    Console.WriteLine("Please enter a valid selection or 0 to exit/cancel.");
                    done = true;
                }
                else
                {
                    Transfer requestTransfer = new Transfer();
                    List<Account> ListOfAccounts = accountsAPIService.AccountInfo();
                    requestTransfer.transferTypeId = 1;
                    requestTransfer.transferStatusId = 1;
                    requestTransfer.accountFrom = ListOfAccounts.Find(a => a.IsLoggedInUser == true).AccountID;
                    requestTransfer.accountTo = ListOfAccounts.Find(a => a.UserID == selectedId).AccountID;
                    if (requestTransfer.accountFrom == requestTransfer.accountTo)
                    {
                        Console.WriteLine("Cannot request money from yourself. Please enter a valid user.");
                    }
                    else
                    {
                        requestTransfer.amount = PromptForMoneyAmount();
                        if (requestTransfer.amount != 0)
                        {
                            bool transferCreated = transfersAPIService.CreateTransfer(requestTransfer);
                            if (transferCreated)
                            {
                                Console.WriteLine($"Request sent to user {requestTransfer.accountTo} for {requestTransfer.amount} TE Bucks.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry or entered zero for requested amount.");
                        }
                    }
                    done = true;
                }

            }
            
        }
    }
}
