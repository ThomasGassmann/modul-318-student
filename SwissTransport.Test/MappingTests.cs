namespace SwissTransport.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Contains the tests to test the mapping.
    /// </summary>
    [TestClass]
    public class MappingTests
    {
        /// <summary>
        /// Contains the query service used to get the data.
        /// </summary>
        private readonly IQueryService queryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingTests"/> class.
        /// </summary>
        public MappingTests()
        {
            this.queryService = new TransportationQueryService();
        }

        /// <summary>
        /// Tests the mapping between two ordinary types.
        /// </summary>
        [TestMethod]
        public void CheckTypeMappingIsWorking()
        {
            // Arrange
            var connection = UnitTestActionHandler.ExecuteUnitTestFunction(() => this.queryService
                .GetConnections("Luzern", "Dagmersellen")
                .ConnectionList.First());

            // Act
            var mappedType = connection.Map<TransportConnection, ListViewItem>();

            // Assert
            Assert.IsNotNull(mappedType);
        }

        /// <summary>
        /// Checks whether the expected exception is thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckInvalidMap()
        {
            // Arrange
            var transportConnection = new TransportConnection();

            // Act
            var mappedType = transportConnection.Map<TransportConnection, TransportStation>();

            // Assert not needed, because there's an expected exception
        }
    }
}
