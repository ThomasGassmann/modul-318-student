namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using System;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Tests the connections between two locations.
    /// </summary>
    [TestClass]
    public class ConnectionTests
    {
        /// <summary>
        /// Contains the query service to create the requests.
        /// </summary>
        private readonly IQueryService queryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionTests"/> class.
        /// </summary>
        public ConnectionTests()
        {
            this.queryService = new TransportationQueryService();
        }

        /// <summary>
        /// Checks the connection between two stations.
        /// </summary>
        [TestMethod]
        public void CheckConnectionBetweenSurseeAndLucerne()
        {
            // Arrange, Act
            var connections = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.queryService.GetConnections(
                "Sursee", 
                "Luzern",
                new DateTime(2017, 5, 22),
                isArrivalTime: false));
            var connection = connections.ConnectionList.First();

            // Assert
            Assert.IsNotNull(connections);
            Assert.AreEqual(connections.ConnectionList.Count(), 4);
            Assert.AreEqual(connection.Duration, "00d00:27:00");
        }

        /// <summary>
        /// Checks the connection between two stations with arrival and departure time.
        /// </summary>
        [TestMethod]
        public void CheckConnectionWithArrivalAndDepartureTime()
        {
            // Arrange, Act
            var arrivalTimeConnections = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.queryService.GetConnections(
                "Sursee",
                "Luzern",
                new DateTime(2017, 5, 22),
                isArrivalTime: true));

            var departureTimeConnections = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.queryService.GetConnections(
                "Sursee",
                "Luzern",
                new DateTime(2017, 5, 22),
                isArrivalTime: false));

            // Assert
            Assert.IsNotNull(arrivalTimeConnections);
            Assert.IsNotNull(departureTimeConnections);
            Assert.AreEqual(arrivalTimeConnections.ConnectionList.Count(), 4);
            Assert.AreEqual(departureTimeConnections.ConnectionList.Count(), 4);
            Assert.AreNotEqual(
                departureTimeConnections.ConnectionList.First().From.DepartureDateTime,
                arrivalTimeConnections.ConnectionList.First().From.DepartureDateTime);
        }
    }
}
