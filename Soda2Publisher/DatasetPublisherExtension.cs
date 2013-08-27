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
            dataset.client.delete(Soda2Url.datasetUri(dataset.domain, dataset.id));
        }

        public static void upsert<R>(this Dataset<R> dataset, Row[] rowsToUpsert)
        {
            var body = ser.Serialize(rowsToUpsert);
            dataset.client.post(Soda2Url.datasetUri(dataset.domain, dataset.id), body);
        }
        
        public static void updateRow<R>(this Dataset<R> dataset, string rowId, Row row)
        {
            var body = ser.Serialize(row);
            dataset.client.post(Soda2Url.rowUri(dataset.domain, dataset.id, rowId), body);
        }

        public static void deleteRow<R>(this Dataset<R> dataset, string rowId)
        {
            dataset.client.delete(Soda2Url.rowUri(dataset.domain, dataset.id, rowId));
        }

        public static void addRow<R>(this Dataset<R> dataset, Row row)
        {
            row.Remove(":id");
            row.Remove(":delete");
            var body = ser.Serialize(row);
            dataset.client.post(Soda2Url.datasetUri(dataset.domain, dataset.id), body);
        }
    }
}
