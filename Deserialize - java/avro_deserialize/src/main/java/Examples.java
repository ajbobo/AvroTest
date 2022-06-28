import AvroTest.Object3;

public class Examples {

    public static void main(String[] args) {
        Serializer<Object3> obj3Serializer = new Serializer<>();
        Deserializer<Object3> obj3Deserializer = new Deserializer<>(Object3.class);

        Object3 obj = new Object3(1.2f, 3, 4L, 5);

        System.out.println("--- STEP 1 ---");
        try {
            String str = obj3Serializer.serialize(obj);
            System.out.println(String.format("(obj) Java serialization : %s ==> %s", Util.AsString(obj), str));
        } 
        catch (Exception ex) {
            System.out.format("Exception in Step1 -- %s", ex.toString());
        }

        System.out.println("--- STEP 2 ---");
        try {
            String str = "mpmZPwYIAgo=";
            Object3 newObj = obj3Deserializer.deserializeString(str); // This is the string that was just
                                                                                 // created
            System.out.println(String.format("(newObj) Java serialization : %s ==> %s", Util.AsString(obj), str));
            if (Util.compareSerializableObjects(obj, newObj)) {
                System.out.println("They are the same");
            } 
            else {
                System.out.println("They are different");
            }
        } 
        catch (Exception ex) {
            System.out.format("Exception in Step2 -- %s", ex.toString());
        }

        System.out.println("--- STEP 3 ---");
        String str = "mpmZPwYICg==";
        try {
            Object3 newObj2 = obj3Deserializer.deserializeString(str); // This was created by the C# code
            System.out.println(String.format("(newObj2) C# serialization : %s ==> %s", Util.AsString(obj), str));
            if (Util.compareSerializableObjects(obj, newObj2)) {
                System.out.println("They are the same");
            } 
            else {
                System.out.println("They are different");
            }
        } 
        catch (Exception ex) {
            System.out.format("Exception in Step3 with serialized string : %s -- %s", str, ex.toString());
        }

    }
}
