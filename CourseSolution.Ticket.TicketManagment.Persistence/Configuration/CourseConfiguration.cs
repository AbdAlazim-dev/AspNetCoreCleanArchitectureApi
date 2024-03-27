using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
