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
			modelBuilder.Entity<Premium>().HasData(Premiums);
			modelBuilder.Entity<Staf>().HasData(Stafs);
			modelBuilder.Entity<Feedback>().HasData(Feedbacks);
			modelBuilder.Entity<Movie>().HasData(Movies);
			modelBuilder.Entity<StafMovie>().HasData(StafMovies);
			modelBuilder.Entity<StafStafRole>().HasData(StafStafRoles);
			modelBuilder.Entity<MovieGenre>().HasData(MovieGenres);
			modelBuilder.Entity<Image>().HasData(Images);
			modelBuilder.Entity<MovieImage>().HasData(MovieImages);
		}


		static readonly Feedback[] Feedbacks =
		[
			new() { Id = 1, MovieId = 1, UserId = "d1901b2435594da2a255db13fc57509b", Text="Чудовий фільм" },
			new() { Id = 2, MovieId = 1, UserId = "c86dc56aedf549f6afe5ceb4d414ebf1" , Text = "Фільм дуже сподобався" },
		];


		static readonly MovieImage[] MovieImages =
		[
			new() { Id = 1, MovieId = 1, ImageId = 1 },
			new() { Id = 2, MovieId = 1, ImageId = 2 },
			new() { Id = 3, MovieId = 1, ImageId = 3 },
			new() { Id = 4, MovieId = 1, ImageId = 4 },
			new() { Id = 5, MovieId = 1, ImageId = 5 },
			new() { Id = 6, MovieId = 1, ImageId = 6 },
			new() { Id = 7, MovieId = 1, ImageId = 7 },


		];

		static readonly Image[] Images =
		[
			//Braveheart screeshots
			new() { Id = 1, Name = "78f6bd3dff214a149d2b819d2bb2f596.jpg" },
			new() { Id = 2, Name = "e8709c9c252c4d0680054104be5d200a.jpg" },
			new() { Id = 3, Name = "9d02da5822204216838b18237d0752bc.jpg" },
			new() { Id = 4, Name = "cadc26fad170460196200194d40a718a.jpg" },
			new() { Id = 5, Name = "9a43056743774ef592a36559134f5be2.jpg" },
			new() { Id = 6, Name = "d14d399aa31d45678ad8cb2b317d6d5b.jpg" },
			new() { Id = 7, Name = "342c6b26fb544d43914ad1060677b2b8.jpg" },
			
		];


		static readonly MovieGenre[] MovieGenres =
		[
			new() { Id = 1, MovieId = 1, GenreId = 18 },
			new() { Id = 2, MovieId = 1, GenreId = 4 },
			new() { Id = 3, MovieId = 1, GenreId = 2 },
		];


		static readonly StafStafRole[] StafStafRoles =
		[
			new() { Id = 1, StafRoleId = 1, StafId = 1 },
			new() { Id = 2, StafRoleId = 2, StafId = 1 },
			new() { Id = 3, StafRoleId = 4, StafId = 1 },
			new() { Id = 4, StafRoleId = 2, StafId = 2 },
			new() { Id = 5, StafRoleId = 2, StafId = 3 },

		];

		static readonly StafMovie[] StafMovies =
		[
			new() { Id = 1, MovieId = 1, StafId = 1 },
			new() { Id = 2, MovieId = 1, StafId = 2 },
			new() { Id = 3, MovieId = 1, StafId = 3 },
		];


		static readonly Movie[] Movies =
		[
			new()
			{
				Id = 1,
				Name = "Хоробре серце",
				OriginalName = "Braveheart",
				Description = "Фільм, що розповідає про боротьбу Шотландського королівства за незалежність проти англійського панування. Головний герой фільму — Вільям Воллес, ватажок шотландців, у виконанні Мела Гібсона.одії фільму починаються 1280 року. Це історія легендарного національного шотландського героя Вільяма Воллеса, який присвятив себе боротьбі з англійцями за часів короля Едуарда Довгоногого. Вільям рано втратив батька, що загинув від рук англійців, але його дядько зумів дати хлопцеві навчання в Європі. На батьківщину Вільям повертається вже дорослим чоловіком, що мріє завести родину і жити мирним життям. Та доля вирішила інакше. Його наречену вбили англійці, і він почав свій «хрестовий похід» за свободу.",
				Poster = "82ff372d46f44895af282106fe13a201.jpg",
				CountryId = 2,
				Date = new DateTime(1995, 4, 25,2,57,0),
				QualityId = 3,
				MovieUrl = @"https://pixel.stream.voidboost.cc/c856f28d3535c356286e0fb2128b2cd4:2024022021:43f8ed35-e4ad-4d7d-bd42-7a4fe8d4055e/7/8/1/6/3/byf31.mp4",
				TrailerUrl = @"https://www.youtube.com/watch?v=277chVHPQSA&t=39s",
				PremiumId = 1
			},
		];



		static readonly Staf[] Stafs =
		[
			new()
			{
				Id = 1,
				Name = "Мел",
				Surname = "Гибсон",
				Description = "Народився 3 січня 1956 року.\r\n\r\nСин ірландців-католиків Гаттона Гібсона та Ен Райлі Гібсон, яка народилася в парафії Колм-Кіллє графства Лонгфорд, Ірландія. Його бабця по батькові Ева Майлот була австралійською оперною співачкою. Мел народився у місті Пікскілл (округ Вестчестер, штат Нью-Йорк) і був шостим з одинадцяти дітей. Один із молодших братів Мела, Донал, також актор.",
				ImageName = "d5d49574945f45c8be24f00cc02923af.webp",
				CountryId = 2,
				Birthdate = new DateTime(1956, 1, 3),
				IsOscar = true
			},
			new()
			{
				Id = 2,
				Name = "Енгус",
				Surname = "Макфадьєн",
				Description = "Народився у сім'ї лікаря. У дитинстві подорожував між трьома країнами — Філіппінами, Сингапуром і Францією. Вищу освіту Енгус отримав у стінах Університету Единбурга, Шотландія. Паралельно з гризенням граніту науки молодий чоловік відвідував заняття в Центральній школі Мовлення та Драми в Лондоні, Англія.",
				ImageName = "da0240d0882b4ec1942342ec6cf72505.jpg",
				CountryId = 21,
				Birthdate = new DateTime(1963, 9, 21),
				IsOscar = false
			},
			new()
			{
				Id = 3,
				Name = "Софі",
				Surname = "Марсо",
				Description = "Народилася 17 листопада 1966 року в Париж, Франція.\r\n\r\nПрославилася підлітком, дебютувавши у «Вечірці» (La Boum, 1980). Вдало знайдений образ «ідеальної французької дівчини», якою Марсо визнали за підсумками глядацького опитування, було розмножено у фільмах «Вечірка-2» (фр. La Boum 2, 1982), «Щасливого Великодня» (1984), «Студентка» (1988), «Аромат кохання. Фанфан» (1993) тощо. Актрису часто залучали до найамбітніших проектів національної кіноіндустрії: «Форт Саґан», «Шуани!», «Дочка Д'Артаньяна», де вона втілювала ідеальну француженку, перетворившись із чарівного підлітка на одну з найкрасивіших актрис світового кіно.\r\n\r\n1999 року зіграла дівчину Бонда у черговому, 19-му за ліком, епізоді Бондіани — підступну, але дуже вразливу Електру Кінґ. Продовжує активно зніматися.",
				ImageName = "c9b0972dd8b6431193cd50e9c272416f.jpg",
				CountryId = 8,
				Birthdate = new DateTime(1966, 11, 17),
				IsOscar = false
			},

		];

		static readonly Premium[] Premiums =
		[
			new() { Id = 1, Name = "Free",Rate = 0 },
			new() { Id = 2, Name = "Light", Rate = 20 },
			new() { Id = 3, Name = "Midle", Rate = 40 },
			new() { Id = 5, Name = "Full", Rate = 60 },
		];

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
			new() { Id = 20, Name = "Британія" },
			new() { Id = 21, Name = "Шотландія" }
		];
		static readonly StafRole[] StafRoles =
		[
			new() { Id = 1, Name = "Режисер" },
			new() { Id = 2, Name = "Актор" },
			new() { Id = 3, Name = "Оператор" },
			new() { Id = 4, Name = "Продюсер" },
			new() { Id = 5, Name = "Автор сценарію" },
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
