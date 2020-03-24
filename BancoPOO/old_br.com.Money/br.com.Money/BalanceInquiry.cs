using System.Transactions;

namespace br.com.Money
{
    internal class BalanceInquiry : Transaction
    {
        private int currentAccountNumber;
        private Screen screen;
        private BankDatabase bankDatabase;

        public BalanceInquiry(int currentAccountNumber, Screen screen, BankDatabase bankDatabase)
        {
            this.currentAccountNumber = currentAccountNumber;
            this.screen = screen;
            this.bankDatabase = bankDatabase;
        }
    }
}