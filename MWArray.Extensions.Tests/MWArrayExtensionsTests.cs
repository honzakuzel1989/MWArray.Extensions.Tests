using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Arrays;

namespace MWArray.Extensions.Tests
{
    [TestFixture()]
    public class MWArrayExtensionsTests
    {
        #region ToSingleItem

        [Test()]
        public void MWArray_ToSingleItem_ArgumentException_Test()
        {
            Assert.That(() => MWArrayExtensions.ToSingleItem<string>(null), Throws.ArgumentNullException);
            Assert.That(() => MWArrayExtensions.ToSingleItem<double>(MWCellArray.Empty), Throws.ArgumentException);

            Assert.That(() => MWArrayExtensions.ToSingleItem<string>(null), Throws.ArgumentNullException);
            Assert.That(() => MWArrayExtensions.ToSingleItem<bool>(MWCellArray.Empty), Throws.ArgumentException);
        }

        [Test()]
        public void MWArray_ToSingleItem_Empty_Array_ArgumentException_Test()
        {
            Assert.That(() => MWArrayExtensions.ToSingleItem<bool>(new MWNumericArray()), Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(-7)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void MWArray_ToSingleItem_Int_to_Bool_Test(int item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<bool>(new MWNumericArray(item)), Is.EqualTo(item == 0 ? false : true));
        }

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(-7)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void MWArray_ToSingleItem_Int_to_String_Test(int item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<string>(new MWNumericArray(item)), Is.EqualTo(item.ToString()));
        }

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(-7)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void MWArray_ToSingleItem_Int_to_Int_Test(int item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<int>(new MWNumericArray(item)), Is.EqualTo(item));
        }

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(-7)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void MWArray_ToSingleItem_Int_to_Double_Test(int item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<double>(new MWNumericArray(item)), Is.EqualTo((double)item));
        }

        [TestCase(0.0)]
        [TestCase(17.7)]
        [TestCase(-7.1989)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void MWArray_ToSingleItem_Double_to_Double_Test(double item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<double>(new MWNumericArray(item)), Is.EqualTo(item));
        }

        [TestCase(0.0)]
        [TestCase(17.7)]
        [TestCase(-7.1989)]
        [TestCase(0)]
        [TestCase(17)]
        [TestCase(-7)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void MWArray_ToSingleItem_Double_to_String_Test(double item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<string>(new MWNumericArray(item)), Is.EqualTo(item.ToString()));
        }

        [TestCase(0.0)]
        [TestCase(17.7)]
        [TestCase(-7.1989)]
        public void MWArray_ToSingleItem_Double_to_Int_Test(double item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<int>(new MWNumericArray(item)), Is.EqualTo(Convert.ToInt32(item)));
        }

        [TestCase(0.0)]
        [TestCase(17.7)]
        [TestCase(-7.1989)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void MWArray_ToSingleItem_Double_to_Bool_Test(double item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<bool>(new MWNumericArray(item)), Is.EqualTo(Convert.ToBoolean(item)));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void MWArray_ToSingleItem_Bool_to_Bool_Test(bool item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<bool>(new MWLogicalArray(item)), Is.EqualTo(Convert.ToBoolean(item)));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void MWArray_ToSingleItem_Bool_to_Int_Test(bool item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<int>(new MWLogicalArray(item)), Is.EqualTo(Convert.ToInt32(item)));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void MWArray_ToSingleItem_Bool_to_Double_Test(bool item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<double>(new MWLogicalArray(item)), Is.EqualTo(Convert.ToDouble(item)));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void MWArray_ToSingleItem_Bool_to_String_Test(bool item)
        {
            Assert.That(MWArrayExtensions.ToSingleItem<string>(new MWLogicalArray(item)), Is.EqualTo(Convert.ToString(item)));
        }

        #endregion

        #region ToArray

        [Test()]
        public void MWArray_ToArray_ArgumentException_Test()
        {
            Assert.That(() => MWArrayExtensions.ToArray<int>(null), Throws.ArgumentNullException);
            Assert.That(() => MWArrayExtensions.ToArray<double>(MWStructArray.Empty), Throws.ArgumentException);
        }

        [Test]
        public void MWArray_ToArray_Empty_Int_Test()
        {
            Assert.That(MWArrayExtensions.ToArray<int>(new MWNumericArray()), Is.EquivalentTo(Array.Empty<int>()));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Int_Test(int[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<int>(new MWNumericArray(item as Array)), Is.EquivalentTo(item));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Int_to_Bool_Test(int[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<bool>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToBoolean(i))));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Int_to_Double_Test(int[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<double>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToDouble(i))));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Int_to_String_Test(int[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<string>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => i.ToString())));
        }

        [Test]
        public void MWArray_ToArray_BigArray_Int_Test()
        {
            var largeItem = Enumerable.Range(-50000, 50000).ToArray();
            Assert.That(MWArrayExtensions.ToArray<int>(new MWNumericArray(largeItem as Array)), Is.EquivalentTo(largeItem));
        }

        [Test]
        public void MWArray_ToArray_Empty_Double_Test()
        {
            Assert.That(MWArrayExtensions.ToArray<double>(new MWNumericArray()), Is.EquivalentTo(Array.Empty<double>()));
        }

        [TestCase(new double[] { })]
        [TestCase(new double[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Double_Test(double[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<double>(new MWNumericArray(item as Array)), Is.EquivalentTo(item));
        }

        [TestCase(new double[] { })]
        [TestCase(new double[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Double_to_Bool_Test(double[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<bool>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToBoolean(i))));
        }

        [TestCase(new double[] { })]
        [TestCase(new double[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Double_to_Int_Test(double[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<int>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToInt32(i))));
        }

        [TestCase(new double[] { })]
        [TestCase(new double[] { 1, 2, 3, 4, 5 })]
        public void MWArray_ToArray_Double_to_String_Test(double[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<string>(new MWNumericArray(item as Array)), Is.EquivalentTo(item.Select(i => i.ToString())));
        }

        [Test]
        public void MWArray_ToArray_BigArray_Double_Test()
        {
            var largeItem = Enumerable.Range(-50000, 50000).Select(i => (double)i).ToArray();
            Assert.That(MWArrayExtensions.ToArray<double>(new MWNumericArray(largeItem as Array)), Is.EquivalentTo(largeItem));
        }

        [Test]
        public void MWArray_ToArray_Empty_Bool_Test()
        {
            Assert.That(MWArrayExtensions.ToArray<bool>(new MWLogicalArray()), Is.EquivalentTo(Array.Empty<bool>()));
        }

        // INFO: chova se odlisne nez napr MWNumericArray - vyhazuje vyjimku pri vytvareni MWLogicalArray, kdezto u MWNumericArray vytvori prazdne
        //[TestCase(new bool[] { })]
        [TestCase(new bool[] { true })]
        [TestCase(new bool[] { false })]
        [TestCase(new bool[] { true, false, true, false, true })]
        public void MWArray_ToArray_Bool_Test(bool[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<bool>(new MWLogicalArray(item as Array)), Is.EquivalentTo(item));
        }

        [TestCase(new bool[] { true })]
        [TestCase(new bool[] { false })]
        [TestCase(new bool[] { true, false, true, false, true })]
        public void MWArray_ToArray_Bool_to_Int_Test(bool[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<int>(new MWLogicalArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToInt32(i))));
        }

        [TestCase(new bool[] { true })]
        [TestCase(new bool[] { false })]
        [TestCase(new bool[] { true, false, true, false, true })]
        public void MWArray_ToArray_Bool_to_Double_Test(bool[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<double>(new MWLogicalArray(item as Array)), Is.EquivalentTo(item.Select(i => Convert.ToDouble(i))));
        }

        [TestCase(new bool[] { true })]
        [TestCase(new bool[] { false })]
        [TestCase(new bool[] { true, false, true, false, true })]
        public void MWArray_ToArray_Bool_to_String_Test(bool[] item)
        {
            Assert.That(MWArrayExtensions.ToArray<string>(new MWLogicalArray(item as Array)), Is.EquivalentTo(item.Select(i => i.ToString())));
        }

        [Test]
        public void MWArray_ToArray_BigArray_Bool_Test()
        {
            var largeItem = Enumerable.Range(-50000, 50000).Select(i => true).ToArray();
            Assert.That(MWArrayExtensions.ToArray<bool>(new MWLogicalArray(largeItem as Array)), Is.EquivalentTo(largeItem));
        }

        #endregion

        #region ToEnumerableOfArray

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_ArgumentException_Test()
        {
            Assert.That(() => MWArrayExtensions.ToEnumerableOfArrays<object>(null), Throws.ArgumentNullException);
            Assert.That(() => MWArrayExtensions.ToEnumerableOfArrays<short>(MWStructArray.Empty), Throws.ArgumentException);
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Empty_Array_Test()
        {
            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray()), Is.EquivalentTo(Array.Empty<IEnumerable<int[]>>()));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Array_Of_Null_Test()
        {
            var ik = new int[8][];

            // INFO: new MWNumericArray throws nullreferenceexception.
            //Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray(ik)), Is.EquivalentTo(ik));
            Assert.Pass();
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Array_Of_Empty_Arrays_Test()
        {
            var ik = new int[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new int[] { };

            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray(ik)), Is.EquivalentTo(ik));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Array_With_One_Item_Test()
        {
            var ik = new int[1][];
            for (int i = 0; i < 1; i++)
                ik[i] = new int[] { 1 };

            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray(ik)), Is.EquivalentTo(ik));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Int_to_Int_Test()
        {
            var ik = new int[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };

            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray(ik)), Is.EquivalentTo(ik));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Double_to_Double_Test()
        {
            var ik = new double[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };

            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<double>(new MWNumericArray(ik)), Is.EquivalentTo(ik));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_Bool_to_Bool_Test()
        {
            var ik = new bool[8][];
            for (int i = 0; i < 8; i++)
                ik[i] = new bool[] { false, false, false, true, true, false, false, false };

            // INFO: nefunguje, zahlasi chybu pri konstrukci
            //Assert.That(MWArrayExtensions.ToEnumerableOfArray<bool>(new MWLogicalArray(ik as Array)), Is.EquivalentTo(ik));
            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<bool>(new MWLogicalArray(8, 8, ik.SelectMany(b => b.ToArray()).ToArray())), Is.EquivalentTo(ik));
        }

        [Test()]
        public void MWArray_ToEnumerableOfNumericArray_RangeInt_to_Int_Test()
        {
            //INFO: matlab implicitne pridava jednu dimenzi !
            var ia = Enumerable.Range(1, 1000).ToArray();

            // takze [0, 1000] se zmeni na [0] = [1000]
            var res = new int[1][];
            res[0] = ia;

            Assert.That(MWArrayExtensions.ToEnumerableOfArrays<int>(new MWNumericArray(ia as Array)),
                Is.EquivalentTo(res));
        }

        #endregion

        #region GetField
        [Test()]
        public void MWArray_GetField_NullReferenceException_Test()
        {
            Assert.That(() => MWArrayExtensions.GetField(null, "field"), Throws.ArgumentNullException);
            Assert.That(() => MWArrayExtensions.GetField(new MWStructArray(), null), Throws.ArgumentNullException);
        }

        [Test()]
        public void MWArray_GetField_ArgumentException_Test()
        {
            Assert.That(() => MWArrayExtensions.GetField(new MWNumericArray(), "field"), Throws.ArgumentException);
            Assert.That(() => MWArrayExtensions.GetField(new MWStructArray(), "\n"), Throws.ArgumentException);
            Assert.That(() => MWArrayExtensions.GetField(new MWStructArray(), "field", -1), Throws.ArgumentException);
        }

        [Test()]
        public void MWArray_GetField_Scalar_Int_Input()
        {
            var f = "intfield";
            int value = 42424242;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Byte_Input()
        {
            var f = "bytefield";
            byte value = 42;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Float_Input()
        {
            var f = "floatfield";
            float value = 42.42f;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Double_Input()
        {
            var f = "doublefield";
            double value = 42.42;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Long_Input()
        {
            var f = "longfield";
            long value = 424242424242424;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Short_Input()
        {
            var f = "shortfield";
            short value = 42;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = value;

            var ra = new MWNumericArray(value);

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(ra));
        }

        [Test()]
        public void MWArray_GetField_Scalar_Multiple_Input()
        {
            var sf = "shortfield";
            var lf = "longfield";
            var _if = "intfield";

            short svalue = 42;
            long lvalue = 424242424242424;
            int ivalue = 42424242;

            var sa = new MWStructArray(new int[] { 1 }, new string[] { sf, lf, _if });
            sa[sf] = svalue;
            sa[lf] = lvalue;
            sa[_if] = ivalue;

            var lra = new MWNumericArray(lvalue);
            var ira = new MWNumericArray(ivalue);
            var sra = new MWNumericArray(svalue);

            Assert.That(MWArrayExtensions.GetField(sa, sf).Equals(sra));
            Assert.That(MWArrayExtensions.GetField(sa, lf).Equals(lra));
            Assert.That(MWArrayExtensions.GetField(sa, _if).Equals(ira));
        }

        [Test()]
        public void MWArray_GetField_Array_Int_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWNumericArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Array_Double_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).Select(i => (double)i).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWNumericArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Array_Bool_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).Select(i => i % 2 == 0).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWLogicalArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Bool_Input()
        {
            var f = "arrayfield";
            bool value = true;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWLogicalArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Array_String_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).Select(i => i.ToString()).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWCharArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_String_Input()
        {
            var f = "arrayfield";
            string value = "value";
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWCharArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Char_Input()
        {
            var f = "arrayfield";
            char value = 'c';
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var result = new MWCharArray(value);

            sa[f] = result;

            Assert.That(MWArrayExtensions.GetField(sa, f).Equals(result));
        }

        [Test()]
        public void MWArray_GetField_Composite_Field_Name_Input()
        {
            var f1 = "composite";
            var f2 = "field";

            var f = $"{f1}.{f2}";
            Array value = Enumerable.Range(0, 42).ToArray();
            var result = new MWNumericArray(value);

            var sa1 = new MWStructArray(new int[] { 1 }, new string[] { f1 });
            var sa2 = new MWStructArray(new int[] { 1 }, new string[] { f2 });

            sa1[f1] = sa2;
            sa2[f2] = result;

            Assert.That(MWArrayExtensions.GetField(sa1, f).Equals(result));
            Assert.That(MWArrayExtensions.GetField(sa2, f2).Equals(result));
            Assert.That(MWArrayExtensions.GetField(sa1, f1).Equals(sa2));
        }

        [Test()]
        public void MWArray_GetField_InvalidOperationException_NonExists_Field_Test()
        {
            var f = "arrayfield";
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            sa[f] = new MWNumericArray();

            Assert.That(() => MWArrayExtensions.GetField(sa, "nonexists"), Throws.InvalidOperationException);

        }

        [Test()]
        public void MWArray_GetField_InvalidOperationException_EmptyStructArray_Test()
        {
            Assert.That(() => MWArrayExtensions.GetField(new MWStructArray(), "epmty"), Throws.InvalidOperationException);

        }
        #endregion

        #region GetFieldAsSingleItem (== GetField + ToSingleItem)
        [Test()]
        public void MWArray_GetFieldAsSingleItem_Numeric_Input()
        {
            var f = "arrayfield";
            var value = 42.42f;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWNumericArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsSingleItem<double>(sa, f), Is.EqualTo(value));
        }

        [Test()]
        public void MWArray_GetFieldAsSingleItem_Bool_Input()
        {
            var f = "arrayfield";
            var value = false;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWLogicalArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsSingleItem<bool>(sa, f), Is.EqualTo(value));
        }

        public void MWArray_GetFieldAsSingleItem_Numeric_Multiple_Input()
        {
            var f = "arrayfield";
            int first = 0;
            Array value = Enumerable.Range(first, 42).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWNumericArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsSingleItem<double>(sa, f), Is.EqualTo(first));
        }

        [Test()]
        public void MWArray_GetFieldAsSingleItem_Bool_Multiple_Input()
        {
            var f = "arrayfield";
            bool first = 0 % 2 == 0;
            Array value = Enumerable.Range(0, 42).Select(i => i % 2 == 0).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWLogicalArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsSingleItem<bool>(sa, f), Is.EqualTo(first));
        }
        #endregion

        #region GetFieldAsArray (== GetField + ToArray)
        [Test()]
        public void MWArray_GetFieldAsArray_Numeric_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).Select(i => (double)i).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWNumericArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsArray<double>(sa, f), Is.EquivalentTo(value));
        }

        [Test()]
        public void MWArray_GetFieldAsArray_Bool_Input()
        {
            var f = "arrayfield";
            Array value = Enumerable.Range(0, 42).Select(i => i % 2 == 0).ToArray();
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWLogicalArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsArray<bool>(sa, f), Is.EquivalentTo(value));
        }

        [Test()]
        public void MWArray_GetFieldAsArray_Bool_Single_Input()
        {
            var f = "arrayfield";
            bool value = true;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWLogicalArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsArray<bool>(sa, f), Is.EquivalentTo(new bool[] { value }));
        }

        [Test()]
        public void MWArray_GetFieldAsArray_Numeric_Single_Input()
        {
            var f = "arrayfield";
            int value = 42;
            var sa = new MWStructArray(new int[] { 1 }, new string[] { f });
            var na = new MWNumericArray(value);

            sa[f] = na;

            Assert.That(MWArrayExtensions.GetFieldAsArray<double>(sa, f), Is.EquivalentTo(new int[] { value }));
        }
        #endregion
    }
}