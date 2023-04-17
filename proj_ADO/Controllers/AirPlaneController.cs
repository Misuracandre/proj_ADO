using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj_ADO.Model;
using proj_ADO.Services;
// regras de negocio vai na camada services(acoes), a controler(controla as acoes) controla a services

namespace proj_ADO.Controllers
{
    public class AirPlaneController // está lincada com a camada de services, ela chama a services
    {
        public bool Insert(AirPlane airplane)
        {
            return new AirPlaneService().Insert(airplane);
        }

        public List<AirPlane> FindAll()
        {
            return new AirPlaneService().FindAll();
        }
    }
}
