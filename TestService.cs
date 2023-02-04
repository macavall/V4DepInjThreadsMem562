namespace V4DepInjThreadsMem562
{
    public class TestService : ITestService
    {
        public string GetTestString()
        {
            Task.Factory.StartNew(() => 
            { 
                Thread.Sleep(10000); 
            });

            return "Test String";
        }
    }
}