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
            TestForm testForm = new TestForm();
            Application.Run(testForm);

        }
    }
}
