using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            TestForm testForm = new TestForm();
            Console.WriteLine(testForm.Width);
            Application.Run(testForm);
        }
    }
}
