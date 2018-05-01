﻿Feature: Generate Levy Projections [CI-498]
	As an employer with a pay bill over £3 million each year and therefore must now pay the apprenticeship levy
	I want my levy credit to be forecast for the next 4 years
	So that I can effectively forecast my account balance

Background:
	Given I'm a levy paying employer
	And the payroll period is 
	| Payroll Year | Payroll Month |
	| 18-19        | 1             |
	And the following commitments have been recorded
	| Apprentice Name   | Course Name | Course Level | Provider Name | Start Date | Installment Amount | Completion Amount | Number Of Installments |
	| Test Apprentice 1 | Test Course | 1            | Test Provider | Yesterday  | 500                | 3000              | 24                     |
	| Test Apprentice 2 | Test Course | 1            | Test Provider | Last year  | 250                | 1500              | 48                     |
	And the current balance is 5000
	And I have no existing levy declarations for the payroll period

Scenario: AC1: Calculate forecast levy credit value when single linked PAYE scheme
	Given the following levy declarations have been recorded
	| Scheme   | Amount | Created Date |
	| ABC-1234 | 3000   | Today        |
	When the account projection is triggered after levy has been declared
	Then the account projection should be generated
	Then calculated levy credit value should be the amount declared for the single linked PAYE scheme
	And each future month's forecast levy credit should be the same

Scenario: AC2: Calculate forecast levy credit value when multiple linked PAYE schemes
	Given the following levy declarations have been recorded
	| Scheme   | Amount | Created Date |
	| ABC-1234 | 3000   | Today        |
	| ABC-5678 | 3500   | Today        |
	| ABC-9012 | 8500   | Today        |
	When the account projection is triggered after levy has been declared
	Then the account projection should be generated
	Then calculated levy credit value should be the amount declared for the sum of the linked PAYE schemes
	And each future month's forecast levy credit should be the same

Scenario: AC3: Use specified start month when generating levy triggered projections
	Given the following levy declarations have been recorded
	| Scheme   | Amount | Created Date |
	| ABC-1234 | 3000   | Today        |
	And the start month should be this month rather than next month
	When the account projection is triggered after levy has been declared
	Then the account projection should be generated
	And the first month should be this month rather than next month	