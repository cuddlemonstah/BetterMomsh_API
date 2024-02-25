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
    public enum Week
    {
        [EnumMember(Value = "1st Week")]
        FirstWeek,

        [EnumMember(Value = "2nd Week")]
        SecondWeek,

        [EnumMember(Value = "3rd Week")]
        ThirdWeek,

        [EnumMember(Value = "4th Week")]
        FourthWeek,

        [EnumMember(Value = "5th Week")]
        FifthWeek,
    }
}
