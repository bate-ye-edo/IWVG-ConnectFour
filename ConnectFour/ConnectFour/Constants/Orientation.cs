
namespace ConnectFour.Constants
{
    internal static class Orientation
    {
        internal static Position NORTH = new(-1, 0);
        internal static Position SOUTH = new(1, 0);
        internal static Position EAST = new(0, 1);
        internal static Position WEST = new(0, -1);
        internal static Position NORTHEAST = new(-1, 1);
        internal static Position NORTHWEST = new(-1, -1);
        internal static Position SOUTHEAST = new(1, 1);
        internal static Position SOUTHWEST = new(1, -1);
    }
}
