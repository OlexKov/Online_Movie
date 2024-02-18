using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
	internal static class DefaultData
	{
		public static void Initialize(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>().HasData(Countries);
			modelBuilder.Entity<Genre>().HasData(Genres);
			modelBuilder.Entity<StafRole>().HasData(StafRoles);
			modelBuilder.Entity<Quality>().HasData(Qualities);
		}

		static readonly Quality[] Qualities =
		[
			new() { Id = 1, Name = "Web-DL" },
			new() { Id = 2, Name = "1080p" },
			new() { Id = 3, Name = "720p" },
			new() { Id = 5, Name = "480p" },
			new() { Id = 6, Name = "2K" },
			new() { Id = 7, Name = "4K" },
			new() { Id = 8, Name = "8K" }
		];

		static readonly Country[] Countries =
		[
		    new() { Id = 1, Name = "Україна" },
			new() { Id = 2, Name = "США" },
			new() { Id = 3, Name = "Китай" },
			new() { Id = 4, Name = "Індія" },
			new() { Id = 5, Name = "Бразилія" },
			new() { Id = 6, Name = "Німеччина" },
			new() { Id = 7, Name = "Японія" },
			new() { Id = 8, Name = "Франція" },
			new() { Id = 9, Name = "Канада" },
			new() { Id = 10, Name = "Італія" },
			new() { Id = 11, Name = "Австралія" },
			new() { Id = 12, Name = "Іспанія" },
			new() { Id = 13, Name = "Мексика" },
			new() { Id = 14, Name = "Південна Корея" },
			new() { Id = 15, Name = "Індонезія" },
			new() { Id = 16, Name = "Нідерланди" },
			new() { Id = 17, Name = "Польща" },
			new() { Id = 18, Name = "Швеція" },
			new() { Id = 19, Name = "Швейцарія" },
			new() { Id = 20, Name = "Британія" }
		];
		static readonly StafRole[] StafRoles =
		[
			new() { Id = 1, Name = "Режисер" },
			new() { Id = 2, Name = "Актор" },
			new() { Id = 3, Name = "Оператор" },
		];

		static readonly Genre[] Genres =
		[
			new() { Id = 1, Name = "Екшн" },
			new() { Id = 2, Name = "Пригоди" },
			new() { Id = 3, Name = "Комедія" },
			new() { Id = 4, Name = "Драма" },
			new() { Id = 5, Name = "Жахи" },
			new() { Id = 6, Name = "Фентезі" },
			new() { Id = 7, Name = "Фантастика" },
			new() { Id = 8, Name = "Романтика" },
			new() { Id = 9, Name = "Трилер" },
			new() { Id = 10, Name = "Кримінал" },
			new() { Id = 11, Name = "Вестерн" },
			new() { Id = 12, Name = "Воєнний" },
			new() { Id = 13, Name = "Документальний" },
			new() { Id = 14, Name = "Містика" },
			new() { Id = 15, Name = "Мюзикл" },
			new() { Id = 16, Name = "Аніме" },
			new() { Id = 17, Name = "Спорт" },
			new() { Id = 18, Name = "Історичний" },
			new() { Id = 19, Name = "Біографія" },
			new() { Id = 20, Name = "Детектив" },
			new() { Id = 21, Name = "Хоррор" },
			new() { Id = 22, Name = "Мелодрама" }
		];
	}
}
