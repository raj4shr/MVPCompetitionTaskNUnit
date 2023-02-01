namespace MVPCompetitionTask;

[SetUpFixture]
class SetupandTeardown : CommonDriver,IExtentRpt
{
    [OneTimeSetUp]
    public void oneTimeSetup()
    {
        IExtentRpt.InitReports();
    }

    [OneTimeTearDown]
    public void voidoneTimeTeardown()
    {
        IExtentRpt.flushReport();
    }

   
}
