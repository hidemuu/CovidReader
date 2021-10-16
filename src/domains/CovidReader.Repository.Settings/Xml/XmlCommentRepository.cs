using CovidReader.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Settings.Xml
{
    public class XmlCommentRepository : XmlSettingRepositoryBase<Comment, Comments>, ICommentRepository
    {
        public XmlCommentRepository(string path) : base(path) { }
    }
}
