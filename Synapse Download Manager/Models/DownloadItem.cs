using System;

namespace Synapse_Download_Manager.Models
{
    public class DownloadItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public int Progress { get; set; }
        public string Speed { get; set; }
        public string Status { get; set; }
        public int Threads { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public TimeSpan RemainingTime { get; set; }
    }
}
