using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 抽奖
{
   public class Randmhelper
    {
       public static int GetRandomNumber(int min, int max)
       {
           Guid guid = new Guid();
           string sguid = guid.ToString();
           int seed = DateTime.Now.Millisecond;
           for (int i = 0; i < sguid.Length; i++)
           {
               switch (sguid[i])
               {
                   case 'a':
                   case 'b':
                   case 'c':
                   case 'd':
                   case 'e':
                   case 'f':
                   case 'g':
                       seed = seed + 1;
                       break;
                   case 'h':
                   case 'i':
                   case 'j':
                   case 'k':
                   case 'l':
                   case 'm':
                   case 'n':
                       seed = seed + 2;
                       break;
                   case 'o':
                   case 'p':
                   case 'q':
                   case 'r':
                   case 's':
                   case 't':
                       seed = seed + 3;
                       break;
                   case 'u':
                   case 'v':
                   case 'w':
                   case 'x':
                   case 'y':
                   case 'z':
                       seed = seed + 3;
                       break;
                   default:
                       seed = seed + 4;
                       break;
               }
           }
           Random r = new Random(seed);
           return r.Next(min, max);
       }
       public static int GetNumber(int min, int max)
       {
           //Thread.Sleep(GetRandomNumber(1000, 2000));
           return GetRandomNumber(min, max);
       }
    }
}
