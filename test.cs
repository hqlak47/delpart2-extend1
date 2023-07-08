using System;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace delpart2_extend1
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void getDriveLetterButton_Click(object sender, EventArgs e)
        {
            // 获取驱动器号
            string driveLetter = GetDriveLetter(0, 2);

            if (!string.IsNullOrEmpty(driveLetter))
            {
                rtb.AppendText($"驱动器号为：{driveLetter}\n");
            // 执行磁盘整理命令
            RunDefragCommand(driveLetter);
            }
            else
            {
                rtb.AppendText("未找到驱动器号。");
            }
        }

        private string GetDriveLetter(int diskNumber, int partitionNumber)
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='Disk #{diskNumber}, Partition #{partitionNumber}'}} WHERE AssocClass = Win32_LogicalDiskToPartition"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string driveLetter = obj["Name"]?.ToString();
                        return driveLetter;
                    }
                }
            }
            catch (Exception ex)
            {
                rtb.AppendText("获取磁盘驱动器号时发生异常：" + ex.Message);
            }

            return null;
        }

        private void RunDefragCommand(string driveLetter)
        {
            // 创建一个进程对象
            Process defragProcess = new Process();

            // 设置进程启动信息
            defragProcess.StartInfo.FileName = "defrag.exe"; // 磁盘整理程序的可执行文件路径
            defragProcess.StartInfo.Arguments = driveLetter; // 传递驱动器字母作为参数
            defragProcess.StartInfo.UseShellExecute = false;
            defragProcess.StartInfo.RedirectStandardOutput = true;
            defragProcess.StartInfo.CreateNoWindow = true;

            // 启动进程
            defragProcess.Start();

            // 读取输出并保存到字符串
            StringBuilder output = new StringBuilder();
            while (!defragProcess.StandardOutput.EndOfStream)
            {
                output.AppendLine(defragProcess.StandardOutput.ReadLine());
            }

            // 等待进程结束
            defragProcess.WaitForExit();

            // 输出整理结果
            string result = output.ToString();
            rtb.AppendText(result);
        }
    }   
}
