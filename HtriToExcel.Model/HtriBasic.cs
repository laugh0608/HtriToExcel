namespace HtriToExcel.Model;

/// <summary>HTRI 基础模型</summary>
public class HtriBasicModel
{
    /// <summary>用户 ID</summary>
    public required int UserId { get; set; }
    
    /// <summary>HTRI 文件名</summary>
    /// <remarks>带文件后缀，*.htri 或 *.edr</remarks>
    public required string FileName { get; set; }

    /// <summary>运行结果状态码</summary>
    /// <remarks>状态码为 0 默认操作无异常</remarks>
    public required int RunStatus { get; set; }

    /// <summary>运行结果消息体</summary>
    public string? RunMessage { get; set; }
}