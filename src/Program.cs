using System;

namespace Kerberos
{
    class Program
    {
        static void Main(string[] args) 
        {
            KerberosClient kerberosClient = new KerberosClient("tar1dev", "sylvène123");
            Console.WriteLine(kerberosClient.secret);
        }
    }
}