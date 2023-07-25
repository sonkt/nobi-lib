using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base.Mvc
{
    public abstract class BaseApiController : ControllerBase
    {
        #region Fields

        public readonly ILogger<BaseApiController> _logger;

        public readonly IMapper _mapper;

        public readonly IMediator _mediator;

        public readonly ITracer _tracer;

        #endregion Fields

        #region Constructors

        public BaseApiController(ILogger<BaseApiController> logger, IMediator mediator, IMapper mapper, ITracer tracer)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _tracer = tracer;
        }

        public virtual async Task<FileContentResult> GetFileFromUrl(string url, string downloadName)
        {
            try
            {
                var filename = Path.GetFileName(url);
                var file = await Task.FromResult(File(System.IO.File.ReadAllBytes(url), "application/octet-stream", filename));
                file.FileDownloadName = $"{downloadName}_{DateTime.Now.ToString("dd-MM-yyyy_HH-ss")}.xlsx";
                FileInfo fileRemove = new FileInfo(url);
                fileRemove.Delete();
                return file;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi trong quá trình lấy file từ URL", ex.StackTrace);
                return null;
            }

        }

        #endregion Constructors
    }
}
