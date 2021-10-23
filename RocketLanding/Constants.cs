using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RocketLandingEngine
{
    public static class Constants
    {
        public const string OUT_OF_PLATFORM = "out of platform";
        public const string CLASH = "clash";
        public const string OK_FOR_LANDING = "ok for landing";

        public const string LENGTH_LESS_ZERO = "length cannot be less than or equal Zero";
        public const string WIDTH_LESS_ZERO = "width cannot be less than  or equal Zero";
        public const string POSITION_LESS_ZERO = "position factors cannot be negtive";

        public const string PLATFORM_OUTSIDE_AREA = "platform outside landing area";
    }
}
