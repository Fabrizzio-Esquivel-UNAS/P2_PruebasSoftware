using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ListaDeHabitaciones;
using System.Threading;

namespace ListaDeHabitacionesTests
{
    [TestClass]
    public class ParticionEquivalencia
    {
        [TestMethod]
        public void Should_Rent_Room_In_Range()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();
            int cantidad = 10;

            // Act
            for (int i = 0; i < cantidad; i++)
            {
                Program.AgregarHabitacion(habitaciones, "");
            }
            
            Program.MarcarHabitacionOcupada(habitaciones, "1");
            // Assert
            Assert.AreEqual(cantidad, habitaciones.Count);
            Assert.IsTrue(habitaciones[0].Ocupada);
        }

        [TestMethod]
        public void Should_Not_Rent_Room_Outside_Range()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();
            int cantidad = 10;

            // Act
            for (int i = 0; i < cantidad; i++)
            {
                Program.AgregarHabitacion(habitaciones, "");
            }

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Program.MarcarHabitacionOcupada(habitaciones, "11"));
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void Should_Not_Rent_Room_When_No_Existing_Rooms()
        {
            // Arrange
            List<Habitacion> habitaciones = new List<Habitacion>();

            // Act and Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Program.EliminarHabitacion(habitaciones, "1"));
            Assert.IsNotNull(ex);
        }
    }
}
