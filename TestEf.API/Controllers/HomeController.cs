using Microsoft.AspNetCore.Mvc;
using TestEf.Application;

namespace TestEf.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITestEfService _testEfService;

        public HomeController(ITestEfService testEfService)
        {
            _testEfService = testEfService;
        }

       
        [HttpGet]
        public async Task<TestEfModel?> Get(Guid id)
        {
            var result = await _testEfService.GetByIdAsync(id);
            if (result != null)
            {
                return new TestEfViewModel
                {
                    CreatedDate = result.CreatedDate,
                    Description = result.Description,
                    CreatedUser = result.CreatedUser,
                    DeletedDate = result.DeletedDate,
                    DeletedUser = result.DeletedUser,
                    Id = result.Id,
                    IsDeleted = result.IsDeleted,
                    TenantId = result.TenantId,
                    TestCode = result.TestCode,
                    TestName = result.TestName,
                    UpdatedDate = result.UpdatedDate,
                    UpdatedUser = result.UpdatedUser,
                    RowVersion = result.RowVersion
                };
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TestEfModel model)
        {
            var result = await _testEfService.AddItemAsync(new TestEfEntity
            {
                CreatedDate = DateTime.Now,
                CreatedUser = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                TestCode = model.TestCode,
                TestName = model.TestName
            });
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("many")]
        public async Task<IActionResult> PostMany(TestEfModel model)
        {
            var listData = new List<TestEfEntity>();
            for (int i = 101; i < 2000; i++)
            {
                listData.Add(new TestEfEntity {
                    CreatedDate = DateTime.Now,
                    CreatedUser = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    TestCode = $"{model.TestCode}_{i+1}",
                    TestName = $"{model.TestName}_{i + 1}",
                });
            }
            var result = await _testEfService.AddItemAsync(listData);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTestEfModel model)
        {
            var result = await _testEfService.UpdateItemAsync(new TestEfEntity
            {
                CreatedDate = model.CreatedDate,
                Description = model.Description,
                CreatedUser = model.CreatedUser,
                DeletedDate = model.DeletedDate,
                DeletedUser = model.DeletedUser,
                IsDeleted = model.IsDeleted,
                RowVersion = model.RowVersion,
                TenantId = model.TenantId,
                TestCode = model.TestCode,
                TestName = model.TestName,
                UpdatedDate = model.UpdatedDate,
                UpdatedUser = model.UpdatedUser,
                Id = model.Id
            }, model.Id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
    public class TestEfModel
    {
        public Guid Id { get; set; }
        public string? TestCode { get; set; }
        public string? TestName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Description { get; set; }
        public Guid? TenantId { get; set; }
    }
    public class UpdateTestEfModel: TestEfModel {
        public byte[] RowVersion { get; set; }
    }

    public class TestEfViewModel: UpdateTestEfModel { }
}
