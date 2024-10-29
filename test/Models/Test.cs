using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Test
    {
        [Key]
        public string _id { get; set; }
        public string name { get; set; }
    }
}
