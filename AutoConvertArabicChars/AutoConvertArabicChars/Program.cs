using System;

namespace AutoConvertArabicChars
{
    class Program
    {
        static void Main(string[] args)
        {

            var _ctx = new MainDbContex();
            _ctx.Posts.Add(new Post() {Title ="Test Convert  chars" , Content= "يك يكي" });
            _ctx.SaveChanges();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
