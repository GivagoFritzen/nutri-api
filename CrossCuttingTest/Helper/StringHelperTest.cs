using Application.ViewModel.Pacientes;
using CrossCutting.Helpers;
using Domain.Entity;
using Domain.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossCuttingTest.Helper
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void Get_Event_Name_Without_Event()
        {
            var retorno = StringHelper.GetEventName(typeof(PacienteEvent).Name);
            Assert.AreEqual("Paciente", retorno);
        }

        [TestMethod]
        public void Get_Event_Name_Without_ViewModel()
        {
            var retorno = StringHelper.GetEventName(typeof(PacienteViewModel).Name);
            Assert.AreEqual("Paciente", retorno);
        }

        [TestMethod]
        public void Get_Event_Name_Without_Entity()
        {
            var retorno = StringHelper.GetEventName(typeof(PacienteEntity).Name);
            Assert.AreEqual("Paciente", retorno);
        }
    }
}
