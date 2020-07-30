using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__account___18186C103EF3EDC8");

            entity.ToTable("account_types");

            entity.HasIndex(e => e.AccountTypeName)
                .HasName("KEY_account_types_account_type_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("account_type_id");

            entity.Property(e => e.AccountTypeName)
                .IsRequired()
                .HasColumnName("account_type_name")
                .HasMaxLength(100);
        }
    }
}
