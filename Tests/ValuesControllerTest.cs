using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using TestClassic.Models;

namespace Tests
{
    public class ValuesControllerTest
    {
        [Test]
        public void Test3()
        {
            
            var xml = @"<?xml version=""1.0""?>

<request xmlns=""http://schemas.cdon.com/integration/0.1/merchant/sku-status/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">


<skus>


<sku_status inStock=""999"" exposure=""buyable"" status=""online"" productId=""0"" sku=""00v"">


<channels>


<channel>

<channel>test.cdon.no</channel>

<sellable>true</sellable>

<ordinary_price>271</ordinary_price>

<current_price>123</current_price>

<vat>25</vat>

</channel>


<channel>

<channel>test.cdon.dk</channel>

<sellable>true</sellable>

<ordinary_price>271</ordinary_price>

<current_price>123</current_price>

<vat>0</vat>

</channel>


<channel>

<channel>test.cdon.se</channel>

<sellable>true</sellable>

<ordinary_price>271</ordinary_price>

<current_price>123</current_price>

<vat>25</vat>

</channel>


<channel>

<channel>test.cdon.fi</channel>

<sellable>true</sellable>

<ordinary_price>257</ordinary_price>

<current_price>25</current_price>

<vat>14</vat>

</channel>

</channels>

</sku_status>

</skus>

</request>";
            var obj = DeserializeObject<MerchantProductUpdateRequest>(xml);
            Assert.IsNotNull(obj);
            Console.WriteLine(obj.Skus.Length);
        }

        public static T DeserializeObject<T>(string xml)
        {
            var array = Encoding.UTF8.GetBytes(xml);

            using (MemoryStream stream = new MemoryStream(array))
            using (var reader = XmlReader.Create(stream))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

            
                var deserialized = (T)serializer.Deserialize(reader);
              
                //reader.MoveToContent();
                //while (reader.Read())
                //{
                //    if (reader.NodeType == XmlNodeType.Element)
                //        Debug.WriteLine(reader.Name);
                //}
                //return default(T);
                return deserialized;

            }
        }
    }
}
