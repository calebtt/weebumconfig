using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using weebumconfig;

namespace weebumconfigtest
{
    public class TestFfmpegData
    {
        const string ERR_NULL_STR = "Replaced arg string null.";
        const string ERR_NO_TOKENINPUT = "Does not start with TOKEN_INPUT";
        const string ERR_NO_TOKENOUTPUT = "Does not start with TOKEN_OUTPUT";
        const string ERR_NO_TOKENVIDEO = "Does not start with TOKEN_VIDEO";
        private const string ERR_BAD_FFMPEG_PATH = "Does not contain a path to ffmpeg.exe";
        const string TST_FFMPEG_PATH = "C:\\Users\\caleb\\Downloads\\ffmpeg-2021-11-18-git-85a6b7f7b7-essentials_build\\bin\\ffmpeg.exe";
        const string TST_INPUT_PATH = "C:\\Users\\caleb\\Videos\\alarms.MP4";
        const string TST_OUTPUT_FOLDER = "C:\\Users\\caleb\\Videos\\";
        const string TST_OUTPUT_NAME = "output.webm";
        private FfmpegData d;

        [SetUp]
        public void Setup()
        {
            d = new FfmpegData();
        }

        [Test]
        public void TestArgstring()
        {
            Console.Error.WriteLine("Begin TestArgString()");

            
            d.FfmpegPath = TST_FFMPEG_PATH;
            d.InputPath = TST_INPUT_PATH;
            d.OutputPath = TST_OUTPUT_FOLDER;
            d.OutputName = TST_OUTPUT_NAME;
            //test can get replaced arg string
            Assert.IsNotNull(d.GetReplacedArgString(), ERR_NULL_STR);
            //test arg string starts with the input token
            Assert.IsTrue(d.ArgString.StartsWith(FfmpegData.TOKEN_INPUT), ERR_NO_TOKENINPUT);
            //test arg string contains both the output token and the video token
            Assert.IsTrue(d.ArgString.Contains(FfmpegData.TOKEN_OUTPUT) && d.ArgString.Contains(FfmpegData.TOKEN_VIDEO), ERR_NO_TOKENOUTPUT + Environment.NewLine + ERR_NO_TOKENVIDEO);
            try
            {
                //test that setting a valid argstring doesn't throw an exception
                d.ArgString = FfmpegData.ARG_STRING_DEFAULT;
                d.ArgString = FfmpegData.TOKEN_INPUT + FfmpegData.TOKEN_VIDEO + " " + FfmpegData.TOKEN_OUTPUT;
            }
            catch (ArgumentException)
            {
                Assert.Fail("[1] Arg exception testing ArgString");
            }
            //test that can still get replaced arg string after the previous tests
            Assert.IsNotNull(d.GetReplacedArgString(), "Replaced arg string null.");
            Console.Error.WriteLine("Tested: " + TestContext.CurrentContext.AssertCount.ToString() + " assertions.");
            Console.Error.WriteLine("End TestArgString()");
        }

        [Test]
        public void TestFfmpegPath()
        {
            Console.Error.WriteLine("Begin TestFfmpegPath()");
            d.FfmpegPath = TST_FFMPEG_PATH;
            Assert.IsNotNull(d.FfmpegPath, ERR_NULL_STR);
            Assert.IsTrue(d.IsFfmpegPath(TST_FFMPEG_PATH), ERR_BAD_FFMPEG_PATH);
            Console.Error.WriteLine("Tested: " + TestContext.CurrentContext.AssertCount.ToString() + " assertions.");
            Console.Error.WriteLine("End TestFfmpegPath()");
        }
    }
}