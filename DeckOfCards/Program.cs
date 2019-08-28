using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

/* Author Ilgiz.
 * This is a console application.
 * This app asks a few question to determine what user wants to see.
 * User can choose between 52 or 32 cards in a deck.
 * After that user can choose to see all cards or one by one.
 */

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro message about this app.
            string intro = "=================================\r\n" +
                           "App to work with a deck of cards.\r\n" +
                           "Author - Ilgiz Urazbaev.\r\n" +
                           "=================================\r\n";
            Console.WriteLine(intro);

            // First question.
            Console.WriteLine("Please press '1' or '2' to choose the size of the deck:\r\n" +
                              "1 - Standard 52-card deck\r\n" +
                              "2 - Stripped 32-card deck\r\n");
            int input_first = Validate();
            int size_of_deck = FirstInputConfirmation(input_first);

            // Second question and decision what to show.
            Console.WriteLine("Do you want to see only one random card or all cards?\r\n" +
                              "Please press '1' or '2' to choose.\r\n" +
                              "1 - To show one card.\r\n" +
                              "2 - To show all cards.\r\n");
            int input_second = Validate();
            SecondInputConfirmation(size_of_deck, input_second);

            Console.WriteLine("You saw all cards. Press 'ESC' or 'X' to Exit.\r\n");
            CloseConsole();
        }

        //Reply with a user choice on a First question
        private static int FirstInputConfirmation(int input_first)
        {
            int size = 0;
            if (input_first == 1){
                Console.WriteLine("You chose a standard deck.\r\n");
                size = 52;
            } else if (input_first == 2) {
                Console.WriteLine("You chose a stripped deck.\r\n");
                size = 32;
            } else {
                Console.WriteLine("You typed a wrong number. Press 'ESC' or 'X' to Exit.\r\n");
                CloseConsole();
            }
            return size;
        }

        //Reply with a user choice on a Second question
        private static void SecondInputConfirmation(int size_of_deck, int input_second)
        {
            if (input_second == 1) {
                Console.WriteLine("You chose to show cards one by one.\r\n");
                ShowOneCard(size_of_deck);
            }
            else if (input_second == 2) {
                Console.WriteLine("You chose to show all cards.\r\n");
                ShowAllCards(size_of_deck);
            }
            else {
                Console.WriteLine("You typed a wrong number. Press 'ESC' or 'X' to Exit.\r\n");
                CloseConsole();
            }
        }

        //Validation to avoid anything except integers
        private static int Validate()
        {
            int input;
            String Result = Console.ReadLine();
            while (!Int32.TryParse(Result, out input)) {
                Console.WriteLine("Not a valid answer, try again.");
                Result = Console.ReadLine();
            }
            return input;
        }

        //Method to show all cards in the deck
        private static void ShowAllCards(int size)
        {
            Deck deck = new Deck(size);
            deck.Shuffle();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0,-19}", deck.ShowCards());
                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
            }
        }

        //Method to show only one card and ask about the next one
        private static void ShowOneCard(int size)
        {
            Deck deck = new Deck(size);
            deck.Shuffle();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0,-19}", deck.ShowCards());
                Console.WriteLine("\r\nDo you want to see a next card or do you want to close this app?\r\n" +
                                  "1 - Next card.\r\n" +
                                  "2 - Close.\r\n");
                int input_third = Validate();
                if (input_third == 1) {
                    Console.WriteLine("Next card is:\r\n");
                } else if (input_third == 2) {
                    Console.WriteLine("Application is ready to close. Press 'ESC' or 'X' to Exit.\r\n");
                    CloseConsole();
                } else { 
                    Console.WriteLine("You typed a wrong number. Press 'ESC' or 'X' to Exit.\r\n");
                    CloseConsole();
                }
            }
        }

        //Method to close application
        private static void CloseConsole()
        {
            ConsoleKeyInfo keys;
            while (true)
            {
                keys = Console.ReadKey();
                if (keys.Key == ConsoleKey.Escape || keys.Key == ConsoleKey.X)
                    System.Environment.Exit(-1);
                Console.WriteLine();
            }
        }
    }
}
