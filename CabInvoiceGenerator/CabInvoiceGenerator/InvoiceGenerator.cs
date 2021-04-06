using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   public class InvoiceGenerator
    {
        RideType rideType;
       
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FAIR;
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            
            try
            {
                if(rideType.Equals(RideType.NORMAL))
                {
                    MINIMUM_COST_PER_KM = 10;
                    COST_PER_TIME = 1;
                    MINIMUM_FAIR = 5;
                } 
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }
        public double CalculateFare(double distance , int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if(distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if(time<0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FAIR);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);

                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "rides are null");
                }

            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

    }
}
