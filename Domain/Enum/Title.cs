﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Title
    {
        [EnumMember(Value = "Ms")]
        Ms,

        [EnumMember(Value = "Mrs")]
        Mrs,

    }
}
