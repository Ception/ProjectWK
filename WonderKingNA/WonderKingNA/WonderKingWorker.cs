using System;
using WonderKingNA.Network;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class WonderKingWorker {

        public void Run() {
            try {
                new AES();
                new Database();
            } catch (Exception ex) { // threw new exception(ex.tostring()) and break;
                Log.ConsoleError($"[SERVER] \tERROR: Starting Server. Error:\n\n\t{ex.ToString()}\n\n\t");
                Log.ConsoleError("[SERVER] \tERROR: Server Not Started.");
            } finally {
                Log.ConsoleMessage("[SERVER] \tSUCCESS: Initialized.");
                Console.ReadKey();
            }
        }
    }
}
            //} finally {
    //Log.ConsoleMessage("[SERVER] \tSUCCESS: Initialized.");
    //Console.ReadKey();
//}