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
            Message.WriteInsertColumnNumber();
            string columnString = Console.ReadLine();
            bool isNumber = int.TryParse(columnString, out int columnNumber);
            while (!isNumber)
            {
                Message.WriteInsertValidColumnNumber();
                columnString = Console.ReadLine();
                isNumber = int.TryParse(columnString, out columnNumber);
            }
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
