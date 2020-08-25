using Sodexo_KKH.PopUpControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sodexo_KKH.Helpers
{
    public static class LogDetailBuilder
    {
        static List<string> DetailStatus = new List<string>();
        public static string ListToString(List<LogDetail>  logDetails)
        {
            
            
            Dictionary<logDetailName, TableBuilder> tableList = new Dictionary<logDetailName, TableBuilder>();

            for (int i = 0; i < logDetails.Count; i++)
            {
                var status = (logDetailName)Enum.Parse(typeof(logDetailName), logDetails[i].Name);
                TableBuilder tb = new TableBuilder();
                if (i == 0)
                {
                    
                    tb.AddRow("Name", "Total Records", "Success");
                    tb.AddRow("-------------", "-------------", "--------");
                    
                }
                tableList.Add(status, tb);
                Added(logDetails[i], tableList[status]);
            }

            foreach (var detail in logDetails)
            {
                AddToTable(tableList, detail);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in tableList)
            {
                //var a = item.Value.Output();
                //Paragraph myParagraph = new Paragraph();
                sb.AppendLine(item.Value.Output());
                
                //sb.a($"<span style='font-family:consolas;'>{}</span>");
               
            }
            return sb.ToString();
        }
        private static void AddToTable(Dictionary<logDetailName, TableBuilder> tableList, LogDetail detail)
        {
            
            
        }
        private static void Added(LogDetail detail, TableBuilder tb)
        {

            if (detail.Name.Length > 13)
                tb.AddRow(detail.Name.Substring(0, 13) +"..", detail.totalRecord, detail.SuccessCount);
            else
                tb.AddRow(detail.Name, detail.totalRecord , detail.SuccessCount);
            
        }
    }

    public class TableBuilder : IEnumerable<ITextRow>
    {
        protected class TextRow : List<String>, ITextRow
        {
            protected TableBuilder _tableBuilder = null;
            public TextRow(TableBuilder tableBuilder)
            {
                _tableBuilder = tableBuilder;
                if (_tableBuilder == null) throw new ArgumentException("tableBuilder");
            }
            public String Output()
            {
                StringBuilder sb = new StringBuilder();
                Output(sb);
                return sb.ToString();
            }
            public void Output(StringBuilder sb)
            {
               sb.AppendFormat(_tableBuilder.FormatString, this.ToArray());
            }
            public Object Tag { get; set; }
        }

        public String Separator { get; set; }

        protected List<ITextRow> rows = new List<ITextRow>();
        protected List<int> colLength = new List<int> { 20,15,10};
        protected bool IsLastItem = false;

        public TableBuilder()
        {
            Separator = "  ";
        }

        public TableBuilder(String separator)
            : this()
        {
            Separator = separator;
        }

        public ITextRow AddRow(params object[] cols)
        {
            TextRow row = new TextRow(this);
            foreach (object o in cols)
            {
                String str = o.ToString().Trim();
                row.Add(str);
                //if (colLength.Count >= row.Count)
                //{
                //    int curLength = colLength[row.Count - 1];
                //    if (str.Length > curLength) colLength[row.Count - 1] = str.Length;
                //}
                //else
                //{
                //    colLength.Add(str.Length);
                //}
                
            }
            rows.Add(row);
            return row;
        }

        protected String _fmtstringLast = null;
        protected String _fmtString = null;
        public String FormatString
        {
            get
            {
                if (_fmtString == null)
                {
                    String format = "";
                    int i = 0;
                    foreach (int len in colLength)
                    {
                        format += String.Format("{{{0},-{1}}}{2}", i++, len, Separator);
                    }
                    _fmtstringLast = format;
                    format += "\r\n";
                    _fmtString = format;
                }

                if (IsLastItem == true)
                    return _fmtstringLast;
                else return _fmtString;


            }
        }
   
        public String Output()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TextRow row in rows)
            {
                IsLastItem = row == rows.Last() ? true : false;
                row.Output(sb);
            }
            return sb.ToString();
        }

        #region IEnumerable Members

        public IEnumerator<ITextRow> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        #endregion
    }

    public interface ITextRow
    {
        String Output();
        void Output(StringBuilder sb);
        Object Tag { get; set; }
    }

    public enum logDetailName{
        Bed_Details,
        BedClassMapping,
        Cycle_Details,
        Ward_Details,
        Allergies_Mstr,
        Mstr_DietType,
        Mstr_Ingredients,
        Mstr_MealClass,
        Meal_Option,
      Meal_Time,
        Meal_Type,
        Items_Cat,
        Other_Mstr,
        Remarks,
        Diet_Texture,
        Fluid_Master,
        Therapeutic,
        Thera_Condition,
        MenuItem,
        MenuMstr

    }
}
