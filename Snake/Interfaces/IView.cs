using Snake.Models;

namespace Snake.Interfaces
{
    public interface IView
    {
        void Update(Grid grid);
        void Inform(string message);
    }
}