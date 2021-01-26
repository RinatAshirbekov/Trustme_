using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trustme_.Models;

namespace Trustme_.Services
{
    class ParsingManager
    {
        public ParsingManager()
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
                Guid uuidCompany = companies[i].Id;
                string[] fullAddressArray = companies[i].Address.Split(",");
                string[] shortAddresArray = null;
                if (fullAddressArray.Length == 1) // нет адреса
                {
                    Console.WriteLine("не найден №" + i);
                    AddRegionAndCityIdZero(uuidCompany, trustmeContext);
                }
                else // есть адрес
                {
                    shortAddresArray = GetShortAddress(fullAddressArray);
                    if (shortAddresArray[0] == "Не указан регион")
                        AddRegionAndCityIdZero(uuidCompany, trustmeContext);
                    else
                    {
                        Console.WriteLine("№" + i);
                        AddRegionAndCityId(uuidCompany, shortAddresArray, trustmeContext);
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
                    if (shortAddress[1] == "Шымкент") // если городом оказался Шымкент, то ему нужно присвоить RegionId
                    {
                        shortAddress = new string[2];
                        shortAddress[0] = RegionParser(fullAddressArray[1]); // меняем на слово "Город Шымкент"
                    }
                    else if (shortAddress[1] != "Район") // если город
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
                        else if (shortAddress[2] == "Шымкент") // если городом оказался Шымкент, то ему нужно присвоить RegionId
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
            if (region.Contains("Г.") || region.Contains("г.") || region.Contains("ГОРОД") || region.Contains("Город") || region.Contains("город") || region.Contains("Г ") || region.Contains("г "))
            {
                // корректировка города Алматы
                if (region.ToLower().Contains("алматы") || region.ToLower().Contains("алма-ата"))
                    region = "Город Алматы";

                // корректировка города Нур-Султан
                if (region.ToLower().Contains("астана") || region.ToLower().Contains("нур-султан"))
                    region = "Город Нур-Султан";

                // корректировка города Шымкент
                if (region.ToLower().Contains("шымкент"))
                    region = "Город Шымкент";
            }
            else if (region.Contains("ОБЛАСТЬ") || region.Contains("Область") || region.Contains("область") || region.Contains("ОБЛ ") || region.Contains("Обл ") || region.Contains("обл ") || region.Contains("ОБЛ.") || region.Contains("Обл.") || region.Contains("обл."))
            {
                // корректировка слова область
                region = region.Replace("ОБЛАСТЬ", "область");
                region = region.Replace("Область", "область");
                region = region.Replace("ОБЛ ", "область");
                region = region.Replace("Обл ", "область");
                region = region.Replace("обл ", "область");
                region = region.Replace("ОБЛ.", "область");
                region = region.Replace("Обл.", "область");
                region = region.Replace("обл.", "область");

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
            if (region.ToLower().Contains("восточно"))
                region = "Восточно-Казахстанская область";
            if (region.ToLower().Contains("западно"))
                region = "Западно-Казахстанская область";
            if (region.ToLower().Contains("северо"))
                region = "Северо-Казахстанская область";
            if (region.ToLower().Contains("южно"))
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
        private void AddRegionAndCityId(Guid uuidCompany, string[] address, trustmeContext context)
        {
            var currentCompany = context.Companies.FirstOrDefault(c => c.Id == uuidCompany);
            try
            {
                if (address.Length < 3) // только область
                {
                    currentCompany.RegionId = context.Regions.FirstOrDefault(r => r.Name == address[0]).Id;
                    currentCompany.CityId = 86;
                    context.SaveChanges();
                }
                else // область и город/район
                {
                    if (address[1] != "Район") // область и город
                    {
                        Console.WriteLine("address[0]" + address[0]);
                        Console.WriteLine("address[1]" + address[address.Length - 1]);
                        foreach (var region in context.Regions.OrderBy(r => r.Id)) Console.WriteLine(region.Name);
                        currentCompany.RegionId = context.Regions.FirstOrDefault(r => r.Name == address[0]).Id;
                        currentCompany.CityId = FindCityId(address[1], context);
                        context.SaveChanges();
                    }
                    else // область и район
                    {
                        currentCompany.RegionId = context.Regions.FirstOrDefault(r => r.Name == address[0]).Id;
                        currentCompany.CityId = 86;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private int FindCityId(string verifiableCity, trustmeContext context)
        {
            Console.WriteLine("ищем айди города: " + verifiableCity);
            if (context.Cities.FirstOrDefault(c => c.Name.ToLower().Contains(verifiableCity.ToLower())) != null)
                return context.Cities.FirstOrDefault(c => c.Name == verifiableCity).Id;
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
        private void AddRegionAndCityIdZero(Guid idCompany, trustmeContext context)
        {
            var currentCompany = context.Companies.FirstOrDefault(c => c.Id == idCompany);
            currentCompany.RegionId = 18;
            currentCompany.CityId = 86;
            context.SaveChanges();
        }
        private void GetRegionsAndCitiesNames(trustmeContext context)
        {
            Console.WriteLine("Регионы: ");
            foreach (var region in context.Regions.OrderBy(r => r.Id))
                Console.WriteLine(region.Name);
            Console.WriteLine("\nГорода: ");
            foreach (var city in context.Cities.OrderBy(r => r.Id))
                Console.WriteLine(city.Name);
        }
        public List<Company> GetCompanies()
        {
            using (trustmeContext db = new trustmeContext())
            {
                return db.Companies.Select(x => new Company { Id = x.Id, Address = x.Address, NameRu = x.NameRu, Bin = x.Bin }).ToList();
            }
        }
    }
}
