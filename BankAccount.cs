using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        public string bankAccount { get; set; }
        public string name { get; set; }
        public int AccNum { get; set; }
        public double balance { get; set; }

        public BankAccount(string Name, int AccountNum, int Bal)
        {
            name = Name;
            AccNum = AccountNum;
            balance = Bal;
        }
        public virtual void Deposit(int D)
        {
            balance += D;
        }
        public virtual void Withdraw(int W)
        {
            balance -= W;
        }
        public class SavingAccount : BankAccount
        {
            public double IntRate;
            public SavingAccount(string Name, int AccountNum, int Bal, double IR) : base(Name, AccountNum, Bal)
            {
                IntRate = IR;
            }
            public override void Deposit(int D)
            {
                balance += (1 + IntRate) * D;

            }
        }
        public class CheckingAccount : BankAccount
        {

            public CheckingAccount(string Name, int AccountNum, int Bal) : base(Name, AccountNum, Bal)
            {

            }
            public override void Withdraw(int W)
            {
                if (W > balance)
                {
                    Console.WriteLine("Amount exceeds the current balance.");
                }
            }
        }
        public class Bank
        {
            List<BankAccount> BankAccounts { get; set; }
            public Bank()
            {
                BankAccounts = new List<BankAccount>();
            }
            public void AddAccount(BankAccount bankAccount)
            {
                BankAccounts.Add(bankAccount);
                Console.WriteLine($"{bankAccount.name} has been added!");
            }
            public void DepositToAccount(BankAccount account, int amount)
            {
                bool state = false;
                foreach (BankAccount bankAccount in BankAccounts)
                {
                    if (bankAccount == account)
                    {
                        account.balance += amount;
                        state = true;
                        Console.WriteLine($"{amount} Amount has been added!");
                    }
                }
                if (state == false)
                {
                    Console.WriteLine("Account not found");
                }
            }
            public void WithdrawFromAccount(BankAccount account, int amount)
            {
                bool state = false;
                foreach (BankAccount bankAccount in BankAccounts)
                {
                    if (bankAccount == account)
                    {
                        account.balance -= amount;
                        state = true;
                        Console.WriteLine($"{amount} Amount has been withdrawn!");
                    }
                }
                if (state == false)
                {
                    Console.WriteLine("Account not found");
                }
            }
            static void Main(string[] args)
            {
                Bank bank = new Bank();
                SavingAccount savingaccount = new SavingAccount ("Haider", 1989, 25000, 0.2);
                bank.AddAccount(savingaccount);
                CheckingAccount checkingaccount = new CheckingAccount("Haider", 1989, 2500);
                bank.AddAccount(checkingaccount);
                bank.DepositToAccount(savingaccount, 2000);
                bank.WithdrawFromAccount(savingaccount, 500);

            }
        }
    }
}
