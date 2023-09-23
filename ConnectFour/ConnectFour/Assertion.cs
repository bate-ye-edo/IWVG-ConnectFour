using System;

namespace ConnectFour
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
