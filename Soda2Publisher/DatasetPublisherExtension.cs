using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soda2Consumer;
using System.Web.Script.Serialization;

namespace Soda2Publisher
{
    public static class DatasetPublisherExtension
    {
        private static JavaScriptSerializer ser = new JavaScriptSerializer();

        public static void truncate<R>(this Dataset<R> dataset)
        {
            var response = dataset.client.delete(Soda2Url.datasetUri(dataset.domain, dataset.id));
        }

        public static void upsert<R>(this Dataset<R> dataset, Row[] rowsToUpsert)
        {
            var body = ser.Serialize(rowsToUpsert);
            var response = dataset.client.post(Soda2Url.datasetUri(dataset.domain, dataset.id), body);
            response.Close();
        }

        public static void replaceRow<R>(this Dataset<R> dataset, string rowId, Row row)
        {
            var body = ser.Serialize(row);
            var response = dataset.client.put(Soda2Url.rowUri(dataset.domain, dataset.id, rowId), body);
            response.Close();
        }

        public static void updateRow<R>(this Dataset<R> dataset, string rowId, Row row)
        {
            var body = ser.Serialize(row);
            var response = dataset.client.post(Soda2Url.rowUri(dataset.domain, dataset.id, rowId), body);
            response.Close();
        }

        public static void deleteRow<R>(this Dataset<R> dataset, string rowId)
        {
            var response = dataset.client.delete(Soda2Url.rowUri(dataset.domain, dataset.id, rowId));
            response.Close();
        }

        public static void addRow<R>(this Dataset<R> dataset, Row row)
        {
            row.Remove(":id");
            row.Remove(":delete");
            var body = ser.Serialize(row);
            var response = dataset.client.post(Soda2Url.datasetUri(dataset.domain, dataset.id), body);
            response.Close();
        }
    }
}
