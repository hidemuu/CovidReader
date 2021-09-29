using CovidReader.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Settings
{
    /// <summary>
    /// UIコメント
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// 一括で取得しデシリアライズ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAsync();
        /// <summary>
        /// 名称が一致するものを取得しデシリアライズ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Comment> GetAsync(string name);
    }
}
