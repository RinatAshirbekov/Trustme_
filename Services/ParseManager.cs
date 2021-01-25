using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Trustme_.Models;

namespace Trustme_.Migrations.Services
{
    public class ParseManager
    {
        public ParseManager()
        {
            var companies = GetCompanies();
            trustmeContext datacontext = new trustmeContext();
            //GetRegionsAndCitiesNames(datacontext);
            ParseAddress(companies, datacontext);
        }
        private void ParseAddress(List<Company> companies, trustmeContext trustmeContext)
        {
            for (int i = 0; i < companies.Count; i++)
            {
     
                string nameCompany = companies[i].NameRu;
                if(i == 11200)
                    Console.WriteLine("GO");
                if (i == 11520) 
                    Console.WriteLine("GO");
                string[] fullAddressArray = companies[i].Address.Split(",");
                string[] shortAddresArray = null;
              
                if (fullAddressArray.Length == 1) // нет адреса
                {
                    Console.WriteLine("не найден №" + i);
                    AddRegionAndCityIdZero(nameCompany, trustmeContext);
                }
                else // есть адрес
                {
                    shortAddresArray = GetShortAddress(fullAddressArray);
                    shortAddresArray[shortAddresArray.Length - 1] = companies[i].Address;
                    if(shortAddresArray[0] == "Не указан регион")
                        AddRegionAndCityIdZero(nameCompany, trustmeContext);
                    else
                    {
                        Console.WriteLine("№" + i);
                        AddRegionAndCityId(companies[i].Id, shortAddresArray[0],shortAddresArray[1], trustmeContext);
                    }
                }
            }
        }
        private string[] GetShortAddress(string[] fullAddressArray)
        {
            string[] shortAddress = null;
            string address = null;
            if (string.IsNullOrEmpty(fullAddressArray[1]) || fullAddressArray[1] == " ") // если после индекса пустая строчка, удаляем первый элемент
            {
                string[] changedAddressArray = new string[fullAddressArray.Length - 1];
                for (int i = 0; i < changedAddressArray.Length; i++)
                    changedAddressArray[i] = fullAddressArray[i + 1];
                shortAddress = GetShortAddress(changedAddressArray);
            }
            else
            {
                address = RegionParser(fullAddressArray[1]);
                if (address.Contains("Город"))
                {
                    shortAddress = new string[2];
                    shortAddress[0] = RegionParser(fullAddressArray[1]);
                }
                else if (address.Contains("область"))
                {
                    shortAddress = new string[4];
                    shortAddress[0] = RegionParser(fullAddressArray[1]); // Область
                    shortAddress[1] = CityParser(fullAddressArray[2]); // Район/Город
                    if(shortAddress[1] == "Шымкент") // если городом оказался Шымкент, то ему нужно присвоить RegionId
                    {
                        shortAddress = new string[2];
                        shortAddress[0] = RegionParser(fullAddressArray[1]); // меняем на слово "Город Шымкент"
                    }
                    else if(shortAddress[1] != "Район") // если город
                    {
                        shortAddress[2] = "Улица";
                    }
                    else // если район
                    {
                        shortAddress[2] = CityParser(fullAddressArray[3]);
                        if (shortAddress[2] == "Район") // если район
                        {
                            shortAddress[1] = "Район";
                            shortAddress[2] = "Село";
                        }
                        else if(shortAddress[2] == "Шымкент") // если городом оказался Шымкент, то ему нужно присвоить RegionId
                        {
                            shortAddress = new string[2];
                            shortAddress[0] = RegionParser(fullAddressArray[1]); // меняем на слово "Город Шымкент"
                        }
                        else // если город
                        {
                            shortAddress[1] = CityParser(fullAddressArray[3]);
                            shortAddress[2] = "Улица";
                        }
                    }
                    #region старый вариант
                    //if (shortAddress[1] == "Шымкент")
                    //{
                    //    shortAddress = new string[2];
                    //    shortAddress[0] = "Город Шымкент";
                    //}
                    //else if (shortAddress[1] != "район")
                    //{
                    //    shortAddress[2] = "улица";
                    //}
                    //else
                    //{
                    //    shortAddress[2] = CityParser(fullAddressArray[3]);
                    //    if (shortAddress[2] == "район")
                    //    {
                    //        shortAddress[1] = "район";
                    //        shortAddress[2] = "село";
                    //    }
                    //    else
                    //    {
                    //        shortAddress[1] = CityParser(fullAddressArray[3]);
                    //        if (shortAddress[1] == "Шымкент")
                    //        {
                    //            shortAddress = new string[2];
                    //            shortAddress[0] = "Город Шымкент";
                    //        }
                    //        else
                    //        {
                    //            shortAddress[1] = CityParser(fullAddressArray[3]);
                    //            shortAddress[2] = "улица";
                    //        }
                    //    }
                    //}
                    #endregion
                }
                else // если не указан ни город, ни область
                {
                    shortAddress = new string[2];
                    shortAddress[0] = "Не указан регион";
                }
            }
            return shortAddress;
        }
        private string RegionParser(string region)
        {
            region = region.Trim();
            // корректировка слова Город
            if (region.Contains("Г.") || region.Contains("г.") || region.Contains("ГОРОД") || region.Contains("Город") || region.Contains("город"))
            {
                region = region.Replace("Г.", "Город ").Replace("  ", " ").Trim();
                region = region.Replace("г.", "Город ").Replace("  ", " ").Trim();
                region = region.Replace("город", "Город ").Replace("  ", " ").Trim();
                region = region.Replace("ГОРОД", "Город ").Replace("  ", " ").Trim();

                // корректировка города Алматы
                if (region.Contains("АЛМАТЫ") || region.Contains("Алматы") || region.Contains("aлматы"))
                    region = "Город Алматы";

                // корректировка города Нур-Султан
                if (region.Contains("АСТАНА") || region.Contains("НУР-СУЛТАН") || region.Contains("Астана"))
                    region = "Город Нур-Султан";

                // корректировка города Шымкент
                if (region.Contains("ШЫМКЕНТ") || region.Contains("Шымкенты") || region.Contains("шымкент"))
                    region = "Город Шымкент";
            }
            else if(region.Contains("ОБЛАСТЬ") || region.Contains("Область") || region.Contains("область"))
            {
                // корректировка слова область
                region = region.Replace("ОБЛАСТЬ", "область");
                region = region.Replace("Область", "область");

                // корректировка положения слова область
                if (region.IndexOf("область") == 0)
                {
                    region = region.Remove(0, 8);
                    region = region.Insert(region.Length, " область");
                }

                // корректировка регистра областей
                char[] addressArr = region.ToCharArray();
                for (int i = 0; i < addressArr.Length; i++)
                {
                    if (i == 0)
                        addressArr[i] = char.ToUpper(addressArr[i]);
                    else
                        addressArr[i] = char.ToLower(addressArr[i]);
                }
                region = String.Concat<char>(addressArr);
            }
            if (region == "Шымкент")
                region = "Город Шымкент";
            if (region.Contains("Восточно"))
                region = "Восточно-Казахстанская область";
            if (region.Contains("Западно"))
                region = "Западно-Казахстанская область";
            if (region.Contains("Северо"))
                region = "Северо-Казахстанская область";
            if (region.Contains("Южно"))
                region = "Туркестанская область";
            return region;
        }
        private string CityParser(string city)
        {
            city = city.Trim();
            if (city.Contains("Г.") || city.Contains("г.") || city.Contains("ГОРОД") || city.Contains("Город") || city.Contains("город")) // если город возвращаем название города
            {
                // корректировка слова город
                city = city.Replace("Г.", "");
                city = city.Replace("г.", "");
                city = city.Replace("ГОРОД", "");
                city = city.Replace("Город", "");
                city = city.Replace("город", "");
                city = city.Trim();
                // корректировка регистра
                char[] cityArr = city.ToCharArray();
                for (int i = 0; i < city.Length; i++)
                {
                    if (i == 0)
                        cityArr[i] = char.ToUpper(cityArr[i]);
                    else
                        cityArr[i] = char.ToLower(cityArr[i]);
                }
                city = String.Concat<char>(cityArr);
                if (city.Contains("Усть-каменогорск")) city = "Усть-Каменогорск";
                if (city.Contains("Форт-шевченко")) city = "Форт-Шевченко";
                if (city.Contains("Караганда")) city = "Караганды";
            }
            else // если район возвращаем слово "Район"
            {
                city = "Район";
            }
            return city;
        }
        private void AddRegionAndCityId(Guid companyid,string region,string city, trustmeContext context)
        {
            try
            {
                if (region.Length < 3) // только область
                {
                    var company = context.Companies.FirstOrDefault(c => c.Id == companyid);
                    var regionrecord = context.Regions.FirstOrDefault(r => r.Name == region);
                    if (regionrecord != null) 
                    {
                        company.CityId = 86;
                        context.SaveChanges();
                    }

                   
                }
                else // область и город/район
                {
                    if (city != "Район") // область и город
                    {
                        var company = context.Companies.FirstOrDefault(c => c.Id == companyid);
                        var regionrecord = context.Regions.FirstOrDefault(r => r.Name == region);
                        if (regionrecord != null)
                        {
                            company.CityId = FindCityId(city, context);
                            context.SaveChanges();
                        }
                        else {
                            Console.WriteLine("регион не найден = " + region);
                        }
                 
                    }
                    else // область и район
                    {
                        var company = context.Companies.FirstOrDefault(c => c.Id == companyid);
                        var regionrecord = context.Regions.FirstOrDefault(r => r.Name == region);
                        if (regionrecord != null)
                        {
                            company.CityId = 86;
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("регион не найден = " + region);
                        }
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            
        }
        private int FindCityId(string verifiableCity, trustmeContext context)
        {
            if (context.Cities.FirstOrDefault(c => c.Name == verifiableCity) != null)
            {
                return context.Cities.FirstOrDefault(c => c.Name == verifiableCity).Id;
            }
            else
            {
                if (verifiableCity == "Ақкөл")
                    return context.Cities.FirstOrDefault(c => c.Name == "Акколь").Id;
                else if (verifiableCity == "Ақсай")
                    return context.Cities.FirstOrDefault(c => c.Name == "Аксай").Id;
                else if (verifiableCity == "Ақсу")
                    return context.Cities.FirstOrDefault(c => c.Name == "Аксу").Id;
                else if (verifiableCity == "Ақтау")
                    return context.Cities.FirstOrDefault(c => c.Name == "Актау").Id;
                else if (verifiableCity == "Ақтөбе")
                    return context.Cities.FirstOrDefault(c => c.Name == "Актобе").Id;
                else if (verifiableCity == "Алға")
                    return context.Cities.FirstOrDefault(c => c.Name == "Алга").Id;
                else if (verifiableCity == "Арқалық")
                    return context.Cities.FirstOrDefault(c => c.Name == "Аркалык").Id;
                else if (verifiableCity == "Аягөз")
                    return context.Cities.FirstOrDefault(c => c.Name == "Аягоз").Id;
                else if (verifiableCity == "Байқоңыр")
                    return context.Cities.FirstOrDefault(c => c.Name == "Байконыр").Id;
                else if (verifiableCity == "Балқаш")
                    return context.Cities.FirstOrDefault(c => c.Name == "Балхаш").Id;
                else if (verifiableCity == "Булаев")
                    return context.Cities.FirstOrDefault(c => c.Name == "Булаево").Id;
                else if (verifiableCity == "Державин")
                    return context.Cities.FirstOrDefault(c => c.Name == "Державинск").Id;
                else if (verifiableCity == "Есік")
                    return context.Cities.FirstOrDefault(c => c.Name == "Есик").Id;
                else if (verifiableCity == "Есіл")
                    return context.Cities.FirstOrDefault(c => c.Name == "Есиль").Id;
                else if (verifiableCity == "Жаңаөзен")
                    return context.Cities.FirstOrDefault(c => c.Name == "Жанаозен").Id;
                else if (verifiableCity == "Жаңатас")
                    return context.Cities.FirstOrDefault(c => c.Name == "Жанатас").Id;
                else if (verifiableCity == "Жезқазған")
                    return context.Cities.FirstOrDefault(c => c.Name == "Жезказган").Id;
                else if (verifiableCity == "Жетісай")
                    return context.Cities.FirstOrDefault(c => c.Name == "Жетысай").Id;
                else if (verifiableCity == "Жітіқара")
                    return context.Cities.FirstOrDefault(c => c.Name == "Житикара").Id;
                else if (verifiableCity == "Зайсаң")
                    return context.Cities.FirstOrDefault(c => c.Name == "Зайсан").Id;
                else if (verifiableCity == "Қазалы")
                    return context.Cities.FirstOrDefault(c => c.Name == "Казалинск").Id;
                else if (verifiableCity == "Қандыағаш")
                    return context.Cities.FirstOrDefault(c => c.Name == "Кандыагаш").Id;
                else if (verifiableCity == "Қапшағай")
                    return context.Cities.FirstOrDefault(c => c.Name == "Капшагай").Id;
                else if (verifiableCity == "Қарағанды")
                    return context.Cities.FirstOrDefault(c => c.Name == "Караганды").Id;
                else if (verifiableCity == "Қаражал")
                    return context.Cities.FirstOrDefault(c => c.Name == "Каражал").Id;
                else if (verifiableCity == "Қаратау")
                    return context.Cities.FirstOrDefault(c => c.Name == "Каратау").Id;
                else if (verifiableCity == "Қарқаралы")
                    return context.Cities.FirstOrDefault(c => c.Name == "Каркаралинск").Id;
                else if (verifiableCity == "Қаскелең")
                    return context.Cities.FirstOrDefault(c => c.Name == "Каскелен").Id;
                else if (verifiableCity == "Көкшетау")
                    return context.Cities.FirstOrDefault(c => c.Name == "Кокшетау").Id;
                else if (verifiableCity == "Қостанай")
                    return context.Cities.FirstOrDefault(c => c.Name == "Костанай").Id;
                else if (verifiableCity == "Құлсары")
                    return context.Cities.FirstOrDefault(c => c.Name == "Кулсары").Id;
                else if (verifiableCity == "Қызылорда")
                    return context.Cities.FirstOrDefault(c => c.Name == "Кызылорда").Id;
                else if (verifiableCity == "Леңгір")
                    return context.Cities.FirstOrDefault(c => c.Name == "Ленгер").Id;
                else if (verifiableCity == "Мамлют")
                    return context.Cities.FirstOrDefault(c => c.Name == "Мамлютка").Id;
                else if (verifiableCity == "Петропавл")
                    return context.Cities.FirstOrDefault(c => c.Name == "Петропавловск").Id;
                else if (verifiableCity == "Приозер")
                    return context.Cities.FirstOrDefault(c => c.Name == "Приозёрск").Id;
                else if (verifiableCity == "Саран")
                    return context.Cities.FirstOrDefault(c => c.Name == "Сарань").Id;
                else if (verifiableCity == "Сарқант")
                    return context.Cities.FirstOrDefault(c => c.Name == "Сарканд").Id;
                else if (verifiableCity == "Сарыағаш")
                    return context.Cities.FirstOrDefault(c => c.Name == "Сарыагаш").Id;
                else if (verifiableCity == "Сәтбаев")
                    return context.Cities.FirstOrDefault(c => c.Name == "Сатпаев").Id;
                else if (verifiableCity == "Сергеев")
                    return context.Cities.FirstOrDefault(c => c.Name == "Сергеевка").Id;
                else if (verifiableCity == "Талғар")
                    return context.Cities.FirstOrDefault(c => c.Name == "Талгар").Id;
                else if (verifiableCity == "Талдықорған")
                    return context.Cities.FirstOrDefault(c => c.Name == "Талдыкорган").Id;
                else if (verifiableCity == "Текелі")
                    return context.Cities.FirstOrDefault(c => c.Name == "Текели").Id;
                else if (verifiableCity == "Темір")
                    return context.Cities.FirstOrDefault(c => c.Name == "Темир").Id;
                else if (verifiableCity == "Теміртау")
                    return context.Cities.FirstOrDefault(c => c.Name == "Темиртау").Id;
                else if (verifiableCity == "Түркістан")
                    return context.Cities.FirstOrDefault(c => c.Name == "Туркестан").Id;
                else if (verifiableCity == "Орал")
                    return context.Cities.FirstOrDefault(c => c.Name == "Уральск").Id;
                else if (verifiableCity == "Өскемен")
                    return context.Cities.FirstOrDefault(c => c.Name == "Усть-Каменогорск").Id;
                else if (verifiableCity == "Үшарал")
                    return context.Cities.FirstOrDefault(c => c.Name == "Ушарал").Id;
                else if (verifiableCity == "Үштөбе")
                    return context.Cities.FirstOrDefault(c => c.Name == "Уштобе").Id;
                else if (verifiableCity == "Шалқар")
                    return context.Cities.FirstOrDefault(c => c.Name == "Шалкар").Id;
                else if (verifiableCity == "Екібастұз")
                    return context.Cities.FirstOrDefault(c => c.Name == "Экибастуз").Id;
                else if (verifiableCity == "Ембі")
                    return context.Cities.FirstOrDefault(c => c.Name == "Эмба").Id;
                else
                    return 86;
            }
        }
        private void AddRegionAndCityIdZero(string company, trustmeContext context)
        {
            context.Companies.FirstOrDefault(c => c.NameRu == company).RegionId = 18;
            context.Companies.FirstOrDefault(c => c.NameRu == company).CityId = 86;
            // TODO: какое значение поставить
            context.SaveChanges();
        }
        private void GetRegionsAndCitiesNames(trustmeContext context) 
        {
            Console.WriteLine("Регионы: ");
            foreach (var region in context.Regions.OrderBy(r=>r.Id))
                Console.WriteLine(region.Name);
            Console.WriteLine("\nГорода: ");
            foreach (var city in context.Cities.OrderBy(r=>r.Id)) 
                Console.WriteLine(city.Name);
        }
        public List<Company> GetCompanies()
        {
            using (trustmeContext db = new trustmeContext())
            {
                return db.Companies.Where(c=>c.RegionId > 0).Select(x => new Company { Id = x.Id, Address = x.Address, NameRu = x.NameRu, Bin = x.Bin }).ToList();
            }
        }
    }
}
#region в базу не правильно сажает айди
// 17c474f9-6593-4361-9131-88a46b8d5fc5
// 238fd3a4-def8-49e4-99e6-df8bcf18ab17
// 7fb0f523-d0a3-4ba9-8900-be879cc5b298
// 80c3e87c-ad99-4b32-9916-23122986cd65
// 59cd51ad-4bcc-4a3d-b086-1a48b6b567a1
#endregion
#region GetShortAddress() старый
//private string[] GetShortAddress(string[] fullAddressArray)
//{
//    string[] shortAddress = null;
//    if (string.IsNullOrEmpty(fullAddressArray[1]) || fullAddressArray[1] == " ") // если после индекса пустая строчка, удаляем первый элемент
//    {
//        string[] changedAddressArray = new string[fullAddressArray.Length - 1];
//        for (int i = 0; i < changedAddressArray.Length; i++)
//            changedAddressArray[i] = fullAddressArray[i + 1];
//        shortAddress = GetShortAddress(changedAddressArray);
//    }
//    else
//    {
//        if (fullAddressArray[1].Contains("ОБЛАСТЬ") || fullAddressArray[1].Contains("Область"))
//        {
//            fullAddressArray[1] = fullAddressArray[1].Replace("ОБЛАСТЬ", "область");
//            fullAddressArray[1] = fullAddressArray[1].Replace("Область", "область");
//        }
//        if (fullAddressArray[1].Contains("область"))
//        {
//            shortAddress = new string[4];
//            shortAddress[0] = RegionParser(fullAddressArray[1]);
//            shortAddress[1] = CityParser(fullAddressArray[2]); // район
//            if (shortAddress[1] == "Шымкент")
//            {
//                shortAddress = new string[2];
//                shortAddress[0] = "Город Шымкент";
//            }
//            else if (shortAddress[1] != "район")
//            {
//                shortAddress[2] = "улица";
//            }
//            else
//            {
//                shortAddress[2] = CityParser(fullAddressArray[3]);
//                if (shortAddress[2] == "район")
//                {
//                    shortAddress[1] = "район";
//                    shortAddress[2] = "село";
//                }
//                else
//                {
//                    shortAddress[1] = CityParser(fullAddressArray[3]);
//                    if (shortAddress[1] == "Шымкент")
//                    {
//                        shortAddress = new string[2];
//                        shortAddress[0] = "Город Шымкент";
//                    }
//                    else
//                    {
//                        shortAddress[1] = CityParser(fullAddressArray[3]);
//                        shortAddress[2] = "улица";
//                    }
//                }
//            }
//        }
//        else if (fullAddressArray[1].Contains("Г.") || fullAddressArray[1].Contains("г.") || fullAddressArray[1].Contains("ГОРОД") || fullAddressArray[1].Contains("Город") || fullAddressArray[1].Contains("город"))
//        {
//            shortAddress = new string[2];
//            shortAddress[0] = RegionParser(fullAddressArray[1]);
//        }
//        else
//        {
//            shortAddress = new string[2];
//            shortAddress[0] = "не указан регион";
//        }
//    }
//    return shortAddress;
//}
#endregion