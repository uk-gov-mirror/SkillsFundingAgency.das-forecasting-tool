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
namespace SFA.DAS.Forecasting.AcceptanceTests.Payments.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Process Payment Event")]
    public partial class ProcessPaymentEventFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Process Payment Event.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Process Payment Event", "\tAs an employer\r\n\tI want my payments to be forecast for the next 4 years\r\n\tSo tha" +
                    "t I can effectively forecast my account balance", ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("I have no existing payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have no existing commitments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC1: Store payment event data")]
        public virtual void AC1StorePaymentEventData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC1: Store payment event data", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 4",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 6",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 7",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "29/05/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 8",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "29/05/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table1.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 9",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "29/05/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
#line 11
 testRunner.Given("I have made the following payments", ((string)(null)), table1, "Given ");
#line 22
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("the Forecasting Payment service should store the payment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And("the Forecasting Payment service should store the commitment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AC2: Do not store invalid data")]
        public virtual void AC2DoNotStoreInvalidData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AC2: Do not store invalid data", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments"});
            table2.AddRow(new string[] {
                        "0",
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 3",
                        "",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 4",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "01/01/0001 00:00",
                        "133.33",
                        "400.00",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "0",
                        "400.00",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 6",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "0",
                        "12"});
            table2.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 7",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "29/05/2017 00:00",
                        "133.33",
                        "400.00",
                        "0"});
#line 27
 testRunner.Given("I made some invalid payments", ((string)(null)), table2, "Given ");
#line 36
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("the Forecasting Payment service should not store the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("the Forecasting Payment service should not store commitments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure sending employer transfer payments are processed")]
        public virtual void EnsureSendingEmployerTransferPaymentsAreProcessed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure sending employer transfer payments are processed", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "Sending Employer Account Id"});
            table3.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "100021"});
            table3.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "100022"});
            table3.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "100021"});
            table3.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 4",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        ""});
            table3.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2017 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "12345"});
#line 41
 testRunner.Given("I have made the following payments", ((string)(null)), table3, "Given ");
#line 48
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("the Forecasting Payment service should store the payment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And("the Forecasting Payment service should store the commitment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure receiving employer transfer payments are processed (CI-762)")]
        public virtual void EnsureReceivingEmployerTransferPaymentsAreProcessedCI_762()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure receiving employer transfer payments are processed (CI-762)", ((string[])(null)));
#line 52
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "Sending Employer Account Id",
                        "FundingSource"});
            table4.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2015 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "1",
                        "Transfer"});
            table4.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "16/04/2015 00:00",
                        "133.33",
                        "400.00",
                        "12",
                        "1",
                        "Transfer"});
#line 53
 testRunner.Given("I have made the following payments", ((string)(null)), table4, "Given ");
#line 57
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("the Forecasting Payment service should store the payment declarations receiving e" +
                    "mployer 12345 from sending employer 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("the Forecasting Payment service should store the commitment declarations for rece" +
                    "iving employer 12345 from sending employer 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure payments for new commitments with an invalid installment amount are ignore" +
            "d (CI-797)")]
        public virtual void EnsurePaymentsForNewCommitmentsWithAnInvalidInstallmentAmountAreIgnoredCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure payments for new commitments with an invalid installment amount are ignore" +
                    "d (CI-797)", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments"});
            table5.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "1",
                        "400.00",
                        "12"});
#line 62
 testRunner.Given("I have made the following payments", ((string)(null)), table5, "Given ");
#line 65
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then("the Forecasting Payment service should not store the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.And("the Forecasting Payment service should not store commitments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure payments for new commitments with an invalid completion amount are ignored" +
            " (CI-797)")]
        public virtual void EnsurePaymentsForNewCommitmentsWithAnInvalidCompletionAmountAreIgnoredCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure payments for new commitments with an invalid completion amount are ignored" +
                    " (CI-797)", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments"});
            table6.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "133.33",
                        "1.00",
                        "12"});
#line 70
 testRunner.Given("I have made the following payments", ((string)(null)), table6, "Given ");
#line 73
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("the Forecasting Payment service should not store the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
 testRunner.And("the Forecasting Payment service should not store commitments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure payments for new commitments with an invalid payment amount are not ignore" +
            "d (CI-797)")]
        public virtual void EnsurePaymentsForNewCommitmentsWithAnInvalidPaymentAmountAreNotIgnoredCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure payments for new commitments with an invalid payment amount are not ignore" +
                    "d (CI-797)", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments"});
            table7.AddRow(new string[] {
                        "0",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "133.33",
                        "400.00",
                        "12"});
#line 78
 testRunner.Given("I have made the following payments", ((string)(null)), table7, "Given ");
#line 81
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("the Forecasting Payment service should store the payment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.And("the Forecasting Payment service should store the commitment declarations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure payments for new commitments with an actual end date are ignored (CI-797)")]
        public virtual void EnsurePaymentsForNewCommitmentsWithAnActualEndDateAreIgnoredCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure payments for new commitments with an actual end date are ignored (CI-797)", ((string[])(null)));
#line 85
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "Actual End Date"});
            table8.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 5",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "133.33",
                        "400.00",
                        "12",
                        "Today"});
#line 86
 testRunner.Given("I have made the following payments", ((string)(null)), table8, "Given ");
#line 89
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("the Forecasting Payment service should not store the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
 testRunner.And("the Forecasting Payment service should not store commitments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Payment with an invalid payment amount but also has an actual end date for an exi" +
            "sting commitment (CI-797)")]
        public virtual void PaymentWithAnInvalidPaymentAmountButAlsoHasAnActualEndDateForAnExistingCommitmentCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment with an invalid payment amount but also has an actual end date for an exi" +
                    "sting commitment (CI-797)", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "Actual End Date"});
            table9.AddRow(new string[] {
                        "0",
                        "Test Apprentice 1",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "133.33",
                        "400.00",
                        "12",
                        "Today"});
#line 94
 testRunner.Given("I have made the following payments", ((string)(null)), table9, "Given ");
#line 97
 testRunner.And("there is a corresponding commitment stored for each of the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
 testRunner.Then("the Forecasting Payment service should record that the commitment has ended", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Payments with invalid earning details but also has an actual end date for an exis" +
            "ting commitment (CI-797)")]
        public virtual void PaymentsWithInvalidEarningDetailsButAlsoHasAnActualEndDateForAnExistingCommitmentCI_797()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payments with invalid earning details but also has an actual end date for an exis" +
                    "ting commitment (CI-797)", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment Amount",
                        "Apprentice Name",
                        "Course Name",
                        "Course Level",
                        "Provider Name",
                        "Start Date",
                        "Installment Amount",
                        "Completion Amount",
                        "Number Of Installments",
                        "Actual End Date"});
            table10.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 2",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "1.00",
                        "400.00",
                        "12",
                        "Today"});
            table10.AddRow(new string[] {
                        "133.33",
                        "Test Apprentice 3",
                        "Test Course",
                        "1",
                        "Test Provider",
                        "Yesterday",
                        "133.33",
                        "1.00",
                        "12",
                        "Today"});
#line 102
 testRunner.Given("I have made the following payments", ((string)(null)), table10, "Given ");
#line 106
 testRunner.And("there is a corresponding commitment stored for each of the payments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("the SFA Employer HMRC Payment service notifies the Forecasting service of the pay" +
                    "ment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("the Forecasting Payment service should record that the commitment has ended", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
