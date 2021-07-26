using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Snake.Controllers;
using Snake.Interfaces;
using Snake.Utilities;
using Snake.Views;

namespace Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GameController _gameController;
        private WinFormsView _view;
        private KeyboardKeyHandler _keyHandler;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _keyHandler = new KeyboardKeyHandler();
            _view = new WinFormsView(CreateGraphics(), 20, Color.DarkRed, Color.Blue, Color.White);
            _gameController = new GameController(35, 35, _keyHandler, _view);
            timer1.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _keyHandler.ReadKey(e.KeyChar.ToString());
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            _gameController.Update();
        }
    }
}