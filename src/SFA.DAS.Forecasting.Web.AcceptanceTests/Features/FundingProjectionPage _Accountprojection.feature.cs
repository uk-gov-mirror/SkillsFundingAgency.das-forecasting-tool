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
namespace SFA.DAS.Forecasting.Web.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("FundingProjectionPage _Accountprojection")]
    public partial class FundingProjectionPage_AccountprojectionFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FundingProjectionPage _Accountprojection.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FundingProjectionPage _Accountprojection", @"As a Levy Employer logged into my Apprenticeship Account
I want to be able to see my current levy balance, credit and apprenticeship commitments displayed as a forecast across multiple future periods.
So that I can explore a variety of possible future scenarios and better plan my future levy spend and apprenticeships", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("that I am an employer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have logged into my Apprenticeship Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("FundingProjectionPageAC1: Forecast data is displayed correctly when forecast betw" +
            "een payments made and 23rd of month")]
        public virtual void FundingProjectionPageAC1ForecastDataIsDisplayedCorrectlyWhenForecastBetweenPaymentsMadeAnd23RdOfMonth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FundingProjectionPageAC1: Forecast data is displayed correctly when forecast betw" +
                    "een payments made and 23rd of month", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date",
                        "Funds in",
                        "Total Cost Of Training",
                        "Completion Payments",
                        "Future Funds"});
            table1.AddRow(new string[] {
                        "Apr 18",
                        "14000",
                        "880",
                        "32200",
                        "31000"});
            table1.AddRow(new string[] {
                        "May 18",
                        "15000",
                        "880",
                        "32200",
                        "17000"});
            table1.AddRow(new string[] {
                        "Jun 18",
                        "91000",
                        "1800",
                        "10000",
                        "23000"});
            table1.AddRow(new string[] {
                        "Jul 18",
                        "21000",
                        "2350",
                        "50000",
                        "23000"});
            table1.AddRow(new string[] {
                        "Aug 18",
                        "45200",
                        "850",
                        "45000",
                        "1000"});
            table1.AddRow(new string[] {
                        "Sep 18",
                        "55000",
                        "700",
                        "37880",
                        "12000"});
            table1.AddRow(new string[] {
                        "Oct 18",
                        "42000",
                        "700",
                        "37880",
                        "1000"});
            table1.AddRow(new string[] {
                        "Nov 18",
                        "22000",
                        "1800",
                        "45000",
                        "5000"});
            table1.AddRow(new string[] {
                        "Dec 18",
                        "42000",
                        "1400",
                        "10000",
                        "4000"});
            table1.AddRow(new string[] {
                        "Jan 19",
                        "41000",
                        "2000",
                        "10000",
                        "1000"});
            table1.AddRow(new string[] {
                        "Feb 19",
                        "10000",
                        "1800",
                        "10000",
                        "1000"});
            table1.AddRow(new string[] {
                        "Mar 19",
                        "15000",
                        "1800",
                        "45000",
                        "31000"});
            table1.AddRow(new string[] {
                        "Apr 19",
                        "42500",
                        "2100",
                        "10000",
                        "1000"});
#line 11
  testRunner.Given("I have generated the following projections", ((string)(null)), table1, "Given ");
