namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using System;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Tests whether the station board returns the correct data.
    /// </summary>
    [TestClass]
    public class StationBoardTests
    {
        /// <summary>
        /// Contains the interface used to query the data.
        /// </summary>
        private readonly IQueryService stationBoardQueryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationBoardTests"/> class.
        /// </summary>
        public StationBoardTests()
        {
            this.stationBoardQueryService = new TransportationQueryService();
        }

        /// <summary>
        /// Checks whether the station board for the given station is valid.
        /// </summary>
        [TestMethod]
        public void CheckStationBoardContainsValidEntries()
        {
            // Arrange, Act
            var stationBoard = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.stationBoardQueryService
                .GetStationBoard("8572991", new DateTime(2017, 5, 22)));

            // Assert
            Assert.IsNotNull(stationBoard);
            Assert.AreEqual(stationBoard.Entries.Count, 20);
            Assert.AreEqual(stationBoard.Station.Name, "Uffikon, Kantonsstrasse");
            Assert.IsTrue(stationBoard.Entries
                .All(x => x.To == "Sursee, Bahnhof" || x.To == "Dagmersellen, Dorf"));
        }
    }
}
