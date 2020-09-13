using System;
using System.Text;

namespace PetReporting.Entities
{
    public abstract class Pet : Owner
    {
        public int numberofVisits;
        public DateTime joinedPractice ;
        public double CostPerVisit;

        public virtual StringBuilder ToCSV()
        {
            var stringBuilder = new StringBuilder(string.Join(" ", Firstname, Lastname));
            stringBuilder.Append($",{joinedPractice.ToString("d")}");
            stringBuilder.Append($",{numberofVisits}");

            return stringBuilder;
        }
    }
}
