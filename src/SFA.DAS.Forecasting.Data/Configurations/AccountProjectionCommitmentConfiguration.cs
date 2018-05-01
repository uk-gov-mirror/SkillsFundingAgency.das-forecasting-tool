﻿using SFA.DAS.Forecasting.Models.Projections;

namespace SFA.DAS.Forecasting.Data.Configurations
{
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public partial class AccountProjectionCommitmentConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AccountProjectionCommitment>
    {
        public AccountProjectionCommitmentConfiguration()
            : this("dbo")
        {
        }

        public AccountProjectionCommitmentConfiguration(string schema)
        {
            ToTable("AccountProjectionCommitment", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AccountProjectionId).HasColumnName(@"AccountProjectionId").HasColumnType("bigint").IsRequired();
            Property(x => x.CommitmentId).HasColumnName(@"CommitmentId").HasColumnType("bigint").IsRequired();

            // Foreign keys
            HasRequired(a => a.AccountProjection).WithMany(b => b.Commitments).HasForeignKey(c => c.AccountProjectionId).WillCascadeOnDelete(false); // FK_AccountProjectionCommitment__AccountProjection
            HasRequired(a => a.Commitment).WithMany().HasForeignKey(c => c.CommitmentId).WillCascadeOnDelete(false); // FK_AccountProjectionCommitment__Commitment
            InitializePartial();
        }
        partial void InitializePartial();
    }
}