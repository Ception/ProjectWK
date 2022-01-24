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
            w.AddHeader(PacketOpcodes.LoginReponse.Login_Response);
            w.Write(r);
            return w;
        }

        public static EndianWriter GetChannelList() {
            EndianWriter w = new EndianWriter();
            w.AddHeader(PacketOpcodes.LoginReponse.Ok);
            w.Write(0);
            w.Write(1); // Admin i guess?

            int channelCount = 1;
            w.WriteShort(channelCount);

            return w;
        }

        public static EndianWriter GetSelectPlayer(User user) {
            EndianWriter w = new EndianWriter();
            w.AddHeader(PacketOpcodes.LoginReponse.Character_Select);
            w.Write(0);
            w.WriteAsciiString(user.GetPassword(), 32);
            w.Write(0);
            w.Write(new byte[22]);
            return w;
        }

        public static EndianWriter DeletePlayer(byte loginPosition) {
            EndianWriter w = new EndianWriter(3);
            w.AddHeader(PacketOpcodes.LoginReponse.Character_Delete);
            w.Write(loginPosition);
            return w;
        }

        public static EndianWriter NameCheckResponse(LoginHandler r) {
            return NameCheckResponse(r.id);
        }

        public static EndianWriter NameCheckResponse(int r) {
            EndianWriter w = new EndianWriter();
            w.AddHeader(PacketOpcodes.LoginReponse.Character_Name_Check);
            w.Write(r);
            return w;
        }
    }
}
