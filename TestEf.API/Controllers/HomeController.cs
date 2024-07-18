using GbLib.Base.Helpers;
using GbLib.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestEf.Application;

namespace TestEf.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITestEfService _testEfService;
        private readonly IPostService _postService;
        private readonly IJwtService _jwtService;

        public HomeController(ITestEfService testEfService, IJwtService jwtService,IPostService postService)
        {
            _testEfService = testEfService;
            _jwtService = jwtService;
            _postService = postService;
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

        [HttpGet]
        [Route("all")]
        public Task<List<TestEfEntity>> GetAll()
        {
            return _testEfService.GetAll();
        }

        [HttpGet]
        [Route("paged/{pageSize}/{pageNumber}")]
        public async Task<PagedData?> GetPaged(int pageSize, int pageNumber)
        {
            return await _testEfService.GetPagedAsync(pageSize, pageNumber, "TestEfEntity.TestName");
        }


        [HttpGet]
        [Auth(Permissions = [1, 2], All = true)]
        [Route("datetime/{date}")]
        public async Task<string> TestDateTime(DateTime date)
        {
            var date1 = date.UtcFromTimeZone();
            var date2 = date.UtcToTimeZone();
            return "Ok";
        }

        [HttpGet]
        [Route("accessToken")]
        public async Task<string> GenerateAccessToken()
        {
            var claims = new List<Claim> {
            new Claim(JwtClaimsTypes.Permissions,"1")
            };
            return $"{_jwtService.GenerateAccessToken(claims)}";
        }



        [HttpDelete]
        public Task<int> Delete(Guid id)
        {
            return _testEfService.DeleteByIdAsync(id);
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
            for (int i = 3000; i < 4000; i++)
            {
                listData.Add(new TestEfEntity
                {
                    CreatedDate = DateTime.Now,
                    CreatedUser = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    TestCode = $"{model.TestCode}_{i + 1}",
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

        [HttpPost]
        [Route("post/many")]
        public async Task<IActionResult> InsertPostMany()
        {
            var listData = new List<Post>();
            var listTags = new List<Tag> { 
                new Tag{
                    TagContent="Content 1"
                },
                new Tag{
                    TagContent="Content 2"
                }
            };
            for (int i = 1; i < 10; i++)
            {
                listData.Add(new Post
                {
                    CreatedDate = DateTime.Now,
                    CreatedUser = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    PostTitle = $"Title {i}",
                    PostBody = $"Nội dung số {i}",
                    Tags= listTags
                });
            }
            var result = await _postService.AddItemAsync(listData);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("posts")]
        public async Task<List<Post>> GetAllPost()
        {
           return await _postService.GetAll();
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

    public class UpdateTestEfModel : TestEfModel
    {
        public byte[] RowVersion { get; set; }
    }

    public class TestEfViewModel : UpdateTestEfModel
    { }
}