#line 28
  testRunner.And("I\'m on the Funding projection page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
  testRunner.When("the Account projection is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
  testRunner.Then("the Account projection has the correct columns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
  testRunner.And("the first month displayed is the next calendar month", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And("there are months up to \'Apr 19\' displayed in the forecast", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("completion payments are shown against the correct months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("FundingProjectionPageAC2: Forecast data is displayed correctly when forecast betw" +
            "een 23rd of month until end of month")]
        public virtual void FundingProjectionPageAC2ForecastDataIsDisplayedCorrectlyWhenForecastBetween23RdOfMonthUntilEndOfMonth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FundingProjectionPageAC2: Forecast data is displayed correctly when forecast betw" +
                    "een 23rd of month until end of month", ((string[])(null)));
#line 39
  this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date",
                        "Funds in",
                        "Total Cost Of Training",
                        "Completion Payments",
                        "Future Funds"});
            table2.AddRow(new string[] {
                        "Apr 18",
                        "14000",
                        "880",
                        "32200",
                        "1000"});
            table2.AddRow(new string[] {
                        "May 18",
                        "15000",
                        "880",
                        "32200",
                        "1000"});
            table2.AddRow(new string[] {
                        "Jun 18",
                        "91000",
                        "1800",
                        "10000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Jul 18",
                        "21000",
                        "2350",
                        "50000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Aug 18",
                        "45200",
                        "850",
                        "45000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Sep 18",
                        "55000",
                        "700",
                        "37880",
                        "1000"});
            table2.AddRow(new string[] {
                        "Oct 18",
                        "42000",
                        "700",
                        "37880",
                        "1000"});
            table2.AddRow(new string[] {
                        "Nov 18",
                        "22000",
                        "1800",
                        "45000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Dec 18",
                        "42000",
                        "1400",
                        "10000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Jan 19",
                        "41000",
                        "2000",
                        "10000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Feb 19",
                        "10000",
                        "1800",
                        "10000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Mar 19",
                        "15000",
                        "1800",
                        "45000",
                        "1000"});
            table2.AddRow(new string[] {
                        "Apr 19",
                        "42500",
                        "2100",
                        "10000",
                        "1000"});
#line 40
  testRunner.Given("I have generated the following projections", ((string)(null)), table2, "Given ");
#line 57
  testRunner.And("I\'m on the Funding projection page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
  testRunner.When("the Account projection is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
  testRunner.Then("the Account projection has the correct columns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
  testRunner.And("the first month displayed is the next calendar month", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("there are months up to \'Apr 19\' displayed in the forecast", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And("the data is displayed correctly in each column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And("completion payments are shown against the correct months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("FundingProjectionPageAC3: Forecast data is displayed correctly when forecast betw" +
            "een 1st of month until next payments made")]
        public virtual void FundingProjectionPageAC3ForecastDataIsDisplayedCorrectlyWhenForecastBetween1StOfMonthUntilNextPaymentsMade()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FundingProjectionPageAC3: Forecast data is displayed correctly when forecast betw" +
                    "een 1st of month until next payments made", ((string[])(null)));
#line 68
  this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date",
                        "Funds in",
                        "Total Cost Of Training",
                        "Completion Payments",
                        "Future Funds"});
            table3.AddRow(new string[] {
                        "Apr 18",
                        "14000",
                        "880",
                        "32200",
                        "1000"});
            table3.AddRow(new string[] {
                        "May 18",
                        "15000",
                        "880",
                        "32200",
                        "1000"});
            table3.AddRow(new string[] {
                        "Jun 18",
                        "91000",
                        "1800",
                        "10000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Jul 18",
                        "21000",
                        "2350",
                        "50000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Aug 18",
                        "45200",
                        "850",
                        "45000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Sep 18",
                        "55000",
                        "700",
                        "37880",
                        "1000"});
            table3.AddRow(new string[] {
                        "Oct 18",
                        "42000",
                        "700",
                        "37880",
                        "1000"});
            table3.AddRow(new string[] {
                        "Nov 18",
                        "22000",
                        "1800",
                        "45000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Dec 18",
                        "42000",
                        "1400",
                        "10000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Jan 19",
                        "41000",
                        "2000",
                        "10000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Feb 19",
                        "10000",
                        "1800",
                        "10000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Mar 19",
                        "15000",
                        "1800",
                        "45000",
                        "1000"});
            table3.AddRow(new string[] {
                        "Apr 19",
                        "42500",
                        "2100",
                        "10000",
                        "1000"});
#line 69
  testRunner.Given("I have generated the following projections", ((string)(null)), table3, "Given ");
#line 86
  testRunner.And("I\'m on the Funding projection page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
  testRunner.When("the Account projection is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
  testRunner.Then("the Account projection has the correct columns", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
  testRunner.And("the first month displayed is the next calendar month", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
  testRunner.And("there are months up to \'Apr 19\' displayed in the forecast", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
  testRunner.And("the data is displayed correctly in each column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
  testRunner.And("completion payments are shown against the correct months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("FundingProjectionPageAC4: Forecast data when negative balance")]
        public virtual void FundingProjectionPageAC4ForecastDataWhenNegativeBalance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FundingProjectionPageAC4: Forecast data when negative balance", ((string[])(null)));
#line 97
  this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Date",
                        "Funds in",
                        "Total Cost Of Training",
                        "Completion Payments",
                        "Future Funds"});
            table4.AddRow(new string[] {
                        "Apr 18",
                        "14000",
                        "880",
                        "32200",
                        "0"});
            table4.AddRow(new string[] {
                        "May 18",
                        "15000",
                        "880",
                        "32200",
                        "0"});
            table4.AddRow(new string[] {
                        "Jun 18",
                        "91000",
                        "1800",
                        "10000",
                        "0"});
            table4.AddRow(new string[] {
                        "Jul 18",
                        "21000",
                        "2350",
                        "50000",
                        "0"});
            table4.AddRow(new string[] {
                        "Aug 18",
                        "45200",
                        "850",
                        "45000",
                        "0"});
            table4.AddRow(new string[] {
                        "Sep 18",
                        "55000",
                        "700",
                        "37880",
                        "0"});
            table4.AddRow(new string[] {
                        "Oct 18",
                        "42000",
                        "700",
                        "37880",
                        "1000"});
            table4.AddRow(new string[] {
                        "Nov 18",
                        "22000",
                        "1800",
                        "45000",
                        "1000"});
            table4.AddRow(new string[] {
                        "Dec 18",
                        "42000",
                        "1400",
                        "10000",
                        "1000"});
            table4.AddRow(new string[] {
                        "Jan 19",
                        "41000",
                        "2000",
                        "10000",
                        "1000"});
            table4.AddRow(new string[] {
                        "Feb 19",
                        "10000",
                        "1800",
                        "10000",
                        "1000"});
            table4.AddRow(new string[] {
                        "Mar 19",
                        "15000",
                        "1800",
                        "45000",
                        "1000"});
            table4.AddRow(new string[] {
                        "Apr 19",
                        "42500",
                        "2100",
                        "10000",
                        "1000"});
#line 98
  testRunner.Given("I have generated the following projections", ((string)(null)), table4, "Given ");
#line 117
  testRunner.And("I\'m on the Funding projection page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
  testRunner.When("I have a negative balance in a forecast month", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
  testRunner.Then("the balance for that month is displayed correctly as £0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
