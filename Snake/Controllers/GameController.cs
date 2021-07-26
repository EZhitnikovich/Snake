using Snake.Interfaces;
using Snake.Models;

namespace Snake.Controllers
{
    public class GameController
    {
        private Game _game;
        private IKeyHandler _keyHandler;
        private IView _view;
        
        public GameController(int width, int height, IKeyHandler keyHandler, IView view)
        {
            _keyHandler = keyHandler;
            _view = view;
            _game = new Game(new Grid(width, height));
        }

        public void Update()
        {
            _game.Move(_keyHandler.Direction);
            _game.UpdateSnakePosition();
            _game.UpdateFruitPosition();
            
            _view.Update(_game.Grid);

            if (!_game.IsAlive)
            {
                _view.Inform("End");
            }
        }
    }
}