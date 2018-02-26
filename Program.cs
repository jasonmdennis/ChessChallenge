using System;
using System.Text.RegularExpressions;

namespace ChessMoves
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * args 0 = name
             * args 1 = position
             * */
            if (args.Length == 2)
            {
                string pieceType = args[0].ToLower();
                string curPosition = args[1];

                string moveList = getMoves(pieceType, curPosition);
                Console.WriteLine(moveList);
            }
            else
            {
                Console.WriteLine("Please include piece and the the position");
            }
            // Keep the console window open.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        public static string getMoves(string pieceType, string curPosition)
        {
            string moveResponse = "";
            try
            {
                Regex regex = new Regex("^[a-h]{1}[1-8]{1}$");

                if (regex.IsMatch(curPosition))
                {
                    switch (pieceType)
                    {
                        case "queen":
                            BRL.Queen q = new BRL.Queen();
                            moveResponse = q.GetMoves(curPosition);
                            break;
                        case "knight":
                            BRL.Knight k = new BRL.Knight();
                            moveResponse = k.GetMoves(curPosition);
                            break;
                        case "rook":
                            BRL.Rook r = new BRL.Rook();
                            moveResponse = r.GetMoves(curPosition);
                            break;
                        default:
                            moveResponse = "Unknown piece";
                            break;
                    }
                }
                else throw new Exception("invalid position");
            }
            catch (Exception ex)
            {
                moveResponse = "error!";
                if (ex != null)
                {
                    moveResponse += " " + ex.Message;
                }
            }

            return moveResponse;
        }
    }
}