using System;
using System.ComponentModel.DataAnnotations;

namespace KaraokeApi.Models
{
    public class KaraokeSession
    {
        [Key]
        public int KaraokeSessionId {get; set; }
        public string SessionName { get; set; }
        public bool IsActive {get; set; }
    }

}