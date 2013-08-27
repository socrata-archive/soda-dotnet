using Soda2Consumer;
using Soda2Publisher;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SampleDataPublisherApp
{
    class PublisherApp
    {
        static void Main(string[] args)
        {
            string host = ConfigurationManager.AppSettings["socrata.host"];
            string datasetId = ConfigurationManager.AppSettings["socrata.sample.publishDataset"];
            string username = ConfigurationManager.AppSettings["socrata.username"];
            string password = ConfigurationManager.AppSettings["socrata.password"];
            var basicAuthClient = new Soda2BasicAuthClient(username, password);
            var dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);

            dataset.truncate();
            var resultA = dataset.query("select *");
            Console.WriteLine(resultA.rows.Length);

            FileStream movieJson = File.OpenRead("resources/movies.json");
            var body = new StreamReader(movieJson).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var movies = ser.Deserialize<Row[]>(body);  
            dataset.upsert(movies);
            var resultB = dataset.query("select :id, title, year, director, country");

            const string idColumn = ":id";

            Row rowToAdd = new Row();
            rowToAdd.Add("title", "My Test Movie");
            rowToAdd.Add("year", 2013);
            dataset.addRow(rowToAdd);

            string idToDelete = resultB.rows[0][idColumn].ToString();
            dataset.deleteRow(idToDelete);

            Row rowToChange = resultB.rows[1];
            rowToChange["title"] = "Changed Title";
            dataset.updateRow(rowToChange[idColumn].ToString(), rowToChange);

            Row rowToReplace = resultB.rows[2];
            rowToReplace["title"] = "Replaced Title";
            rowToReplace.Remove("director");
            dataset.replaceRow(rowToReplace[idColumn].ToString(), rowToReplace);
            var resultC = dataset.query("select *");

            Console.WriteLine(resultC);
        }
    }
}
