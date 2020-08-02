using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Agronomous.Core;
using Agronomous.Data;
using Agronomous.Database;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class createGardenModel : PageModel
    {
        [BindProperty]
        public string searchTerm { get; set; }
        public plant searchedPlant;
        private readonly ApplicationDbContext db;
        private readonly IPlantData plants;
        public createGardenModel(ApplicationDbContext db, IPlantData plants)
        {
            this.db = db;
            this.plants = plants;
        }
        public void OnGet()
        {
            Console.WriteLine(db.Users.FirstOrDefault(r => r.UserName == User.Identity.Name).plantGuid);
        }
        public void OnPost()
        {
            plant plant = new plant();
            HtmlDocument htmlDocument = scrape("https://www.almanac.com/search/site/growing%2520" + searchTerm);
            List<HtmlNode> searchTerms = htmlDocument.DocumentNode.Descendants("a").Where(r => r.GetAttributeValue("href", "").Contains("https://www.almanac.com/plant")).ToList();
            string plantUrl = searchTerms[0].OuterHtml.Split("\"")[1];
            HtmlDocument htmlResult = scrape(plantUrl);
            List<HtmlNode> plantTable = htmlResult.DocumentNode.Descendants("table").Where(r => r.GetAttributeValue("class", "").Contains("views-table")).ToList();
            List<string> plantDataPairs = plantTable[0].InnerText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Where(r => !string.IsNullOrWhiteSpace(r)).Cast<string>().ToList();
            plant.botanicalName = plantDataPairs[1];
            plant.PlantType = plantDataPairs[3];
            plant.SunExposure = plantDataPairs[5];
            plant.SoilType = plantDataPairs[7];
            plant.SoilPh = plantDataPairs[9];
            plant.BloomTime = plantDataPairs[11];
            plant.FlowerColor = plantDataPairs[13];
            plant.HardinessZones = plantDataPairs[15];
            searchedPlant = plant;
        }

        private HtmlDocument scrape(string term)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Agronomous");
            var html = httpClient.GetStringAsync(term);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html.Result);
            return htmlDoc;
        }
    }
}