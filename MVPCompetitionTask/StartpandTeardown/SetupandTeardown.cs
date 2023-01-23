using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
