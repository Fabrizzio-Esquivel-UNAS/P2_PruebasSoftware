using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ListaDeHabitaciones;

namespace ListaDeHabitacionesTests
{
    [TestClass]
    public class TransicionEstados
    {
        [TestMethod]
        public void ShouldReturnAddedStateWhenCreatingRoom()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");

            // Assert
            Assert.AreEqual(1, habitaciones.Count);
            Assert.IsTrue(habitaciones[0].Ocupada == false);
        }

        [TestMethod]
        public void ShouldReturnRentedStateWhenRentingRoom()
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
        public void ShouldReturnAvailableStateVacatingRoom()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");
            Program.MarcarHabitacionDesocupada(habitaciones, "1");

            // Assert
            Assert.AreEqual(1, habitaciones.Count);
            Assert.IsTrue(habitaciones[0].Ocupada == false);
        }

        [TestMethod]
        public void ShouldReturnDeletedStateWhenDeletingRoom()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");
            Program.MarcarHabitacionDesocupada(habitaciones, "1");
            Program.EliminarHabitacion(habitaciones, "1");

            // Assert
            Assert.AreEqual(0, habitaciones.Count);
        }

    }
}
