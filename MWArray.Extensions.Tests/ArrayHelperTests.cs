using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATLAB.NET.Arrays;

namespace MWArray.Extensions.Tests
{
    [TestFixture()]
    public class ArrayHelperTests
    {
        #region DDArrayToEnumerable

        [Test()]
        public void DDArrayToEnumerable_Simple_Usage_Test()
        {
            Assert.That(() => ArrayHelper.DDArrayToEnumerable(new int[,] { { 4, 0, 0, 0 }, { 2, 2, 0, 0 }, { 1, 2, 1, 0 }, { 1, 1, 1, 1 } }),
                Is.EquivalentTo(new[] { new[] { 4, 0, 0, 0 }, new[] { 2, 2, 0, 0 }, new[] { 1, 2, 1, 0 }, new[] { 1, 1, 1, 1 } }));
        }

        [Test]
        public void DDArrayToEnumerable_NullArgument_Test()
        {
            Assert.That(() => ArrayHelper.DDArrayToEnumerable<int>(null), Throws.ArgumentNullException);
        }

        [Test()]
        public void DDArrayToEnumerable_8x10_Usage_Test()
        {
            var ik = new int[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };

            Assert.That(() => ArrayHelper.DDArrayToEnumerable(new int[,] {
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                }), Is.EquivalentTo(ik));
        }

        #endregion

        #region EnumerableToDDArray

        [Test()]
        public void EnumerableToDDArray_Simple_Usage_Test()
        {
            Assert.That(() => ArrayHelper.EnumerableToDDArray(new[] { new[] { 4, 0, 0, 0 }, new[] { 2, 2, 0, 0 }, new[] { 1, 2, 1, 0 }, new[] { 1, 1, 1, 1 } }),
                Is.EquivalentTo(new int[,] { { 4, 0, 0, 0 }, { 2, 2, 0, 0 }, { 1, 2, 1, 0 }, { 1, 1, 1, 1 } }));
        }

        [Test]
        public void EnumerableToDDArray_NullArgument_Test()
        {
            Assert.That(() => ArrayHelper.EnumerableToDDArray<int>(null), Throws.ArgumentNullException);
        }

        [Test()]
        public void EnumerableToDDArray_8x10_Usage_Test()
        {
            var ik = new int[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };

            Assert.That(() => ArrayHelper.EnumerableToDDArray(ik),
                Is.EquivalentTo(new int[,] {
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                }));
        }

        #endregion
    }
}