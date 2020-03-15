using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.Money
{
    public class Screen
    {
        // displays a message without a terminating carriage return
        public void DisplayMessage(string message)
        {
            Console.Write(message);
        } // end method DisplayMessage

        // display a message with a terminating carriage return
        public void DisplayMessageLine(string message)
        {
            Console.WriteLine(message);
        } // end method DisplayMessageLine

        // display a dollar amount
        public void DisplayDollarAmount(decimal amount)
        {
            Console.Write("{0:C}", amount);
        } // end method DisplayDollarAmount
    } // end class Screen
}
