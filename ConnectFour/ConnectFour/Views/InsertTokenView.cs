using ConnectFour.Models;
using System;
namespace ConnectFour.Views
{
    class InsertTokenView
    {
        private readonly Game game;
        public InsertTokenView(Game game)
        {
            this.game = game;
        }  
        public int ReadColumnNumber()
        {
            int columnNumber;
            bool isNumber;
            do
            {
                Message.WriteInsertColumnNumber();
                string columnString = Console.ReadLine();
                isNumber = int.TryParse(columnString, out columnNumber);
            } while (!isNumber);
            return columnNumber;
        }
        public bool CanInsertIntoColumn(int columnNumber)
        {
            bool canInsertIntoColumn = this.game.CanInsertIntoColumn(columnNumber);
            if (!canInsertIntoColumn)
            {
                Message.WriteCanNotInsertIntoSelectedColumn(columnNumber);
            }
            return canInsertIntoColumn;
        }
    }
}
