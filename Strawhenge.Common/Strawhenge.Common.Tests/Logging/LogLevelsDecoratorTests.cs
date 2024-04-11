using System;
using Moq;
using Strawhenge.Common.Logging;
using Xunit;

namespace Strawhenge.Common.Tests.Logging
{
    public partial class LogLevelsDecoratorTests
    {
        const string Info = "Info message";
        const string Warning = "Warning message";
        const string Error = "Error message";
        static readonly Exception Exception = new Exception("This is an exception.");

        readonly Mock<ILogger> _innerLogger;
        readonly LogLevelsDecorator _decorator;

        public LogLevelsDecoratorTests()
        {
            _innerLogger = new Mock<ILogger>();
            _decorator = new LogLevelsDecorator(_innerLogger.Object);
        }

        [Fact]
        public void Should_send_log_messages_to_all_when_log_level_is_all()
        {
            _decorator.LogLevel = LogLevel.All;

            PerformLogging();

            Assert.Multiple(
                VerifyInformationLogged,
                VerifyWarningLogged,
                VerifyErrorLogged,
                VerifyExceptionLogged);
        }

        [Fact]
        public void Should_not_send_log_messages_to_any_when_log_level_is_none()
        {
            _decorator.LogLevel = LogLevel.None;

            PerformLogging();

            Assert.Multiple(
                VerifyInformationNotLogged,
                VerifyWarningNotLogged,
                VerifyErrorNotLogged,
                VerifyExceptionNotLogged);
        }

        [Fact]
        public void Should_only_send_log_message_to_error_and_exception_when_log_level_is_error()
        {
            _decorator.LogLevel = LogLevel.Error;

            PerformLogging();

            Assert.Multiple(
                VerifyInformationNotLogged,
                VerifyWarningNotLogged,
                VerifyErrorLogged,
                VerifyExceptionLogged);
        }


        void PerformLogging()
        {
            ILogger logger = _decorator;

            logger.LogInformation(Info);
            logger.LogWarning(Warning);
            logger.LogError(Error);
            logger.LogException(Exception);
        }
    }
}