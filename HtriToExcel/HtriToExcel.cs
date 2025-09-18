using HTRICalc;

namespace HtriToExcel;

public class HtriToExcel(HeatExchangerNetwork htriNetWork)
{
    // 定义一个 HTRI NetWork 服务器，这是 HTRI 自带的对外 API 接口
    private HeatExchangerNetwork _htriNetWork = htriNetWork;

    public string Test()
    {
        try
        {
            // 启动一个 HTRI NetWork 服务器实例
            _htriNetWork = new HeatExchangerNetwork();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return "HTRI Success";
    }
}