using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldTake1Damage()
        {
            var dummy = new Dummy(10, 10);
            dummy.TakeAttack(1);
            Assert.AreEqual(9, dummy.Health, "Dummy should take only 1 damage");
        }
        [Test]
        public void DummyShouldThrowAnExpeptionWhenDead()
        {
            var dummy = new Dummy(10, 10);
            dummy.TakeAttack(10);
            Assert.IsTrue(dummy.IsDead(), "Dummy should be dead");
        }
        [Test]
        public void DeadDummyShouldGiveXP()
        {
            var dummy = new Dummy(10, 10);
            dummy.TakeAttack(10);
            Assert.AreEqual(10, dummy.GiveExperience(), "The Dummy shoud be dead and give 10 XP");
        }
        [Test]
        public void AliveDummyShouldNOTGiveXP()
        {
            var dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy should not be able to give XP");
        }
    }
}