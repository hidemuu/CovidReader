using CovidReader.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Api
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected delegate Task<string> CommandHandler(IEnumerable<string> parameters);
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, CommandHandler> _handlers;
        /// <summary>
        /// 
        /// </summary>
        protected string _command = "";
        /// <summary>
        /// 
        /// </summary>
        protected IEnumerable<string> _parameters;
        /// <summary>
        /// 
        /// </summary>
        protected string _status = "Standby";
        /// <summary>
        /// 
        /// </summary>
        protected string _response = "";
        private static Process _process;

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        public void Register(string command, IEnumerable<string> parameters = null)
        {
            if (_status != "Running")
            {
                _command = command;
                if (parameters != null)
                {
                    _parameters = parameters;
                }
                else
                {
                    _parameters = new string[0];
                }

                _status = "Ready";
            }

        }

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RunAsync(string command, IEnumerable<string> parameters = null)
        {

            Register(command, parameters);

            if (IsExist(_command))
            {
                if (_status == "Ready")
                {
                    _status = "Running";
                    await Task.Run(() => Invoke());
                    _status = "Finished";
                }
            }
            return true;
        }

        /// <summary>
        /// 存在確認
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool IsExist(string command)
        {
            return _handlers.ContainsKey(command);
        }

        /// <summary>
        /// インボーク処理
        /// </summary>
        public bool Invoke()
        {
            var task = Task.Run(() => _handlers[_command].Invoke(_parameters));
            Task.WaitAll(task);
            _response = task.Result;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            return _response.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string Help();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ViewSample()
        {
            var fileName = "notepad";
            var fullpath = Urls.RootPath + @"docs\" + @"AppCommandSample.txt";
            // 同名のプロセスが他に存在した場合は、既に起動していると判断する
            if (Process.GetProcessesByName(fileName).Length > 0)
            {
                return false;
            }
            using (_process = new Process())
            {
                _process.StartInfo.UseShellExecute = true;
                _process.StartInfo.FileName = fileName;
                _process.StartInfo.Arguments = fullpath;
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                return _process.Start();
            }
        }

    }
}
