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
		}


		static readonly Feedback[] Feedbacks =
		[
			new() { Id = 1, MovieId = 1, UserId = "d1901b2435594da2a255db13fc57509b", Text="Чудовий фільм",Rating = 4 },
			new() { Id = 2, MovieId = 1, UserId = "c86dc56aedf549f6afe5ceb4d414ebf1" , Text = "Фільм дуже сподобався", Rating = 4 },
			new() { Id = 3, MovieId = 2, UserId = "028582c83a914a45b330b5234f4131fb", Text = "Один з найкащих фільмів", Rating = 4 },
			new() { Id = 4, MovieId = 2, UserId = "eb05f9548a2c4cf8adcc2be7305fc732", Text = "Фільм дуже сподобався", Rating = 5 },
		];


		static readonly Image[] Images =
		[
			//Braveheart screeshots
			new() { Id = 1, MovieId = 1, Name = "78f6bd3dff214a149d2b819d2bb2f596.jpg" },
			new() { Id = 2, MovieId = 1, Name = "e8709c9c252c4d0680054104be5d200a.jpg" },
			new() { Id = 3, MovieId = 1, Name = "9d02da5822204216838b18237d0752bc.jpg" },
			new() { Id = 4, MovieId = 1, Name = "cadc26fad170460196200194d40a718a.jpg" },
			new() { Id = 5, MovieId = 1, Name = "9a43056743774ef592a36559134f5be2.jpg" },
			new() { Id = 6, MovieId = 1, Name = "d14d399aa31d45678ad8cb2b317d6d5b.jpg" },
			new() { Id = 7, MovieId = 1, Name = "342c6b26fb544d43914ad1060677b2b8.jpg" },
			//Inception screeshots
			new() { Id = 8,  MovieId = 2, Name = "2d0627d1199a466c8486c07dc446e1b1.jpg" },
			new() { Id = 9,  MovieId = 2, Name = "fc404272f1b34d2e9f887073b58831b9.jpg" },
			new() { Id = 10, MovieId = 2, Name = "3ad737531a5c4b35b0bf99250208badd.jpg" },
			new() { Id = 11, MovieId = 2, Name = "c0299b7d354d4aa79f21d7e7b49519a5.jpg" },
			new() { Id = 12, MovieId = 2, Name = "978e2ab0753c4161bbd7f3af865df208.jpg" },
			new() { Id = 13, MovieId = 2, Name = "80c0e4e646d8435e9d7a4e9211a3be96.jpg" },
			new() { Id = 14, MovieId = 2, Name = "3484dbfface144648621281a62b40d81.jpg" },

		];

		
		static readonly MovieGenre[] MovieGenres =
		[
			new() { Id = 1, MovieId = 1, GenreId = 18 },
			new() { Id = 2, MovieId = 1, GenreId = 4 },
			new() { Id = 3, MovieId = 1, GenreId = 2 },
		];


		static readonly StafStafRole[] StafStafRoles =
		[
			//Braveheart staf
			new() { Id = 1, StafRoleId = 1, StafId = 1 },
			new() { Id = 2, StafRoleId = 2, StafId = 1 },
			new() { Id = 3, StafRoleId = 4, StafId = 1 },
			new() { Id = 4, StafRoleId = 2, StafId = 2 },
			new() { Id = 5, StafRoleId = 2, StafId = 3 },
			//Inception staf
			new() { Id = 6, StafRoleId = 1, StafId = 4 },
			new() { Id = 7, StafRoleId = 2, StafId = 5 },
			new() { Id = 8, StafRoleId = 2, StafId = 6 },
			new() { Id = 9, StafRoleId = 2, StafId = 7 },
			new() { Id = 10, StafRoleId = 2, StafId = 8 },
			new() { Id = 11, StafRoleId = 2, StafId = 9 },
			new() { Id = 12, StafRoleId = 2, StafId = 10 },

		];

		static readonly StafMovie[] StafMovies =
		[
			new() { Id = 1, MovieId = 1, StafId = 1 },
			new() { Id = 2, MovieId = 1, StafId = 2 },
			new() { Id = 3, MovieId = 1, StafId = 3 },
			//Inception staf
			new() { Id = 4, MovieId = 2, StafId = 4 },
			new() { Id = 5, MovieId = 2, StafId = 5 },
			new() { Id = 6, MovieId = 2, StafId = 6 },
			new() { Id = 7, MovieId = 2, StafId = 7 },
			new() { Id = 8, MovieId = 2, StafId = 8 },
			new() { Id = 9, MovieId = 2, StafId = 9 },
			new() { Id = 10, MovieId = 2, StafId = 10 },
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
				MovieUrl = @"https://pixel.stream.voidboost.cc/52806ed4b4d47c4a8297f9e4983a9659:2024022221:4c97894d-562e-4330-9154-0facb485bda1/7/8/1/6/3/byf31.mp4",
				TrailerUrl = @"https://www.youtube.com/watch?v=277chVHPQSA&t=39s",
				PremiumId = 1
			},
			new()
			{
				Id = 2,
				Name = "Початок",
				OriginalName = "Inception",
				Description = "Ми звикли, що в нашому розумінні злодій - це людина здатна вкрасти якісь цінності або гроші. Сюжет фантастичного бойовика «Початок» розповідає про злодіїв здатних вкрасти ідею прямо у людини з підсвідомості. Одним з таких є головний герой фільму Домінік Кобб. Після того як його дружина померла, він змушений ховатися, і не може навіть повернутися в країну, щоб побачити дітей. Якось раз Кобб отримує дуже неординарне замовлення: йому потрібно не вкрасти, а навпаки впровадити нову ідею в підсвідомість людини. Домініку не надто хотітися братися за цю справу, але замовник в обмін пропонує можливість повернутися додому. Заручившись підтримкою професіоналів цієї справи, Кобб починає розробляти план як все провернути. Все потрібно дуже добре продумати, адже злодіям доведеться відтворити багатошарову реальність в підсвідомості об'єкта, в результаті чого межі можуть почати стиратися.",
				Poster = "7d4159900afd4481881c42483b369f3e.jpg",
				CountryId = 2,
				Date = new DateTime(2010, 7, 22, 2, 28, 0),
				QualityId = 2,
				MovieUrl = @"https://aura.stream.voidboost.cc/e86eaadc35a0ecfb807054393e269605:2024022217:a95fa9f9-d7d0-4039-ad6f-4e785486da15/5/9/1/7/7/to9f8.mp4",
				TrailerUrl = @"https://www.youtube.com/watch?v=85Zz1CCXyDI",
				PremiumId = 2
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
			new()
			{
				Id = 4,
				Name = "Крістофер",
				Surname = "Нолан",
				Description = "Крістофер Джонатан Джеймс Нолан - англійський кінорежисер, сценарист і продюсер, який має британське і американське громадянства.[3][4][5] Його 12 фільмів були схвально прийняті світовою кінокритикою та зібрали понад 4 млрд доларів касових зборів, що робить його одним з найуспішніших режисерів сучасності.\r\n\r\nОтримав перше визнання після виходу психологічного трилера Мементо (2000), композиція якого побудована на викривленнях часу. Це дало йому змогу зняти високобюджетний трилер Безсоння (2002) та драму Престиж (2006). Подальший успіх режисерові принесли трилогія Темний лицар (2005—2012), фільм про проникання в чужі сни Початок (2010), науково-фантастичний фільм Інтерстеллар (2014), військову драму Дюнкерк (2017) та науково-фантастичний бойовик Тенет (2020).",
				ImageName = "2dbb31f7096740559fba2c8a22a870b2.jpg",
				CountryId = 22,
				Birthdate = new DateTime(1970, 7, 30),
				IsOscar = false
			},
			new()
			{
				Id = 5,
				Name = "Леонардо",
				Surname = "Ді Капріо",
				Description = "Леона́рдо Вільгельм Ді Ка́пріо (англ. Leonardo Wilhelm DiCaprio; нар. 11 листопада 1974, Лос-Анджелес, США) — американський актор, кінопродюсер. Лауреат премії «Оскар» за найкращу чоловічу роль у фільмі «Легенда Г'ю Гласса» (2016), та нагороди BAFTA і Гільдії кіноакторів США за виконання ролі Г'ю Гласса. Лауреат трьох премій «Золотий глобус» у категорії «Найкращий актор в драматичній картині» і «Найкращий актор — комедія або мюзикл» за головні ролі в картинах «Авіатор», «Вовк з Уолл-стріт» і «Легенда Г'ю Гласса». Лауреат нагороди Берлінського кінофестивалю «Срібний ведмідь» в категорії «Найкращий актор» за виконання ролі Ромео Монтеккі в картині «Ромео + Джульєтта».\r\n\r\nПовноцінну акторську кар'єру почав в шістнадцять років на початку 1990-х років. У 2000-х роках отримав визнання публіки і критиків за роботу в широкому діапазоні кіно і акторську майстерність.",
				ImageName = "1d4e8a9fea6146a887c774ffa2db33d7.jpg",
				CountryId = 2,
				Birthdate = new DateTime(1974, 11, 11),
				IsOscar = true
			},

			new()
			{
				Id = 6,
				Name = "Том",
				Surname = "Харді",
				Description = "Едвард Томас Гарді (англ. Edward Thomas Hardy) (нар. 15 вересня 1977, Гаммерсміт, Лондон, Велика Британія), знаніший як Том Гарді (англ. Tom Hardy) — британський актор театру та кіно, відомий за головною роллю у фільмі «Бронсон» (2009), а також завдяки участі в голлівудських блокбастерах «Зоряний шлях: Відплата» (2002), «Початок» (2010), «Воїн» (2011) та «Темний лицар повертається» (2012), «Шалений Макс: Дорога гніву» (2015), «Легенда Г'ю Гласса» (2015)",
				ImageName = "42713c2fa8b64141a74b4fa6b3d05a0c.jpg",
				CountryId = 20,
				Birthdate = new DateTime(1977, 9, 15),
				IsOscar = false
			},
			new()
			{
				Id = 7,
				Name = "Маріон",
				Surname = "Котіяр",
				Description = "Маріо́н Котія́р (фр. Marion Cotillard; нар. 30 вересня 1975, Париж, Франція) — французька акторка театру, телебачення та кіно. Володарка премій Оскар, Золотий глобус та BAFTA. Кавалерка та офіцерка ордена мистецтв та літератури.\r\n\r\nЗа роль у стрічці «Довгі заручини» (2004) отримала премію «Сезар» у номінації «Найкраща акторка другого плану». 2008 року удостоєна премії «Оскар» у номінації «Найкраща акторка» за фільм «Життя у рожевому кольорі», в якому виконала роль Едіт Піаф. Маріон Котіяр стала другою акторкою, що здобула премію «Оскар» за роль у фільмі іноземною мовою. Раніше цей рекорд утримувала Софі Лорен, володарка «Оскар» 1962 року. Також за фільм «Життя у рожевому кольорі» Котіяр отримала премію «Золотий глобус» у номінації «Найкраща жіноча роль (комедія або мюзикл)» і премію Британської академії телебачення та кіномистецтва (BAFTA) у номінації «Найкраща акторка».",
				ImageName = "a9141daeb1e04aff947474ad3f2d07d7.jpg",
				CountryId = 8,
				Birthdate = new DateTime(1975, 9, 30),
				IsOscar = true
			},
			new()
			{
				Id = 8,
				Name = "Майкл",
				Surname = "Кейн",
				Description = "Сер Мо́ріс Джо́зеф Міклвайт (англ. Sir Maurice Joseph Micklewhite), відоміший за акторським (артистичним) псевдонімом як Майкл Кейн (англ. Michael Caine, народився 14 березня 1933 в Лондоні) — один з найпопулярніших британських акторів (знявся більш ніж у 100 фільмах). Це один з двох акторів (другий — Джек Ніколсон), який був номінований на премію «Оскар» у 1960-х, 1970-х, 1980-х, 1990-х та 2000-х роках.",
				ImageName = "7adf0a94c3da4d8ea8809a79c6ea3eda.jpg",
				CountryId = 20,
				Birthdate = new DateTime(1933, 3, 14),
				IsOscar = true
			},
			new()
			{
				Id = 9,
				Name = "Кілліан",
				Surname = "Мерфі",
				Description = "Кілліан Мерфі (англ. Cillian Murphy; нар. 25 травня 1976, Дуглас, графство Корк, Ірландія) — ірландський актор театру і кіно. Колишній співак, гітарист та автор пісень гурту The Sons of Mr. Green Genes. Наприкінці 90-х почав свою акторську кар'єру граючи на сцені, в короткометражних та незалежних фільмах. Свою першу помітну роль він зіграв у фільмі \"28 днів потому\" (2002), в чорній комедії \"Розрив\" (2003), в трилері \"Нічний рейс\" (2005). Також зіграв ірландську жінку-трансвестита в комедійній драмі \"Сніданок на Плутоні\" (2005), за що був номінований на премію Золотий глобус в категорії \"найкращий актор в мюзиклі або комедії\". З 2013 по 2022 знімався у кримінально-драматичному серіалі \"Гострі картузи\", де зіграв Томаса Шелбі.",
				ImageName = "f39d0a89af744d498bc8aac540fefe4d.jpg",
				CountryId = 23,
				Birthdate = new DateTime(1976, 5, 25),
				IsOscar = true
			},
			new()
			{
				Id = 10,
				Name = "Джозеф",
				Surname = "Гордон-Левітт",
				Description = "Джозеф Леонард Гордон-Левітт (англ. Joseph Leonard Gordon-Levitt; нар. 17 лютого 1981, Лос-Анджелес, Каліфорнія, США) — американський актор, режисер, сценарист та продюсер. Отримав популярність завдяки ролі Томмі Соломона у комедійному серіалі «Третя планета від Сонця» (1996—2001), а також фільмам «Цеглина» (2005), «500 днів літа» (2009), «Початок» (2010), «Темний лицар повертається» (2012) та «Петля часу».",
				ImageName = "7d4159900afd4481881c42483b369f3e.jpg",
				CountryId = 2,
				Birthdate = new DateTime(1981, 2, 17),
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
			new() { Id = 21, Name = "Шотландія" },
			new() { Id = 22, Name = "Англія" },
			new() { Id = 23, Name = "Ірландія" }
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
