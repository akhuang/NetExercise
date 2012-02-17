using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BackgroundWorker_Ex02
{
    public class CalculatePrimeProgressChangedEventArgs : ProgressChangedEventArgs
    {
        private int latestPrimeNumberValue = 1;

        public CalculatePrimeProgressChangedEventArgs(
            int latestPrime,
            int progressPercentage,
            object userToken)
            : base(progressPercentage, userToken)
        {
            this.latestPrimeNumberValue = latestPrime;
        }

        public int LatestPrimeNumber
        {
            get
            {
                return latestPrimeNumberValue;
            }
        }
    }
}
