namespace Sodexo_KKH.Models
{
    public class Patient
    {
        private string v1;
        private string v2;
        private byte[] image;
        private int v;
        private byte img;


        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public byte[] Image { get; set; }
        public Patient()
        {

        }
        public Patient(string name, string age, byte[] img)
        {
            Name = name;
            Age = age;
            Image = img;
        }

        public Patient(int v, string name, string age, byte img)
        {
            this.v = v;
            Name = name;
            Age = age;
            this.img = img;
        }

        ////public void Insert( string name,string age, byte img)
        ////{
        ////    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        ////    try
        ////    {
        ////        Db_Helper.Insert_Patient(new Patient(1, name, age,img));
        ////    }
        ////    catch(Exception e)
        ////    {

        ////    }

        ////}
    }
}
