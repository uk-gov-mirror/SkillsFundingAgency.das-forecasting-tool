﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Generate Training Cost Projections [CI-499]")]
    public partial class GenerateTrainingCostProjectionsCI_499Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Generate Training Cost Projections.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Generate Training Cost Projections [CI-499]", "\tAs an employer with a pay bill over £3 million each year and therefore must now " +
                    "pay the apprenticeship levy\r\n\tI want my trainging costs to be forecast for the n" +
                    "ext 4 years\r\n\tSo that I can effectively forecast my account balance", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
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
                        "64569.55",
                        "Today"});
#line 11
 testRunner.And("the following levy declarations have been recorded", ((string)(null)), table2, "And ");
#line 14
 testRunner.And("the current balance is 623104.60", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC1: Training cost for commitments included in the projection")]
        public virtual void AC1TrainingCostForCommitmentsIncludedInTheProjection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC1: Training cost for commitments included in the projection", null, ((string[])(null)));
#line 16
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
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
                        "Number Of Installments"});
            table3.AddRow(new string[] {
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table3.AddRow(new string[] {
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
#line 17
 testRunner.Given("the following commitments have been recorded", ((string)(null)), table3, "Given ");
#line 21
 testRunner.When("the account projection is triggered after a payment run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("the account projection should be generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("the training costs should be included in the correct months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sending employer transfer training costs")]
        public virtual void SendingEmployerTransferTrainingCosts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sending employer transfer training costs", null, ((string[])(null)));
#line 25
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line 26
 testRunner.Given("I am a sending employer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "FundingSource"});
            table4.AddRow(new string[] {
                        "Test Apprentice 1",
                        "Test Course",
                        "1",
                        "Test Provider 1",
                        "Last Year",
                        "333.33",
                        "2000",
                        "24",
                        "Transfer"});
            table4.AddRow(new string[] {
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider 2",
                        "Yesterday",
                        "444.44",
                        "2000",
                        "18",
                        "Transfer"});
            table4.AddRow(new string[] {
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider 3",
                        "Next Year",
                        "666.66",
                        "2000",
                        "12",
                        "Transfer"});
#line 27
 testRunner.And("the following commitments have been recorded", ((string)(null)), table4, "And ");
#line 32
 testRunner.When("the account projection is triggered after a payment run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("the account projection should be generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Months From Now",
                        "Transfer Out Total Cost Of Training"});
            table5.AddRow(new string[] {
                        "0",
                        "333.33"});
            table5.AddRow(new string[] {
                        "1",
                        "777.77"});
            table5.AddRow(new string[] {
                        "2",
                        "777.77"});
            table5.AddRow(new string[] {
                        "3",
                        "777.77"});
            table5.AddRow(new string[] {
                        "4",
                        "777.77"});
            table5.AddRow(new string[] {
                        "5",
                        "777.77"});
            table5.AddRow(new string[] {
                        "6",
                        "777.77"});
            table5.AddRow(new string[] {
                        "7",
                        "777.77"});
            table5.AddRow(new string[] {
                        "8",
                        "777.77"});
            table5.AddRow(new string[] {
                        "9",
                        "777.77"});
            table5.AddRow(new string[] {
                        "10",
                        "777.77"});
            table5.AddRow(new string[] {
                        "11",
                        "777.77"});
            table5.AddRow(new string[] {
                        "12",
                        "777.77"});
            table5.AddRow(new string[] {
                        "13",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "14",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "15",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "16",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "17",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "18",
                        "1111.10"});
            table5.AddRow(new string[] {
                        "19",
                        "666.66"});
#line 34
 testRunner.And("should have the following transfers costs of training", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Receiving employer transfer training costs")]
        public virtual void ReceivingEmployerTransferTrainingCosts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Receiving employer transfer training costs", null, ((string[])(null)));
#line 57
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line 58
 testRunner.Given("I am a receiving employer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Scheme",
                        "Amount",
                        "Created Date"});
#line 59
 testRunner.And("the following levy declarations have been recorded", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "FundingSource"});
            table7.AddRow(new string[] {
                        "Test Apprentice 1",
                        "Test Course",
                        "1",
                        "Test Provider 1",
                        "Last Year",
                        "333.33",
                        "2000",
                        "24",
                        "Transfer"});
            table7.AddRow(new string[] {
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider 2",
                        "Yesterday",
                        "444.44",
                        "2000",
                        "18",
                        "Transfer"});
            table7.AddRow(new string[] {
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider 3",
                        "Next Year",
                        "666.66",
                        "2000",
                        "12",
                        "Transfer"});
#line 61
 testRunner.And("the following commitments have been recorded", ((string)(null)), table7, "And ");
#line 66
 testRunner.When("the account projection is triggered after a payment run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then("the account projection should be generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Months From Now",
                        "Transfer In Total Cost Of Training",
                        "Transfer Out Total Cost Of Training"});
            table8.AddRow(new string[] {
                        "0",
                        "333.33",
                        "333.33"});
            table8.AddRow(new string[] {
                        "1",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "2",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "3",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "4",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "5",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "6",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "7",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "8",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "9",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "10",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "11",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "12",
                        "777.77",
                        "777.77"});
            table8.AddRow(new string[] {
                        "13",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "14",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "15",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "16",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "17",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "18",
                        "1111.10",
                        "1111.10"});
            table8.AddRow(new string[] {
                        "19",
                        "666.66",
                        "666.66"});
#line 68
 testRunner.And("should have the following transfers costs of training", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
