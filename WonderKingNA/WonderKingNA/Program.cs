using System;

namespace WonderKingNA {
    internal class Program {
        static void Main() {
            WonderKingWorker wk = new WonderKingWorker();
            wk.Run();

            Console.Title = "Wonderking Online MMORPG - North America";
            Console.ReadKey();
        }
    }
}
