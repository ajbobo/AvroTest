import org.apache.avro.specific.SpecificRecordBase;

import AvroTest.Object1;
import AvroTest.Object2;
import AvroTest.Object3;
import AvroTest.Object4;

public class Util {

	public static String AsString(Object1 obj) {
		return String.format("Object1 { %d, %.3f, %d }", obj.getIntVal1(), obj.getFloatVal(), obj.getIntVal2());
	}

	public static String AsString(Object2 obj) {
		return String.format("Object2 { %.3f, %d, %d }", obj.getFloatVal(), obj.getSomeInteger(), obj.getSomeLong());
	}

	public static String AsString(Object3 obj) {
		return String.format("Object3 { %.3f, %d, %d, %d }", obj.getFloatVal(), obj.getSomeInteger(), obj.getSomeLong(), obj.getOptionalInt());
	}

	public static String AsString(Object4 obj) {
		return String.format("Object4 { %.3f, %d, %d, %d }", obj.getFloatVal(), obj.getSomeInteger(), obj.getSomeLong(), obj.getOptionalInt());
	}

	public static boolean compareSerializableObjects(SpecificRecordBase one, SpecificRecordBase two) {
		if (one == null && two == null)
			return true;
		else if (one == null || two == null)
			return false;

		boolean res = true;
		try {
			for (int x = 0; res /*Stop when res is false - let x continue forever*/; x++) {
				if (one.get(x) == null && two.get(x) == null)
					continue;
				if (one.get(x) == null || two.get(x) == null)
					res = false;
				else if (!one.get(x).equals(two.get(x)))
					res = false;
			}
		}
		catch (org.apache.avro.AvroRuntimeException | java.lang.IndexOutOfBoundsException ex) {
			// We're at the end of the object's members - we're done
		}
		return res;
	}
}
