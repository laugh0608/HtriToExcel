using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HtriToExcel.Api.Filter;

/// <summary>自定义路特性</summary>
/// <remarks> /api/{version}/[controller]/[action] </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class CustomRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
{
    /// <summary>分组名称</summary>
    /// <remarks>实现接口 IApiDescriptionGroupNameProvider，
    /// 用来切换 API 集合，配合 Scaler 的多版本文档</remarks>
    public string GroupName { get; set; }

    /// <summary>标签名称</summary>
    /// <remarks>用来替换 Scaler 侧边栏中的 API 名称，类似于备注</remarks>
    public string TagsName { get; set; }

    /// <summary>自定义路由构造函数，继承基类路由</summary>
    /// <param name="tagsName"></param>
    /// <param name="groupName"></param>
    /// <param name="actionName"></param>
    public CustomRouteAttribute(string tagsName = "[controller]", string groupName = "[controller]",
        string actionName = "[action]")
        : base("/api/{version}/[controller]/" + actionName)
    {
        GroupName = groupName;
        TagsName = tagsName;
    }

    /// <summary>自定义版本和路由构造函数，继承基类路由</summary>
    /// <param name="tagsName"></param>
    /// <param name="actionName"></param>
    /// <param name="apiVersion"></param>
    public CustomRouteAttribute(CustomApiVersion.ApiVersions apiVersion, string tagsName = "[controller]",
        string actionName = "")
        : base($"/api/{apiVersion.ToString()}/[controller]/{actionName}")
    {
        GroupName = apiVersion.ToString();
        TagsName = tagsName;
    }
}

/// <summary>自定义 API 版本</summary>
public abstract class CustomApiVersion
{
    /// <summary>API 接口版本，自定义</summary>
    public enum ApiVersions
    {
        /// <summary>INTERNAL 内部测试版本</summary>
        Internal = 1,

        /// <summary>V1Beta 预发布版本</summary>
        V1Beta = 2,

        /// <summary>V2 公开版本</summary>
        V2 = 3,
    }
}