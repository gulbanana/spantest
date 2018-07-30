using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var oneGigabyte = Enumerable.Repeat((byte)1, 1000 * 1024 * 1024).ToArray();
        
        for (var i = 0; i < 1000; i++)
        {
            var offset = i * 1024 * 1024; // skip i megabytes
            var span = oneGigabyte.AsSpan().Slice(offset); // does not copy memory - otherwise we'd allocate 1000 GB!
            Console.WriteLine(Sum(span));
        }
    }

    static int Sum(Span<byte> bs)
    {
        var total = 0;
        for  (var i = 0; i < bs.Length; i++)
        {
            total += bs[i];
        }
        return total;
    }
}
