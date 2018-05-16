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
namespace SFA.DAS.Forecasting.AcceptanceTests.Projections.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Calculate monthly cost of actual transfer commitments (Sending Employer - CI-619)" +
        "")]
    public partial class CalculateMonthlyCostOfActualTransferCommitmentsSendingEmployer_CI_619Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculateMonthlyCostOfActualTransferCommitments.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Calculate monthly cost of actual transfer commitments (Sending Employer - CI-619)" +
                    "", "\tAs an employer\r\n\tI want to see my actual training costs for transfers that I\'m f" +
                    "unding\r\n\tSo that they can be taken into account while forecasting against my tra" +
                    "nsfer allowance", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 6
#line 7
 testRunner.Given("I\'m a levy paying employer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payroll Year",
                        "Payroll Month"});
            table1.AddRow(new string[] {
                        "18-19",
                        "1"});
#line 8
 testRunner.And("the payroll period is", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Scheme",
                        "Amount",
                        "Created Date"});
            table2.AddRow(new string[] {
                        "ABC-1234",
                        "3000",
                        "Today"});
#line 11
 testRunner.And("the following levy declarations have been recorded", ((string)(null)), table2, "And ");
#line 14
 testRunner.And("the current balance is 5000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC1 Transfer training cost when some commitments duration exceeds forecast period" +
            "")]
        public virtual void AC1TransferTrainingCostWhenSomeCommitmentsDurationExceedsForecastPeriod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC1 Transfer training cost when some commitments duration exceeds forecast period" +
                    "", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "EmployerAccountId",
                        "SendingEmployerAccountId",
                        "FundingSource"});
            table3.AddRow(new string[] {
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider 1",
                        "Yesterday",
                        "2000",
                        "1200",
                        "6",
                        "999",
                        "12345",
                        "Transfer"});
            table3.AddRow(new string[] {
                        "Test Apprentice 1",
                        "Test Course",
                        "1",
                        "Test Provider 2",
                        "Yesterday",
                        "2000",
                        "1200",
                        "6",
                        "999",
                        "12345",
                        "Transfer"});
            table3.AddRow(new string[] {
                        "Test Apprentice 2",
                        "Test Course 2",
                        "1",
                        "Test Provider 3",
                        "Yesterday",
                        "2000",
                        "1200",
                        "6",
                        "999",
                        "12345",
                        "Transfer"});
            table3.AddRow(new string[] {
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider 4",
                        "Yesterday",
                        "2000",
                        "1200",
                        "6",
                        "999",
                        "12345",
                        "Transfer"});
            table3.AddRow(new string[] {
                        "Test Apprentice 4",
                        "Test Course 2",
                        "1",
                        "Test Provider 5",
                        "Next Year",
                        "2000",
                        "1200",
                        "6",
                        "999",
                        "12345",
                        "Transfer"});
#line 18
 testRunner.Given("the following commitments have been recorded", ((string)(null)), table3, "Given ");
#line 25
 testRunner.When("the account projection is triggered after a payment run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the account projection should be generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "MonthsFromNow",
                        "TransferOutTotalCostOfTraining"});
            table4.AddRow(new string[] {
                        "1",
                        "8000"});
            table4.AddRow(new string[] {
                        "2",
                        "8000"});
            table4.AddRow(new string[] {
                        "3",
                        "8000"});
            table4.AddRow(new string[] {
                        "4",
                        "8000"});
            table4.AddRow(new string[] {
                        "5",
                        "8000"});
            table4.AddRow(new string[] {
                        "6",
                        "8000"});
            table4.AddRow(new string[] {
                        "7",
                        "0"});
            table4.AddRow(new string[] {
                        "12",
                        "0"});
            table4.AddRow(new string[] {
                        "13",
                        "2000"});
            table4.AddRow(new string[] {
                        "14",
                        "2000"});
            table4.AddRow(new string[] {
                        "15",
                        "2000"});
            table4.AddRow(new string[] {
                        "16",
                        "2000"});
            table4.AddRow(new string[] {
                        "17",
                        "2000"});
            table4.AddRow(new string[] {
                        "18",
                        "2000"});
            table4.AddRow(new string[] {
                        "19",
                        "0"});
#line 27
 testRunner.And("should have following projections", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
