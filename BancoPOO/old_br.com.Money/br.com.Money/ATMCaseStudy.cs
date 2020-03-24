using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.Money
{
    // Application for testing the ATM case study.
    public class ATMCaseStudy
    {
        // Main method is the application's entry point
        public static void Main(string[] args)
        {
            ATM theATM = new ATM();
            theATM.Run();
        } // end method Main
    } // end class ATMCaseStudy
}
