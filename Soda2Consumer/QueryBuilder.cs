using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soda2Consumer
{
    public class QueryBuilder
    {
        private string[] _selectColumns;
        public string[] selectColumns 
        {
            get 
            {
                if (_selectColumns == null)
                {
                    return new string[] {"*"};
                }
                return _selectColumns; 
            }
            set { _selectColumns = value; } 
        }
        public QueryBuilder select(params string[] columnNames)
        {
            selectColumns = columnNames;
            return this;
        }

        public string whereFilter { get; set; }
        public QueryBuilder where(string filter)
        {
            whereFilter = filter;
            return this;
        }

        public string[] groupByColumns { get; set; }
        public QueryBuilder groupBy(params string[] columnNames)
        {
            groupByColumns = columnNames;
            return this;
        }

        public string havingAfterGropingFilter { get; set; }
        public QueryBuilder having(string filter)
        {
            havingAfterGropingFilter = filter;
            return this;
        }

        public string orderByColumn { get; set; }
        public QueryBuilder orderBy(string columnName)
        {
            orderByColumn = columnName;
            return this;
        }

        public uint offsetRows { get; set; }
        public QueryBuilder offset(uint skip)
        {
            offsetRows = skip;
            return this;
        }

        public uint limitRows { get; set; }
        public QueryBuilder limit(uint limit)
        {
            limitRows = limit;
            return this;
        }

        protected const string delim = ", ";
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("select ");
            sb.Append(string.Join(delim, selectColumns));

            if (whereFilter != null)
            {
                sb.Append(" where ");
                sb.Append(whereFilter);
            }

            if (groupByColumns != null)
            {
                sb.Append(" group by ");
                sb.Append(String.Join(delim, groupByColumns));
            }

            if (havingAfterGropingFilter != null)
            {
                sb.Append(" having ");
                sb.Append(havingAfterGropingFilter);
            }

            if (orderByColumn != null)
            {
                sb.Append(" order by ");
                sb.Append(orderByColumn);
            }

            if (offsetRows > 0)
            {
                sb.Append(" offset ");
                sb.Append(offsetRows);
            }

            if (limitRows > 0)
            {
                sb.Append(" limit ");
                sb.Append(limitRows);
            }
            
            return sb.ToString();
        }
    }
}
