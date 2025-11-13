using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Sarah = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;
        string currentOperation = "";
        int step = 0;
        double num1, num2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechDetected);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            if (speech == "Hello")
            {
                Sarah.SpeakAsync("Hello, I am here");
            }
            else if (speech == "How are you")
            {
                Sarah.SpeakAsync("I am working normally");
            }
            else if (speech == "What date is it today")
            {
                Sarah.SpeakAsync(DateTime.Now.ToString("MMMM dd, yyyy"));
            }
            else if (speech == "What Islamic date is it today")
            {
                HijriCalendar hijri = new HijriCalendar();
                DateTime now = DateTime.Now;
                string hijriDate = string.Format("{0} {1} {2}",
                    hijri.GetDayOfMonth(now),
                    hijri.GetMonth(now),
                    hijri.GetYear(now));
                Sarah.SpeakAsync($"The Hijri date today is {hijriDate}");
            }
            else if (speech == "What time is it")
            {
                Sarah.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            else if (speech == "Math")
            {
                Sarah.SpeakAsync("Which operation would you like to perform? Say 1 for Addition, 2 for Subtraction, 3 for Multiplication, or 4 for Division.");
                step = 1;
            }
            else if (step == 1)
            {
                if (speech == "1" || speech == "2" || speech == "3" || speech == "4")
                {
                    switch (speech)
                    {
                        case "1":
                            currentOperation = "Addition";
                            break;
                        case "2":
                            currentOperation = "Subtraction";
                            break;
                        case "3":
                            currentOperation = "Multiplication";
                            break;
                        case "4":
                            currentOperation = "Division";
                            break;
                    }
                    Sarah.SpeakAsync("Please provide the first number.");
                    step = 2;
                }
                else
                {
                    Sarah.SpeakAsync("Please choose a valid operation: Say 1 for Addition, 2 for Subtraction, 3 for Multiplication, or 4 for Division.");
                }
            }
            else if (step == 2)
            {
                if (double.TryParse(speech, out num1))
                {
                    Sarah.SpeakAsync("Please provide the second number.");
                    step = 3;
                }
                else
                {
                    Sarah.SpeakAsync("I couldn't understand the number. Please provide the first number.");
                }
            }
            else if (step == 3)
            {
                if (double.TryParse(speech, out num2))
                {
                    PerformCalculation();
                    step = 0;
                }
                else
                {
                    Sarah.SpeakAsync("I couldn't understand the number. Please provide the second number.");
                }
            }
            else if (speech == "Stop talking")
            {
                Sarah.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    Sarah.SpeakAsync("Yes Sir");
                }
                if (ranNum == 2)
                {
                    Sarah.SpeakAsync("I'm sorry, I will be quiet");
                }
            }
            else if (speech == "Stop listening")
            {
                Sarah.SpeakAsync("If you need me, just ask");
                _recognizer.RecognizeAsyncCancel();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
            }
            else if (speech == "Show commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                LstCommands.Items.Clear();
                LstCommands.SelectionMode = SelectionMode.None;
                LstCommands.Visible = true;
                foreach (string command in commands)
                {
                    LstCommands.Items.Add(command);
                }
            }
            else if (speech == "Hide commands")
            {
                LstCommands.Visible = false;
            }
            else if (speech == "Goodbye Sarah")
            {
                Sarah.SpeakAsync("Goodbye. Have a great day!");
                Application.Exit();
            }
            else if (speech == "Open YouTube")
            {
                OpenWebsite("https://www.youtube.com");
                Sarah.SpeakAsync("Opening YouTube.");
            }
        }

        private void PerformCalculation()
        {
            double result = 0;
            switch (currentOperation)
            {
                case "Addition":
                    result = num1 + num2;
                    break;
                case "Subtraction":
                    result = num1 - num2;
                    break;
                case "Multiplication":
                    result = num1 * num2;
                    break;
                case "Division":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Sarah.SpeakAsync("Cannot divide by zero.");
                        return;
                    }
                    break;
            }
            Sarah.SpeakAsync($"The result of {currentOperation} is {result}");
        }

        private void _recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                Sarah.SpeakAsync("Yes, I'm here. Hello again.");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void LstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OpenWebsite(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                Sarah.SpeakAsync("Sorry, I couldn't open the website.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                TmrSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }
    }
}
