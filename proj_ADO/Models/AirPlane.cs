using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj_ADO.Models;

namespace proj_ADO.Model
{
    public class AirPlane
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPassagers { get; set; }
        public string Description { get; set; }
        public Engine Engine { get; set; } // conceito associacao

        #endregion

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name} \nNumerOfPassagers: {NumberOfPassagers} \nDescription: {Description} \nMotor: {Engine}";
        }
    }
}
