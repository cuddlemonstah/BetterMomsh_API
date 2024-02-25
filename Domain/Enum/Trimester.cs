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
    public enum Trimester
    {
        [EnumMember(Value = "1st Trimester")]
        FirstTrimester,

        [EnumMember(Value = "2nd Trimester")]
        SecondTrimester,

        [EnumMember(Value = "3rd Trimester")]
        ThirdTrimester,

    }
}
