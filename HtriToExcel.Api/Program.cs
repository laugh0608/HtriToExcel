using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// 对应 Scaler 的多个 API 文档
builder.Services.AddOpenApi("V2"); // 最终发布 V2
builder.Services.AddOpenApi("V1Beta"); // 测试 V1Beta，默认
builder.Services.AddOpenApi("Internal"); // 内部使用 Internal
builder.Services.AddOpenApi(options =>
{
    // Scaler 扩展
    options.AddScalarTransformers();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // .NET 9 默认的 OpenAPI
    app.MapOpenApi();

    // 注入 Scaler 依赖，Api Web UI 管理
    // 文档地址：https://guides.scalar.com/scalar/scalar-api-references/integrations/net-aspnet-core/integration
    // 默认路由地址为：/scalar ，自定义路由地址为：/ApiDocs
    // 自定义路由方法：app.MapScalarApiReference("/ApiDocs", options => {});
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("HtriToExcel API") // 标题
            .WithTheme(ScalarTheme.BluePlanet) // 主题
            // .WithSidebar(false) // 关闭侧边栏
            .WithDarkMode() // 默认使用黑暗模式
            .WithDefaultOpenAllTags(false); // 是否展开所有标签栏
        // 自定义查找 Open API 文档地址
        // options.WithOpenApiRoutePattern("/openapi/{documentName}.json");
        // 设置默认的 Http 客户端
        options.WithDefaultHttpClient(ScalarTarget.Node, ScalarClient.HttpClient);

        // 自定义多个版本 API 文档集合
        options
            .AddDocument("V2", "V2 API", "openapi/V2.json") // 最终发布 v2
            .AddDocument("V1Beta", "V1Beta API", "openapi/V1Beta.json", isDefault: true) // 测试 v1beta，默认
            .AddDocument("Internal", "Internal API", "openapi/Internal.json"); // 内部使用 internal
    });
}

// 允许跨域请求
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Content-Disposition");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 默认根路由下要显示的内容。
app.MapGet("/", () => "Welcome To HtriToExcel");

app.Run();