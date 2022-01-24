using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderKingNA.Network {
    internal static class PacketOpcodes {

        public enum LoginReponse {
            Login_Response,
            Ok,
            Character_Select,
            Character_Name_Check,
            Account_No_Exist,
            Incorrect_Password,
            Error,
            Duplicate_Connection,
            Suspended,
            Please_Register,
            Suspended_2,
            Character_Delete,
            Email_Verification,
            Server_Internal_Error,
            Payment_Issue,
            User_Deleted,
            No_More_Tries,
            Nothing,
            Already_Exists,
            Incorrect
        }
    }
}
