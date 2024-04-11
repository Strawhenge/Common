using Moq;

namespace Strawhenge.Common.Tests.Logging
{
    public partial class LogLevelsDecoratorTests
    {
        void VerifyInformationLogged() => _innerLogger.Verify(x => x.LogInformation(Info));

        void VerifyInformationNotLogged() => _innerLogger.Verify(x => x.LogInformation(Info), Times.Never);

        void VerifyWarningLogged() => _innerLogger.Verify(x => x.LogWarning(Warning));

        void VerifyWarningNotLogged() => _innerLogger.Verify(x => x.LogWarning(Warning), Times.Never);

        void VerifyErrorLogged() => _innerLogger.Verify(x => x.LogError(Error));

        void VerifyErrorNotLogged() => _innerLogger.Verify(x => x.LogError(Error), Times.Never);

        void VerifyExceptionLogged() => _innerLogger.Verify(x => x.LogException(Exception));

        void VerifyExceptionNotLogged() => _innerLogger.Verify(x => x.LogException(Exception), Times.Never);
    }
}