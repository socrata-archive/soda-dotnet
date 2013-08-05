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
        public static void truncate(this Dataset dataset)
        {
            throw new NotImplementedException();
        }

        public static void upsert(this Dataset dataset, Row[] rowsToUpsert)
        {
            throw new NotImplementedException();
        }

        public static void replaceRow(this Dataset dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void updateRow(this Dataset dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void deleteRow(this Dataset dataset, Row row)
        {
            throw new NotImplementedException();
        }

        public static void addRow(this Dataset dataset, Row row)
        {
            throw new NotImplementedException();
        }
    }
}
