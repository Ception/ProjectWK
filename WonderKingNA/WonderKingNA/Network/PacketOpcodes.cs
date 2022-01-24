using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderKingNA.Network {
    internal static class PacketOpcodes {
        public static readonly int id;
        public enum LoginReponse {
            Ok,
            CharacterSelect,
            AccountNotExist,
            IncorrectPassword,
            Error,
            DuplicateConnection,
            Suspended,
            PleaseRegister,
            Suspended2,
            EmailVerification,
            NotCBTAccount,
            ServerInternalError,
            PaymentIssue,
            UserDeleted,
            NotMoreTries,
            Nothing,
            AlreadyExists,
            Incorrect
        }
    }
}
