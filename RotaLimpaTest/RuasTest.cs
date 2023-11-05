using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RotaLimpa.Api;

namespace RotaLimpaTest
{
    [TestClass]
    public class RuasTest
    {
        [TestMethod]
        public void RuasDoesExiste()
        {
            RuasController rua = new RuasController();
            bool GetSingle;

            GetSingle = rua.GetSingle(1);

            Assert.IsTrue(GetSingle);
        }
        
        [TestMethod]
        public void RuasDoesNotExiste()
        {
            //TODO;
            Assert.Inconclusive();
        }

        [TestMethod]
        public void RuasNullOrEmpty_Throw()
        {
            //TODO;
            Assert.Inconclusive();
        }
    }
}
