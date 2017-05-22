namespace SwissTransport
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Test.Mock;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Tests the locatable statino service.
    /// </summary>
    [TestClass]
    public class LocatableStationServiceTests
    {
        /// <summary>
        /// Contains the locatable station service to test.
        /// </summary>
        private readonly ILocatableStationService locatableStationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocatableStationServiceTests"/> class.
        /// </summary>
        public LocatableStationServiceTests()
        {
            var fakeLocation = new FakeLocationProvider();
            this.locatableStationService = new LocatableStationService(
                fakeLocation,
                new TransportationQueryService());
        }

        /// <summary>
        /// Checks whether the cloest station is valid corresponding to the given fake location.
        /// </summary>
        [TestMethod]
        public void CheckStationsCloseAreValid()
        {
            // Arrange, Act
            var closestStation = this.locatableStationService.GetClosestStation();

            // Assert
            Assert.AreEqual(closestStation.Name, "Uffikon, Kantonsstrasse");
            Assert.AreEqual(closestStation.Id, "8572991");
            Assert.AreEqual(closestStation.Distance, 124.5);
        }

        /// <summary>
        /// Checks whether all locations close to the fake location are correct.
        /// </summary>
        [TestMethod]
        public void CheckCloseStationsCount()
        {
            // Arrange, Act
            var closestStations = this.locatableStationService.GetClosestStations();

            // Assert
            Assert.AreEqual(closestStations.Count(), 10);
            Assert.AreEqual(closestStations.First().Name, "Uffikon, Kantonsstrasse");
        }
    }
}
