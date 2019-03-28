using System;
using TrelloAPI;
using NUnit.Framework;
using TrelloAPI.Models;
using TechTalk.SpecFlow;

namespace TrelloAPITest
{
    [Binding]
    public class TrelloBoardSteps
    {
        BoardService BoardService = new BoardService();

        [AfterScenario]
        public void CleanUp()
        {
            BoardService.DeleteAllBoards();
        }


        [Given(@"Empty name as a Board name")]
        public void GivenEmptyNameAsABoardName()
        {
            BoardCreationParameters = new BoardCreationParameters { Name = "" };
        }

        [Then(@"Trello Service returns (.*) error")]
        public void ThenTrelloServiceReturnsForNameError(string errorMessage)
        {
            StringAssert.Contains(errorMessage, Error);
        }

        [Given(@"Board Creation Parameters \((.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenBoardCreationParameters(string nameParam, string descParam, string defaultListsParam, string defaultLabelsParam, string idOrganizationParam)
        {
            var boardParams = new BoardCreationParameters();

            if (nameParam != string.Empty)
                boardParams.Name = nameParam;
            if (descParam != string.Empty)
                boardParams.Desc = descParam;
            if (defaultListsParam != string.Empty)
                boardParams.DefaultLists = defaultListsParam;
            if (defaultLabelsParam != string.Empty)
                boardParams.DefaultLabels = defaultLabelsParam;
            if (idOrganizationParam != string.Empty)
                boardParams.IdOrganization = idOrganizationParam;

            BoardCreationParameters = boardParams;
        }

        [Given(@"Default Board with predefined Lists")]
        public void DefaultBoardWithPredefinedLists()
        {
            var boardParams = new BoardCreationParameters();
            boardParams.Name = "Default name";
            boardParams.Desc = "Default desc";

            var createdBoard = BoardService.CreateBoard(boardParams);

            DefaultBoardId = createdBoard.Id;
        }

        [When(@"New Board is Being Created")]
        public void WhenNewBoardIsBeingCreated()
        {
            try
            {
                Board = BoardService.CreateBoard(BoardCreationParameters);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        [When(@"Default Board is Being Read")]
        public void WhenDefaultBoardIsBeingRead()
        {
            try
            {
                Board = BoardService.GetBoard(DefaultBoardId);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        [When(@"Default Board Name is Updated")]
        public void WhenDefaultNameIsUpdated()
        {
            try
            {
                Board = BoardService.UpdateBoardName(DefaultBoardId, "Updated name");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        [When(@"Default Board is Deleted")]
        public void WhenDefaultBoardIsDeleted()
        {
            try
            {
                BoardService.DeleteBoard(DefaultBoardId);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        [Then(@"Trello Service returns Board Entity with options \((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void ThenTrelloServiceReturnsBoardEntityWithOptions(string nameResult, string idOrganizationResult, string descResult, string descDataResult, bool closedResult, bool pinnedResult)
        {
            var createdBoard = Board;
            Assert.AreEqual(createdBoard.Name, nameResult);
            Assert.AreEqual(createdBoard.Description, descResult);
            Assert.AreEqual(createdBoard.DescData ?? string.Empty, descDataResult);
            Assert.AreEqual(createdBoard.Closed, closedResult);
            Assert.AreEqual(createdBoard.Pinned, pinnedResult);
        }

        [Then(@"Trello Service returns no default board")]
        public void ThenTrelloServiceReturnsNoDefaultBoard()
        {
            try
            {
                BoardService.GetBoard(DefaultBoardId);
                Assert.Fail("BoardService.GetBoard did not throw");
            }
            catch (Exception ex)
            {
                Assert.AreEqual($"Response Status Code: NotFound\n" +
                    $"Response Error Message: \n" +
                    $"Response Content: The requested resource was not found.",
                    ex.Message);
            }
        }

        private Board Board
        {
            get { return (Board)ScenarioContext.Current["Board"]; }
            set { ScenarioContext.Current["Board"] = value; }
        }

        private string DefaultBoardId
        {
            get { return (string)ScenarioContext.Current["DefaultBoardId"]; }
            set { ScenarioContext.Current["DefaultBoardId"] = value; }
        }

        private string Error
        {
            get { return (string)ScenarioContext.Current["Error"]; }
            set { ScenarioContext.Current["Error"] = value; }
        }

        private BoardCreationParameters BoardCreationParameters
        {
            get { return (BoardCreationParameters)ScenarioContext.Current["BoardCreationParameters"]; }
            set { ScenarioContext.Current["BoardCreationParameters"] = value; }
        }
    }
}
