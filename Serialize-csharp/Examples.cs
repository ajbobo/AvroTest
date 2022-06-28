using System;

namespace AvroTest
{
    public class Examples
    {
        public static void Main()
        {
            Serializer<Object3> serializer = new Serializer<Object3>();

            Object3 obj = new Object3() { floatVal = 1.2f, someInteger = 3, someLong = 4L, optionalInt = 5 };

            Console.WriteLine("--- STEP 1 ---");
            string str = serializer.Serialize(obj);
            Console.WriteLine($"(obj) C# serialization : {obj.ToString()} ==> {str}");


            Console.WriteLine("--- STEP 2 ---");
            str = "mpmZPwYIAgo=";
            Object3 newObj = serializer.DeserializeString(str); // This is the string that was just created
            Console.WriteLine($"(newObj) C# serialization : {newObj.ToString()} ==> {str}");
            if (newObj.Equals(obj))
            {
                Console.WriteLine("They are the same");
            }
            else
            {
                Console.WriteLine("They are different");
            }

            Console.WriteLine("--- STEP 3 ---");
            Object3 obj3 = new Object3();
            obj3.floatVal = 1.2f;
            obj3.someInteger = 3;
            obj3.someLong = 4L;
            // optionalInt defaults to null

            try
            {
                string str2 = serializer.Serialize(obj3);
                Console.WriteLine($"(obj3) C# serialization : {obj3.ToString()} ==> {str2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while serializing object : {obj3.ToString()} ==> {ex.Message}");
            }

            Console.WriteLine("--- STEP 2 ---");
            str = "mpmZPwYIAA==";
            newObj = serializer.DeserializeString(str); // This is the string that was just created
            Console.WriteLine($"(newObj) C# serialization (with null) : {newObj.ToString()} ==> {str}");
            if (newObj.Equals(obj3))
            {
                Console.WriteLine("They are the same");
            }
            else
            {
                Console.WriteLine("They are different");
            }

        }
    }
}