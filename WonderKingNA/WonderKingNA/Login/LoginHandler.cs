using WonderKingNA.Network;
using WonderKingNA.User;

namespace WonderKingNA.Login {
    internal class LoginHandler {
        private readonly int id;

        public LoginHandler(int id) {
            this.id = id;
        }

        public static EndianWriter GetLoginResponse(LoginHandler r) {
            return GetLoginResponse(r.id);
        }

        public static EndianWriter GetLoginResponse (int r) {
            EndianWriter w = new EndianWriter (3);
            w.WriteShort(PacketOpcodes.id);
            w.Write(r);
            return w;
        }

        public static EndianWriter GetChannelList() { //  TODO: Finish this.
            EndianWriter w = new EndianWriter();
            w.Write((int)PacketOpcodes.LoginReponse.Ok);
            w.Write(0);
            w.Write(1); // Admin i guess?

            int channelCount = 1;
            w.WriteShort(channelCount);

            return w;
        }

        public static EndianWriter GetSelectPlayer(Player player) {
            EndianWriter w = new EndianWriter();
            w.WriteShort(PacketOpcodes.id);
            w.WriteShort(0);
            //w.WriteAsciiString(player.GetPassword(), 32);
            w.Write(0);
            w.Write(new byte[22]);
            return w;
        }
    }
}
