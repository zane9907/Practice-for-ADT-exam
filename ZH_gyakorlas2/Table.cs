using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZH_gyakorlas2
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Invited> Guests { get; set; }

        public static List<Table> LoadXML(string xml)
        {
            var doc = XDocument.Load(xml);
            List<Table> tables = new List<Table>();

            foreach (var item in doc.Descendants("table"))
            {
                tables.Add(new Table()
                {
                    Id = int.Parse(item.Attribute("id").Value),
                    Name = item.Attribute("name").Value,
                    Guests = new List<Invited>()
                });
            }

            
            foreach (var item in tables)
            {
                foreach (var guests in doc.Descendants("table").Where(x => int.Parse(x.Attribute("id").Value) == item.Id).Descendants("guest"))
                {
                    item.Guests.Add(new Invited()
                    {
                        Name = guests.Element("name").Value,
                        RelativeStatus = (RelativeStatuses)Enum.Parse(typeof(RelativeStatuses), guests.Element("relativeStatus").Value),
                        Age = int.Parse(guests.Element("age").Value),
                        AlcoholConsumption = int.Parse(guests.Element("alcoholConsumption").Value)
                    });
                }
            }

            return tables;
        }
    }
}
