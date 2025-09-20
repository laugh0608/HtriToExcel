using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// options => options.AddScalarTransformers() 是 Scaler 扩展，用来添加自定义路由等功能
builder.Services.AddOpenApi(options => options.AddScalarTransformers());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // 本来下面这几个关于 API 文档的配置都在这里面，但是为了一直能渲染所以移出去了
}

// .NET 9 默认的 OpenAPI
app.MapOpenApi();

// 注入 Scaler 依赖，Api Web UI 管理，文档地址：https://guides.scalar.com/scalar/scalar-api-references/integrations/net-aspnet-core/integration
// 默认路由地址为：/scalar ，自定义路由地址为：/ApiDocs
// 自定义路由方法：app.MapScalarApiReference("/ApiDocs", options => {});
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("HtriToExcel API") // 标题
        .WithTheme(ScalarTheme.BluePlanet) // 主题
        // .WithSidebar(false) // 关闭侧边栏
        .WithDarkMode() // 是否启用黑暗模式开关
        .WithDefaultOpenAllTags(); // 是否展开所有标签栏
    // 自定义查找 Open API 文档地址
    // options.WithOpenApiRoutePattern("/api-spec/{documentName}.json");
    // 设置默认的 Http 客户端
    // options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

// 自定义多个版本 API 文档
// var documents = new[]
// {
//     new ScalarDocument("v1", "Production API", "api/v1/openapi.json"),
//     new ScalarDocument("v2", "Beta API", "api/v2-beta/openapi.json", true),
//     new ScalarDocument("galaxy", "Galaxy API", "https://registry.scalar.com/@scalar/apis/galaxy/latest?format=json")
// };
// app.MapScalarApiReference(options => options.AddDocuments(documents));
// app.MapPost("/orders", CreateOrder)
//     .WithBadge("New", BadgePosition.Before, "#28a745")
//     .WithBadge("Premium", BadgePosition.Before, "#ffc107");

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