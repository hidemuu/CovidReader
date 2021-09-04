using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CovidReader.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowHelper
    {
        //using System.Runtime.InteropServices;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// エントリポイント
        /// </summary>
        public static void SetForeground(string title)
        {
            //すべてのプロセスを列挙する
            foreach (System.Diagnostics.Process p
                in System.Diagnostics.Process.GetProcesses())
            {
                //"title"がメインウィンドウのタイトルに含まれているか調べる
                if (0 <= p.MainWindowTitle.IndexOf(title))
                {
                    //ウィンドウをアクティブにする
                    SetForegroundWindow(p.MainWindowHandle);
                    break;
                }
            }
        }
    }
}
