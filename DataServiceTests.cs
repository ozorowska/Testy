using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestProjectAO.UnitTests
{
    [TestFixture]
    public class DataServiceTests
    {
        private Mock<IDataFetcher> _dataFetcherMock;
        private Mock<ILogger> _loggerMock;
        private Mock<IEmailService> _emailServiceMock;
        private Mock<ICacheService> _cacheServiceMock;
        private DataService _dataService;

        [SetUp]
        public void SetUp()
        {
            _dataFetcherMock = new Mock<IDataFetcher>();
            _loggerMock = new Mock<ILogger>();
            _emailServiceMock = new Mock<IEmailService>();
            _cacheServiceMock = new Mock<ICacheService>();
            _dataService = new DataService(
                _dataFetcherMock.Object,
                _loggerMock.Object,
                _emailServiceMock.Object,
                _cacheServiceMock.Object
            );
        }

        [Test]
        public void GetData_WhenCalled_FetchesDataFromDataFetcher()
        {
            _dataFetcherMock.Setup(df => df.FetchData()).Returns("fetched data");

            var result = _dataService.GetData();

            Assert.That(result, Is.EqualTo("fetched data"));
        }

        [Test]
        public void ProcessData_WhenCalled_ConvertsFetchedDataToUpperCase()
        {
            _dataFetcherMock.Setup(df => df.FetchData()).Returns("lowercase");

            var result = _dataService.ProcessData();

            Assert.That(result, Is.EqualTo("LOWERCASE"));
        }

        [Test]
        public void ValidateData_WithValidString_ReturnsTrue()
        {
            var result = _dataService.ValidateData("valid data");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateData_WithEmptyString_ReturnsFalse()
        {
            var result = _dataService.ValidateData(string.Empty);

            Assert.That(result, Is.False);
        }

        [Test]
        public void SplitData_WithCommaSeparatedString_ReturnsListOfStrings()
        {
            var result = _dataService.SplitData("one,two,three");

            Assert.That(result, Is.EqualTo(new List<string> { "one", "two", "three" }));
        }

        [Test]
        public void LogData_WhenCalled_LogsMessage()
        {
            var logMessage = "This is a log message";

            _dataService.LogData(logMessage);

            _loggerMock.Verify(logger => logger.Log(logMessage), Times.Once);
        }

        [Test]
        public void SendNotification_WhenCalled_SendsEmail()
        {
            var emailMessage = "This is an email message";

            _dataService.SendNotification(emailMessage);

            _emailServiceMock.Verify(emailService => emailService.SendEmail(emailMessage), Times.Once);
        }

        [Test]
        public void GetCachedData_WhenCalled_ReturnsCachedValue()
        {
            var cacheKey = "cacheKey";
            var cachedData = "cached data";

            _cacheServiceMock.Setup(cacheService => cacheService.Get(cacheKey)).Returns(cachedData);

            var result = _dataService.GetCachedData(cacheKey);

            Assert.That(result, Is.EqualTo(cachedData));
        }

        [Test]
        public void CacheData_WhenCalled_CachesValue()
        {
            var cacheKey = "cacheKey";
            var data = "data to cache";

            _dataService.CacheData(cacheKey, data);

            _cacheServiceMock.Verify(cacheService => cacheService.Set(cacheKey, data), Times.Once);
        }

        [Test]
        public void GetData_WhenDataFetcherThrowsException_ThrowsException()
        {
            _dataFetcherMock.Setup(df => df.FetchData()).Throws(new InvalidOperationException());

            Assert.Throws<InvalidOperationException>(() => _dataService.GetData());
        }
    }
}
