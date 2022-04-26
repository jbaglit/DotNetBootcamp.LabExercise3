using System;

namespace act3draft2
{
    class Account
    {
        public decimal Balance { get; set; }

        public decimal GetBalance()
        {
            return this.Balance;
        }
    }

    class SelectTransactionDisplay
    {
        public void selectTransactionDisplay()
        {
            Console.WriteLine("\n\n~~~~~Welcome to ATM Service~~~~~~\n");
            Console.WriteLine("|\t1. Check Balance\t|\n");
            Console.WriteLine("|\t2. Withdraw Cash\t|\n");
            Console.WriteLine("|\t3. Deposit Cash\t\t|\n");
            Console.WriteLine("|\t4. Exit\t\t\t|\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.Write("Select option: ");
        }

    }

    class PinValidator
    {
        public void EnterPin()
        {
            int MyPin = 1234;
            Console.Write("Enter Pin: ");
            int pinInput = Convert.ToInt32(Console.ReadLine());

            bool IsPinCorrect = true;
            while (IsPinCorrect)
            {
                if (pinInput == MyPin)
                {
                    ATMRenderer displayMenu = new ATMRenderer();
                    displayMenu.atmRenderer();
                    break;
                }
                else
                    Console.WriteLine("\nInvalid Pin! Please Try Again.");
                EnterPin();
                break;
            }
        }
    }

    class ATMRenderer
    {
        public void atmRenderer()
        {
            bool continueToInput = true;

            Account account = new Account();
            account.GetBalance();

            Console.Clear();
            while (continueToInput)
            {
                SelectTransactionDisplay selectTransactionDisplay = new SelectTransactionDisplay();
                selectTransactionDisplay.selectTransactionDisplay();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nYour Total Account Balanace : PHP " + account.Balance);
                        break;

                    case "2":
                        Console.Write("\nEnter Withdrawal amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        if (amount > account.Balance)
                        {
                            Console.WriteLine("\nInsufficient balance in your account, please put a deposit.");
                        }

                        else if (amount < 0)
                        {
                            Console.WriteLine("\nInvalid withdrawal amount!");
                        }

                        else
                        {
                            account.Balance = account.GetBalance() - amount;
                            Console.WriteLine("\n\nWithdrawal Transaction Successful! Please Get Your Money.");
                            Console.WriteLine("\nYour remaining balance is: " + account.Balance);
                        }
                        break;

                    case "3":
                        {
                            Console.Write("\nEnter amount to deposit: ");
                            int amountDeposit = Convert.ToInt32(Console.ReadLine());

                            if (amountDeposit > 0)
                            {
                                account.Balance = account.Balance + amountDeposit;
                                Console.WriteLine("\n\nDeposit Transaction Successful!");
                                Console.WriteLine("Your current balance: " + account.Balance);
                            }

                            else
                            {
                                Console.WriteLine("Invalid deposit amount!");
                            }

                        }
                        break;

                    case "4":

                        Console.WriteLine("\n\n~THANK YOU FOR USING THE ATM SERVICE~");
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.WriteLine("Invalid Selection!");
                        break;
                }
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Your PIN is 1234\n");

            PinValidator pinValidator = new PinValidator();
            pinValidator.EnterPin();

        }
    }
}
