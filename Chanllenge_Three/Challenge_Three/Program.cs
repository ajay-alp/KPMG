using System;

namespace Challenge.Three
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myObject = CreateNestedObject();
            var key = "a/b/c";

            Console.WriteLine($"Output: {GetNestedValue(myObject, key)}");
        }

        public static object CreateNestedObject()
        {
        return new Class_A(
                new Class_B(
                    new Class_C()));
        }

        public static object GetNestedValue(object myObject, string key)
        {
            try
            {
                var keyValues = key.Split("/");

                foreach (var keyValue in keyValues)
                    myObject = myObject.GetType().GetProperty(keyValue).GetValue(myObject);

                return myObject.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}\n");
                return null;
            }
            
        }
    }
}
