using System;

namespace MarshallingSample
{
    class StringMarshalling
    {
        public static void Run()
        {
            Console.WriteLine("----- String marshalling samples -----");

            MarshallingSampleNative.CountBytesInString(null); // returns -1
            MarshallingSampleNative.CountBytesInString("some string"); // returns 11
            MarshallingSampleNative.CountBytesInString("😊"); // returns 4 on unix, 2 on windows

            MarshallingSampleNative.CountUtf8StringSize("some string"); // returns 11
            MarshallingSampleNative.CountUtf8StringSize("😊"); // returns 4

            MarshallingSampleNative.CountUtf16StringSize("some string"); // returns 11
            MarshallingSampleNative.CountUtf16StringSize("😊"); // returns 2

            MarshallingSampleNative.CountPlatformSpecificCharacters("some string"); // returns 11
            MarshallingSampleNative.CountPlatformSpecificCharacters("😊"); // returns 4 on unix, 2 on windows

            string value;
            MarshallingSampleNative.GetStringIntoCalleeAllocatedBuffer(out value);
            // value is "Native string value - callee allocated"

            value = MarshallingSampleNative.ReturnStringIntoCalleeAllocatedBuffer();
            // value is "Native string value - callee allocated - return"

            int count = 0;
            char[] buffer = null;
            MarshallingSampleNative.GetStringIntoCallerAllocatedBuffer(buffer, ref count); // returns -1, count is 39
            buffer = new char[count];
            MarshallingSampleNative.GetStringIntoCallerAllocatedBuffer(buffer, ref count); // returns 39
            // buffer contains the characters "Native string value - caller allocated"
        }
    }
}
