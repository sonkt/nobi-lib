using GbLib.Entities;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test
{

    [Table("TestEntities")]
    public class TestEntity:AuditEntity<Guid>
    {
        [Key]
        [Column("PK_TestEntityID")]
        public override Guid Id { get; set; }

        public string? TestCode { get; set; }

        public string? TestName { get; set; }
    }
}
