using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if(matchesFound == 18)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
           // throw new NotImplementedException();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🦣","🦣",
                "🐑","🐑",
                "🦛","🦛",
                "🐪","🐪",
                "🐍","🐍",
                "🐊","🐊",
                "🐀","🐀",
                "🐟","🐟",
                "🦔","🦔",
                "🦨","🦨",
                "🦡","🦡",
                "🐐","🐐",
                "🐄","🐄",
                "🐖","🐖",
                "🦇","🦇",
                "🐒","🐒",
                "🐓","🐓",
                "🦜","🦜",
            };

            Random random = new Random();

            
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);

                    switch (index)
                    {
                        case < 2:
                            textBlock.Foreground = Brushes.Crimson;
                            break;
                        case < 4:
                            textBlock.Foreground = Brushes.Blue;
                            break;
                        case < 6:
                            textBlock.Foreground = Brushes.YellowGreen;
                            break;
                        case < 8:
                            textBlock.Foreground = Brushes.DarkOrange;
                            break;
                        case < 10:
                            textBlock.Foreground = Brushes.Brown;
                            break;
                        case < 12:
                            textBlock.Foreground = Brushes.OrangeRed;
                            break;
                        case < 14:
                            textBlock.Foreground = Brushes.DeepPink;
                            break;
                        case < 16:
                            textBlock.Foreground = Brushes.Purple;
                            break;
                        case < 18:
                            textBlock.Foreground = Brushes.BurlyWood;
                            break;
                        case < 20:
                            textBlock.Foreground = Brushes.DarkViolet;
                            break;
                        case < 22:
                            textBlock.Foreground = Brushes.Lime;
                            break;
                        case < 24:
                            textBlock.Foreground = Brushes.Maroon;
                            break;
                        case < 26:
                            textBlock.Foreground = Brushes.Aqua;
                            break;
                        case < 28:
                            textBlock.Foreground = Brushes.Sienna;
                            break;
                        case < 30:
                            textBlock.Foreground = Brushes.MistyRose;
                            break;
                        case < 32:
                            textBlock.Foreground = Brushes.IndianRed;
                            break;
                        case < 34:
                            textBlock.Foreground = Brushes.PaleTurquoise;
                            break;
                        default:
                            textBlock.Foreground = Brushes.Black;
                            break;

                    }

                    
                }
                
            }
            matchesFound = 0;
            //throw new NotImplementedException();
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if(findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch= false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            
            if (matchesFound == 18)
            {
                SetUpGame();

            }

        }
    }
}
