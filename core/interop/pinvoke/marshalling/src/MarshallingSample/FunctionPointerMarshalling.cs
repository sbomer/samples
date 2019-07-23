using System;

namespace MarshallingSample
{

    class FunctionPointerMarshalling
    {
        public static void PrintStringManaged()
        {
            Console.WriteLine("in PrintStringManaged");
        }

        public static int SumInts(int arg1, int arg2)
        {
            return arg1 + arg2;
        }

        public static void Run()
        {
            Console.WriteLine("----- Function pointer marshalling samples -----");

            // Pass delegate to native code as function pointer
            MarshallingSampleNative.CallFunctionPointer(PrintStringManaged);
            // prints "in PrintStringManaged"

            // Get delegate from native function pointer and call it
            MarshallingSampleNative.ReturnVoidNoArguments printString = MarshallingSampleNative.ReturnPrintStringFunctionPointer();
            printString(); // prints "in PrintStringNative"

            int value;

            value = MarshallingSampleNative.CallFunctionPointerReturningIntWithArguments(SumInts, 4, 5);
            // value is 9, computed by SumInts in managed code

            MarshallingSampleNative.ReturnIntAcceptingInts sumInts = MarshallingSampleNative.ReturnSumIntsFunctionPointer();
            value = sumInts(6, 7); // value is 13, computed by SumIntsSimple in native code
        }
    }
}
