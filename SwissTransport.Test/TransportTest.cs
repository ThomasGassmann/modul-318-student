namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;

    [TestClass]
    public class TransportTest
    {
        private readonly IQueryService queryService;

        public TransportTest()
        {
            this.queryService = new TransportationQueryService();
        }

        [TestMethod]
        public void Locations()
        {
            var stations = this.queryService.GetStations("Sursee,");


            Assert.AreEqual(50, stations.StationList.Count);
        }

        [TestMethod]
        public void StationBoard()
        {
            var stationBoard = this.queryService.GetStationBoard("Sursee", "8502007");

            Assert.IsNotNull(stationBoard);
        }

        [TestMethod]
        public void Connections()
        {
            var connections = this.queryService.GetConnections("Sursee", "Luzern");

            Assert.IsNotNull(connections);
        }
    }
}
