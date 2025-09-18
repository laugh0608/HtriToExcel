namespace HtriToExcel.Model;

/// <summary>HTRI 输入参数模型</summary>
public class HtriInputModel : HtriBasicModel
{
    /// <summary>壳程质量流量 kg/h</summary>
    public double ShellMassFlow { get; set; }
    /// <summary>管程质量流量 kg/h</summary>
    public double TubeMassFlow { get; set; }
    /// <summary>壳程入口温度 C</summary>
    public double ShellInletTemperature { get; set; }
    /// <summary>管程入口温度 C</summary>
    public double TubeInletTemperature { get; set; }
    /// <summary>壳程入口压力 kPaG</summary>
    public double ShellInletPressure { get; set; }
    /// <summary>管程入口压力 kPaG</summary>
    public double TubeInletPressure { get; set; }
}