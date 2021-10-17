using CovidReader.UseCases;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CovidReader.Windows.ViewModels
{
    public class TreeListViewModel : BindableBase
    {
        public List<Model> Models { get; set; }
        private IAppController appController;

        public TreeListViewModel(IRegionManager regionManager, IAppController appController)
        {
            this.appController = appController;
            ReadXml();
        }

        private void ReadXml()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"ViewModels/TreeModel.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Model));
                var value = (Model)serializer.Deserialize(reader);
                Console.WriteLine(string.Format("NumOfStore = {0}.", value.Models.Count()));
                foreach (var child in value.Models)
                {
                    Console.WriteLine(string.Format("Name = {0}", child.Item.Path));
                    
                }
            }

        }

    }

    [System.Xml.Serialization.XmlRoot("Model")]
    public class Model
    {
        [System.Xml.Serialization.XmlElement("Item")]
        public Item Item { get; set; }
        [System.Xml.Serialization.XmlArray("Models")]
        [System.Xml.Serialization.XmlArrayItem("Model")]
        public List<Model> Models { get; set; }
    }

    [Serializable]
    public class Item
    {
        [System.Xml.Serialization.XmlElement("Path")]
        public string Path { get; set; }
        
    }



}
