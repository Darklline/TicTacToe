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
    }
}
