using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDAL;
using CoreDAL.Dto;
using CoreLogic;
using CoreService;
using CoreService.Dto;
using NSubstitute;
using NUnit.Framework;

namespace CoreLogicTests
{
    [TestFixture]
    public class BoardLogicTests
    {
        [Test]
        public void Is_Success()
        {

            var _apiService = Substitute.For<IApiService>();
            _apiService.PostApi<BoardQueryDto, BoardQueryResp>(null)
                .ReturnsForAnyArgs(new BoardQueryResp() {IsSuccess = true, Items = new List<BoardQueryRespItem>()});

            var _boardDa = Substitute.For<IBoardDa>();
            _boardDa.GetBoardData(new List<string>()).ReturnsForAnyArgs(new List<BoardDto>());
            
            IBoardLogic boardLogic = new BoardLogic(null, _boardDa, _apiService);

            var boardList = boardLogic.GetBoardList(null, 0).Result;

            Assert.IsTrue(boardList.IsSuccess);
        }

        [Test]
        public void Is_Fail()
        {

            var _apiService = Substitute.For<IApiService>();
            _apiService.PostApi<BoardQueryDto, BoardQueryResp>(null)
                .ReturnsForAnyArgs(new BoardQueryResp() { IsSuccess = false, Items = null });

            IBoardLogic boardLogic = new BoardLogic(null, null, _apiService);

            var boardList = boardLogic.GetBoardList(null, 0).Result;

            Assert.IsFalse(boardList.IsSuccess);
        }
    }
}