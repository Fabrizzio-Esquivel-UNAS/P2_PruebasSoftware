using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ListaDeHabitaciones;
using NuGet.Frameworks;
using System.Threading;

namespace ListaDeHabitacionesTests
{
    [TestClass]
    public class TablaDecision
    {
        [TestMethod]
        public void Should_Rent_Available_Existing_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");

            // Assert
            Assert.AreEqual(1, habitaciones.Count);
            Assert.IsTrue(habitaciones[0].Ocupada);
        }

        [TestMethod]
        public void Should_Not_Rent_Occuped_Existing_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Program.MarcarHabitacionOcupada(habitaciones, "1"));
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Should_Not_Rent_Occuped_NotExisting_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Program.EliminarHabitacion(habitaciones, "1"));
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Should_Not_Rent_NotOccuped_NotExisting_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act & Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Program.MarcarHabitacionOcupada(habitaciones, "1"));
            Assert.IsNotNull(ex);
        }
    }
}
