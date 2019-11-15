//
//
//

using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace KRollerClientCs
{
    class Program
    {
        //const string PIPE_FOO = "\\\\.\\pipe\foo";
        const string PIPE_FOO = "foo";

        static void Main(string[] args)
        {
            Console.WriteLine("c: pipe client");

            using (var client = new NamedPipeClientStream(PIPE_FOO))
            {
                Console.WriteLine("c: try to connect");
                client.Connect();
                using (var reader = new StreamReader(client))
                {
                    char[] s = new char[1024];
                    Console.WriteLine("c: read");
                    while (true)
                    {
                        var n = reader.Read(s, 0, s.Length - 1);
                        if (n != 0)
                        {
                            Console.WriteLine(s, 0, n);
                        }

                        if (Console.KeyAvailable == true)
                        {
                            var c = Console.ReadKey(true);
                            if (c.KeyChar == 'q')
                            {
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("c: broken pipe, bye bye");
        }
    }
}

//
// eof
//
