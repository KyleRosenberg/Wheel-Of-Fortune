using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Reflection;

namespace WheelOfFortune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        int team1Score = 0;
        int team2Score = 0;
        int team3Score = 0;
        int scoreToGet;
        int currenteam = 1;
        TextBox[][] textBoxes = {
            new TextBox[12],
            new TextBox[14],
            new TextBox[14],
            new TextBox[12]
        };
        List<TextBox> box = new List<TextBox>();
        Random number = new Random();
        int number2;
        int spinnumber;
        int spinnernumber = 1;
        bool jackpot = false;
        bool vowel = false;
        String[] phrase;
        int currentPhrase = 0;
        List<string> GuessedLetters = new List<string>();
        SoundPlayer bankrupt = new SoundPlayer(WheelOfFortune.Properties.Resources.ubankrupt);
        SoundPlayer wrong = new SoundPlayer(WheelOfFortune.Properties.Resources.ubuzzer);
        SoundPlayer correct = new SoundPlayer(WheelOfFortune.Properties.Resources.uinpuzz);
        SoundPlayer cat = new SoundPlayer(WheelOfFortune.Properties.Resources.ucategory);
        SoundPlayer vowels = new SoundPlayer(WheelOfFortune.Properties.Resources.uchirps);
        SoundPlayer spin = new SoundPlayer(WheelOfFortune.Properties.Resources.ROULETTE__1_);
        List<string> phrases = new List<string>();
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            wheel.Visible = true;
            spinButton.Visible = false;
            timer1.Enabled = true;
            number2 = number.Next(27, 60);
            spinnumber = 0;
            vowel = false;
            spin.Play();
        }

        private void guessLetter()
        {
            guessBox.Visible = true;
            label6.Visible = true;
            wheel.Visible = false;
            buyVowel.Visible = false;
            guessPuzzel.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (number2 < spinnumber)
            {
                timer1.Enabled = false;
                spin.Stop();
                if (spinnernumber == 1 || 
                    spinnernumber == 17 ||
                    spinnernumber == 25 ||
                    spinnernumber == 9)
                {
                    MessageBox.Show("You landed on 1!");
                    scoreToGet = 1;
                    guessLetter();
                }
                else if (spinnernumber == 8 ||
                    spinnernumber == 26 ||
                    spinnernumber == 2 ||
                    spinnernumber == 20 ||
                    spinnernumber == 16 ||
                    spinnernumber == 10)
                {
                    MessageBox.Show("You landed on 2!");
                    scoreToGet = 2;
                    guessLetter();
                }
                else if (spinnernumber == 11 ||
                    spinnernumber == 15 ||
                    spinnernumber == 22 ||
                    spinnernumber == 3 ||
                    spinnernumber == 7)
                {
                    MessageBox.Show("You landed on 3!");
                    scoreToGet = 3;
                    guessLetter();
                }
                else if (spinnernumber == 13 ||
                    spinnernumber == 19 ||
                    spinnernumber == 5)
                {
                    MessageBox.Show("You landed on 5!");
                    scoreToGet = 5;
                    guessLetter();
                }
                else if (spinnernumber == 12 ||
                    spinnernumber == 14 ||
                    spinnernumber == 21 ||
                    spinnernumber == 6)
                {
                    MessageBox.Show("You landed on 4!");
                    scoreToGet = 4;
                    guessLetter();
                }
                else if (spinnernumber == 18)
                {
                    MessageBox.Show("Spin Again!");
                    wheel.Visible = false;
                    spinButton.Visible = true;
                }
                else if (spinnernumber == 24)
                {
                    MessageBox.Show("You landed on Jackpot!", "JACKPOT!");
                    MessageBox.Show("If you guess the letter correctly, you will win the jackpot!");
                    jackpot = true;
                    scoreToGet = 0;
                    guessLetter();
                }
                else if (spinnernumber == 23 ||
                    spinnernumber == 4)
                {
                    bankrupt.Play();
                    MessageBox.Show("You landed on BANKRUPT! You lost all your points!", "BANKRUPT!");
                    scoreToGet = 0;
                    if (currenteam == 1) 
                    {
                        team1Score = 0; 
                        t1score.Text = "0";
                    }
                    else if (currenteam == 2)
                    {
                        team2Score = 0;
                        t2score.Text = "0";
                    }
                    else if (currenteam == 3)
                    {
                        team3Score = 0;
                        t3score.Text = "0";
                    }
                    if (currenteam < 3) currenteam++;
                    else currenteam = 1;
                    MessageBox.Show("It is now team " + currenteam + "'s turn!");
                    t1.BackColor = Color.Transparent;
                    t2.BackColor = Color.Transparent;
                    t3.BackColor = Color.Transparent;
                    this.Controls.Find("t" + currenteam, true)[0].BackColor = Color.Gray;
                    wheel.Visible = false;
                    guessBox.Visible = false;
                    buyVowel.Visible = true;
                    guessPuzzel.Visible = true;
                    spinButton.Visible = true;
                }
            }
            else
            {
                spinnumber++;
                switch (spinnernumber)
                {
                    case 1:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F2;
                        break;
                    case 2:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F3;
                        break;
                    case 3:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F4;
                        break;
                    case 4:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F5;
                        break;
                    case 5:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F6;
                        break;
                    case 6:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F7;
                        break;
                    case 7:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F8;
                        break;
                    case 8:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F9;
                        break;
                    case 9:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F10;
                        break;
                    case 10:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F11;
                        break;
                    case 11:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F12;
                        break;
                    case 12:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F13;
                        break;
                    case 13:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F14;
                        break;
                    case 14:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F15;
                        break;
                    case 15:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F16;
                        break;
                    case 16:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F17;
                        break;
                    case 17:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F18;
                        break;
                    case 18:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F19;
                        break;
                    case 19:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F20;
                        break;
                    case 20:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F21;
                        break;
                    case 21:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F22;
                        break;
                    case 22:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F23;
                        break;
                    case 23:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F24;
                        break;
                    case 24:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F25;
                        break;
                    case 25:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F26;
                        break;
                    default:
                        wheel.BackgroundImage = WheelOfFortune.Properties.Resources.F1;
                        break;
                }
                spinnernumber++;
                if (spinnernumber > 26) spinnernumber = 1;
            }
        }

        private void guessBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                checkPhrase();
                guessBox.Text = "";
                label6.Visible = false;
            }
        }

        private bool checkForVowelsLeft()
        {
            List<string> vowels = new List<string>();
            for (int i = 0; i < textBoxes.Length; i++)
            {
                for (int j = 0; j < textBoxes[i].Length; j++)
                {
                    if (textBoxes[i][j].Visible)
                    {
                        if ((textBoxes[i][j].Tag.ToString().ToLower() == "a" ||
                            textBoxes[i][j].Tag.ToString().ToLower() == "e" ||
                            textBoxes[i][j].Tag.ToString().ToLower() == "i" ||
                            textBoxes[i][j].Tag.ToString().ToLower() == "o" ||
                            textBoxes[i][j].Tag.ToString().ToLower() == "u")
                            && textBoxes[i][j].Text == "" && textBoxes[i][j].BackColor != Color.Blue)
                        {
                            vowels.Add(textBoxes[i][j].Tag.ToString().ToLower());
                        }
                    }
                }
            }
            for (int i = 0; i<phrases[currentPhrase].Length; i++)
            {
                if (vowels.Contains(phrases[currentPhrase].Substring(i, 1).ToLower())) return true;
            }
            return false;
        }

        private void checkPhrase()
        {
            if (vowel)
            {
                if (guessBox.Text.ToLower() == "a" || 
                    guessBox.Text.ToLower() == "e" ||
                    guessBox.Text.ToLower() == "i" ||
                    guessBox.Text.ToLower() == "o" || 
                    guessBox.Text.ToLower() == "u")
                {
                    if (GuessedLetters.Contains(guessBox.Text.ToUpper()) || GuessedLetters.Contains(guessBox.Text.ToUpper()))
                    {
                        MessageBox.Show("You already guessed " + guessBox.Text.ToUpper() + "!");
                    }
                    else
                    {
                        if (phrase.Contains(guessBox.Text.ToUpper()) || phrase.Contains(guessBox.Text.ToLower()))
                        {
                            MessageBox.Show("There are " + guessBox.Text.ToUpper() + "'s !");
                            int i;
                            for (i = 0; i < textBoxes[0].Length; i++)
                            {
                                doContains(textBoxes[0][i]);
                            }
                            for (i = 0; i < textBoxes[1].Length; i++)
                            {
                                doContains(textBoxes[1][i]);
                            }
                            for (i = 0; i < textBoxes[2].Length; i++)
                            {
                                doContains(textBoxes[2][i]);
                            }
                            for (i = 0; i < textBoxes[3].Length; i++)
                            {
                                doContains(textBoxes[3][i]);
                            }
                            if (checkForVowelsLeft() == false)
                            {
                                vowels.Play();
                                MessageBox.Show("There are no more vowels!");
                            }
                        }
                        else if (GuessedLetters.Contains(guessBox.Text.ToUpper()))
                        {
                            MessageBox.Show("You already guessed " + guessBox.Text.ToUpper() + "!");
                            return;
                        }
                        else
                        {
                            wrong.Play();
                            MessageBox.Show("There are no " + guessBox.Text.ToUpper() + "'s !");
                            if (currenteam != 3)
                            {
                                currenteam++;
                                MessageBox.Show("It is now team " + currenteam + "'s turn!");
                            }
                            else
                            {
                                currenteam = 1;
                                MessageBox.Show("It is now team " + currenteam + "'s turn!");
                            }
                            t1.BackColor = Color.Transparent;
                            t2.BackColor = Color.Transparent;
                            t3.BackColor = Color.Transparent;
                            this.Controls.Find("t" + currenteam, true)[0].BackColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must guess a vowel!");
                    return;
                }
            }
            else if (!vowel)
            {
                if (guessBox.Text.ToLower() != "a" && guessBox.Text.ToLower() != "e" && guessBox.Text.ToLower() != "i" && guessBox.Text.ToLower() != "o" && guessBox.Text.ToLower() != "u")
                {
                    if ((phrase.Contains(guessBox.Text.ToUpper()) && !GuessedLetters.Contains(guessBox.Text.ToUpper())) ||
                        (phrase.Contains(guessBox.Text.ToLower()) && !GuessedLetters.Contains(guessBox.Text.ToLower())))
                    {
                        MessageBox.Show("There are " + guessBox.Text.ToUpper() + "'s !");
                        if (jackpot)
                        {
                            int avg = Convert.ToInt32(Math.Floor((double)team1Score + team2Score + team3Score) / 3);
                            scoreToGet = Convert.ToInt32((avg)+Math.Floor(8.0/(avg+4)));
                            MessageBox.Show("You have earned " + scoreToGet + " points per " + guessBox.Text.ToUpper() + "!");
                            jackpot = false;
                        }
                        int i;
                        for (i = 0; i < textBoxes[0].Length; i++)
                        {
                            doContains(textBoxes[0][i]);
                        }
                        for (i = 0; i < textBoxes[1].Length; i++)
                        {
                            doContains(textBoxes[1][i]);
                        }
                        for (i = 0; i < textBoxes[2].Length; i++)
                        {
                            doContains(textBoxes[2][i]);
                        }
                        for (i = 0; i < textBoxes[3].Length; i++)
                        {
                            doContains(textBoxes[3][i]);
                        }
                    }
                    else
                    {
                        wrong.Play();
                        MessageBox.Show("There are no " + guessBox.Text.ToUpper() + "'s !"); 
                        if (currenteam != 3)
                        {
                            currenteam++;
                            MessageBox.Show("It is now team " + currenteam + "'s turn!");
                        }
                        else
                        {
                            currenteam = 1;
                            MessageBox.Show("It is now team " + currenteam + "'s turn!");
                        }
                        t1.BackColor = Color.Transparent;
                        t2.BackColor = Color.Transparent;
                        t3.BackColor = Color.Transparent;
                        this.Controls.Find("t" + currenteam, true)[0].BackColor = Color.Gray;
                        if (jackpot) jackpot = false;
                    }
                }
                else
                {
                    MessageBox.Show("You cannot guess a vowel!");
                    return;
                }
            }
            guessedLetters.Text += guessBox.Text.ToUpper() + " ";
            GuessedLetters.Add(guessBox.Text.ToUpper());
            guessBox.Visible = false;
            buyVowel.Visible = true;
            guessPuzzel.Visible = true;
            spinButton.Visible = true;
        }

        private void doContains(TextBox tb)
        {
            TextBox temp = tb as TextBox;
            if (temp != null && temp.Visible)
            {
                if (temp.Tag.ToString().ToUpper() == guessBox.Text.ToUpper())
                {
                    temp.BackColor = Color.Blue;
                    if (currenteam == 1)
                    {
                        team1Score += scoreToGet;
                        t1score.Text = team1Score.ToString();
                    }
                    else if (currenteam == 2)
                    {
                        team2Score += scoreToGet;
                        t2score.Text = team2Score.ToString();
                    }
                    else if (currenteam == 3)
                    {
                        team3Score += scoreToGet;
                        t3score.Text = team3Score.ToString();
                    }
                }
            }
        }

        private void generatePhrase(int num)
        {
            currentPhrase = num;
            String[] temp = new String[phrases[currentPhrase].Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = phrases[currentPhrase].Substring(i, 1);
            }
            phrase = temp; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cat.Play();
            phrases.Add("LOAD A PUZZLE FILE!");
            fillTextBoxArray();
            generatePhrase(number.Next(phrases.Count));
            setTextBoxes();
            timer3.Enabled = true;
        }

        private void fillTextBoxArray()
        {
            int i;
            for (i = 0; i < textBoxes[0].Length; i++ )
            {
                textBoxes[0][i] = this.Controls.Find("textBox" + (i+1), true)[0] as TextBox;
                textBoxes[0][i].Visible = false;
                textBoxes[0][i].Text = "";
                textBoxes[0][i].MouseDown += textBoxMouseDown;
                textBoxes[0][i].TextAlign = HorizontalAlignment.Center;
                textBoxes[0][i].ReadOnly = true;
                textBoxes[0][i].BackColor = Color.White;
                //MessageBox.Show(textBoxes[0][i].Name + ", " + textBoxes[0].Length);
            } 
            for (i = 0; i < textBoxes[1].Length; i++)
            {
                textBoxes[1][i] = this.Controls.Find("textBox" + (i + 13), true)[0] as TextBox;
                textBoxes[1][i].Visible = false;
                textBoxes[1][i].Text = "";
                textBoxes[1][i].MouseDown += textBoxMouseDown;
                textBoxes[1][i].TextAlign = HorizontalAlignment.Center;
                textBoxes[1][i].ReadOnly = true;
                textBoxes[1][i].BackColor = Color.White;
                //MessageBox.Show(textBoxes[1][i].Name + ", " + textBoxes[1].Length);
            }
            for (i = 0; i < textBoxes[2].Length; i++)
            {
                textBoxes[2][i] = this.Controls.Find("textBox" + (i + 27), true)[0] as TextBox;
                if (textBoxes[2][i].Name == "textBox41" || i + 27 == 41) MessageBox.Show("Yes");
                textBoxes[2][i].Visible = false;
                textBoxes[2][i].Text = "";
                textBoxes[2][i].MouseDown += textBoxMouseDown;
                textBoxes[2][i].TextAlign = HorizontalAlignment.Center;
                textBoxes[2][i].ReadOnly = true;
                textBoxes[2][i].BackColor = Color.White;
                //MessageBox.Show(textBoxes[2][i].Name + ", " + textBoxes[2].Length);
            }
            for (i = 0; i < textBoxes[3].Length; i++)
            {
                textBoxes[3][i] = this.Controls.Find("textBox" + (i + 41), true)[0] as TextBox;
                textBoxes[3][i].Visible = false;
                textBoxes[3][i].Text = "";
                textBoxes[3][i].MouseDown += textBoxMouseDown;
                textBoxes[3][i].TextAlign = HorizontalAlignment.Center;
                textBoxes[3][i].ReadOnly = true;
                textBoxes[3][i].BackColor = Color.White;
                //MessageBox.Show(textBoxes[3][i].Name + ", " + textBoxes[0].Length);
            } 
        }

        private void setTextBoxes()
        {
            String tempphrase = phrases[currentPhrase];
            int boxstart = 0;
            int lineNum = 0;
            int lineLength = textBoxes[lineNum].Length;
            int end = tempphrase.IndexOf(" ");
            if (end == -1) end = tempphrase.Length;
            bool going = true;
            while (going)
            {
                int i;
                for (i = boxstart; i < boxstart+end; i++)
                {
                    textBoxes[lineNum][i].Tag = tempphrase.Substring(i-boxstart, 1);
                    textBoxes[lineNum][i].Visible = true;
                    if (!Char.IsLetter(tempphrase, i - boxstart))
                    {
                        textBoxes[lineNum][i].Text = textBoxes[lineNum][i].Tag.ToString();
                    }
                    //MessageBox.Show(textBoxes[lineNum][i].Tag.ToString());
                }
                boxstart = i+1;
                if (tempphrase.IndexOf(" ") == -1)
                {
                    going = false;
                    //return;
                }
                int ind = end + 1;
                int leng = tempphrase.Length - (end+1);
                tempphrase = tempphrase.Substring(ind, leng);
                end = tempphrase.IndexOf(" ");
                if (end == -1) end = tempphrase.Length;
                if (boxstart + end > lineLength) 
                { 
                    if (lineNum < 3) 
                    { 
                        lineNum++; 
                        lineLength = textBoxes[lineNum].Length;
                        boxstart = 0;
                    } 
                    else return; 
                }
            }
        }

        private void buyVowel_Click(object sender, EventArgs e)
        {
            scoreToGet = 0;
            if (MessageBox.Show(this, "Are you sure you would like to buy a vowel?", "Buy Vowel", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (currenteam == 1)
                {
                    if (team1Score >= 2)
                    {
                        guessBox.Visible = true;
                        vowel = true;
                        team1Score -= 2;
                    }
                    else MessageBox.Show("You do not have enough points. You must have at least 2!", "Not Enough Points!");
                }
                else if (currenteam == 2)
                {
                    if (team2Score >= 2)
                    {
                        guessBox.Visible = true;
                        vowel = true;
                        team2Score -= 2;
                    }
                    else MessageBox.Show("You do not have enough points. You must have at least 2!", "Not Enough Points!");
                }
                if (currenteam == 3)
                {
                    if (team3Score >= 2)
                    {
                        guessBox.Visible = true;
                        vowel = true;
                        team3Score -= 2;
                    }
                    else MessageBox.Show("You do not have enough points. You must have at least 2!", "Not Enough Points!");
                }
            }
        }

        private void skipTurn_Click(object sender, EventArgs e)
        {
            spinButton.Visible = false;
            buyVowel.Visible = false;
            guessPuzzel.Visible = false;
            label6.Visible = false;
            guessThePhrase.Visible = true;
        }

        private void textBoxMouseDown(object sender, EventArgs e)
        {
            TextBox inQuestion = sender as TextBox;
            if (inQuestion.BackColor == Color.Blue)
            {
                correct.Play();
                inQuestion.Text = inQuestion.Tag.ToString();
                inQuestion.BackColor = Color.White;
            }
        }

        private void textBox28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guessThePhrase.Text.ToLower() == phrases[currentPhrase].ToLower())
                {
                    MessageBox.Show("Team " + currenteam + " has solved the puzzle! \n" + "They have earned 1 point for each letter not guessed yet. \n" + "The game is over.");
                    scoreToGet = 0;
                    int i;
                    for (i = 0; i < textBoxes[0].Length; i++)
                    {
                        if (textBoxes[0][i].Visible == true && textBoxes[0][i].Text == "")
                        {
                            scoreToGet++;
                            textBoxes[0][i].BackColor = Color.Blue;
                        }
                    }
                    for (i = 0; i < textBoxes[1].Length; i++)
                    {
                        if (textBoxes[1][i].Visible == true && textBoxes[1][i].Text == "")
                        {
                            scoreToGet++;
                            textBoxes[1][i].BackColor = Color.Blue;
                        }
                    }
                    for (i = 0; i < textBoxes[2].Length; i++)
                    {
                        if (textBoxes[2][i].Visible == true && textBoxes[2][i].Text == "")
                        {
                            scoreToGet++;
                            textBoxes[2][i].BackColor = Color.Blue;
                        }
                    }
                    for (i = 0; i < textBoxes[3].Length; i++)
                    {
                        if (textBoxes[3][i].Visible == true && textBoxes[3][i].Text == "")
                        {
                            scoreToGet++;
                            textBoxes[3][i].BackColor = Color.Blue;
                        }
                    }
                    guessThePhrase.Visible = false;
                    if (currenteam == 1) team1Score += scoreToGet; t1score.Text = team1Score.ToString();
                    if (currenteam == 2) team2Score += scoreToGet; t2score.Text = team2Score.ToString();
                    if (currenteam == 3) team3Score += scoreToGet; t3score.Text = team3Score.ToString();
                    for (int k = 0; k < textBoxes.Length; k++)
                    {
                        for (int j = 0; j < textBoxes[k].Length; j++)
                        {
                            if (textBoxes[k][j].Visible) box.Add(textBoxes[k][j]);
                        }
                    }
                    timer2.Enabled = true;
                    MessageBox.Show("Team 1 has  " + team1Score + " Points! \n" + "Team 2 has " + team2Score + " Points! \n" + "Team 3 has " + team3Score + " Points! \n");
                }
                else
                {
                    MessageBox.Show("Sorry, that is not the phrase!");
                    if (currenteam != 3)
                    {
                        wrong.Play();
                        currenteam++;
                        MessageBox.Show("It is now team " + currenteam + "'s turn!");
                    }
                    else
                    {
                        currenteam = 1;
                        MessageBox.Show("It is now team " + currenteam + "'s turn!");
                    }
                    t1.BackColor = Color.Transparent;
                    t2.BackColor = Color.Transparent;
                    t3.BackColor = Color.Transparent;
                    this.Controls.Find("t" + currenteam, true)[0].BackColor = Color.Gray;
                    spinButton.Visible = true;
                    buyVowel.Visible = true;
                    guessPuzzel.Visible = true;
                    label6.Visible = true;
                    guessThePhrase.Visible = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int boxnum = 0;
            while (box[boxnum].BackColor == Color.White)
            {
                boxnum++;
                if (boxnum >= box.Count)
                {
                    timer2.Enabled = false;
                    restart.Visible = true;
                    return;
                }
            }
            box[boxnum].BackColor = Color.White;
            correct.Play();
            box[boxnum].Text = box[boxnum].Tag.ToString();
            if (boxnum >= box.Count)
            {
                timer2.Enabled = false;
                restart.Visible = true;
            }
            
        }

        private void restart_Click(object sender, EventArgs e)
        {
            if (currenteam != 3) currenteam++;
            else currenteam = 1;
            team1Score = 0;
            team2Score = 0;
            team3Score = 0;
            genNewPuzzle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo[] dis = di.GetDirectories();
            for (int i = 0; i < dis.Length; i++)
            {
                if (dis[i].Name == "Resources") openFileDialog1.InitialDirectory = dis[i].FullName;
            }
            
            openFileDialog1.Filter = "Puzzle files (*.pzl)|*.pzl";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    phrases.Add(line);
                }
                sr.Close();
            }
            genNewPuzzle();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            bool solved = true;
            for (int i = 0; i < textBoxes.Length; i++)
            {
                for (int j = 0; j < textBoxes[i].Length; j++)
                {
                    if (textBoxes[i][j].Visible && (textBoxes[i][j].Text != textBoxes[i][j].Tag.ToString() && textBoxes[i][j].BackColor != Color.Blue))
                        solved = false;
                }
            }
            if (solved)
            {
                MessageBox.Show("Team 1 has  " + team1Score + " Points! \n" + "Team 2 has " + team2Score + " Points! \n" + "Team 3 has " + team3Score + " Points! \n");
                restart.Visible = true;
                timer3.Enabled = false;
            }
        }

        private void clearPuzl_Click(object sender, EventArgs e)
        {
            phrases.Clear();
            phrases.Add("LOAD A PUZZLE FILE!");
            genNewPuzzle();
        }

        private void textBox53_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                string phrase = textBox53.Text.ToUpper();
                phrases.Add(phrase);
                currentPhrase = phrases.Count - 1;
                genNewPuzzle();
            }
        }

        private void addPhrase_Click(object sender, EventArgs e)
        {
            textBox53.Visible = true;
            cancel.Visible = true;
        }

        private void textBox53_MouseLeave(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            if (temp.Text == "")
            {
                temp.ForeColor = Color.DarkGray;
                temp.Text = "Enter A Phrase";
            }
        }

        private void textBox53_MouseEnter(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            if (temp.ForeColor == Color.DarkGray)
            {
                temp.ForeColor = Color.Black;
                temp.Text = "";
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            textBox53.Text = "Enter A Phrase";
            textBox53.ForeColor = Color.DarkGray;
            textBox53.Visible = false;
            cancel.Visible = false;
        }

        private void newPuzzle_Click(object sender, EventArgs e)
        {
            genNewPuzzle();
        }

        private void genNewPuzzle()
        {
            cat.Play();
            team1Score = 0;
            team2Score = 0;
            team3Score = 0;
            t1score.Text = team1Score.ToString();
            t2score.Text = team2Score.ToString();
            t3score.Text = team3Score.ToString();
            t1.BackColor = Color.Transparent;
            t2.BackColor = Color.Transparent;
            t3.BackColor = Color.Transparent;
            this.Controls.Find("t" + currenteam, true)[0].BackColor = Color.Gray;
            fillTextBoxArray();
            currentPhrase = number.Next(phrases.Count);
            generatePhrase(currentPhrase);
            setTextBoxes();
            guessedLetters.Text = "";
            GuessedLetters.Clear();
            buyVowel.Visible = true;
            guessPuzzel.Visible = true;
            spinButton.Visible = true;
            label6.Visible = false;
            restart.Visible = false;
            timer3.Enabled = true;
            textBox53.Visible = false;
            cancel.Visible = false;
        }
    }
}
