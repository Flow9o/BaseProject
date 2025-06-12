using BaseProject.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Infrastructure.Configurations;

public class BookmarkConfig : IEntityTypeConfiguration<Bookmark>
{
	public void Configure(EntityTypeBuilder<Bookmark> builder)
	{
		builder.HasKey(b => b.Id);
	}
}