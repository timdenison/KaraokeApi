using System;
using System.ComponentModel.DataAnnotations;

namespace KaraokeApi.Models
{
    public class Song
    {
        [Key]
        public long Id { get; set; }
        public string StageName { get; set; }
        public string Url { get; set; }
        public string Title {get; set; }
        public int Order { get; set; }
        public bool IsComplete { get; set; }
        public int SessionId {get; set;}
    }
}