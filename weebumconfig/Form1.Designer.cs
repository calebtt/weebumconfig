
namespace weebumconfig
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFfmpegLocation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenOutputFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOutputFileName = new System.Windows.Forms.TextBox();
            this.tbxVidyaPath = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSelectVidyaLocation = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.tbxFfmpegPath = new System.Windows.Forms.TextBox();
            this.rtxProgramArgs = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "FFMPEG .exe file |*.exe";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSelectFfmpegLocation
            // 
            this.btnSelectFfmpegLocation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSelectFfmpegLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelectFfmpegLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectFfmpegLocation.Location = new System.Drawing.Point(0, 0);
            this.btnSelectFfmpegLocation.Name = "btnSelectFfmpegLocation";
            this.btnSelectFfmpegLocation.Size = new System.Drawing.Size(196, 24);
            this.btnSelectFfmpegLocation.TabIndex = 2;
            this.btnSelectFfmpegLocation.Text = "Select FFMPEG location";
            this.btnSelectFfmpegLocation.UseVisualStyleBackColor = false;
            this.btnSelectFfmpegLocation.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenOutputFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxOutputFileName);
            this.groupBox1.Controls.Add(this.tbxVidyaPath);
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Controls.Add(this.tbxFfmpegPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1083, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FFMPEG Setup";
            // 
            // btnOpenOutputFolder
            // 
            this.btnOpenOutputFolder.BackColor = System.Drawing.Color.GreenYellow;
            this.btnOpenOutputFolder.Location = new System.Drawing.Point(918, 12);
            this.btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            this.btnOpenOutputFolder.Size = new System.Drawing.Size(153, 34);
            this.btnOpenOutputFolder.TabIndex = 7;
            this.btnOpenOutputFolder.Text = "Open Output Folder";
            this.btnOpenOutputFolder.UseVisualStyleBackColor = false;
            this.btnOpenOutputFolder.Click += new System.EventHandler(this.btnOpenOutputFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Must end in .webm!";
            // 
            // tbxOutputFileName
            // 
            this.tbxOutputFileName.Location = new System.Drawing.Point(457, 23);
            this.tbxOutputFileName.Name = "tbxOutputFileName";
            this.tbxOutputFileName.Size = new System.Drawing.Size(203, 23);
            this.tbxOutputFileName.TabIndex = 1;
            this.tbxOutputFileName.TextChanged += new System.EventHandler(this.tbxOutputFileName_TextChanged);
            // 
            // tbxVidyaPath
            // 
            this.tbxVidyaPath.Location = new System.Drawing.Point(0, 101);
            this.tbxVidyaPath.Multiline = true;
            this.tbxVidyaPath.Name = "tbxVidyaPath";
            this.tbxVidyaPath.ReadOnly = true;
            this.tbxVidyaPath.Size = new System.Drawing.Size(1083, 43);
            this.tbxVidyaPath.TabIndex = 4;
            this.tbxVidyaPath.Text = "Path to vidya file goes here...";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(7, 22);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSelectFfmpegLocation);
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSelectVidyaLocation);
            this.splitContainer2.Panel2.Controls.Add(this.btnExecute);
            this.splitContainer2.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Size = new System.Drawing.Size(443, 24);
            this.splitContainer2.SplitterDistance = 219;
            this.splitContainer2.TabIndex = 3;
            // 
            // btnSelectVidyaLocation
            // 
            this.btnSelectVidyaLocation.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelectVidyaLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSelectVidyaLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectVidyaLocation.Location = new System.Drawing.Point(0, 0);
            this.btnSelectVidyaLocation.Name = "btnSelectVidyaLocation";
            this.btnSelectVidyaLocation.Size = new System.Drawing.Size(103, 24);
            this.btnSelectVidyaLocation.TabIndex = 3;
            this.btnSelectVidyaLocation.Text = "Vidya";
            this.btnSelectVidyaLocation.UseVisualStyleBackColor = false;
            this.btnSelectVidyaLocation.Click += new System.EventHandler(this.btnSelectVidyaLocation_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExecute.Location = new System.Drawing.Point(106, 0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(114, 24);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute Command";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxFfmpegPath
            // 
            this.tbxFfmpegPath.BackColor = System.Drawing.Color.NavajoWhite;
            this.tbxFfmpegPath.Location = new System.Drawing.Point(0, 52);
            this.tbxFfmpegPath.Multiline = true;
            this.tbxFfmpegPath.Name = "tbxFfmpegPath";
            this.tbxFfmpegPath.ReadOnly = true;
            this.tbxFfmpegPath.Size = new System.Drawing.Size(1083, 42);
            this.tbxFfmpegPath.TabIndex = 5;
            this.tbxFfmpegPath.Text = "Path to FFMPEG.exe goes here...";
            // 
            // rtxProgramArgs
            // 
            this.rtxProgramArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxProgramArgs.Location = new System.Drawing.Point(0, 0);
            this.rtxProgramArgs.Name = "rtxProgramArgs";
            this.rtxProgramArgs.Size = new System.Drawing.Size(1083, 162);
            this.rtxProgramArgs.TabIndex = 2;
            this.rtxProgramArgs.Text = "-i $MOVIE$ -c:v libvpx -crf 60 -b:v 14294k -vf scale=640:-1 -an $OUTPUT$";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1083, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "Idle...";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Silver;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1083, 159);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "Output from FFMPEG call goes here...\n";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 150);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtxProgramArgs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1083, 325);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 5;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 536);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WeebumConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelectFfmpegLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxFfmpegPath;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RichTextBox rtxProgramArgs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnSelectVidyaLocation;
        private System.Windows.Forms.TextBox tbxVidyaPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox tbxOutputFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenOutputFolder;
    }
}

