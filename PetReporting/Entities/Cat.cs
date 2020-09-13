using System.Text;

namespace PetReporting.Entities
{
    public class Cat : Pet
    {
        public int? numberOfLives;

        public override StringBuilder ToCSV()
        {
            StringBuilder stringBuilder = base.ToCSV();
            stringBuilder.Append($",{numberOfLives}");

            return stringBuilder;
        }
    }
}
