using System;
using System.Text;

namespace lq1
{
    public class exercise
    {
        static void Main()
        {
            int n=int.Parse(Console.ReadLine());
            string[] massiv = new string[n];
            for(int i=0;i<n;i++)
            {
                var c = Console.ReadLine();
                massiv[i]=c;
            }

            var l=LQ3(massiv);
            var final = LQ1(massiv, -7);
            foreach(var c in final) Console.WriteLine(c);
        }

        public static string[] LQ3(string [] all) 
        {
            return all.Where(c=>c.ToCharArray().Where(x=>char.IsLetter(x)).Distinct().ToDictionary(v=>v,v=>c.Count(r=>r==v)).Where(g=>g.Value>2).Count()==0).ToArray();
        }

        public static T[] LQ1<T>(T[] all,int k) where T : IComparable
        { 
            if(k==0 || all.Length==0 || (k==all.Length) ||(k%all.Length==0))
            {
                return all;
            }
            int t = 0;

            if (k > 0)
            {
                return all.Select(x =>
                {
                    var l = t;
                    t++;
                    if (l >= k%all.Length) return (x, l - k%all.Length);
                    return (x, all.Length-(k % all.Length - l));
                }).OrderBy(x=>x.Item2).Select(b=>b.Item1).ToArray();
            }

            return all.Select(x =>
            {
                var l = t;
                t++;
                if (l+Math.Abs(k) % all.Length<all.Length) return (x, l + Math.Abs(k) % all.Length);
                return (x, -all.Length +(Math.Abs(k) % all.Length + l));
            }).OrderBy(x => x.Item2).Select(b => b.Item1).ToArray();
        }
    }
}
