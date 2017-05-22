namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Tests all functionality in the station query service, 
    /// to check whether the stations are queried in the correc way.
    /// </summary>
    [TestClass]
    public class TransportStationTests
    {
        /// <summary>
        /// Contains the query service to gather the stations.
        /// </summary>
        private readonly IQueryService transportQueryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportStationTests"/> class.
        /// </summary>
        public TransportStationTests()
        {
            this.transportQueryService = new TransportationQueryService();
        }

        /// <summary>
        /// Checks whether the specified station is valid.
        /// </summary>
        [TestMethod]
        public void CheckStationIsValid()
        {
            // Arrange, Act
            var stations = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.transportQueryService
                .GetStations("Uffikon, Kantonsstrasse"));

            // Assert
            Assert.AreEqual(stations.StationList.Count, 1);
            Assert.AreEqual(stations.StationList.Single().Id, "008572991");
        }
    }
}
