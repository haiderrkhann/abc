﻿using System;
using System.Collections.Generic;

namespace BankAccount
{
    public interface IBankAccount
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }

    public abstract class BankAccount : IBankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        public BankAccount(int accountNumber, string accountHolderName, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public abstract void DisplayAccountInfo();

        public virtual void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Amount exceeds the current balance.");
            }
        }
    }

    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(int accountNumber, string accountHolderName, double balance, double interestRate)
            : base(accountNumber, accountHolderName, balance)
        {
            InterestRate = interestRate * 100;
        }

        public override void Deposit(double amount)
        {
            double interest = amount * InterestRate;
            Balance += amount + interest;
            Console.WriteLine($"Deposited {amount} with interest {InterestRate}%. New balance: {Balance}");
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Savings Account Information");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumber, string accountHolderName, double balance)
            : base(accountNumber, accountHolderName, balance)
        {
        }

        public override void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance to withdraw.");
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Checking Account Information");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    public class Bank
    {
        private List<BankAccount> BankAccounts { get; }

        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }

        public void AddAccount(BankAccount account)
        {
            BankAccounts.Add(account);
            Console.WriteLine($"{account.AccountHolderName}'s account ({account.AccountNumber}) has been added!");
        }

        public void DepositToAccount(int accountNumber, double amount)
        {
            bool accountFound = false;

            for (int i = 0; i < BankAccounts.Count; i++)
            {
                if (BankAccounts[i].AccountNumber == accountNumber)
                {
                    BankAccounts[i].Deposit(amount);
                    accountFound = true;
                    break;
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void WithdrawFromAccount(int accountNumber, double amount)
        {
            bool accountFound = false;

            for (int i = 0; i < BankAccounts.Count; i++)
            {
                if (BankAccounts[i].AccountNumber == accountNumber)
                {
                    BankAccounts[i].Withdraw(amount);
                    accountFound = true;
                    break;
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void Main(string[] args)
        {
            Bank bank = new Bank();

            SavingsAccount savingsAccount = new SavingsAccount(246810, "Haider Khan", 2000, 0.04);
            bank.AddAccount(savingsAccount);

            CheckingAccount checkingAccount = new CheckingAccount(1357913, "Shoaib Ahmed", 3500);
            bank.AddAccount(checkingAccount);

            bank.DepositToAccount(246810, 500);
            bank.WithdrawFromAccount(246810, 200);

            bank.DepositToAccount(1357913, 1000);
            bank.WithdrawFromAccount(1357913, 3000);

            Console.ReadKey();
        }
    }
}
