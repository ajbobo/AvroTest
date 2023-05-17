using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AvroTest
{
    [TestClass]
    public class BasicTests
    {
        /******************************************************************************************************/

        public static IEnumerable<object[]> ProvideObject1s()
        {
            yield return new object[] { new Object1(){ intVal_1 = 1, floatVal = 1.1f, intVal_2= 2}, "As3MjD8E" };
            // yield return new object[] { new Object1(123, 123.321f, 321), "9gFapPZCggU=" };
            // yield return new object[] { new Object1(321, 18f, 123), "ggUAAJBB9gE=" };
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject1s), DynamicDataSourceType.Method)]
        public void Object1_Serialize(Object1 obj, string expected)
        {
            Serializer<Object1> serializer = new Serializer<Object1>();

            string str = serializer.Serialize(obj);

            Assert.AreEqual(expected, str);
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject1s), DynamicDataSourceType.Method)]
        public void Object1_Deserialize(Object1 expected, string str)
        {
            Serializer<Object1> serializer = new Serializer<Object1>();

            Object1 obj = serializer.DeserializeString(str);

            Assert.AreEqual(expected, obj);
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject1s), DynamicDataSourceType.Method)]
        public void Object1_SerializeToFile(Object1 obj, string expected)
        {
            Serializer<Object1> serializer = new Serializer<Object1>();
            serializer.SerializeToFile(obj, $"{expected}.txt");
        }

        /******************************************************************************************************/

        public static IEnumerable<object[]> ProvideObject2s()
        {
            yield return new object[] { new Object2(){ floatVal = 789.123f, someInteger = 1919, someLong = 1003L }, "30dFRP4d1g8=" };
            // yield return new object[] { new Object2(1f, 1919, 19191919L), "AACAP/4d3uGmEg==" };
            // yield return new object[] { new Object2(123.456f, 1919, -35L), "een2Qv4dRQ==" };
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject2s), DynamicDataSourceType.Method)]
        public void Object2_Serialize(Object2 obj, string expected)
        {
            Serializer<Object2> serializer = new Serializer<Object2>();

            string str = serializer.Serialize(obj);

            Assert.AreEqual(expected, str);
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject2s), DynamicDataSourceType.Method)]
        public void Object2_Deserialize(Object2 expected, string str)
        {
            Serializer<Object2> serializer = new Serializer<Object2>();

            Object2 obj = serializer.DeserializeString(str);

            Assert.AreEqual(expected, obj);
        }

        /******************************************************************************************************/

        public static IEnumerable<object[]> ProvideObject3s()
        {
            // This null works with Avro 1.11.0
            yield return new object[] { new Object3(){ floatVal = 789.123f, someInteger = 1919, someLong = 1003L }, "30dFRP4d1g8A" };

            // These came from a Java serializer with the same schema, they work with Avro 1.11.0
            yield return new object[] { new Object3(){ floatVal = 789.123f, someInteger = 1919, someLong = 1003L, optionalInt = 494 }, "30dFRP4d1g8C3Ac=" };
            yield return new object[] { new Object3(){ floatVal = 1f, someInteger = 1919, someLong = 10031010101L, optionalInt = 36 }, "AACAP/4d6sSo3koCSA==" };

            // These came from the 1.8.1 Hadoop serializer - They no longer work
            // yield return new object[] { new Object3(){ floatVal = 789.123f, someInteger = 1919, someLong = 1003L, optionalInt = 494 }, "30dFRP4d1g/cBw==" };
            // yield return new object[] { new Object3(1f, 1919, 10031010101L, 36), "AACAP/4d6sSo3kpI" };
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject3s), DynamicDataSourceType.Method)]
        public void Object3_Serialize(Object3 obj, string expected)
        {
            Serializer<Object3> serializer = new Serializer<Object3>();

            string str = serializer.Serialize(obj);

            Assert.AreEqual(expected, str);
        }

        [DataTestMethod]
        [DynamicData(nameof(ProvideObject3s), DynamicDataSourceType.Method)]
        public void Object3_Deserialize(Object3 expected, string str)
        {
            Serializer<Object3> serializer = new Serializer<Object3>();

            Object3 obj = serializer.DeserializeString(str);

            Assert.AreEqual(expected, obj);
        }

        /******************************************************************************************************/

        // public static IEnumerable<object[]> ProvideObject4s()
        // {
        //     yield return new object[] { new Object4(789.123f, 1919, 1003L, 494), "30dFRP4d1g/cBw==" };
        //     yield return new object[] { new Object4(1f, 1919, 10031010101L, 36), "AACAP/4d6sSo3kpI" };
        //     yield return new object[] { new Object4(12.34f, 123, 321L, 0), "pHBFQfYBggUA" };
        // }

        // [DataTestMethod]
        // [DynamicData(nameof(ProvideObject4s), DynamicDataSourceType.Method)]
        // public void Object4_Serialize(Object4 obj, String expected)
        // {
        //     Serializer<Object4> serializer = new Serializer<Object4>();

        //     string str = serializer.Serialize(obj);

        //     Assert.AreEqual(expected, str);
        // }

        // [DataTestMethod]
        // [DynamicData(nameof(ProvideObject4s), DynamicDataSourceType.Method)]
        // public void Object4_Deserialize(Object4 expected, String str)
        // {
        //     Serializer<Object4> serializer = new Serializer<Object4>();

        //     Object4 obj = serializer.DeserializeString(str);

        //     Assert.AreEqual(expected, obj);
        // }
    }
}
