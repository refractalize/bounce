using System.Collections.Generic;
using Bounce.Framework.Obsolete;
using Moq;
using NUnit.Framework;

namespace Bounce.Framework.Tests.Obsolete {
    [TestFixture]
    public class RemoteBounceTest {
        [Test]
        public void ShouldReturnRemoteTargetsAsWellAsLocalTargets() {
            var remote = new RemoteBounce();
            var remoteOne = new Mock<ITask>().Object;
            var localOne = new Mock<ITask>().Object;

            remote.ArgumentsForTargets(new { RemoteOne = remoteOne });

            var withRemoteTargets = (IDictionary<string, ITask>) remote.WithRemoteTargets(new {LocalOne = localOne});

            Assert.That(withRemoteTargets["LocalOne"], Is.SameAs(localOne));
            Assert.That(withRemoteTargets["RemoteOne"], Is.SameAs(remoteOne));
            Assert.That(withRemoteTargets.Count, Is.EqualTo(2));
        }
    }
}