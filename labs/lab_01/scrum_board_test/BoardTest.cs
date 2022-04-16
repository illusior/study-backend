using Xunit;

using ScrumBoard.Board;
using ScrumBoard.Factory;
using System;

namespace ScrumBoardTest
{
    public class BoardUnitTest
    {
        [Fact]
        public void Created_board_named_correctly()
        {
            const string boardName = "TestBoardName";
            IBoard board = MockBoard(boardName);

            Assert.True(board.GetBoardName() == boardName);
        }

        [Fact]
        public void Adding_column_into_board_creates_column_in_board()
        {
            IBoard board = MockBoard("TestBoard");
            const string columnName = "TestColumn";

            board.AddColumn(columnName);

            Assert.True(board.GetColumnIndexByName(columnName) != -1);
        }

        [Fact]
        public void Adding_two_columns_with_equal_names_fails()
        {
            IBoard board = MockBoard("TestBoard");
            const string columnName = "TestColumn";

            board.AddColumn(columnName);

            Assert.Throws<Exception>(() => board.AddColumn(columnName));
            Assert.True(board.GetAllColumnsNames().Count == 1);
            Assert.True(board.GetAllColumnsNames()[0] == columnName);
        }

        [Fact]
        public void Adding_column_with_empty_name_gives_no_effect()
        {
            IBoard board = MockBoard("TestBoard");
            const string columnName = "";

            Assert.Throws<Exception>(() => board.AddColumn(columnName));
            Assert.True(board.GetAllColumnsNames().Count == 0);
        }

        [Fact]
        public void Adding_column_when_board_has_more_than_10_columns_gives_no_effect()
        {
            IBoard board = MockBoard("TestBoard");
            const string columnName = "Column";

            for (int i = 0; i < 10; ++i)
            {
                board.AddColumn(columnName + i.ToString());
            }

            Assert.Throws<Exception>(() => board.AddColumn(columnName + "10"));
            Assert.True(board.GetAllColumnsNames().Count == 10);
            Assert.True(!board.GetAllColumnsNames().Contains(columnName + "10"));
        }

        [Fact]
        public void Moving_column_changing_columns_index()
        {
            IBoard board = MockBoard("TestBoard");
            const string columnName = "Column";
            for (int i = 0; i < 4; ++i)
            {
                board.AddColumn(columnName + i.ToString());
            }

            //board.MoveColumnFromTo();
        }

        private IBoard MockBoard(string title)
        {
            return ScrumBoardFactory.CreateBoard(title);
        }
    }
}
