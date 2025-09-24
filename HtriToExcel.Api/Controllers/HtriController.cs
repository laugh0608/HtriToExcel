using HtriToExcel.Api.Filter;
using Microsoft.AspNetCore.Mvc;
using static HtriToExcel.Api.Filter.CustomApiVersion;

namespace HtriToExcel.Api.Controllers;

/// <summary>HTRI 相关 API</summary>
[ApiController]
[Route("api/[controller]")]
public class HtriController : ControllerBase
{
    /// <summary>测试 HTRI 是否可以运行，获取 HTRI 版本号</summary>
    /// <returns></returns>
    [HttpGet]
    [CustomRoute(ApiVersions.V1Beta, "", "GetHtriVersion")]
    public IActionResult GetHtriVersion()
    {
        return Ok("Hello World!");
    }
}