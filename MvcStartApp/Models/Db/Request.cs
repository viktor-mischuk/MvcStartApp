using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }

    }
}
