using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonsOfDoom
{
    static class TextUtils
    {
        static public void AnimateText(string text, int delay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
