﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SFA.DAS.Forecasting.Core;
using SFA.DAS.Forecasting.Core.Validation;
using SFA.DAS.Forecasting.Domain.Commitments.Validation;
using SFA.DAS.Forecasting.Domain.Events;
using SFA.DAS.Forecasting.Models.Commitments;

namespace SFA.DAS.Forecasting.Domain.Commitments
{
    public class EmployerCommitments
    {
        private readonly long _employerAccountId;
        private readonly List<Commitment> _commitments;
        private readonly IEventPublisher _eventPublisher;
        public ReadOnlyCollection<Commitment> Commitments => _commitments.AsReadOnly();
        private readonly List<ICommitmentValidator> _addCommitmentValidators = new List<ICommitmentValidator>
        {
            //new CommitmentEndDateValidator()
        };

        public EmployerCommitments(long employerAccountId, List<Commitment> commitments, IEventPublisher eventPublisher)
        {
            _employerAccountId = employerAccountId;
            _commitments = commitments ?? throw new ArgumentNullException(nameof(commitments));
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public void AddCommitment(long apprenticeshipId, long learnerId, DateTime startDate, DateTime plannedEndDate,
            DateTime? actualEndDate, decimal monthlyInstallment, decimal completionAmount, short numberOfInstallments)
        {
            var commitment = new Commitment
            {
                EmployerAccountId = _employerAccountId,
                ApprenticeshipId = apprenticeshipId,
                LearnerId = learnerId,
                StartDate = startDate,
                PlannedEndDate = plannedEndDate,
                ActualEndDate = actualEndDate,
                MonthlyInstallment = monthlyInstallment,
                CompletionAmount = completionAmount,
                NumberOfInstallments = numberOfInstallments
            };
            var results = _addCommitmentValidators.Select(validator => validator.Validate(commitment)).Where(failureReason => failureReason != null).ToList();
            if (results.Any())
            {
                _eventPublisher.Publish(new ValidationFailure<Commitment>(results.ToList(), commitment));
                return;
            }

            var existingCommitment = _commitments.FirstOrDefault(c =>
                c.ApprenticeshipId == commitment.ApprenticeshipId && c.LearnerId == commitment.LearnerId);
            if (existingCommitment != null)
            {
                existingCommitment.ActualEndDate = actualEndDate;
                existingCommitment.MonthlyInstallment = monthlyInstallment;
                existingCommitment.PlannedEndDate = plannedEndDate;
                existingCommitment.StartDate = startDate;
                existingCommitment.CompletionAmount = completionAmount;
                existingCommitment.NumberOfInstallments = numberOfInstallments;
            }
            else
                _commitments.Add(commitment);
        }

        public virtual decimal GetTotalCostOfTraining(DateTime date)
        {
            var startOfMonth = date.GeStartOfMonth();
            return _commitments.Where(commitment =>
                    commitment.StartDate.GeStartOfMonth() <= startOfMonth &&
                    commitment.PlannedEndDate.GeStartOfMonth().AddMonths(-1) >= startOfMonth)
                .Select(commitment => commitment.MonthlyInstallment)
                .Sum();
        }

        public virtual decimal GetTotalCompletionPayments(DateTime date)
        {
            var startOfMonth = date.GeStartOfMonth();
            return _commitments.Where(commitment =>
                    commitment.PlannedEndDate.GeStartOfMonth() == startOfMonth)
                .Select(commitment => commitment.CompletionAmount)
                .Sum();
        }
    }
}