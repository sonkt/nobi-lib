using GbLib.Ef.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEf.Application
{
    [Table("Tags")]
    public class Tag : EntityBase<Guid>
    {
        public string TagContent { get; set; }
        public List<Post> Posts { get; set; }
    }
}