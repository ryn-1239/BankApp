using System;
using System.Collections.Generic;

namespace Bank
{
    class Client
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Bank Menu ===");
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Show All Accounts");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Search Account");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Client newClient = new Client();
                        Console.Write("Enter account number: ");
                        newClient.AccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter client name: ");
                        newClient.Name = Console.ReadLine();
                        Console.Write("Enter initial balance: ");
                        newClient.Balance = float.Parse(Console.ReadLine());
                        clients.Add(newClient);
                        Console.WriteLine("\nAccount created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("\n=== All Accounts ===");
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("No accounts found.");
                        }
                        else
                        {
                            foreach (Client c in clients)
                            {
                                Console.WriteLine("Account Number: {0}", c.AccountNumber);
                                Console.WriteLine("Client Name: {0}", c.Name);
                                Console.WriteLine("Balance: {0}", c.Balance);
                                Console.WriteLine("------------------------");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("\n=== Deposit ===");
                        Console.Write("Enter account number to deposit: ");
                        int depositAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter amount to deposit: ");
                        float depositAmount = float.Parse(Console.ReadLine());
                        bool foundDeposit = false;
                        foreach (Client c in clients)
                        {
                            if (depositAcc == c.AccountNumber)
                            {
                                c.Balance += depositAmount;
                                Console.WriteLine("Deposit successful!");
                                Console.WriteLine("New balance for account {0}: {1}", c.AccountNumber, c.Balance);
                                foundDeposit = true;
                                break;
                            }
                        }
                        if (!foundDeposit)
                        {
                            Console.WriteLine("Account not found!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("\n=== Withdraw ===");
                        Console.Write("Enter account number to withdraw: ");
                        int withdrawAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter amount to withdraw: ");
                        float withdrawAmount = float.Parse(Console.ReadLine());
                        bool foundWithdraw = false;
                        foreach (Client c in clients)
                        {
                            if (withdrawAcc == c.AccountNumber)
                            {
                                if (c.Balance >= withdrawAmount)
                                {
                                    c.Balance -= withdrawAmount;
                                    Console.WriteLine("Withdraw successful!");
                                    Console.WriteLine("New balance for account {0}: {1}", c.AccountNumber, c.Balance);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance!");
                                }
                                foundWithdraw = true;
                                break;
                            }
                        }
                        if (!foundWithdraw)
                        {
                            Console.WriteLine("Account not found!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("\n=== Transfer ===");
                        Console.Write("Enter source account number: ");
                        int sourceAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter destination account number: ");
                        int destAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter amount to transfer: ");
                        float transferAmount = float.Parse(Console.ReadLine());
                        Client sourceClient = null;
                        Client destClient = null;
                        foreach (Client c in clients)
                        {
                            if (c.AccountNumber == sourceAcc) sourceClient = c;
                            if (c.AccountNumber == destAcc) destClient = c;
                        }
                        if (sourceClient != null && destClient != null)
                        {
                            if (sourceClient.Balance >= transferAmount)
                            {
                                sourceClient.Balance -= transferAmount;
                                destClient.Balance += transferAmount;
                                Console.WriteLine("Transfer successful!");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance in source account!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("One or both accounts not found!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\n=== Search Account ===");
                        Console.Write("Enter account number: ");
                        int searchAcc = int.Parse(Console.ReadLine());
                        bool foundSearch = false;
                        foreach (Client c in clients)
                        {
                            if (c.AccountNumber == searchAcc)
                            {
                                Console.WriteLine("Account Number: {0}", c.AccountNumber);
                                Console.WriteLine("Client Name: {0}", c.Name);
                                Console.WriteLine("Balance: {0}", c.Balance);
                                foundSearch = true;
                                break;
                            }
                        }
                        if (!foundSearch)
                        {
                            Console.WriteLine("Account not found!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }

            } while (choice != 7);
        }
    }
}
