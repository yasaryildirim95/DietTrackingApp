using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BA.DietTrackApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calori = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Portion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMeals_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meyve" },
                    { 2, "Sebze/Baharat" },
                    { 3, "Hamur İşi" },
                    { 4, "Tahıl" },
                    { 5, "Baklagil" },
                    { 6, "Et" },
                    { 7, "Deniz Ürünleri" },
                    { 8, "Süt Ürünleri" },
                    { 9, "Kuruyemiş" },
                    { 10, "Tohumlar" },
                    { 11, "Yağ" },
                    { 12, "Soslar" },
                    { 13, "Turşular" },
                    { 14, "Tatlılar" },
                    { 15, "Fastfood & Atıştırmalık" },
                    { 16, "Yumurtalar" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calori", "FName", "FoodTypeId" },
                values: new object[,]
                {
                    { 1, 114m, "Armut-1 adet (orta)", 1 },
                    { 2, 98m, "Ayva-1 adet (orta)", 1 },
                    { 3, 44m, "Beyaz dut-1 kase (orta)", 1 },
                    { 4, 163m, "Beyaz üzüm-1 kase (orta)", 1 },
                    { 5, 68m, "Böğürtlen-1 kase (orta)", 1 },
                    { 6, 46m, "Çilek-1 kase (orta)", 1 },
                    { 7, 52m, "Elma-1 adet (orta)", 1 },
                    { 8, 9m, "Erik-1 adet (orta)", 1 },
                    { 9, 52m, "Frambuaz-1 kase (orta)", 1 },
                    { 10, 150m, "Greyfurt-1 adet (orta)", 1 },
                    { 11, 48m, "İncir-1 adet (orta)", 1 },
                    { 12, 343m, "Karadut-1 kase (orta)", 1 },
                    { 13, 105m, "Karpuz-1 dilim (orta)", 1 },
                    { 14, 76m, "Kavun-1 dilim (orta)", 1 },
                    { 15, 14m, "Kayısı-1 adet (orta)", 1 },
                    { 16, 4m, "Kiraz-1 adet (orta)", 1 },
                    { 17, 61m, "Kivi-1 adet (orta)", 1 },
                    { 18, 49m, "Kuşburnu-1 kase (orta)", 1 },
                    { 19, 43m, "Limon-1 adet (orta)", 1 },
                    { 20, 66m, "Mandalina-1 adet (orta)", 1 },
                    { 21, 151m, "Muz-1 adet (orta)", 1 },
                    { 22, 101m, "Portakal-1 adet (orta)", 1 },
                    { 23, 160m, "Siyah üzüm-1 kase (orta)", 1 },
                    { 24, 78m, "Şeftali-1 adet (orta)", 1 },
                    { 25, 3m, "Vişne-1 adet (orta)", 1 },
                    { 26, 44m, "Yaban mersini-1 kase (orta)", 1 },
                    { 27, 159m, "Yeşil üzüm-1 kase (orta)", 1 },
                    { 28, 40m, "Ananas-1 dilim (orta)", 1 },
                    { 29, 224m, "Avokado-1 adet", 1 },
                    { 30, 97m, "Çarkıfelek-1 adet", 1 },
                    { 31, 354m, "Hindistan cevizi-1 adet", 1 },
                    { 32, 26m, "Hurma-1 adet", 1 },
                    { 33, 59m, "Mango-1 adet", 1 },
                    { 34, 42m, "Papaya-1 adet", 1 },
                    { 35, 11m, "Pomelo-1 dilim (orta)", 1 },
                    { 36, 30m, "Yıldız meyvesi-1 adet", 1 },
                    { 37, 336m, "Dut-100 gram", 1 },
                    { 38, 346m, "Goji berry-100 gram", 1 },
                    { 39, 249m, "Kuru incir-100 gram", 1 },
                    { 40, 241m, "Kuru kayısı-100 gram", 1 },
                    { 41, 299m, "Kuru üzüm-100 gram", 1 },
                    { 42, 302m, "Kuru yaban mersini-100 gram", 1 },
                    { 43, 335m, "Kurutulmuş portakal-100 gram", 1 },
                    { 44, 283m, "Kuş üzümü-100 gram", 1 },
                    { 45, 525m, "Muz kurusu-100 gram", 1 },
                    { 46, 42m, "Akdeniz yeşillikleri-100 gram", 2 },
                    { 47, 72m, "Bakla-100 gram", 2 },
                    { 48, 33m, "Bal kabağı-100 gram", 2 },
                    { 49, 36m, "Bamya-100 gram", 2 },
                    { 50, 25m, "Beyaz lahana-100 gram", 2 },
                    { 51, 84m, "Bezelye-100 gram", 2 },
                    { 52, 22m, "Biber-100 gram", 2 },
                    { 53, 34m, "Brokoli-100 gram", 2 },
                    { 54, 63m, "Brüksel lahanası-100 gram", 2 },
                    { 55, 40m, "Deniz börülcesi-100 gram", 2 },
                    { 56, 42m, "Dere otu-100 gram", 2 },
                    { 57, 22m, "Domates-100 gram", 2 },
                    { 58, 53m, "Enginar-100 gram", 2 },
                    { 59, 13m, "Göbek salata-100 gram", 2 },
                    { 60, 45m, "Havuç-100 gram", 2 },
                    { 61, 26m, "Ispanak-100 gram", 2 },
                    { 62, 26m, "Kabak-100 gram", 2 },
                    { 63, 45m, "Kara lahana-100 gram", 2 },
                    { 64, 27m, "Karnıbahar-100 gram", 2 },
                    { 65, 40m, "Kereviz-100 gram", 2 },
                    { 66, 31m, "Kırmızı lahana-100 gram", 2 },
                    { 67, 20m, "Kıvırcık salata-100 gram", 2 },
                    { 68, 26m, "Körpe ıspanak-100 gram", 2 },
                    { 69, 26m, "Kuşkonmaz-100 gram", 2 },
                    { 70, 42m, "Kuzu kulağı-100 gram", 2 },
                    { 71, 56m, "Limon-1 adet", 2 },
                    { 72, 22m, "Madımak-100 gram", 2 },
                    { 73, 28m, "Mantar-100 gram", 2 },
                    { 74, 14m, "Marul-100 gram", 2 },
                    { 75, 14m, "Maskulin salata-100 gram", 2 },
                    { 76, 44m, "Maydonoz-100 gram", 2 },
                    { 77, 91m, "Mısır-1 adet", 2 },
                    { 78, 42m, "Pancar-100 gram", 2 },
                    { 79, 76m, "Patates-100 gram", 2 },
                    { 80, 25m, "Patlıcan-100 gram", 2 },
                    { 81, 33m, "Pazı-100 gram", 2 },
                    { 82, 52m, "Pırasa-100 gram", 2 },
                    { 83, 33m, "Roka-100 gram", 2 },
                    { 84, 15m, "Salatalık-100 gram", 2 },
                    { 85, 123m, "Sarımsak-100 gram", 2 },
                    { 86, 32m, "Semiz otu-100 gram", 2 },
                    { 87, 39m, "Soğan-1 adet", 2 },
                    { 88, 51m, "Soya filizi-100 gram", 2 },
                    { 89, 30m, "Şalgam-100 gram", 2 },
                    { 90, 118m, "Taze biberiye-100 gram", 2 },
                    { 91, 32m, "Taze fasülye-100 gram", 2 },
                    { 92, 30m, "Taze fesleğen-100 gram", 2 },
                    { 93, 101m, "Taze kekik-100 gram", 2 },
                    { 94, 33m, "Taze kişniş-100 gram", 2 },
                    { 95, 65m, "Taze nane-100 gram", 2 },
                    { 96, 255m, "Taze tarhun-100 gram", 2 },
                    { 97, 80m, "Taze zencefil-100 gram", 2 },
                    { 98, 33m, "Tere-100 gram", 2 },
                    { 99, 19m, "Turp-1 adet", 2 },
                    { 100, 75m, "Yer elması-1 adet", 2 },
                    { 101, 49m, "Yonca filizi-100 gram", 2 },
                    { 102, 31m, "Defne yaprağı-100 gram", 2 },
                    { 103, 26m, "Karabiber-100 gram", 2 },
                    { 104, 32m, "Karanfil-100 gram", 2 },
                    { 105, 35m, "Kereviz tozu-100 gram", 2 },
                    { 106, 16m, "Kırmızı pulbiber-100 gram", 2 },
                    { 107, 13m, "Kimyon-100 gram", 2 },
                    { 108, 15m, "Köri-100 gram", 2 },
                    { 109, 27m, "Kuru bamya-100 gram", 2 },
                    { 110, 30m, "Kuru biberiye-100 gram", 2 },
                    { 111, 25m, "Kuru dereotu-100 gram", 2 },
                    { 112, 26m, "Kuru domates-100 gram", 2 },
                    { 113, 27m, "Kuru fesleğen-100 gram", 2 },
                    { 114, 28m, "Kuru kekik-100 gram", 2 },
                    { 115, 30m, "Kuru kişniş-100 gram", 2 },
                    { 116, 28m, "Kuru maydonoz-100 gram", 2 },
                    { 117, 25m, "Kuru nane-100 gram", 2 },
                    { 118, 29m, "Kuru patlıcan-100 gram", 2 },
                    { 119, 26m, "Kuru tarhun-100 gram", 2 },
                    { 120, 14m, "Lavanta-100 gram", 2 },
                    { 121, 14m, "Mahlep-100 gram", 2 },
                    { 122, 19m, "Muskat-100 gram", 2 },
                    { 123, 35m, "Rezene tohumu-100 gram", 2 },
                    { 124, 16m, "Safran-100 gram", 2 },
                    { 125, 15m, "Sarımsak tozu-100 gram", 2 },
                    { 126, 19m, "Sumak-100 gram", 2 },
                    { 127, 19m, "Tarçın-100 gram", 2 },
                    { 128, 12m, "Vanilya-100 gram", 2 },
                    { 129, 16m, "Yenibahar-100 gram", 2 },
                    { 130, 35m, "Zencefil tozu-100 gram", 2 },
                    { 131, 14m, "Zerdeçal-100 gram", 2 },
                    { 132, 127m, "Akıtma-1 porsiyon", 3 },
                    { 133, 503m, "Anne kurabiyesi-1 porsiyon", 3 },
                    { 134, 426m, "Avcı böreği-1 porsiyon", 3 },
                    { 135, 431m, "Boşnak mantısı-1 porsiyon", 3 },
                    { 136, 208m, "Çekirdekli ekmek-1 porsiyon", 3 },
                    { 137, 528m, "Çiğ börek-1 porsiyon", 3 },
                    { 138, 192m, "Ekşi mayalı köy ekmeği-1 porsiyon", 3 },
                    { 139, 441m, "Elmalı turta-1 porsiyon", 3 },
                    { 140, 327m, "Ev yapımı lahmacun-1 porsiyon", 3 },
                    { 141, 233m, "Fındık lahmacun-1 porsiyon", 3 },
                    { 142, 378m, "Akdarı-100 gram", 4 },
                    { 143, 354m, "Arpa-100 gram", 4 },
                    { 144, 584m, "Ayçiçeği tohumu-100 gram", 4 },
                    { 145, 216m, "Buğday kepeği-100 gram", 4 },
                    { 146, 281m, "Çavdar tohumu-100 gram", 4 },
                    { 147, 388m, "Esmer pirinç-100 gram", 4 },
                    { 148, 390m, "Galeta-100 gram", 4 },
                    { 149, 399m, "Grissini (İnce)-100 gram", 4 },
                    { 150, 351m, "İnce mısır unu-100 gram", 4 },
                    { 151, 343m, "Kara buğday-100 gram", 4 },
                    { 152, 534m, "Keten tohumu-100 gram", 4 },
                    { 153, 381m, "Mısır nişastası-100 gram", 4 },
                    { 154, 237m, "Tortilla-100 gram", 4 },
                    { 155, 246m, "Yulaf kepeği-100 gram", 4 },
                    { 156, 612m, "Akceviz-100 gram", 5 },
                    { 157, 84m, "Bakla-100 gram", 5 },
                    { 158, 27m, "Bambu filizi-100 gram", 5 },
                    { 159, 33m, "Bamya-100 gram", 5 },
                    { 160, 336m, "Beyaz fasülye-100 gram", 5 },
                    { 161, 81m, "Bezelye-100 gram", 5 },
                    { 162, 347m, "Barbunya fasülyesi-100 gram", 5 },
                    { 163, 115m, "Börülce-100 gram", 5 },
                    { 164, 353m, "Kahverengi mercimek-100 gram", 5 },
                    { 165, 329m, "Kırmızı mercimek-100 gram", 5 },
                    { 166, 12m, "Maş fasülyesi-100 gram", 5 },
                    { 167, 364m, "Nohut-100 gram", 5 },
                    { 168, 147m, "Soya fasülyesi-100 gram", 5 },
                    { 169, 567m, "Yer fıstığı-100 gram", 5 },
                    { 170, 31m, "Yeşil fasülye-100 gram", 5 },
                    { 171, 257m, "Yeşil mercimek-100 gram", 5 },
                    { 172, 208m, "Hindi but-100 gram", 6 },
                    { 173, 100m, "Hindi füme-100 gram", 6 },
                    { 174, 162m, "Hindi göğüs-100 gram", 6 },
                    { 175, 121m, "Hindi jambon-100 gram", 6 },
                    { 176, 165m, "Hindi kıyma-100 gram", 6 },
                    { 177, 268m, "Hindi pastırma-100 gram", 6 },
                    { 178, 221m, "Tavuk but-100 gram", 6 },
                    { 179, 201m, "Tavuk füme-100 gram", 6 },
                    { 180, 165m, "Tavuk göğüs-100 gram", 6 },
                    { 181, 100m, "Tavuk jambon-100 gram", 6 },
                    { 182, 177m, "Tavuk kalça şiş-100 gram", 6 },
                    { 183, 143m, "Tavuk kıyma-100 gram", 6 },
                    { 184, 124m, "Tavuk salam-100 gram", 6 },
                    { 185, 168m, "Dana antrikot-100 gram", 6 },
                    { 186, 185m, "Dana biftek-100 gram", 6 },
                    { 187, 168m, "Dana bonfile-100 gram", 6 },
                    { 188, 125m, "Dana dil-100 gram", 6 },
                    { 189, 181m, "Dana jambon-100 gram", 6 },
                    { 190, 155m, "Dana kıyma-100 gram", 6 },
                    { 191, 188m, "Dana pirzola-100 gram", 6 },
                    { 192, 445m, "Dana salam-100 gram", 6 },
                    { 193, 320m, "Dana sosis-100 gram", 6 },
                    { 194, 445m, "Dana sucuk-100 gram", 6 },
                    { 195, 231m, "Kuzu but-100 gram", 6 },
                    { 196, 376m, "Kuzu incik-100 gram", 6 },
                    { 197, 244m, "Kuzu kıyma-100 gram", 6 },
                    { 198, 231m, "Kuzu kol-100 gram", 6 },
                    { 199, 343m, "Kuzu pirzola-100 gram", 6 },
                    { 200, 118m, "Barbun-70 gram", 7 },
                    { 201, 112m, "Çinekop-60 gram", 7 },
                    { 202, 360m, "Çipura-300 gram", 7 },
                    { 203, 100m, "Fener balığı-100 gram", 7 },
                    { 204, 42m, "İstavrit-25 gram", 7 },
                    { 205, 45m, "Hamsi-20 gram", 7 },
                    { 206, 188m, "Kalamar-250 gram", 7 },
                    { 207, 8m, "Karides-8 gram", 7 },
                    { 208, 164m, "Kılıç balığı-100 gram", 7 },
                    { 209, 279m, "Levrek-300 gram", 7 },
                    { 210, 336m, "Lüfer-200 gram", 7 },
                    { 211, 180m, "Mezgit-200 gram", 7 },
                    { 212, 336m, "Palamut-200 gram", 7 },
                    { 213, 183m, "Somon-100 gram", 7 },
                    { 214, 184m, "Ton balığı-100 gram", 7 },
                    { 215, 318m, "Uskumru-200 gram", 7 },
                    { 216, 68m, "Keçi sütü-100 gram", 8 },
                    { 217, 108m, "Koyun sütü-100 gram", 8 },
                    { 218, 35m, "Normal light süt-100 gram", 8 },
                    { 219, 61m, "Normal yağlı süt-100 gram", 8 },
                    { 220, 62m, "Laktozsuz süt-100 gram", 8 },
                    { 221, 41m, "Light kefir-100 gram", 8 },
                    { 222, 57m, "Light yoğurt-100 gram", 8 },
                    { 223, 65m, "Tam yağlı kefir-100 gram", 8 },
                    { 224, 84m, "Yağlı yoğurt-100 gram", 8 },
                    { 225, 101m, "Çedar peyniri-25 gram", 8 },
                    { 226, 95m, "Çökelek peyniri-25 gram", 8 },
                    { 227, 59m, "Eski kaşar peyniri-25 gram", 8 },
                    { 228, 78m, "Ezine keçi peyniri-25 gram", 8 },
                    { 229, 89m, "Gravyer peyniri-25 gram", 8 },
                    { 230, 45m, "Light beyaz peynir-25 gram", 8 },
                    { 231, 45m, "Light dil peyniri-25 gram", 8 },
                    { 232, 36m, "Light labne-25 gram", 8 },
                    { 233, 56m, "Light taze kaşar peyniri-25 gram", 8 },
                    { 234, 21m, "Lor peyniri-25 gram", 8 },
                    { 235, 110m, "Krem peynir-25 gram", 8 },
                    { 236, 70m, "Mozzerella-25 gram", 8 },
                    { 237, 59m, "Normal beyaz peynir-25 gram", 8 },
                    { 238, 52m, "Normal labne-25 gram", 8 },
                    { 239, 45m, "Normal dil peyniri-25 gram", 8 },
                    { 240, 82m, "Otlu peynir-25 gram", 8 },
                    { 241, 95m, "Parmesan peyniri-25 gram", 8 },
                    { 242, 21m, "Ricotta peyniri-25 gram", 8 },
                    { 243, 92m, "Rokfor peyniri-25 gram", 8 },
                    { 244, 59m, "Saf keçi peyniri-25 gram", 8 },
                    { 245, 101m, "Taze kaşar peyniri-25 gram", 8 },
                    { 246, 89m, "Tulum peyniri-25 gram", 8 },
                    { 247, 71m, "Yörük peyniri-25 gram", 8 },
                    { 248, 1m, "Bıldırcın yumurtası-1 adet", 16 },
                    { 249, 79m, "Yumurta-1 adet", 16 },
                    { 250, 15m, "Yumurta akı-1 adet", 16 },
                    { 251, 66m, "Yumurta sarısı-1 adet", 16 },
                    { 252, 590m, "Antep fıstığı-100 gram", 9 },
                    { 253, 560m, "Ay çekirdeği-100 gram", 9 },
                    { 254, 600m, "Badem-100 gram", 9 },
                    { 255, 650m, "Ceviz-100 gram", 9 },
                    { 256, 640m, "Çam fıstığı-100 gram", 9 },
                    { 257, 630m, "Fındık-100 gram", 9 },
                    { 258, 610m, "Kabak çekirdeği-100 gram", 9 },
                    { 259, 610m, "Kaju fıstığı-100 gram", 9 },
                    { 260, 580m, "Yer fıstığı-100 gram", 9 },
                    { 261, 34m, "Anason tohumu-10 gram", 10 },
                    { 262, 20m, "Çörek otu-10 gram", 10 },
                    { 263, 53m, "Haşhaş tohumu-10 gram", 10 },
                    { 264, 46m, "Keten tohumu-10 gram", 10 },
                    { 265, 44m, "Ayçiçek yağı-1 tatlı kaşığı", 11 },
                    { 266, 44m, "Canola yağı-1 tatlı kaşığı", 11 },
                    { 267, 44m, "Fındık yağı-1 tatlı kaşığı", 11 },
                    { 268, 44m, "Margarin-1 tatlı kaşığı", 11 },
                    { 269, 44m, "Soya yağı-1 tatlı kaşığı", 11 },
                    { 270, 44m, "Susam yağı-1 tatlı kaşığı", 11 },
                    { 271, 44m, "Tereyağı-1 tatlı kaşığı", 11 },
                    { 272, 44m, "Zeytinyağı-1 tatlı kaşığı", 11 },
                    { 273, 1m, "Balzemik sirke-10 gram", 12 },
                    { 274, 5m, "Elma sirkesi-10 gram", 12 },
                    { 275, 7m, "Hardal-10 gram", 12 },
                    { 276, 11m, "Ketçap-10 gram", 12 },
                    { 277, 37m, "Mayonez light-10 gram", 12 },
                    { 278, 8m, "Nar ekşisi sosu-10 gram", 12 },
                    { 279, 52m, "Pesto sos-10 gram", 12 },
                    { 280, 1m, "Pirinç sirkesi-10 gram", 12 },
                    { 281, 7m, "Soya sosu-10 gram", 12 },
                    { 282, 1m, "Üzüm sirkesi-10 gram", 12 },
                    { 283, 30m, "Bamya turşusu-100 gram", 13 },
                    { 284, 14m, "Biber turşusu-100 gram", 13 },
                    { 285, 10m, "Domates turşusu-100 gram", 13 },
                    { 286, 30m, "Fasülye turşusu-100 gram", 13 },
                    { 287, 24m, "Havuç turşusu-100 gram", 13 },
                    { 288, 24m, "Karnıbahar turşusu-100 gram", 13 },
                    { 289, 30m, "Kereviz turşusu-100 gram", 13 },
                    { 290, 10m, "Kuru soğan turşusu-100 gram", 13 },
                    { 291, 10m, "Lahana turşusu-100 gram", 13 },
                    { 292, 10m, "Pancar turşusu-100 gram", 13 },
                    { 293, 10m, "Patlıcan turşusu-100 gram", 13 },
                    { 294, 6m, "Salatalık turşusu-100 gram", 13 },
                    { 295, 10m, "Taze soğan turşusu-100 gram", 13 },
                    { 296, 270m, "Ahududu reçeli-100 gram", 14 },
                    { 297, 320m, "Bal-100 gram", 14 },
                    { 298, 390m, "Beyaz şeker-100 gram", 14 },
                    { 299, 270m, "Böğürtlen reçeli-100 gram", 14 },
                    { 300, 270m, "Çilek reçeli-100 gram", 14 },
                    { 301, 290m, "Dut pekmezi-100 gram", 14 },
                    { 302, 500m, "Esmer şeker-100 gram", 14 },
                    { 303, 620m, "Jöle-100 gram", 14 },
                    { 304, 270m, "İncir reçeli-100 gram", 14 },
                    { 305, 400m, "Kakao-100 gram", 14 },
                    { 306, 270m, "Kayısı reçeli-100 gram", 14 },
                    { 307, 290m, "Keçiboynuzu pekmezi-100 gram", 14 },
                    { 308, 390m, "Pudra şekeri-100 gram", 14 },
                    { 309, 260m, "Şekersiz kızılcık reçeli-100 gram", 14 },
                    { 310, 68m, "Şeftali kompostosu-100 gram", 14 },
                    { 311, 290m, "Üzüm pekmezi-100 gram", 14 },
                    { 312, 250m, "Yaş pasta-100 gram", 14 },
                    { 313, 194m, "Albeni-1 adet", 15 },
                    { 314, 594m, "Biskrem-1 paket (120 gr,)", 15 },
                    { 315, 1163m, "Burger whopper menü-1 menü", 15 },
                    { 316, 124m, "Doritos nacho-1 paket (25 gr,)", 15 },
                    { 317, 231m, "Eti canga-1 adet", 15 },
                    { 318, 289m, "Köfteci Yusuf Köfte-100 gram", 15 },
                    { 319, 548m, "Lays-100 gram", 15 },
                    { 320, 248m, "Magnum Antep fıstıklı-1 adet (75 gr,)", 15 },
                    { 321, 251m, "Magnum bademli-1 adet (76 gr,)", 15 },
                    { 322, 247m, "Magnum double çikolata-1 adet (72,5 gr,)", 15 },
                    { 323, 239m, "Magnum classic-1 adet (77 gr,)", 15 },
                    { 324, 250m, "Magnum tiramisu-1 adet (82 gr,)", 15 },
                    { 325, 900m, "Mc donald’s chicken menü-1 menü", 15 },
                    { 326, 251m, "Pop kek-1 adet", 15 },
                    { 327, 861m, "Pringles-1 kutu", 15 },
                    { 328, 404m, "Sade mısır cipsi-1 paket (orta)", 15 },
                    { 329, 1174m, "Tavuk dünyası bi’köri-1 porsiyon", 15 },
                    { 330, 184m, "Toblerone-1 paket (35 gr,)", 15 },
                    { 331, 507m, "Eti tutku bisküvi-1 paket", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeals_FoodId",
                table: "FoodMeals",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeals_MealId",
                table: "FoodMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMeals");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
