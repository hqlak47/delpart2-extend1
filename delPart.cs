using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delpart2_extend1
{
    public partial class delPart : Form
    {
        public delPart()
        {
            InitializeComponent();   
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbDisk.Text = ConfigurationManager.AppSettings["disk"];
            cbPart.Text = ConfigurationManager.AppSettings["part"];
            string cacheTxtPath = ConfigurationManager.AppSettings["txtPath"];
            string onekey = ConfigurationManager.AppSettings["onekey"];
            if (onekey == "1")
            {
                rtb.AppendText("全自动");
                completelyDel.PerformClick();
                Process.Start("explorer.exe", "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");

                // 获取分区的可用空间大小
                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(cacheTxtPath));
                long availableSpace = driveInfo.AvailableFreeSpace;

                // 生成随机数据填充文件
                GenerateRandomFile(cacheTxtPath, availableSpace);

                MessageBox.Show("随机文件生成完成。");
                //可以通过检查随机文件是否被使用来判断缓存是否写完
                Application.Exit();
            }
            else
            {
                rtb.AppendText("磁盘信息：");
            }
            UpdateInfo();
        }


        // 删除分区
        private void DeletePartitionButton_Click(object sender, EventArgs e)
        {
            rtb.AppendText("\n===============================================\n");
            string diskIndex = cbDisk.Text;
            string partitionIndex = cbPart.Text;
            //string deleteCommand = $"select disk 0\nselect partition 2\ndelete partition";
            //string deleteCommand = $"select disk 0\nselect partition 2\nlist partition\nselect disk 0\nlist disk\n";
            string delCommand = $"select disk {diskIndex}\n" +
                             $"select partition {partitionIndex}\n" +
                             "delete partition override\n" +
                             "exit";
            ExecuteDiskPartCommand(delCommand, $"删除磁盘：{diskIndex}的分区：{partitionIndex}");
            UpdateInfo();
        }

        // 删除并扩展分区，再磁盘整理
        private void ExtendPartitionButton_Click(object sender, EventArgs e)
        {
            rtb.AppendText("\n===============================================\n");
            int diskIndex = Convert.ToInt32( cbDisk.Text);
            int partitionIndex = Convert.ToInt32(cbPart.Text);
            string delCommand = $"select disk {diskIndex}\n" +
                             $"select partition {partitionIndex}\n" +
                             "delete partition override\n" +
                             "exit";
            ExecuteDiskPartCommand(delCommand, $"删除磁盘：{diskIndex}的分区：{partitionIndex--}");
            rtb.AppendText("磁盘删除partitionIndex：" + partitionIndex.ToString());
            
            UpdateSelectedInfo(diskIndex);

            for (int i = 0; i < 9; i++)
            {
            rtb.AppendText("磁盘拓展\n" );
            string extendCommand = $"select disk {diskIndex}\nselect partition {i}\nextend\n";
            ExecuteDiskPartCommand(extendCommand, "扩展分区");
                rtb.ScrollToCaret();
            }
            UpdateSelectedInfo(diskIndex);

            for(int i = 0; i < 9; i++)
            {
            rtb.AppendText("磁盘整理\n");
            DefragDiskPart(diskIndex, i);
                rtb.ScrollToCaret();
            }
            UpdateSelectedInfo(diskIndex);
        }

        private void ExecuteDiskPartCommand(string command, string operationName)
        {
            try
            {
                // 使用 diskpart 命令执行磁盘操作
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "diskpart",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process();
                process.StartInfo = startInfo;

                // 启动进程
                process.Start();

                // 发送命令到 diskpart
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");

                // 读取 diskpart 输出
                string output = process.StandardOutput.ReadToEnd();
                output = FilterLinesWithKeywords(output, "Microsoft", "DISKPART>", "在计算机上", "退出");

                // 等待命令执行完成
                process.WaitForExit();

                // 使用 output 变量中的结果
                rtb.AppendText(output);

                // 检查命令的退出代码
                if (process.ExitCode != 0)
                {
                    rtb.AppendText($"{operationName}失败");
                }
            }
            catch (Exception ex)
            {
                rtb.AppendText($"执行命令时发生错误：{ex.Message}");
            }
        }

        private void UpdateInfo()
        {
            UpdateSelectedInfo(0);         
                foreach (string li in rtb.Lines)//获取有多少磁盘（从0开始数）
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (li.Contains($"磁盘 {i}"))
                        {
                            if (i > Convert.ToInt32(lnum.Text))
                            {
                                lnum.Text = i.ToString();
                            }
                        }
                    }
                }            
            for (int i = 1; i <= Convert.ToInt32(lnum.Text); i++)
            {
                UpdateSelectedInfo(i);              
            }
        }
        private void UpdateSelectedInfo(int diskI)
        {
            rtb.AppendText("\n================================================================\n");
            string Command = $"select disk {diskI}\nlist disk\nlist partition\n";
            ExecuteDiskPartCommand(Command, $"列出磁盘{diskI}的分区");
        }

        private void BtnDefrag_Click(object sender, EventArgs e)
        {
            rtb.AppendText("\n================================================================\n");            
            int diskI = Convert.ToInt32(cbDisk.Text);
            int partitionI = Convert.ToInt32(cbPart.Text);
            DefragDiskPart(diskI, partitionI);
        }
        //整理指定磁盘的指定分区
        private void DefragDiskPart(int diskI, int partI)
        {
            // 获取磁盘0分区3的驱动器号
            string driveLetter = GetDriveLetter(diskI, partI);
            if (!string.IsNullOrEmpty(driveLetter))
            {
                rtb.AppendText($"磁盘{diskI}分区{partI}的驱动器号为：{driveLetter}");
                // 执行磁盘整理命令
                RunDefragCommand($"{driveLetter}");
                //RunDefragCommand($"{driveLetter} /l");
                //RunDefragCommand($"{driveLetter} /o");
            }
            else
            {
                rtb.AppendText($"未找到磁盘{diskI}分区{partI}的驱动器号。");
            }
        }

        // 查找驱动器号
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

        // 启动进程执行磁盘整理命令
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

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }
        public static string FilterLinesWithKeywords(string input, params string[] keywords)
        {
            //把字符串通过换行符分开，同时舍弃空行
            string[] lines = input.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray(); 
            //正则表达式“或”来判断语句
            Regex regex = new Regex(string.Join("|", keywords));
            string filteredText = "";
            foreach (string line in lines)
            {
                if (!regex.IsMatch(line))
                {
                    filteredText += line + "\n";
                }
                else
                {
                    continue;
                }
            }
            return filteredText;
        }
        static void GenerateRandomFile(string filePath, long fileSize)
        {
            const int bufferSize = 1024 * 1024; // 1MB 缓冲区大小
            byte[] buffer = new byte[bufferSize];
            Random random = new Random();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                long remainingSize = fileSize;

                while (remainingSize > 0)
                {
                    // 每次写入缓冲区大小的随机数据
                    random.NextBytes(buffer);
                    int bytesToWrite = (int)Math.Min(remainingSize, bufferSize);
                    fileStream.Write(buffer, 0, bytesToWrite);
                    remainingSize -= bytesToWrite;
                }
            }
        }
    }
}
