﻿using System;

namespace Crawler.ConsoleApplication
{
    public class ConsoleService
    {
        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
