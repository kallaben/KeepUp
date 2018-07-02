using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CircleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Game testForm = new Game(500, 500);
            Application.Run(testForm);
        }
    }
}