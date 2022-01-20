using System;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class Start {

        static void Main() {
            Console.Title = "Wonderking Online MMORPG - North America";

            Log.ConsoleWarning("[SERVER] Starting...");
            WonderKingWorker wk = new WonderKingWorker();

            try {
                wk.Run();
            } catch (Exception ex) {
                Log.ConsoleError($"[SERVER] Error starting. Error:\n\n\t{ex.ToString()}\n\n\t");
                Console.ReadKey();
            } finally {
                Log.ConsoleMessage("[SERVER] Started successfully.");
                Console.ReadKey();
            }
        }
    }
}
