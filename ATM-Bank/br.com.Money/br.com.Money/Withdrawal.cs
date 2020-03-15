using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.Money
{
    // Class Withdrawal represents an ATM withdrawal transaction
    public class Withdrawal
    {
        // attributes
        private int accountNumber; // account to withdraw funds from
        private decimal amount; // amount to withdraw

        // references to associated objects
        private Screen screen; // ATM's screen
        private Keypad keypad; // ATM's keypad
        private CashDispenser cashDispenser; // ATM's cash dispenser
        private BankDatabase bankDatabase; // account-information database

        // parameterless constructor
        public Withdrawal(int currentAccountNumber)
        {
        // constructor body code
        } // end constructor

        public Withdrawal(int currentAccountNumber, Screen screen, BankDatabase bankDatabase, Keypad keypad, CashDispenser cashDispenser) : this(currentAccountNumber)
        {
            this.screen = screen;
            this.bankDatabase = bankDatabase;
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
        }

        // operations
        // perform transaction
        public void Execute()
        {
         // Execute method body code
        } // end method Execute

    } // end class Withdrawal
}