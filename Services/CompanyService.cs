using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Trustme_.Models;

namespace Trustme_.Services
{
    public class CompanyService
    {
        public static List<CompanyOpenDataViewModel> SearchCompanyOpenData(string search)
        {
            string url = "https://data.egov.kz/api/v4/gbd_ul/v1?apiKey=11faff5386924009945bb9a1c1f60572&source={\"size\":100,\"query\":{\"bool\":{\"must\":[{\"match\":{\"nameru\":\"" + search + "\"}}]}}}";
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<CompanyOpenDataViewModel>>(content);
        }
        public static List<CompanyOpenDataViewModel> SearchCompanyOpenDataParse(int skip)
        {
            if (skip != 0)
            {
                skip = skip * 10000;
            }
            string url = "https://data.egov.kz/api/v4/gbd_ul/v1?apiKey=11faff5386924009945bb9a1c1f60572&source={\"size\":10000,\"from\":" + skip + "}";
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<CompanyOpenDataViewModel>>(content);
        }
    }
}
