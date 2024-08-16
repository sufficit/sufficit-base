using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public enum FreePBXMailBoxStatus
    {
        [EnumMember(Value = "Sem Mensagem")]
        NoMessage = 0,

        [EnumMember(Value = "Ocupado")]
        Busy,

        [EnumMember(Value = "Indisponível")]
        Unvailable,

        [EnumMember(Value = "Apenas Instruções")]
        Instructions, 
    }

    public static class FreePBXMailBoxStatusExtensions
    {
        public static string GetPrefix(this FreePBXMailBoxStatus source)
        {
            return source switch
            {
                 FreePBXMailBoxStatus.Busy => "vmb",
                 FreePBXMailBoxStatus.Unvailable => "vmu",
                 FreePBXMailBoxStatus.Instructions => "vmi",
                 FreePBXMailBoxStatus.NoMessage => "vms",
                 _ => throw new ArgumentOutOfRangeException(nameof(source)),
            };
        }

        public static FreePBXMailBoxStatus GetStatusFromPrefix(string prefix)
        {
            return prefix switch
            {
                "vmb" => FreePBXMailBoxStatus.Busy,
                "vmu" => FreePBXMailBoxStatus.Unvailable,
                "vmi" => FreePBXMailBoxStatus.Instructions,
                "vms" => FreePBXMailBoxStatus.NoMessage,
                _ => throw new ArgumentOutOfRangeException(nameof(prefix)),
            };
        }
    }
}
