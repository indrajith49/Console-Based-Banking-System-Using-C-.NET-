using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class BankAccount
    {
        public int AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(int accountNumber, string accountHolder)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount}.");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount}.");
        }

        public void DisplayDetails()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Holder : {AccountHolder}");
            Console.WriteLine($"Balance        : {Balance}");
            Console.WriteLine("------------------------");
        }
    }

    class Program
    {
        static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        static int nextAccountNumber = 1001;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Banking System ===");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Display Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        CheckBalance();
                        break;
                    case "5":
                        DisplayAccountDetails();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter account holder name: ");
            string name = Console.ReadLine();

            var account = new BankAccount(nextAccountNumber, name);
            accounts.Add(nextAccountNumber, account);

            Console.WriteLine($"Account created successfully. Account Number: {nextAccountNumber}");
            nextAccountNumber++;
        }

        static BankAccount GetAccount()
        {
            Console.Write("Enter account number: ");
            int accNo = int.Parse(Console.ReadLine());

            if (accounts.ContainsKey(accNo))
                return accounts[accNo];

            Console.WriteLine("Account not found.");
            return null;
        }

        static void DepositMoney()
        {
            var account = GetAccount();
            if (account == null) return;

            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            account.Deposit(amount);
        }

        static void WithdrawMoney()
        {
            var account = GetAccount();
            if (account == null) return;

            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }

        static void CheckBalance()
        {
            var account = GetAccount();
            if (account == null) return;

            Console.WriteLine($"Current Balance: {account.Balance}");
        }

        static void DisplayAccountDetails()
        {
            var account = GetAccount();
            if (account == null) return;

            account.DisplayDetails();
        }
    }
}
