﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.DAS.Forecasting.Web.AcceptanceTests.Features.Estimation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DisplayModelledApprenticeships")]
    public partial class DisplayModelledApprenticeshipsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DisplayModelledApprenticeships.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DisplayModelledApprenticeships", "\t\tAs an employer\r\n\t\tI want to be able to see the apprenticeships that I have mode" +
                    "lled\r\n\t\tSo that I can understand the details behind the modelled costs", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
 testRunner.Given("that I am an employer with predefined projections", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I have logged into my Apprenticeship Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("that I\'m on the estimator start page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC2: Check costs of modelled apprenticeships")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void AC2CheckCostsOfModelledApprenticeships()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC2: Check costs of modelled apprenticeships", new string[] {
                        "mytag"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Apprenticeship",
                        "Number Of Apprentices",
                        "Number Of Months",
                        "Start Date Month",
                        "Start Date Year",
                        "Total Cost"});
            table1.AddRow(new string[] {
                        "Advanced butcher, Level: 3 (Standard)",
                        "1",
                        "12",
                        "3",
                        "2019",
                        "12000"});
            table1.AddRow(new string[] {
                        "Baker, Level: 2 (Standard)",
                        "3",
                        "15",
                        "12",
                        "2018",
                        "27000"});
            table1.AddRow(new string[] {
                        "Network engineer, Level: 4 (Standard)",
                        "2",
                        "24",
                        "12",
                        "2020",
                        "36000"});
#line 14
 testRunner.Given("that I have added the following apprenticeships", ((string)(null)), table1, "Given ");
#line 19
 testRunner.When("the modelled apprenticeships page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("the column headings are displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("each added apprenticeship is displayed in a separate row", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("the apprenticeship with the earliest start date is shown first", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("the other apprenticeships are in order of start date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("the details against each apprenticeship match what was entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
