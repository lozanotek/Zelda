namespace Zelda.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ListRepositoryTest {
        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void ArgumentNullException_Is_Thrown_With_Null_Seed() {
            new ListRepository<int>(null);
        }

        [Test]
        public void Valid_Creation_Of_Instance_With_Empty_Seed() {
            var temp = new ListRepository<int>(new List<int>());

            Assert.IsNotNull(temp);
            Assert.IsEmpty(temp.ToList());
        }

        [Test]
        public void Simple_Select_With_Integers() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5});

            var value = temp.FirstOrDefault(val => val == 2);
            Assert.AreEqual(value, 2);
        }

        [Test]
        public void Simple_Select_With_Syntactic_Sugar_Integers() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });
            var value = (from val in temp where val == 2 select val).FirstOrDefault();

            Assert.AreEqual(value, 2);
        }

        [Test]
        public void Simple_Select_With_Integers_And_No_Match() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });

            var value = temp.FirstOrDefault(val => val == 9);
            Assert.AreNotEqual(value, 9);
        }

        [Test]
        public void Simple_Remove_With_Integers() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });
            var count = temp.Count();

            temp.Remove(5);

            Assert.AreNotEqual(count, temp.Count());
        }

        [Test]
        public void Simple_Remove_With_Integers_No_Match() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });
            var count = temp.Count();

            temp.Remove(9);

            Assert.AreEqual(count, temp.Count());
        }

        [Test]
        public void Simple_Update_With_Integers() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });
            temp.Update(5);

            Assert.AreEqual(temp.ToList()[4], 5);
        }

        [Test]
        public void Simple_Update_With_Integers_No_Match() {
            var temp = new ListRepository<int>(new List<int> { 1, 2, 3, 4, 5 });
            temp.Update(9);

            Assert.AreNotEqual(temp.ToList()[4], 9);
        }
    }
}
