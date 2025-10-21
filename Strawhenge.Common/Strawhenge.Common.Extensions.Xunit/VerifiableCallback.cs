using System;
using Xunit;

namespace Strawhenge.Common.Extensions.Xunit
{
    public class VerifiableCallback
    {
        public static implicit operator Action(VerifiableCallback callback) => callback.OnInvoked;

        int _invokedCount;

        public void VerifyInvoked(int times) =>
            Assert.True(
                _invokedCount == times,
                $"Expected callback invoked {times} times, but was invoked {_invokedCount} times.");

        public void VerifyInvokedNever() => VerifyInvoked(0);

        public void VerifyInvokedOnce() => VerifyInvoked(1);

        void OnInvoked() => _invokedCount++;
    }
}