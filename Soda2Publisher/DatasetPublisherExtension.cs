using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soda2Consumer;

namespace Soda2Publisher
{
    public static class DatasetPublisherExtension
    {
        public static void truncate<R>(this Dataset<R> dataset)
        {
            throw new NotImplementedException();
        }

        public static void upsert<R>(this Dataset<R> dataset, Row[] rowsToUpsert)
        {
            throw new NotImplementedException();
        }

        public static void replaceRow<R>(this Dataset<R> dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void updateRow<R>(this Dataset<R> dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void deleteRow<R>(this Dataset<R> dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void addRow<R>(this Dataset<R> dataset, Row row)
        {
            throw new NotImplementedException();
        }
    }
}
