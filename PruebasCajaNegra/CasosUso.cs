using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ListaDeHabitaciones;

namespace ListaDeHabitacionesTests
{
    [TestClass]
    public class CasosUso
    {
        [TestMethod]
        public void User_Adds_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");

            // Assert
            Assert.AreEqual(1, habitaciones.Count);
        }

        [TestMethod]
        public void User_Adds_And_Rents_Room()
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
        public void User_Adds_Rents_And_Leaves_Room()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act
            Program.AgregarHabitacion(habitaciones, "Habitacion 1");
            Program.MarcarHabitacionOcupada(habitaciones, "1");
            Program.MarcarHabitacionDesocupada(habitaciones, "1");

            // Assert
            Assert.AreEqual(1, habitaciones.Count);
            Assert.IsFalse(habitaciones[0].Ocupada);
        }

        [TestMethod]
        public void User_Adds_Rents_Leaves_And_Deletes_Room()
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
