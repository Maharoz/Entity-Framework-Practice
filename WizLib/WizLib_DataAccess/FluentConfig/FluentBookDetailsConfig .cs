using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WizLib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookDetailsConfig : IEntityTypeConfiguration<Fluent_BookDetails>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetails> modelBuilder)
        {
            //BookDetails
            modelBuilder.HasKey(b => b.BookDetail_Id);
            modelBuilder.Property(b => b.NumberOfChapters).IsRequired();



        }
    }
}
