using static System.Console;

namespace SchoolCore.Util
{
    public static class Printer
    {
        public static void DrawLine(int siz = 10)
        {
            System.Console.WriteLine("".PadLeft(siz, '='));
        }

        public static void WriteTitle(string title)
        {
            var size =title.Length + 4;
            DrawLine(size);
            System.Console.WriteLine($"| {title} |");
            DrawLine(size);
        }
        public static void WriteLine(string text)
        {
            System.Console.WriteLine($"{text}");
        }

        public static void Beep(int hz = 2000, int time=500, int amount =1)
        {
            while (amount-- > 0)
            {
                System.Console.Beep(hz, time);
            }
        }
    }
}