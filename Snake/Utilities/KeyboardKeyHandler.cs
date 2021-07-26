using Snake.Enums;
using Snake.Interfaces;

namespace Snake.Utilities
{
    public class KeyboardKeyHandler: IKeyHandler
    {
        public Direction Direction { get; private set; }

        public void ReadKey(string key)
        {
            Direction = key.ToLower() switch
            {
                "a" => Direction.Left,
                "d" => Direction.Right,
                "w" => Direction.Up,
                "s" => Direction.Down,
                _ => Direction
            };
        }
    }
}