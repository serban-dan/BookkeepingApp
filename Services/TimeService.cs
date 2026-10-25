using System;

namespace BookkeepingApp.Services
{
    public static class TimeService
    {
        public static bool IsSimulated { get; set; } = false;
        public static DateTime SimulatedDate { get; set; } = DateTime.Now;

        // The entire app will look at this property instead of DateTime.Now
        public static DateTime Now => IsSimulated ? SimulatedDate : DateTime.Now;
    }
}