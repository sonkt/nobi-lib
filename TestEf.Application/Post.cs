using GbLib.Ef.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEf.Application
{
    [Table("Posts")]
    public class Post : EntityBase<Guid>
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
