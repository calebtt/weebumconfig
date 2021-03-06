using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace weebumconfig
{
    /// <summary>
    /// Holds some data associated with calling FFMPEG and has some functions
    /// to validate the data, as well as replace the special tokens ($SOMETHING$) with real values.
    /// </summary>
    public class FfmpegData
    {
        public const string NAME_FFMPEG = "ffmpeg.exe";
        public const string NAME_OUTPUT_EXTENSION = ".webm";
        public const string NAME_OUTPUT_DEFAULT = "output.webm";
        public const string TOKEN_VIDEO = "$MOVIE$";
        public const string TOKEN_OUTPUT = "$OUTPUT$";
        public const string TOKEN_TIMESPAN = "$TIMESPAN$";
        public const string TOKEN_INPUT = "-i ";
        public const string ARG_STRING_DEFAULT = "-i $MOVIE$ $TIMESPAN$ -c:v libvpx -crf 60 -b:v 14294k -vf scale=640:-1 -an $OUTPUT$";
        private string outputName;
        private string outputPath; // a directory
        private string inputPath; // a full path plus filename
        private string ffmpegPath; // a full path plus filename
        private string argString;
        public FfmpegData()
        {
            outputName = NAME_OUTPUT_DEFAULT;
            argString = ARG_STRING_DEFAULT;
        }
        public string OutputPath
        {
            get => outputPath;
            set
            {
                if (CheckIfDirectoryExists(value))
                    outputPath = value;
                else
                    throw new ArgumentException("FfmpegData.OutputPath: Invalid output file path.");
            }
        }
        public string InputPath
        {
            get => inputPath;
            set
            {
                if (CheckIfFileExists(value))
                    inputPath = value;
                else
                    throw new ArgumentException("Invalid input file path.");
            }
        }
        public string FfmpegPath
        {
            get => ffmpegPath;
            set
            {
                if (CheckIfFileExists(value) && IsFfmpegPath(value))
                    ffmpegPath = value;
                else
                    throw new ArgumentException("Invalid FFMPEG path.");
            }
        }
        /// <summary>
        /// ArgString is the arg string with replacement tokens still included,
        /// use GetReplacedArgString() if you want the usable form.
        /// </summary>
        public string ArgString
        {
            get => argString;
            set
            {
                if (IsValidTokenArgString(value))
                    argString = value;
                else
                    throw new ArgumentException("Invalid arg string.");
            }
        }
        public string OutputName
        {
            get => outputName;
            set
            {
                Action<int> ThrowFunc = (nonwscount) =>
                {
                    if (nonwscount == 0)
                        throw new ArgumentException("FfmpegData.OutputName: Invalid output file name string.");
                };
                if (value.EndsWith(NAME_OUTPUT_EXTENSION) && value.Length > NAME_OUTPUT_EXTENSION.Length)
                {
                    string temp = value.Substring(0, value.Length - NAME_OUTPUT_EXTENSION.Length);
                    var ws = temp.Where((c) =>
                    {
                        return !Char.IsWhiteSpace(c);
                    });
                    ThrowFunc(ws.Count());
                    outputName = value;
                }
                else
                    ThrowFunc(0);
            }
        }
        //Check if file exists in directory.
        public bool CheckIfFileExists(string fullPath)
        {
            if (fullPath == null)
                return false;
            try
            {
                System.IO.FileInfo fi = new FileInfo(fullPath);
                return fi.Exists;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckIfDirectoryExists(string fullPath)
        {
            if (fullPath == null)
                return false;
            try
            {
                System.IO.FileInfo fi = new FileInfo(fullPath);
                return fi.Directory.Exists;
            }
            catch
            {
                return false;
            }
        }
        //Can throw null-ref exception if path is invalid.
        public string GetDirectoryOfFullPath(string fullPath)
        {
            return System.IO.Path.GetDirectoryName(fullPath);
        }
        public bool IsFfmpegPath(string currentPath)
        {
            return currentPath.ToLower().EndsWith(NAME_FFMPEG);
        }
        //Checks for a couple things that might indicate it's an invalid arg string.
        private bool IsValidTokenArgString(string currentArgs)
        {
            return currentArgs.StartsWith(TOKEN_INPUT + TOKEN_VIDEO) && currentArgs.EndsWith(TOKEN_OUTPUT);
        }
        //Add double quotes to the beginning and end of a string
        private string Quotes(string quoted)
        {
            return "\"" + quoted + "\"";
        }
        //Replaces the arg string tokens with properties in the class.
        public string GetReplacedArgString()
        {
            if (argString == null || inputPath == null || outputPath == null || ffmpegPath == null || outputName == null)
                throw new ArgumentNullException("Null data member, can't get replaced arg string.");
            if (argString.Length == 0 || inputPath.Length == 0 || outputPath.Length == 0 || ffmpegPath.Length == 0 || outputName.Length == 0)
                throw new ArgumentNullException("Empty string data member, can't get replaced arg string.");
            string replacedArgString = argString
                .Replace(TOKEN_VIDEO, Quotes(inputPath))
                .Replace(TOKEN_OUTPUT, Quotes(outputPath + "\\" + outputName))
                .Replace(TOKEN_TIMESPAN, "");
            return replacedArgString;
        }
    }
    /// <summary>
    /// Basic function is to accept data to call ffmpeg with (FfmpegData). Then start the process ffmpeg and provide functions to 
    /// update the gui from within another thread.
    /// </summary>
    public class FfmpegCall
    {
        private FfmpegData data;
        private readonly SynchronizationContext localSyncContext;
        public FfmpegCall(System.Threading.SynchronizationContext sct, FfmpegData builtData)
        {
            localSyncContext = sct;
            data = builtData;
        }
        public Process StartProcess()
        {
            Process proc = new Process();
            string interpretedArgs = data.GetReplacedArgString();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.FileName = data.FfmpegPath;
            proc.StartInfo.Arguments = interpretedArgs;
            proc.StartInfo.WorkingDirectory = data.OutputPath;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            return proc;
        }
        //function to update text box via the other thread, using the SynchronizationContext
        public void UpdateTextBox(string text, RichTextBox tbx)
        {
            localSyncContext.Post(delegate (object state)
            {
                tbx.AppendText(text + "\r\n");

            }, null);
        }
    }
}