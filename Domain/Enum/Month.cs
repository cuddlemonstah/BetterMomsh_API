using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Month
    {
        [EnumMember(Value = "1st Month")]
        FirstMonth,

        [EnumMember(Value = "2nd Month")]
        SecondMonth,

        [EnumMember(Value = "3rd Month")]
        ThirdMonth,

        [EnumMember(Value = "4th Month")]
        FourthMonth,

        [EnumMember(Value = "5th Month")]
        FifthMonth,

        [EnumMember(Value = "6th Month")]
        SixthMonth,

        [EnumMember(Value = "7th Month")]
        SeventhMonth,

        [EnumMember(Value = "8th Month")]
        EightMonth,

        [EnumMember(Value = "9th Month")]
        NinthMonth,
    }
}
