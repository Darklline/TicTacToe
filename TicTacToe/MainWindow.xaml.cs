using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Current results of cells
        /// </summary>
        private MarkType[] mResults;

        private bool mPlayer1Turn;
        private bool mGameEnded;

        #endregion
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        private void NewGame()
        {
            // New array of free cells
            mResults = new MarkType[9];
            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }
            // Player 1 starts the game
            mPlayer1Turn = true;

            // ForEach every button in UI
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //Default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            //New Game
            mGameEnded = false;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            // Button position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free) return;

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "O";

            if (!mPlayer1Turn) button.Foreground = Brushes.Red;
            //Change players turns
            mPlayer1Turn ^= true;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
                #region Horizontal Wins
                //  - Row 0
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
                {
                    mGameEnded = true;

                    Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                }
                //  - Row 1
                if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
                {
                    mGameEnded = true;

                    Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                }
                //  - Row 2
                if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
                {
                    mGameEnded = true;

                    Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                }

                #endregion

                #region Vertical Wins
                //  - Column 0
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
                {
                    mGameEnded = true;

                    Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                }
                //  - Column 1
                if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
                {
                    mGameEnded = true;

                    Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                }
                //  - Column 2
                if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
                {
                    mGameEnded = true;

                    Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                }

            #endregion

            #region Diagonally Wins
            //   Win '\'
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
                {
                    mGameEnded = true;

                    Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                }
                //   Win '/'
                if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
                {
                    mGameEnded = true;

                    Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
                }

                #endregion

                #region No Winners

                if (!mResults.Any(f => f == MarkType.Free))
                {
                    mGameEnded = true;

                    Container.Children.Cast<Button>().ToList().ForEach(button =>
                    {
                        button.Background = Brushes.Black;
                    });
                }

                #endregion
            }

        }
    }

