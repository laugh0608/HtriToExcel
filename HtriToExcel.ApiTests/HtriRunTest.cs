using HtriToExcel.Core;
using HtriToExcel.Model;
using JetBrains.Annotations;

namespace HtriToExcel.ApiTests;

[TestClass]
[TestSubject(typeof(HtriRun))]
public class HtriRunTest(TestContext testContext)
{
    public TestContext TestContext { get; set; } = testContext;

    [TestMethod]
    public void HtriRunTest_WithDetailedLogging()
    {
        // 记录开始时间
        var startTime = DateTime.Now;
        TestContext.WriteLine($"🚀 测试开始: {TestContext.TestName}");
        TestContext.WriteLine($"⏰ 开始时间: {startTime:yyyy-MM-dd HH:mm:ss.fff}");
        
        try
        {
            // Arrange
            var model = new HtriInputModel
            {
                // UserId = 10086,
                UserId = 1111,
                FileName = "htri_test.htri",
                RunStatus = 0
            };
            
            TestContext.WriteLine($"📋 输入参数: UserId={model.UserId}, FileName={model.FileName}");
            
            // Act
            TestContext.WriteLine("⚡ 执行HTRI测试...");
            var result = HtriRun.HtriTest(model);
            TestContext.WriteLine("✅ HTRI测试执行完成");
            
            // Assert
            TestContext.WriteLine("🔍 验证结果...");
            
            // 记录成功和失败信息
            var duration = DateTime.Now - startTime;
            if (result.RunStatus == 0)
            {
                TestContext.WriteLine("✅ 运行状态验证通过");
                TestContext.WriteLine($"🎉 测试成功！耗时: {duration.TotalMilliseconds}ms");
                TestContext.WriteLine($"📊 结果: RunStatus={result.RunStatus}");
            }
            else
            {
                TestContext.WriteLine("❌ 运行状态验证未通过");
                TestContext.WriteLine($"💥 测试失败！耗时: {duration.TotalMilliseconds}ms");
                TestContext.WriteLine($"❌ 错误信息: RunStatus={result.RunStatus}");
            }

            TestContext.WriteLine($"----------: RunMessage=\"{result.RunMessage}\"");
            // 进行单元测试断言，退出单元测试
            Assert.AreEqual(0, result.RunStatus);
        }
        catch (Exception ex)
        {
            // 断言失败，捕获异常
            var duration = DateTime.Now - startTime;
            TestContext.WriteLine($"💥 测试失败！耗时: {duration.TotalMilliseconds}ms");
            TestContext.WriteLine($"❌ 错误信息: {ex.Message}");
            throw;
        }
        finally
        {
            TestContext.WriteLine("🏁 测试执行结束");
        }
    }
    
    
    [TestInitialize]
    public void TestInitialize()
    {
        TestContext.WriteLine($"测试初始化: {TestContext.TestName}");
    }
    
    [TestCleanup]
    public void TestCleanup()
    {
        TestContext.WriteLine($"测试清理: {TestContext.TestName} 完成");
    }
}
