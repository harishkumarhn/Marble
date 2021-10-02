using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MarbaleManagementStudio.Models
{
    public class Configuration
    {
        [DisplayName("Start In Physical Ticket Mode")]
        public bool StartInPhysicalTicketMode { get; set; }
        [DisplayName("Number Of Coins")]
        public int NumberOfCoins { get; set; }
        [DisplayName("Ticket Pulse Width")]
        public int TicketPulseWidth { get; set; }
        [DisplayName("Ticket Pulse Gap")]
        public int TicketPulseGap { get; set; }
        [DisplayName("Reverse Display Direction")]
        public bool ReverseDisplayDirection { get; set; }
        [DisplayName("Balance Delay")]
        public int BalanceDelay { get; set; }
        [DisplayName("Min Seconds Between Repeat Play")]
        public int MinSecondsBetweenRepeatPlay { get; set; }
        [DisplayName("Out Of Service Theme")]
        public int OutOfServiceTheme { get; set; }
        [DisplayName("Coin Pulse Width")]
        public int CoinPulseWidth { get; set; }
        [DisplayName("Coin Pulse Gap")]
        public int CoinPulseGap { get; set; }
        [DisplayName("Sensor Interval")]
        public int SensorInterval { get; set; }
        [DisplayName("Disabled Tickets")]
        public bool DisableTickets { get; set; }
        [DisplayName("Debug Mode")]
        public int DebugMode { get; set; }
        [DisplayName("Card Retries")]
        public int CardRetries { get; set; }
        [DisplayName("Display Language")]
        public int DisplayLanguage { get; set; }
        [DisplayName("Max Ticket Per Game Play")]
        public int MaxTicketPerGamePlay { get; set; }
        [DisplayName("Out of Service")]
        public bool OutOfService { get; set; }
        [DisplayName("Game Play Duration")]
        public int GamePlayDuration { get; set; }
        [DisplayName("Default Theme")]
        public int DefaultTheme { get; set; }
        [DisplayName("Enable Ext Antenna")]
        public bool EnableExtAntenna {get; set;}
        [DisplayName("Free Play Theme")]
        public int FreePlayTheme { get; set; }
    }
}