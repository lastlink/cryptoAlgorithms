using System.ComponentModel.DataAnnotations;

namespace dotnetcore._2.x.DTO
{
    public class hashVerifyRequest
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public int? iterations { get; set; }
        [Required]
        public string Algorithm { get; set; }
    }
    public class hashRequest
    {
        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
        public int? iterations { get; set; }
        [Required]
        public string Algorithm { get; set; }
    }

    public class hashResponse
    {
        public string Message { get; set; }
        public string HashedPassword { get; set; }
        public bool? Matched { get; set; }
    }
}