using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Trustme_.Models;
using System.Linq;
using Trustme_.Migrations.Services;

namespace Trustme_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region добавление компаний (api)
            //string url = "https://data.egov.kz/api/v4/gbd_ul/v1?apiKey=11faff5386924009945bb9a1c1f60572&source={\"size\":1000,\"query\":{\"bool\":{\"must\":[{\"match\":{\"nameru\":\"" + "a" + "\"}}]}}}";
            //HttpClient httpClient = new HttpClient();
            //var response = httpClient.GetAsync(url).Result;
            //var content = response.Content.ReadAsStringAsync().Result;
            //var companies = JsonSerializer.Deserialize<List<CompanyOpenDataViewModel>>(content);
            //using (trustmeContext db = new trustmeContext())
            //{
            //    //db.Okeds.Add(new Oked { Id = 1, Name = "" });
            //    //db.SaveChanges();
            //    var companiesList = companies.Select(x => new Company { Id = Guid.NewGuid(), Address = x.addressru, Bin = x.bin, NameRu = x.nameru, OkedId = 1, CityId = 86, RegionId = 18 }).ToList();
            //    foreach (var company in companiesList)
            //    {
            //        db.Companies.Add(company);
            //        db.SaveChanges();
            //    }
            //}
            #endregion
            #region добавление областей
            List<Region> regions = new List<Region>();
            Region ALMATY = new Region { Id = 1, Name = "Город Алматы" };
            Region NURSULTAN = new Region { Id = 2, Name = "Город Нур-Султан" };
            Region SHYMKENT = new Region { Id = 3, Name = "Город Шымкент" };
            Region akm = new Region { Id = 4, Name = "Акмолинская область‎" };
            Region akt = new Region { Id = 5, Name = "Актюбинская область" };
            Region alm = new Region { Id = 6, Name = "Алматинская область‎" };
            Region atu = new Region { Id = 7, Name = "Атырауская область" };
            Region vko = new Region { Id = 8, Name = "Восточно-Казахстанская область‎" };
            Region zham = new Region { Id = 9, Name = "Жамбылская область" };
            Region zko = new Region { Id = 10, Name = "Западно-Казахстанская область‎" };
            Region kar = new Region { Id = 11, Name = "Карагандинская область‎" };
            Region kos = new Region { Id = 12, Name = "Костанайская область‎" };
            Region kuz = new Region { Id = 13, Name = "Кызылординская область‎" };
            Region man = new Region { Id = 14, Name = "Мангистауская область" };
            Region pav = new Region { Id = 15, Name = "Павлодарская область‎" };
            Region sko = new Region { Id = 16, Name = "Северо-Казахстанская область" };
            Region tur = new Region { Id = 17, Name = "Туркестанская область" };
            Region emptyRegion = new Region { Id = 18, Name = "Не определен" };

            regions.AddRange(new Region[] { ALMATY, NURSULTAN, SHYMKENT, akm, akt, alm, atu, vko, zham, zko, kar, kos, kuz, man, pav, sko, tur, emptyRegion });
            using (trustmeContext db = new trustmeContext())
            {
                // добавление в базу областей
                db.Regions.AddRange(regions);
                db.SaveChanges();
            }
            #endregion
            #region добавление в базу городов
            List<City> cities = new List<City>();
            City abai = new City { Id = 1, Name = "Абай", /*Region = kar,*/ RegionId = kar.Id };
            City akkol = new City { Id = 2, Name = "Акколь", /*Region = akm,*/ RegionId = akm.Id };
            City aksai = new City { Id = 3, Name = "Аксай", /*Region = zko,*/ RegionId = zko.Id };
            City aksu = new City { Id = 4, Name = "Аксу", /*Region = pav,*/ RegionId = pav.Id };
            City aktau = new City { Id = 5, Name = "Актау", /*Region = man,*/ RegionId = man.Id };
            City aktobe = new City { Id = 6, Name = "Актобе", /*Region = akt,*/ RegionId = akt.Id };
            City alga = new City { Id = 7, Name = "Алга", /*Region = akt,*/ RegionId = akt.Id };
            //City almaty = new City { Id = 8, Name = "Алматы", /*Region = null,*/ RegionId = 0 };
            City aral = new City { Id = 8, Name = "Арал", /*Region = kuz,*/ RegionId = kuz.Id };
            City arkalyk = new City { Id = 9, Name = "Аркалык", /*Region = kos,*/ RegionId = kos.Id };
            City arys = new City { Id = 10, Name = "Арыс", /*Region = tur,*/ RegionId = tur.Id };
            //City nursultan = new City { Id = 12, Name = "Нур-Султан", /*Region = null,*/ RegionId = 0 };
            City atbasar = new City { Id = 11, Name = "Атбасар", /*Region = akm,*/ RegionId = akm.Id };
            City atyrau = new City { Id = 12, Name = "Атырау", /*Region = atu,*/ RegionId = atu.Id };
            City ayagoz = new City { Id = 13, Name = "Аягоз", /*Region = vko,*/ RegionId = vko.Id };
            City baikonyr = new City { Id = 14, Name = "Байконыр", /*Region = kuz,*/ RegionId = kuz.Id };
            City balkhash = new City { Id = 15, Name = "Балхаш", /*Region = kar,*/ RegionId = kar.Id };
            City bulaevo = new City { Id = 16, Name = "Булаево", /*Region = sko,*/ RegionId = sko.Id };
            City derzhavinsk = new City { Id = 17, Name = "Державинск", /*Region = akm,*/ RegionId = akm.Id };
            City ereimentau = new City { Id = 18, Name = "Ерейментау", /*Region = akm,*/ RegionId = akm.Id };
            City esik = new City { Id = 19, Name = "Есик", /*Region = alm,*/ RegionId = alm.Id };
            City esil = new City { Id = 20, Name = "Есиль", /*Region = akm,*/ RegionId = akm.Id };
            City zhanaozen = new City { Id = 21, Name = "Жанаозен", /*Region = man,*/ RegionId = man.Id };
            City zhanatas = new City { Id = 22, Name = "Жанатас", /*Region = zham,*/ RegionId = zham.Id };
            City zharkent = new City { Id = 23, Name = "Жаркент", /*Region = alm,*/ RegionId = alm.Id };
            City zhezkazgan = new City { Id = 24, Name = "Жезказган", /*Region = kar,*/ RegionId = kar.Id };
            City zhem = new City { Id = 25, Name = "Жем", /*Region = akt,*/ RegionId = akt.Id };
            City zhetysay = new City { Id = 26, Name = "Жетысай", /*Region = tur,*/ RegionId = tur.Id };
            City zhitikara = new City { Id = 27, Name = "Житикара", /*Region = kos,*/ RegionId = kos.Id };
            City zaysan = new City { Id = 28, Name = "Зайсан", /*Region = vko,*/ RegionId = vko.Id };
            City zyryanovsk = new City { Id = 29, Name = "Зыряновск", /*Region = vko,*/ RegionId = vko.Id };
            City kazalinsk = new City { Id = 30, Name = "Казалинск", /*Region = kuz,*/ RegionId = kuz.Id };
            City kandyagash = new City { Id = 31, Name = "Кандыагаш", /*Region = akt,*/ RegionId = akt.Id };
            City kapshagay = new City { Id = 32, Name = "Капшагай", /*Region = alm,*/ RegionId = alm.Id };
            City karaganda = new City { Id = 33, Name = "Караганды", /*Region = kar,*/ RegionId = kar.Id };
            City karazhal = new City { Id = 34, Name = "Каражал", /*Region = kar,*/ RegionId = kar.Id };
            City karatau = new City { Id = 35, Name = "Каратау", /*Region = zham,*/ RegionId = zham.Id };
            City karkaralinsk = new City { Id = 36, Name = "Каркаралинск", /*Region = kar,*/ RegionId = kar.Id };
            City kaskelen = new City { Id = 37, Name = "Каскелен", /*Region = alm,*/ RegionId = alm.Id };
            City kentau = new City { Id = 38, Name = "Кентау", /*Region = tur,*/ RegionId = tur.Id };
            City kokshetau = new City { Id = 39, Name = "Кокшетау", /*Region = akm,*/ RegionId = akm.Id };
            City kostanay = new City { Id = 40, Name = "Костанай", /*Region = kos,*/ RegionId = kos.Id };
            City kulsary = new City { Id = 41, Name = "Кулсары", /*Region = atu,*/ RegionId = atu.Id };
            City kurchatov = new City { Id = 42, Name = "Курчатов", /*Region = vko,*/ RegionId = vko.Id };
            City kyzylorda = new City { Id = 43, Name = "Кызылорда", /*Region = kuz,*/ RegionId = kuz.Id };
            City lenger = new City { Id = 44, Name = "Ленгер", /*Region = tur,*/ RegionId = tur.Id };
            City lisakovsk = new City { Id = 45, Name = "Лисаковск", /*Region = kos,*/ RegionId = kos.Id };
            City makinsk = new City { Id = 46, Name = "Макинск", /*Region = akm,*/ RegionId = akm.Id };
            City mamlyutka = new City { Id = 47, Name = "Мамлютка", /*Region = sko,*/ RegionId = sko.Id };
            City pavlodar = new City { Id = 48, Name = "Павлодар", /*Region = pav,*/ RegionId = pav.Id };
            City petropavlovsk = new City { Id = 49, Name = "Петропавловск", /*Region = sko,*/ RegionId = sko.Id };
            City priozersk = new City { Id = 50, Name = "Приозёрск", /*Region = kar,*/ RegionId = kar.Id };
            City ridder = new City { Id = 51, Name = "Риддер", /*Region = vko,*/ RegionId = vko.Id };
            City rudnui = new City { Id = 52, Name = "Рудный", /*Region = kos,*/ RegionId = kos.Id };
            City saran = new City { Id = 53, Name = "Сарань", /*Region = kar,*/ RegionId = kar.Id };
            City sarkand = new City { Id = 54, Name = "Сарканд", /*Region = alm,*/ RegionId = alm.Id };
            City saryagash = new City { Id = 55, Name = "Сарыагаш", /*Region = tur,*/ RegionId = tur.Id };
            City satpayev = new City { Id = 56, Name = "Сатпаев", /*Region = kar,*/ RegionId = kar.Id };
            City semey = new City { Id = 57, Name = "Семей", /*Region = vko,*/ RegionId = vko.Id };
            City sergeevka = new City { Id = 58, Name = "Сергеевка", /*Region = sko,*/ RegionId = sko.Id };
            City serebryansk = new City { Id = 59, Name = "Серебрянск", /*Region = vko,*/ RegionId = vko.Id };
            City stepnogorsk = new City { Id = 60, Name = "Степногорск", /*Region = akm,*/ RegionId = akm.Id };
            City stepnyak = new City { Id = 61, Name = "Степняк", /*Region = akm,*/ RegionId = akm.Id };
            City taiynsha = new City { Id = 62, Name = "Тайынша", /*Region = sko,*/ RegionId = sko.Id };
            City talgar = new City { Id = 63, Name = "Талгар", /*Region = alm,*/ RegionId = alm.Id };
            City taldykorgan = new City { Id = 64, Name = "Талдыкорган", /*Region = alm,*/ RegionId = alm.Id };
            City taraz = new City { Id = 65, Name = "Тараз", /*Region = zham,*/ RegionId = zham.Id };
            City tekeli = new City { Id = 66, Name = "Текели", /*Region = alm,*/ RegionId = alm.Id };
            City temir = new City { Id = 67, Name = "Темир", /*Region = akt,*/ RegionId = akt.Id };
            City temirtau = new City { Id = 68, Name = "Темиртау", /*Region = kar,*/ RegionId = kar.Id };
            City tobyl = new City { Id = 69, Name = "Тобыл", /*Region = kos,*/ RegionId = kos.Id };
            City turkestan = new City { Id = 70, Name = "Туркестан", /*Region = tur,*/ RegionId = tur.Id };
            City uralsk = new City { Id = 71, Name = "Уральск", /*Region = zko,*/ RegionId = zko.Id };
            City ustKamenogorsk = new City { Id = 72, Name = "Усть-Каменогорск", /*Region = vko,*/ RegionId = vko.Id };
            City usharal = new City { Id = 73, Name = "Ушарал", /*Region = alm,*/ RegionId = alm.Id };
            City ushtobe = new City { Id = 74, Name = "Уштобе", /*Region = alm,*/ RegionId = alm.Id };
            City fortShevchenko = new City { Id = 75, Name = "Форт-Шевченко", /*Region = man,*/ RegionId = man.Id };
            City khromtau = new City { Id = 76, Name = "Хромтау", /*Region = akt,*/ RegionId = akt.Id };
            City shardara = new City { Id = 77, Name = "Шардара", /*Region = tur,*/ RegionId = tur.Id };
            City shalkar = new City { Id = 78, Name = "Шалкар", /*Region = akt,*/ RegionId = akt.Id };
            City shar = new City { Id = 79, Name = "Шар", /*Region = vko,*/ RegionId = vko.Id };
            City shakhtinsk = new City { Id = 80, Name = "Шахтинск", /*Region = kar,*/ RegionId = kar.Id };
            City shemonaikha = new City { Id = 81, Name = "Шемонаиха", /*Region = vko,*/ RegionId = vko.Id };
            City shu = new City { Id = 82, Name = "Шу", /*Region = zham,*/ RegionId = zham.Id };
            //City shymkent = new City { Id = 85, Name = "Шымкент", /*Region = null,*/ RegionId = 0 };
            City shchuchinsk = new City { Id = 83, Name = "Щучинск", /*Region = akm,*/ RegionId = akm.Id };
            City ekibastuz = new City { Id = 84, Name = "Экибастуз", /*Region = pav,*/ RegionId = pav.Id };
            City emba = new City { Id = 85, Name = "Эмба", /*Region = akt,*/ RegionId = akt.Id };
            City emptyCity = new City { Id = 86, Name = "Не определен", /*Region = akt,*/ RegionId = emptyRegion.Id };
            cities.AddRange(new City[] { abai, akkol, aksai, aksu, aktau, aktobe, alga, aral, arkalyk, arys, atbasar, atyrau, ayagoz, baikonyr, balkhash, bulaevo, derzhavinsk, ereimentau, esik, esil, zhanaozen, zhanatas, zharkent, zhezkazgan, zhem, zhetysay, zhitikara, zaysan, zyryanovsk, kazalinsk, kandyagash, kapshagay, karaganda, karazhal, karatau, karkaralinsk, kaskelen, kentau, kokshetau, kostanay, kulsary, kurchatov, kyzylorda, lenger, lisakovsk, makinsk, mamlyutka, pavlodar, petropavlovsk, priozersk, ridder, rudnui, saran, sarkand, saryagash, satpayev, semey, sergeevka, serebryansk, stepnogorsk, stepnyak, taiynsha, talgar, taldykorgan, taraz, tekeli, temir, temirtau, tobyl, turkestan, uralsk, ustKamenogorsk, usharal, ushtobe, fortShevchenko, khromtau, shardara, shalkar, shar, shakhtinsk, shemonaikha, shu, shchuchinsk, ekibastuz, emba, emptyCity });
            using (trustmeContext db = new trustmeContext())
            {
                foreach (var item in cities)
                {
                    db.Cities.Add(item);
                    db.SaveChanges();
                }
            }
            #endregion
            ParseManager parsing = new ParseManager();
            Console.WriteLine("ГОТОВО");
            Console.ReadKey();
        }
    }
}
