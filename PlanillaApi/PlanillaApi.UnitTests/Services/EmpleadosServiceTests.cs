using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanillaApi.UnitTests.Services
{
    [TestClass]
    public class EmpleadosServiceTests
    {
        [TestMethod]
        public void CrearEmpleado_NoHayPlazaDisponible_NoDebePermitirElRegistro()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CrearEmpleado_ExcedeTechoSalarial_NoDebePermitirElRegistro()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CrearEmpleado_HayPlazaDisponibleYNoExcedeRangoSalarial_DebePermitirElRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
