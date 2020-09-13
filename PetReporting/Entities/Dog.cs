using System.Text;

namespace PetReporting.Entities
{
    public class Dog : Pet
    {
        public override StringBuilder ToCSV()
        {
            return base.ToCSV();
        }
    }
}
