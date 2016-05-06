using ExamMaker.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ExamMaker.Data.Map {
    public class AppraiserMap : EntityTypeConfiguration<Appraiser> {
        public AppraiserMap() {
            ToTable("appraisers");

            Property(x => x.AppraiserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Cpf)
                .HasMaxLength(11)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_CPF", 1) { IsUnique = true }))
                .IsRequired();
        }
    }
}
