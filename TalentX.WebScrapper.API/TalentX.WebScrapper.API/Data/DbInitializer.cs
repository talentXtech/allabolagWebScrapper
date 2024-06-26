using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using TalentX.WebScrapper.API.Entities;

namespace TalentX.WebScrapper.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {

            if (context.InitialScrapOutputData.Any()) return;

            var testData1 = new InitialScrapOutputData
            {
                Title = "test",
                Url = "testUrl"

            };

            context.InitialScrapOutputData.Add(testData1);
            context.SaveChanges();

            if (context.DetailedScrapOutputData.Any()) return;

            var testData = new DetailedScrapOutputData
            {
                CompanyName = "test",
                AllabolagUrl = "testUrl",
                OrgNo = "test",
                CEO = "test",
                Address = "test",
                Location = "test",
                YearOfEstablishment = "test",
                Revenue = "test",
                EmployeeNames = "test,test"
            };

            context.DetailedScrapOutputData.Add(testData);
            context.SaveChanges();

            if (context.LayOffScrapInfo.Any()) return;

            var testData2 = new LayOffScrapInfo
            {
                elementName = "text",
                numberText = "1",
                CompanyName = "companyNameElement",
                LocationHQ = "location",
                LaidOff = "laidOff",
                Date = "date",
                Percentage = "percentage",
                Industry = "industry",
                SourceUrl = "source",
                listOfLaidOffEmployeesUrl = "employees",
                Stage = "stage",
                Raised = "raised",
                Country = "country",
                DateAdded = "dateAdded"
            };

            context.LayOffScrapInfo.Add(testData2);
            context.SaveChanges();

            if (context.SiftedFinalScrapInfo.Any()) return;

            var testData3 = new SiftedFinalScrapInfo
            {
                Sector = "test",
                Sectorurl = "test",
                ContentType = "test",
                Date = "test",
                Subject = "test",
                Summary = "test",
                articleUrl = "test",
                Tags = "test"
            };

            context.SiftedFinalScrapInfo.Add(testData3);
            context.SaveChanges();

            if (context.SiftedInitialScrapInfo.Any()) return;

            var testData4 = new SiftedInitialScrapInfo
            {
                Sectors = "test",
                SectorUrl = "test"
            };

            context.SiftedInitialScrapInfo.Add(testData4);
            context.SaveChanges();
        }
    }
}
