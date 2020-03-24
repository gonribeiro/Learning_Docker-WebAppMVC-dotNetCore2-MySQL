namespace br.com.Money
{
    internal class Deposit
    {
        private int currentAccountNumber;
        private Screen screen;
        private BankDatabase bankDatabase;
        private Keypad keypad;
        private DepositSlot depositSlot;

        public Deposit(int currentAccountNumber, Screen screen, BankDatabase bankDatabase, Keypad keypad, DepositSlot depositSlot)
        {
            this.currentAccountNumber = currentAccountNumber;
            this.screen = screen;
            this.bankDatabase = bankDatabase;
            this.keypad = keypad;
            this.depositSlot = depositSlot;
        }
    }
}