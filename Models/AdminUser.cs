using System;
using System.ComponentModel.DataAnnotations;

namespace KaraokeApi.Models
{
    public class AdminUser
    {
        [Key]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}