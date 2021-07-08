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
using Snake.Controller;

namespace SnakeUI
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private string _direction;
        private GameController _controller;
        private int _height = 20;
        private int _width = 20;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _graphics = CreateGraphics();
            _direction = "right";
            _controller = new GameController(20, 20);
        }

        private void DrawGrid()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    var brush = new SolidBrush(Color.White);
                    
                    if (_controller.Grid[i, j].IsApple)
                    {
                        brush.Color = Color.Red;
                    }
                    if (_controller.Grid[i, j].IsSnake)
                    {
                        brush.Color = Color.Blue;
                    }
                    
                    _graphics.FillRectangle(brush, j * 25, i * 25, 25, 25);
                }
            }
        }

        private void Form1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'd': _direction = "right"; break;
                case 's': _direction = "down"; break;
                case 'a': _direction = "left"; break;
                case 'w': _direction = "up"; break;
            }
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_controller.IsAlive)
            {
                Application.Exit();
            }
            DrawGrid();
            _controller.Move(_direction);
        }
    }
}