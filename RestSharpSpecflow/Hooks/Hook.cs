using System;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using RestSharpSpecflow.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace RestSharpSpecflow.Hooks
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports _extentReports;
        private static ExtentTest _scenarioTest;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;

        }


        [BeforeTestRun()]
        public static void InitializeReport()
        {
            var extentReportPath = Path.Combine(Assembly.GetExecutingAssembly().Location) + "ExtentReport.html";
            _extentReports = new ExtentReports();
            var reporter = new ExtentSparkReporter(extentReportPath);

            _extentReports.AttachReporter(reporter);


        }

        [AfterTestRun()]
        public static void CleanupReport()
        {
            if(_extentReports != null)
            {
                _extentReports.Flush();
            }
        }
        [AfterStep]
        public  void AfterTestStep()
        {
            if(_scenarioContext.TestError == null)
            {
                switch(_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        _scenarioTest.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case (StepDefinitionType.When):
                        _scenarioTest.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                        case (StepDefinitionType.Then):
                        _scenarioTest.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        _scenarioTest.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail();
                        break;

                    case (StepDefinitionType.When):
                        _scenarioTest.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail();
                        break;
                    case (StepDefinitionType.Then):
                        _scenarioTest.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail();
                        break;
                    default:
                        break;
                }
            }
                
        }

        [BeforeScenario()]
        public void InitializeDriver()
        {
           
            Driver driver = new Driver(_scenarioContext);

            var feature = _extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenarioTest = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        
        }
    }
}