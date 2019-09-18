using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace CommonHelper
{
    public class GenericSerializer<T> where T : class
    {
        public static byte[] Serialize(T obj, SerializerType serializerType = SerializerType.Xml)
        {
            byte[] returnBytes = new byte[0];

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    switch (serializerType)
                    {
                        case SerializerType.Xml:
                            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
                            xns.Add(string.Empty, string.Empty);
                            new XmlSerializer(obj.GetType()).Serialize(ms, obj, xns);
                            break;
                        case SerializerType.Binary:
                            new BinaryFormatter().Serialize(ms, obj);
                            break;
                        case SerializerType.Soap:
                            new SoapFormatter().Serialize(ms, obj);
                            break;
                    }

                    returnBytes = ms.GetBuffer();
                }
                catch (Exception) { }
            }
            return returnBytes;
        }

        public static T DeSerialize(Stream ms, SerializerType serializerType = SerializerType.Xml)
        {
            try
            {

                switch (serializerType)
                {
                    case SerializerType.Xml:
                        return (T)new XmlSerializer(typeof(T)).Deserialize(ms);
                    case SerializerType.Binary:
                        return (T)new BinaryFormatter().Deserialize(ms);
                    case SerializerType.Soap:
                        return (T)new SoapFormatter().Deserialize(ms);
                }


            }
            catch (Exception)
            {
                ms.Close();
                ms = null;
            }
            return default(T);
        }

        public static T DeSerialize(XmlReader ms)
        {
            try
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(ms);
            }
            catch (Exception)
            {
                ms.Close();
                ms = null;
            }
            finally { ms.Close(); }
            return default(T);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Description("Represents the various _modifiers that controls the behaviour of the text control.")]
    public class NumericModifiers
    {
        private double _MinValue = 0.0;
        private double _MaxValue = Double.MaxValue;
        private bool _ExcludeMinMax = false;
        private bool _IsValid = true;
        private NumericDataType _DataType = NumericDataType.Decimal;

        [DefaultValue(0.0)]
        [NotifyParentProperty(true)]
        [Description("The minimum value that this control can allow the user to enter.")]
        public double MinValue
        {
            get { return _MinValue; }
            set
            {
                if (_DataType == NumericDataType.Decimal) _MinValue = value;
                else if (_DataType == NumericDataType.Integer) _MinValue = Math.Floor(value);
            }
        }

        [DefaultValue(Double.MaxValue)]
        [NotifyParentProperty(true)]
        [Description("The maximum value that this control can allow the user to enter.")]
        public double MaxValue
        {
            get { return _MaxValue; }
            set
            {
                if (_DataType == NumericDataType.Decimal) _MaxValue = value;
                else if (_DataType == NumericDataType.Integer) _MaxValue = Math.Floor(value);
            }
        }

        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Indicates whether to include or exclude the minimum and maximum values in the acceptable range.")]
        public bool ExcludeMinMax
        {
            get { return _ExcludeMinMax; }
            set { _ExcludeMinMax = value; }
        }

        [DefaultValue(NumericDataType.Decimal)]
        [NotifyParentProperty(true)]
        [Description("Indicates whether to accept decimals or integers.")]
        public NumericDataType DataType
        {
            get { return _DataType; }
            set
            {
                _DataType = value;
                if (_DataType == NumericDataType.Decimal) { }
                else if (_DataType == NumericDataType.Integer)
                {
                    _MinValue = Math.Floor(_MinValue);
                    _MaxValue = Math.Floor(_MaxValue);
                }
            }
        }

        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("This property can be used to determine if the value in this property is valid or not.")]
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }
    }

    public class EntityBase
    {
        public bool IsDirty { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int Status { get; set; }
        public int Remove { get; set; }
       
        public T Clone<T>()
        {
            return (T)this.MemberwiseClone();
        }
    }

    public class EntityCollection<T> : System.Collections.Generic.List<T>
    {
        [System.Xml.Serialization.XmlAttribute()]
        public char DMLType { get; set; }

        public EntityCollection<T> Clone()
        {
            return (EntityCollection<T>)this.MemberwiseClone();
        }
    }

    public class CommonHelper
    {

        public static string Language = String.Empty;

        public static string GetMessage(string key)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                XmlNode xmlNode = null;
                if (!File.Exists(string.Concat(Environment.CurrentDirectory, "\\ErrMessages.xml")))
                {
                    xDoc.LoadXml(File.ReadAllText(string.Concat(Environment.CurrentDirectory + "\\ErrMessages.xml")));
                    xmlNode = xDoc.SelectSingleNode(string.Format("ErrorMessages/Message[@key='{0}']", key));
                }
                return xmlNode != null ? xmlNode.InnerXml : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
                
            }
            finally { }

        }

      
    }

    public class ConvertionHelper
    {
        /// <summary>
        /// Converts DataTable into List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ConvertToList<T>(DataTable table)
        {
            if (table == null)
                return null;
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
                rows.Add(row);
            return ConvertTo<T>(rows).ToList();
        }
       

        /// <summary>
        /// Converts DataRows in T type list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        private static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Convert DataRow into T Object
        /// </summary>  
        private static T CreateItem<T>(DataRow row)
        {
            string columnName;
            T obj = default(T);
            if (row != null)
            {
                //Create the instance of type T
                obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    columnName = column.ColumnName;
                    //Get property with same columnName
                    PropertyInfo prop = obj.GetType().GetProperty(columnName);
                    try
                    {
                        if (prop != null) // check property is available or not
                        {
                            //Get value for the column
                            object value = (row[columnName].GetType() == typeof(DBNull)) ? null : row[columnName];
                            //Set property value
                            prop.SetValue(obj, value, null);
                        }

                    }
                    catch
                    {
                        throw;
                        //Catch whatever here
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// this Method to Convert List to DataTabl
        /// Created By Meena.R
        /// </summary>
        /// 
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
    
}
