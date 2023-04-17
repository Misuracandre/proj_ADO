using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_ADO.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Description { get; set; }

        #region Methods
        public override string ToString()
        {
            return $"Descrição: {Description}";
        }
        #endregion
    }
}
