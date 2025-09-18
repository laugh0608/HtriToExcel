using HTRICalc;
using HtriToExcel.Model;

namespace HtriToExcel.Core;

/// <summary>HTRI RUN 方法的直接实现</summary>
public class HtriRun
{
    /// <summary>测试 HTRI 进程是否可以正常启动</summary>
    /// <remarks>测试 COM 接口和依赖是否加载</remarks>
    /// <returns></returns>
    public static HtriOutputModel HtriTest(HtriInputModel model)
    {
        var resultModel = new HtriOutputModel
        {
            UserId = model.UserId,
            FileName = model.FileName,
            RunStatus = 0,
        };

        // 确保 UserId 和 FileName 存在
        if (model.UserId is 0 || model.FileName == "" || model.FileName == "string")
        {
            resultModel.RunStatus = -1;
            resultModel.RunMessage = "UserId or FileName is empty";
            return resultModel;
        }
        
        // 定义一个 HTRI NetWork 服务器，这是 HTRI 自带的对外 API 接口
        HeatExchangerNetwork htriNetWork;

        try
        {
            // 启动一个 HTRI NetWork 服务器实例
            htriNetWork = new HeatExchangerNetwork();
        }
        catch (Exception ex)
        {
            resultModel.RunStatus = -2;
            resultModel.RunMessage = $"HTRI Failed To Start: {ex.Message}";
            return resultModel;
        }
        
        try
        {
            // 通过用户名来读取文件路径
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(basePath, "Data", "HTRI", model.UserId.ToString());
            // 检查目录是否存在
            if (!Directory.Exists(fullPath))
            {
                // 如果不存在，创建目录（包括所有父目录）
                Directory.CreateDirectory(fullPath);
            }
            // 拼接 HTRI 文件的完整路径
            var htriFile = Path.Combine(fullPath, model.FileName);
            // 将该文件加载进刚才创建好的 HTRI NetWork 服务器实例中
            htriNetWork.OpenFile(htriFile);
        }
        catch (Exception ex)
        {
            resultModel.RunStatus = -3;
            resultModel.RunMessage = $"HTRI Failed To Open File: {ex.Message}";
            return resultModel;
        }
        
        return resultModel;
    }
}