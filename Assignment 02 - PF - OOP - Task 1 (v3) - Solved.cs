using System;
using System.Collections.Generic;

interface IBankAccount //Interface class having 2 functions deposit and withdraw
{
    void Deposit(double DepositAmount); //only declared 
    void Withdraw(double WithdrawAmount);
}

abstract class BankAccount : IBankAccount //inherit the interface 
{
    public string AccountNumber { get; set; }
    protected string AccountHolderName { get; set; }
    protected double Balance { get; set; }

    public BankAccount(string accountNumber, string accountHolderName, double balance) //constructor used for intializing 
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = balance;
    }
    public abstract void Deposit(double DepositAmount); //defined abstract that means they cam be override but there body can't be written here
    public abstract void Withdraw(double WithdrawAmount);
    public abstract void DisplayAccountInfo();
}

class SavingsAccount : BankAccount //inheritance
{
    protected double InterestRate { get; set; }
    public double Previous_Balance = 0;

    public SavingsAccount(string accountNumber, string accountHolderName, double balance, double interestRate)
        : base(accountNumber, accountHolderName, balance) //constructor 
    {
        InterestRate = interestRate;
    }

    public override void Deposit(double DepositAmount) // It will override the function Deposit present in parent class
    {
        Previous_Balance = Balance;
        Balance += DepositAmount;
        Balance += (DepositAmount * InterestRate);
    }
    public override void Withdraw(double WithdrawAmount) // no need for withdraw function but as it compulsory to write hence just defined and body is kept empty
    { }

    public override void DisplayAccountInfo() // will display the info of SavingsAccount class
    {
        Console.WriteLine("---Saving class info---");
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Account Holder Name: " + AccountHolderName);
        Console.WriteLine("Balance before deposit is: " + Previous_Balance);
        Console.WriteLine("Interest Rate: " + InterestRate);
        Console.WriteLine("Balance after deposit is: " + Balance);
        Console.WriteLine();
    }
}

class CheckingAccount : BankAccount //CheckingAccount (child class) is inherited from the parent class (Bank Account)
{

    public double Previous_Balance = 0; // will store the previous balance
    public double Withdraw_Amount = 0; //will store the withdraw amount
    public CheckingAccount(string accountNumber, string accountHolderName, double balance)
        : base(accountNumber, accountHolderName, balance) //Constructor of child class CheckingAccount
    {
    }

    public override void Deposit(double DepositAmount) // no need for deposit function but as it compulsory to write hence just defined and body is kept empty
    { }
    public override void Withdraw(double WithdrawAmount) // will override the withdraw function
    {
        Previous_Balance = Balance;
        Withdraw_Amount = WithdrawAmount;

        if (Balance < WithdrawAmount)
        {
            Console.WriteLine("Invalid Amount");
        }
        else
        {
            Balance = Balance - WithdrawAmount;
        }

    }

    public override void DisplayAccountInfo() // will display the info of CheckingAccount class
    {

        Console.WriteLine("---Checking class info---");
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Account Holder Name: " + AccountHolderName);
        Console.WriteLine("Balance before deposit is: " + Previous_Balance);
        Console.WriteLine("Amount to withdraw: " + Withdraw_Amount);
        Console.WriteLine("Balance after deposit is: " + Balance);
        Console.WriteLine();

    }
}

class Bank
{
    public List<BankAccount> Accounts { get; set; } //List is Bank Accounts named Accounts

    public Bank() //constructor that intializes the list 
    {
        Accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account) //Accounts are added to the list
    {
        Accounts.Add(account);
    }

    public void DepositToAccount(string accountNumber, double amount)
    {
        foreach (BankAccount account in Accounts)
        {
            if (account.AccountNumber == accountNumber) // if the accountNumber in the list is equal to the accountNumber than call the deposit function 
            {
                account.Deposit(amount);
                break;
            }
        }
    }

    public void WithdrawFromAccount(string accountNumber, double amount)
    {
        foreach (BankAccount account in Accounts)
        {
            if (account.AccountNumber == accountNumber) // if the accountNumber in the list is equal to the accountNumber than call the withdraw function 
            {
                account.Withdraw(amount);
                break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank(); //object of class bank is created

        SavingsAccount savingsAccount = new SavingsAccount("123456789", "John Smith", 1000, 0.05); // object is created of the SavingsAccount and arguments are passed 
        CheckingAccount checkingAccount = new CheckingAccount("987654321", "Jane Doe", 500); // object is created of the CheckingAccount and arguments are passed 

        bank.AddAccount(savingsAccount); //savingsAccount is added in the list of Accounts and AddAccount function is called
        bank.AddAccount(checkingAccount); //checkingAccount is added in the list of Accounts and AddAccount function is called

        bank.DepositToAccount("123456789", 500); //Arguemnts are passed to the DepositToAccount and is called
        bank.WithdrawFromAccount("987654321", 200);//Arguemnts are passed to the WithdrawFromAccount and is called

        savingsAccount.DisplayAccountInfo(); //Will display the info of savingsAccount
        checkingAccount.DisplayAccountInfo();//Will display the info of checkingAccount
        Console.ReadKey();
    }
}