using AccountApp.Exceptions;
using AccountApp.Model;

namespace AccountApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new Account
            {
                Id = 1,
                Iban = "GR1601101250000000012300695",
                Firstname = "Αθανάσιος",
                Lastname = "Ανδρούτσος",
                Ssn = "12345678901",
                Balance = 100m
            };

            // Account methods already log the error message to Console.Error and rethrow.
            try
            {
                account.Deposit(50m);
                Console.WriteLine($"Deposit OK. Balance: {account.GetBalance("12345678901"):C}");

                account.Withdraw(30m, "12345678901");
                Console.WriteLine($"Withdraw OK. Balance: {account.GetBalance("12345678901"):C}");

                // Fails: ends the try block here. Swap in any of the following to try them:
                // account.Deposit(-20m);                      -> NegativeAmountException
                // account.Withdraw(1000m, "12345678901");     -> InsufficientBalanceException
                // account.Withdraw(10m, "000000000");         -> InvalidSsnException
                // account.GetBalance(null);                   -> InvalidSsnException
                account.Withdraw(1000m, "12345678901");

                Console.WriteLine("Not reached.");
            }
            catch (Exception ex) when (ex is NegativeAmountException
                                    or InsufficientBalanceException
                                    or InvalidSsnException)
            {
                Console.WriteLine($"Operation failed: {ex.GetType().Name}");
            }
        }
    }
}
