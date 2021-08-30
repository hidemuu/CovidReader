using CovidReader.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Settings.Xml
{
    public abstract class XmlSettingRepositoryBase<T, L> where T : SettingDbObject where L : List<T>
    {
        private readonly XmlFileHelper _xml;

        public XmlSettingRepositoryBase(string fileName)
        {
            _xml = new XmlFileHelper(fileName);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => _xml.Read<L>());
        }
        public async Task<T> GetAsync(string name)
        {
            var items = await GetAsync();
            return items.FirstOrDefault(x => x.Name == name);
        }

    }
}
