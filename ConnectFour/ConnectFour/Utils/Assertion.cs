using System;

namespace ConnectFour.Utils
{
    static class Assertion
    {
        public static void AssertTrue(bool assert)
        {
            if (assert)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
