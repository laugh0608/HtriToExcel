namespace HtriToExcel.Model;

public class HtriOutputModel : HtriInputModel
{
    /// <summary>壳程出口温度 C</summary>
    public double ShellOutTemperature { get; set; }
    /// <summary>管程出口温度 C</summary>
    public double TubeOutTemperature { get; set; }
}