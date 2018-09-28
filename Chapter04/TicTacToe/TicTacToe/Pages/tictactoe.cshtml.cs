using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Pages
{
    public class tictactoeModel : BlazorComponent
    {
        protected char currentPlayer { get; set; }
        protected char winner { get; set; }
        protected bool win { get; set; } = false;

        protected int[] gameBoard = new int[3] { 0, 1, 2 };

        protected char[,] cellValue = new char[3, 3];
        protected override async Task OnInitAsync()
        {
            await Task.Run(() =>
            {
                ResetGame();
            });
        }

        // Check for win condition
        protected bool GameWon()
        {
            for (int i = 0; i < 3; i++)
            {
                // Check for winning on row
                if ((cellValue[i, 0] == cellValue[i, 1]) && (cellValue[i, 1] == cellValue[i, 2]) && cellValue[i, 0] != '\0')
                {
                    win = true;
                }
                // Check for winning on column
                else if ((cellValue[0, i] == cellValue[1, i]) && (cellValue[1, i] == cellValue[2, i]) && cellValue[0, i] != '\0')
                {
                    win = true;
                }
            }

            // Check for winning on diagonal
            if ((cellValue[0, 0] == cellValue[1, 1]) && (cellValue[1, 1] == cellValue[2, 2]) && cellValue[0, 0] != '\0')
            {
                win = true;

            }
            else if ((cellValue[0, 2] == cellValue[1, 1]) && (cellValue[1, 1] == cellValue[2, 0]) && cellValue[0, 2] != '\0')
            {
                win = true;
            }

            return win;
        }

        // Set the cell value in game board
        protected void SetCellValue(int row, int col)
        {
            if (cellValue[row, col] == '\0' && !GameWon())
            {
                cellValue[row, col] = currentPlayer;
                if (GameWon())
                {
                    winner = currentPlayer;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        protected void ResetGame()
        {
            currentPlayer = 'X';
            this.win = false;

            Array.Clear(cellValue, 0, cellValue.Length);
        }
    }
}