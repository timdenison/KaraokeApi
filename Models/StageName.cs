using System;
using System.ComponentModel.DataAnnotations;

namespace KaraokeApi.Models
{
    public class StageName
    {
        [Key]
        public long Id { get; set; }
        public int SessionId {get; set;}
        public string Name { get; set; }
        public bool IsActive { get; set; }   
    }
}