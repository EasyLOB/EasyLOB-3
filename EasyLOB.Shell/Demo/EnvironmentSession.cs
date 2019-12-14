using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoEnvironmentSession()
        {
            Console.WriteLine("\nSession Demo");
            Console.WriteLine("\nIs Web ? " + DIHelper.EnvironmentManager.IsWeb.ToString());
            Console.WriteLine("Session Write");
            SessionWrite();
            Console.WriteLine("Session Read");
            SessionRead();
            Console.WriteLine("Session Clear");
            SessionClear();
        }

        private static void SessionWrite()
        {
            Console.WriteLine("1 => Session[A]");
            DIHelper.EnvironmentManager.SessionWrite("A", "1");
            Console.WriteLine("2 => Session[B]");
            DIHelper.EnvironmentManager.SessionWrite("B", "2");

            Console.WriteLine("1 => Session[A]");
            DIHelper.EnvironmentManager.SessionWrite("A", "1");
            Console.WriteLine("2 => Session[B]");
            DIHelper.EnvironmentManager.SessionWrite("B", "2");
        }

        private static void SessionRead()
        {
            string sessionName;

            sessionName = "A";
            Console.WriteLine(((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            Console.WriteLine(((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");

            sessionName = "A";
            Console.WriteLine(((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            Console.WriteLine(((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
        }

        private static void SessionClear()
        {
            string sessionName;

            sessionName = "A";
            DIHelper.EnvironmentManager.SessionClear(sessionName);
            Console.WriteLine((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            DIHelper.EnvironmentManager.SessionClear(sessionName);
            Console.WriteLine((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");

            sessionName = "A";
            DIHelper.EnvironmentManager.SessionClear(sessionName);
            Console.WriteLine((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            DIHelper.EnvironmentManager.SessionClear(sessionName);
            Console.WriteLine((string)DIHelper.EnvironmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
        }
    }
}