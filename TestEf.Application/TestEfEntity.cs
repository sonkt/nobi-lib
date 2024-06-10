using GbLib.Ef.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEf.Application
{
    [Table("TestEfEntities")]
    public class TestEfEntity : EntityBase<Guid>
    {
        [Key]
        [Column("PK_TestEfEntityID")]
        public override Guid Id { get; set; }

        public string? TestCode { get; set; }

        public string? TestName { get; set; }
    }
}