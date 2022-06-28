
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import AvroTest.Object1;
import AvroTest.Object2;
import AvroTest.Object3;
import AvroTest.Object4;

import static org.testng.Assert.fail;

public class BasicTests {

	@DataProvider
	public Object[][] provideObject1() {
		return new Object[][] {
				{ new Object1(1, 1.1f, 2), "As3MjD8E" },
				{ new Object1(123, 123.321f, 321), "9gFapPZCggU=" },
				{ new Object1(321, 18f, 123), "ggUAAJBB9gE=" },
		};
	}

	@Test(dataProvider = "provideObject1")
	public void Object1_Serialize(Object1 obj, String val) {
		try {
			String res = new Serializer<Object1>().serialize(obj);
			Assert.assertEquals(res, val);
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@Test(dataProvider = "provideObject1")
	public void Object1_Deserialize(Object1 obj, String val) {
		try {
			Object1 res = new Deserializer<>(Object1.class).deserializeString(val);
			Assert.assertTrue(Util.compareSerializableObjects(obj, res));
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@DataProvider
	public Object[][] provideObject2() {
		return new Object[][] {
				{ new Object2(789.123f, 1919, 1003L), "30dFRP4d1g8=" },
				{ new Object2(1f, 1919, 19191919L), "AACAP/4d3uGmEg==" },
				{ new Object2(123.456f, 1919, -35L), "een2Qv4dRQ==" },
		};
	}

	@Test(dataProvider = "provideObject2")
	public void Object2_Serialize(Object2 obj, String val) {
		try {
			String res = new Serializer<Object2>().serialize(obj);
			Assert.assertEquals(res, val);
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@Test(dataProvider = "provideObject2")
	public void Object2_Deserialize(Object2 obj, String val) {
		try {
			Object2 res = new Deserializer<>(Object2.class).deserializeString(val);
			Assert.assertTrue(Util.compareSerializableObjects(obj, res));
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@DataProvider
	public Object[][] provideObject3() {
		return new Object[][] {
				{ new Object3(789.123f, 1919, 1003L, null), "30dFRP4d1g8A" },
				{ new Object3(789.123f, 1919, 1003L, 494), "30dFRP4d1g8C3Ac=" },
				// { new Object3(789.123f, 1919, 1003L, 494), "30dFRP4d1g/cBw==" }, // This is the serialized value from the C# code
				{ new Object3(1f, 1919, 10031010101L, 36), "AACAP/4d6sSo3koCSA==" },
		};
	}

	@Test(dataProvider = "provideObject3")
	public void Object3_Serialize(Object3 obj, String val) {
		try {
			String res = new Serializer<Object3>().serialize(obj);
			Assert.assertEquals(res, val);
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@Test
	public void Object3_WithImplicitNull() throws Exception {
		// This doesn't define 2 of the members, but the defaults in the avdl aren't used
		// The generated code only calls defaultValue() when Builder.build() is called, otherwise Java defaults are used
		Object3 source = new Object3();
		source.setFloatVal(123.321f);
		source.setSomeLong(18L);
		System.out.println("Source: " + Util.AsString(source));

		String res = new Serializer<Object3>().serialize(source);

		Object3 target = new Deserializer<>(Object3.class).deserializeString(res);
		System.out.println("Target: " + Util.AsString(target));
	}

	@Test
	public void Object3_WithBuilder() throws Exception {
		// This doesn't define 2 of the members, but the defaults in the avdl are used correctly
		Object3 source = Object3.newBuilder()
				.setFloatVal(123.321f)
				.setSomeLong(19L)
				.build();
		System.out.println("Source2: " + Util.AsString(source));

		String res = new Serializer<Object3>().serialize(source);

		Object3 target = new Deserializer<>(Object3.class).deserializeString(res);
		System.out.println("Target2: " + Util.AsString(target));
	}

	@Test(dataProvider = "provideObject3")
	public void Object3_Deserialize(Object3 obj, String val) {
		try {
			Object3 res = new Deserializer<>(Object3.class).deserializeString(val);
			Assert.assertTrue(Util.compareSerializableObjects(obj, res));
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@DataProvider
	public Object[][] provideObject4() {
		return new Object[][] {
				{ new Object4(789.123f, 1919, 1003L, 494), "30dFRP4d1g/cBw==" },
				{ new Object4(1f, 1919, 10031010101L, 36), "AACAP/4d6sSo3kpI" },
				{ new Object4(12.34f, 123, 321L, 0), "pHBFQfYBggUA" },
		};
	}

	@Test(dataProvider = "provideObject4")
	public void Object4_Serialize(Object4 obj, String val) {
		try {
			String res = new Serializer<Object4>().serialize(obj);
			Assert.assertEquals(res, val);
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}

	@Test(dataProvider = "provideObject4")
	public void Object4_Deserialize(Object4 obj, String val) {
		try {
			Object4 res = new Deserializer<>(Object4.class).deserializeString(val);
			Assert.assertTrue(Util.compareSerializableObjects(obj, res));
		}
		catch (Exception ex) {
			ex.printStackTrace();
			fail();
		}
	}
}
