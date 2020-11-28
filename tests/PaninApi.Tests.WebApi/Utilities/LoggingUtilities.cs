using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Moq;

namespace PaninApi.Tests.WebApi.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class LoggingUtilities
    {
        public static Mock<ILogger<T>> SetupTrace<T>(this Mock<ILogger<T>> logger) =>
            logger.Setup(LogLevel.Trace);
        
        public static Mock<ILogger<T>> VerifyTrace<T>(this Mock<ILogger<T>> logger, Func<Times> times) =>
            logger.Verify(LogLevel.Trace, times);
        
        public static Mock<ILogger<T>> SetupDebug<T>(this Mock<ILogger<T>> logger) =>
            logger.Setup(LogLevel.Debug);
        
        public static Mock<ILogger<T>> VerifyDebug<T>(this Mock<ILogger<T>> logger, Func<Times> times) =>
            logger.Verify(LogLevel.Debug, times);

        private static Mock<ILogger<T>> Setup<T>(this Mock<ILogger<T>> logger, LogLevel expectedLevel)
        {
            logger.Setup(x => x.Log(
                It.Is<LogLevel>(level => level == expectedLevel),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));

            return logger;
        }

        private static Mock<ILogger<T>> Verify<T>(this Mock<ILogger<T>> logger, LogLevel expectedLevel, Func<Times> times)
        {
            logger.Verify(x => x.Log(
                It.Is<LogLevel>(level => level == expectedLevel),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), times);

            return logger;
        }
    }
}