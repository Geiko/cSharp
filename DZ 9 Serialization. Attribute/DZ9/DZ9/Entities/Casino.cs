using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a casino - an array of playing tables.
    /// </summary>
    class Casino : ICasino
    {
        /// <summary>
        /// This method allows player to select a table and serialize data.
        /// </summary>
        /// <param name="myPurse">It is money($) in purse of player.</param>
        public void SelectTable(double myPurse)
        {
            while (true)
            {
                Console.WriteLine("\n\nWhat table whould you like to play at?");
                Console.WriteLine("\nPlease, set table's number\n\n    Alt+F(1-10) or esc to quit.");

                ConsoleKeyInfo cki = Console.ReadKey();
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0)
                {
                    try
                    {
                        switch (cki.Key)
                        {
                            #region cases
                            case ConsoleKey.F1:
                                NewtonJson_Serialize(1, ref myPurse);
                                //                         JS_Serialize(1, ref myPurse);
                                //                         SoapSerialize(1, ref myPurse);
                                //                         JsonSerialize(1, ref myPurse);
                                //                         XmlSerialize(1, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(1, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize( 1, ref myPurse );
                                break;
                            case ConsoleKey.F2:
                                NewtonJson_Serialize(1, ref myPurse);
                                //                         JS_Serialize(2, ref myPurse);
                                //                         SoapSerialize(2, ref myPurse);
                                //                         JsonSerialize(2, ref myPurse);
                                //                         XmlSerialize(2, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(2, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(2, ref myPurse);
                                break;
                            case ConsoleKey.F3:
                                NewtonJson_Serialize(3, ref myPurse);
                                //                         JS_Serialize(3, ref myPurse);
                                //                         SoapSerialize(3, ref myPurse);
                                //                         JsonSerialize(3, ref myPurse);
                                //                         XmlSerialize(3, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(3, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(3, ref myPurse);
                                break;
                            case ConsoleKey.F4:
                                NewtonJson_Serialize(4, ref myPurse);
                                //                         JS_Serialize(4, ref myPurse);
                                //                         SoapSerialize(4, ref myPurse);
                                //                         JsonSerialize(4, ref myPurse);
                                //                         XmlSerialize(4, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(4, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(4, ref myPurse);
                                break;
                            case ConsoleKey.F5:
                                NewtonJson_Serialize(5, ref myPurse);
                                //                         JS_Serialize(5, ref myPurse);
                                //                         SoapSerialize(5, ref myPurse);
                                //                         JsonSerialize(5, ref myPurse);
                                //                         XmlSerialize(5, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(5, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(5, ref myPurse);
                                break;
                            case ConsoleKey.F6:
                                NewtonJson_Serialize(6, ref myPurse);
                                //                         JS_Serialize(6, ref myPurse);
                                //                         SoapSerialize(6, ref myPurse);
                                //                         JsonSerialize(6, ref myPurse);
                                //                         XmlSerialize(6, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(6, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(6, ref myPurse);
                                break;
                            case ConsoleKey.F7:
                                NewtonJson_Serialize(7, ref myPurse);
                                //                         JS_Serialize(7, ref myPurse);
                                //                         SoapSerialize(7, ref myPurse);
                                //                         JsonSerialize(7, ref myPurse);
                                //                         XmlSerialize(7, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(7, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(7, ref myPurse);
                                break;
                            case ConsoleKey.F8:
                                NewtonJson_Serialize(8, ref myPurse);
                                //                         JS_Serialize(8, ref myPurse);
                                //                         SoapSerialize(8, ref myPurse);
                                //                         JsonSerialize(8, ref myPurse);
                                //                         XmlSerialize(8, ref myPurse);
                                //                         BinaryFormatMemoryStreamSerialize(8, ref myPurse);
                                //                         BinaryFormatFileStreamSerialize(8, ref myPurse);
                                break;
                            case ConsoleKey.F9:
                                NewtonJson_Serialize(9, ref myPurse);
                                //                          JS_Serialize(9, ref myPurse);
                                //                          SoapSerialize(9, ref myPurse);
                                //                          JsonSerialize(9, ref myPurse);
                                //                          XmlSerialize(9, ref myPurse);
                                //                          BinaryFormatMemoryStreamSerialize(9, ref myPurse);
                                //                          BinaryFormatFileStreamSerialize(9, ref myPurse);
                                break;
                            case ConsoleKey.F10:
                                NewtonJson_Serialize(10, ref myPurse);
                                //                          JS_Serialize(10, ref myPurse);
                                //                          SoapSerialize(10, ref myPurse);
                                //                          JsonSerialize(10, ref myPurse);
                                //                          XmlSerialize(10, ref myPurse);
                                //                          BinaryFormatMemoryStreamSerialize(10, ref myPurse);
                                //                          BinaryFormatFileStreamSerialize(10, ref myPurse);
                                break;
                            default:
                                Console.WriteLine("\nIt is irrelevant table number! Try again.");
                                Console.ReadKey();
                                break;
                            #endregion
                        }
                    }
                    catch ( SystemException e )
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                    }
                }
                if (cki.Key == ConsoleKey.Escape)
                    return;
            }
        }
        

        /// <summary>
        /// This method serializes object graphs to Memory stream in binary format.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void BinaryFormatMemoryStreamSerialize(int tableNumber, ref double myPurse)
        {
            MemoryStream MS = new MemoryStream();
            BinaryFormatter BF = new BinaryFormatter();
            if (MS.Length != 0)
            {
                MS.Seek(0, SeekOrigin.Begin);
                ITable table = (Table)BF.Deserialize(MS);
                MS.Close();
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                BF.Serialize(MS, table);
                MS.Close();
            }
        }


        /// <summary>
        /// This method serializes object graphs to File stream in binary format.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void BinaryFormatFileStreamSerialize(int tableNumber, ref double myPurse)
        {
            string temp = "table" + tableNumber.ToString() + ".dat";

            BinaryFormatter BF = new BinaryFormatter();
            if (File.Exists(temp) == true)
            {
                FileStream FS = new FileStream(temp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FS.Seek(0, SeekOrigin.Begin);
                ITable table = (Table)BF.Deserialize(FS);
                FS.Close();
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                FileStream FS = new FileStream(temp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BF.Serialize(FS, table);
                FS.Close();
            }
        }


        /// <summary>
        /// This method serializes object graphs to File stream in Soap format.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void SoapSerialize(int tableNumber, ref double myPurse)
        {
            string temp = "table_Soap_" + tableNumber.ToString() + ".xml";

            SoapFormatter SoapForm = new SoapFormatter();
            if (File.Exists(temp))
            {
                FileStream fs = new FileStream(temp, FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.Begin);
                ITable table = (Table)SoapForm.Deserialize(fs);
                fs.Close();
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                FileStream fs = new FileStream(temp, FileMode.OpenOrCreate);
                SoapForm.Serialize(fs, table);
                fs.Close();
            }
        }


        /// <summary>
        /// This method serializes object's public info to file stream in Xml format.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void XmlSerialize(int tableNumber, ref double myPurse)
        {
            string temp = "table" + tableNumber.ToString() + ".xml";
            if (File.Exists(temp))
            {
                Stream streamout = new FileStream(temp, FileMode.Open, FileAccess.Read);     
                XmlSerializer deserializer = new XmlSerializer(typeof(Table));
                ITable table = (Table)deserializer.Deserialize(streamout);
                table.UserMenu(ref myPurse, tableNumber);
                streamout.Close();
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                StreamWriter writer = new StreamWriter(temp);
                XmlSerializer serializer = new XmlSerializer(typeof(Table));
                serializer.Serialize(writer, table);
                writer.Close();
            }
        }


        /// <summary>
        /// This method serializes object info to file stream in Json format.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void JsonSerialize(int tableNumber, ref double myPurse)
        {
            string temp = "table" + tableNumber.ToString() + ".json";

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Table));
            if (File.Exists(temp))
            {
                FileStream fs = new FileStream(temp, FileMode.OpenOrCreate);
                ITable table = (Table)jsonSerializer.ReadObject(fs);
                fs.Close();
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                FileStream fs = new FileStream(temp, FileMode.OpenOrCreate);
                jsonSerializer.WriteObject(fs, table);
                fs.Close();
            }
        }



        /// <summary>
        /// This method serializes object info to file stream in Json format with JavaScript Serializer.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void JS_Serialize(int tableNumber, ref double myPurse)
        {
            string temp = "table_JS_" + tableNumber.ToString() + ".json";

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            if (File.Exists(temp))
            {
                string json = File.ReadAllText(temp);
                ITable table = jsSerializer.Deserialize<Table>(json);
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                string json = jsSerializer.Serialize( table );
                File.WriteAllText(temp, json);
            }
        }



        /// <summary>
        /// This method serializes object info to file stream in Json format with Json.NET Serializer.
        /// </summary>
        /// <param name="tableNumber">Number of the table.</param>
        /// <param name="myPurse">Money in the purse of player.</param>
        private void NewtonJson_Serialize(int tableNumber, ref double myPurse)
        {
            string temp = "table_NewtonJson_" + tableNumber.ToString() + ".json";

            if (File.Exists(temp))
            {
                string json = File.ReadAllText(temp);
                ITable table = JsonConvert.DeserializeObject<Table>(json);
                table.UserMenu(ref myPurse, tableNumber);
            }
            else
            {
                ITable table = new Table();
                table.UserMenu(ref myPurse, tableNumber);
                string json = JsonConvert.SerializeObject( table, Formatting.Indented );
                File.WriteAllText(temp, json);
            }
        }
    }
}
