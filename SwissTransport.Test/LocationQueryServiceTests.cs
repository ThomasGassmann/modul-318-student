namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using System.Threading;

    /// <summary>
    /// The main test class for the location.
    /// </summary>
    [TestClass]
    public class LocationQueryServiceTests
    {
        /// <summary>
        /// Contains the location query service to test.
        /// </summary>
        private readonly ILocationQueryService locationQueryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationQueryServiceTests"/> class.
        /// </summary>
        public LocationQueryServiceTests()
        {
            this.locationQueryService = new LocationQueryService();
        }

        /// <summary>
        /// Tests, whether the given location is not null.
        /// </summary>
        [TestMethod]
        public void TestCurrentLocationIsReturned()
        {
            var location = this.locationQueryService.GetCurrentLocation();
            Assert.IsNotNull(location);
        }
    }
}
