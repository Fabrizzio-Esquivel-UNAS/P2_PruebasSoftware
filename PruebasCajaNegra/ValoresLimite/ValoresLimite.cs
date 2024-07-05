using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ListaDeHabitaciones;

namespace ListaDeHabitacionesTests
{
    [TestClass]
    public class ValoresLimite
    {

        [TestMethod]
        public void Should_Allow_Input_When_Valid_Range()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();
            // Assert para cada entrada
            for (int i = 1; i < 7; i++)
            {
                // Act and Assert
                Assert.IsTrue(Program.RedirigirEntrada(i.ToString(), habitaciones, true));
            }
        }

        [TestMethod]
        public void Should_Not_Allow_Input_When_Invalid_Bottom_Range()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Program.RedirigirEntrada("0", habitaciones));
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Should_Not_Allow_Input_When_Null()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Program.RedirigirEntrada(null, habitaciones));
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Should_Not_Allow_Input_When_Invalid_Top_Range()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Program.RedirigirEntrada("7", habitaciones));
            Assert.IsNotNull(ex);
        }
    }
}
