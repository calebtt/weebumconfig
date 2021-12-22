using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace weebumconfig
{
    public partial class Form1 : Form
    {
        FfmpegCall caller;
        FfmpegData data;
        readonly string STATUS_BAD_EXE = "The file path you selected does not end in ffmpeg.exe!!";
        readonly string STATUS_IDLE = "Idle...";
        readonly string STATUS_WORKING = "Working...";
        readonly string MESSAGE_GENERAL_ERROR = "Error.";
        readonly string MESSAGE_OUTPUT_EXISTS = "Output file exists in directory already.";
        //used for status indication
        readonly Color goodColor;
        readonly Color badColor = Color.Crimson;
        //used for IO with the ffmpeg.exe
        Process proc;
        public Form1()
        {
            InitializeComponent();
            data = new FfmpegData();
            caller = new FfmpegCall(SynchronizationContext.Current, data);
            goodColor = this.statusStrip1.Items[0].ForeColor;
            if (SettingsFile.Default.PREVIOUS_FFMPEG_PATH != null)
            {
                if (SettingsFile.Default.PREVIOUS_FFMPEG_PATH != "")
                {
                    this.tbxFfmpegPath.Text = SettingsFile.Default.PREVIOUS_FFMPEG_PATH;
                }
            }
            this.openFileDialog2.InitialDirectory = SettingsFile.Default.PREVIOUS_VIDEO_FOLDER;
            this.tbxOutputFileName.Text = data.OutputName;
        }

        //Update status strip
        private void SetTextAndColor(string newText, bool isGood)
        {
            if(!isGood)
                SystemSounds.Exclamation.Play();
            this.statusStrip1.Items[0].Text = newText;
            this.statusStrip1.Items[0].ForeColor = isGood ? goodColor : badColor;
        }
        private void tbxOutputFileName_TextChanged(object sender, EventArgs e)
        {
            if (this.tbxOutputFileName.Text != null && data.OutputPath != null)
            {
                try
                {
                    if (!data.CheckIfFileExists(data.OutputPath + "\\" + this.tbxOutputFileName.Text))
                    {
                        data.OutputName = this.tbxOutputFileName.Text;
                        SetTextAndColor(STATUS_IDLE, true);
                    }
                    else
                    {
                        SetTextAndColor(MESSAGE_OUTPUT_EXISTS, false);
                    }
                }
                catch(Exception ex)
                {
                    SetTextAndColor(MESSAGE_GENERAL_ERROR + ex.Message, false);
                    return;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog(this);
        }
        private void btnSelectVidyaLocation_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.ShowDialog(this);
        }
        //Execute button click event
        private void button2_Click(object sender, EventArgs e)
        {
            if((this.tbxFfmpegPath.Text.Length==0) || (this.tbxVidyaPath.Text.Length==0))
            {
                return;
            }
            SetTextAndColor(STATUS_WORKING, true);
            this.Refresh();
            try
            {
                data.ArgString = this.rtxProgramArgs.Text;
                data.FfmpegPath = this.tbxFfmpegPath.Text;
                proc = caller.StartProcess();
                this.backgroundWorker1.RunWorkerAsync();
                this.backgroundWorker2.RunWorkerAsync();
                this.btnExecute.Enabled = false;
            }
            catch (Exception ex)
            {
                SetTextAndColor(ex.Message, false);
                return;
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                data.FfmpegPath = this.openFileDialog1.FileName;
                this.tbxFfmpegPath.Text = this.openFileDialog1.FileName;
                SetTextAndColor(STATUS_IDLE, true);
                SettingsFile.Default.PREVIOUS_FFMPEG_PATH = this.openFileDialog1.FileName;
                SettingsFile.Default.Save();
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Hand.Play();
                SetTextAndColor(STATUS_BAD_EXE + ex.Message, false);
                return;
            }
        }
        //Fileok event handler for choose video file dialog.
        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                data.InputPath = this.openFileDialog2.FileName;
                data.OutputPath = System.IO.Path.GetDirectoryName(this.openFileDialog2.FileName);
                this.tbxVidyaPath.Text = this.openFileDialog2.FileName;
                if (data.CheckIfFileExists(data.OutputPath + "\\" + tbxOutputFileName.Text))
                {
                    SetTextAndColor(MESSAGE_OUTPUT_EXISTS,false);
                }
                else
                {
                    SetTextAndColor(STATUS_IDLE, true);
                }
                
                SettingsFile.Default.PREVIOUS_VIDEO_FOLDER = System.IO.Path.GetDirectoryName(this.openFileDialog2.FileName);
                SettingsFile.Default.Save();
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Hand.Play();
                SetTextAndColor(ex.Message, false);
                return;
            }
        }
        //Worker for handling standard output. NOTE: ffmpeg doesn't use the standard output.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string allText = this.proc.StandardOutput.ReadToEnd();
            this.proc.WaitForExit();
        }
        //Worker for handling error output. NOTE: ffmpeg uses error output as standard output.
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string allText = this.proc.StandardError.ReadToEnd();
            this.proc.WaitForExit();
            if (allText.Length > 0)
            {
                System.Media.SystemSounds.Beep.Play();
                caller.UpdateTextBox(allText, this.richTextBox2);
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                caller.UpdateTextBox(MESSAGE_GENERAL_ERROR, this.richTextBox2);
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            SetTextAndColor(STATUS_IDLE,true);
            this.btnExecute.Enabled = true;

        }
        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            if (data.OutputPath != null)
            {
                if (data.CheckIfDirectoryExists(data.OutputPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", data.OutputPath);
                }
            }
        }
    }
}
