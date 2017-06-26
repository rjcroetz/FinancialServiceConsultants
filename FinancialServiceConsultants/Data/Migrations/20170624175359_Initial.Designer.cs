using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FinancialServiceConsultants.Data;

namespace FinancialServiceConsultants.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170624175359_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinancialServiceConsultants.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("ContactPerson");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });
        }
    }
}
