using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Models
{
    public class Service
    {
        public string Host_Name { get; set; }
        public string Description { get; set; }
        public string Plugin_Output { get; set; }
        public string Long_Plugin_Output { get; set; }
        public string Perf_Data { get; set; }
        public int Max_Attempts { get; set; }
        public int Current_Attempt { get; set; }
        public int Status { get; set; }
        public long Last_Update { get; set; }
        public bool Has_Been_Checked { get; set; }
        public bool Should_Be_Scheduled { get; set; }
        public long Last_Check { get; set; }
        public int Check_Options { get; set; }
        public int Check_Type { get; set; }
        public bool Checks_Enabled { get; set; }
        public long Last_State_Change { get; set; }
        public long Last_Hard_State_Change { get; set; }
        public int Last_Hard_State { get; set; }
        public long Last_Time_Ok { get; set; }
        public int Last_Time_Warning { get; set; }
        public int Last_Time_Unknown { get; set; }
        public long Last_Time_Critical { get; set; }
        public int State_Type { get; set; }
        public long Last_Notification { get; set; }
        public int Next_Notification { get; set; }
        public long Next_Check { get; set; }
        public bool No_More_Notifications { get; set; }
        public bool Notifications_Enabled { get; set; }
        public bool Problem_Has_Been_Acknowledged { get; set; }
        public int Acknowledgement_Type { get; set; }
        public int Current_Notification_Number { get; set; }
        public bool Accept_Passive_Checks { get; set; }
        public bool Event_Handler_Enabled { get; set; }
        public bool Flap_Detection_Enabled { get; set; }
        public bool Is_Flapping { get; set; }
        public int Percent_State_Change { get; set; }
        public int Latency { get; set; }
        public double Execution_Time { get; set; }
        public int Scheduled_Downtime_Depth { get; set; }
        public bool Process_Performance_Data { get; set; }
        public bool Obsess { get; set; }
    }

}
