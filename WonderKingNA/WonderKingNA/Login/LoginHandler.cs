using WonderKingNA.Network;
using WonderKingNA.PlayerUser;

namespace WonderKingNA.Login {

    internal class LoginHandler {
        private readonly int id;

        public LoginHandler() { }

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

        public static void EncodePlayerSelect(EndianWriter w, Player player) {
            LoginHandler lh = new LoginHandler(); // wtf X_X
            w.WriteInt(player.GetLoginPosition());
            w.WriteAsciiString(player.GetUsername(), 32);
            w.Write(player.GetJob());
            w.Write(0);
            w.Write(0);
            w.Write(0);
            w.Write(player.GetGender());
            w.WriteShort(player.GetLevel());
            w.Write(0); // exp as percentage
            lh.EncodeBasicStats(w);
            w.WriteInt(player.GetHP());
            w.WriteInt(player.GetMP());
        }

        /**
        * 12 bytes
        */
        public void EncodeBasicStats(EndianWriter w) {
            Player player = new Player();
            w.WriteShort(player.str);
            w.WriteShort(player.dex);
            w.WriteShort(player.ints);
            w.WriteShort(player.vitality);
            w.WriteShort(player.luk);
            w.WriteShort(player.wisdom);
        }

        /**
         * 108 bytes
         */
        public void EncodeStats(EndianWriter w) {
            Player player = new Player();
            w.WriteShort(player.GetHP());
            w.WriteShort(player.GetMP());
            w.WriteShort(player.GetMaxHP());
            w.WriteShort(player.GetMaxMP());
            w.WriteShort(1000);
            getDynamicStats().encodeAttack(w);
            w.WriteShort(10);
            w.WriteShort(7);
            w.WriteShort(7);
            w.WriteShort(7);
            w.WriteShort(7);
            getDynamicStats().encodeElements(w);
            w.WriteFloat(player.xVelocity);
            w.WriteFloat(player.yVelocity);
            w.WriteShort(0); // critical
            w.WriteShort(0); // bonus stats
            w.WriteShort(0); // skill points
            w.Skip(44);
        }

    }
}
