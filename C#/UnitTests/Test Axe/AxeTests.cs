using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeDurabilityShouldLowerAfterAnAttack()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }
        [Test]
        public void AxeShouldNotAttackWhenBroaken()
        {
            var axe = new Axe(10, 0);
            var dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe cannot Attack when broaken.");
        }
    }
}