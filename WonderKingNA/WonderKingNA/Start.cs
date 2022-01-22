using System;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class Start {

        static void Main() {
            Console.Title = "Wonderking Online MMORPG - North America";

            Log.ConsoleWarning("[SERVER] \tStarting Server...");
            WonderKingWorker wk = new WonderKingWorker();

            wk.Run();
        }
    }
}