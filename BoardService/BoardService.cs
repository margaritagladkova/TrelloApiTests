using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TrelloAPI.Models;

namespace TrelloAPI
{
    public class BoardCreationParameters
    {
        public string Name { get; set;}
        public string DefaultLabels { get; set; }
        public string DefaultLists { get; set; }
        public string Desc { get; set; }
        public string IdOrganization { get; set; }
        public string IdBoardSource { get; set; }
        public string KeepFromSource { get; set; }
        public string PowerUps { get; set; }
        public string Prefs_permissionLevel { get; set; }
        public string Prefs_voting { get; set; }
        public string Prefs_comments { get; set; }
        public string Prefs_invitations { get; set; }
        public string Prefs_selfJoin { get; set; }
        public string Prefs_cardCovers { get; set; }
        public string Prefs_background { get; set; }
        public string Prefs_cardAging { get; set; }
    }

    public class BoardService
    {
        private RestClient client = new RestClient("https://api.trello.com/1");

        public Board CreateBoard(BoardCreationParameters parameters)
        {
            var request = CreateRequest("boards", Method.POST);
            
            if(parameters.Name != null)
                request.AddParameter("name", parameters.Name);

            if (parameters.DefaultLabels != null)
                request.AddParameter("defaultLabels", parameters.DefaultLabels);

            if (parameters.DefaultLists != null)
                request.AddParameter("defaultLists", parameters.DefaultLists);

            if (parameters.Desc != null)
                request.AddParameter("desc", parameters.Desc);

            if (parameters.IdOrganization != null)
                request.AddParameter("idOrganization", parameters.IdOrganization);

            if (parameters.IdBoardSource != null)
                request.AddParameter("idBoardSource", parameters.IdBoardSource);

            if (parameters.KeepFromSource != null)
                request.AddParameter("keepFromSource", parameters.KeepFromSource);

            if (parameters.PowerUps != null)
                request.AddParameter("powerUps", parameters.PowerUps);

            if (parameters.Prefs_permissionLevel != null)
                request.AddParameter("prefs_permissionLevel", parameters.Prefs_permissionLevel);

            if (parameters.Prefs_voting != null)
                request.AddParameter("prefs_voting", parameters.Prefs_voting);

            if (parameters.Prefs_comments != null)
                request.AddParameter("prefs_comments", parameters.Prefs_comments);

            if (parameters.Prefs_invitations != null)
                request.AddParameter("prefs_invitations", parameters.Prefs_invitations);

            if (parameters.Prefs_selfJoin != null)
                request.AddParameter("prefs_selfJoin", parameters.Prefs_selfJoin);

            if (parameters.Prefs_cardCovers != null)
                request.AddParameter("prefs_cardCovers", parameters.Prefs_cardCovers);

            if (parameters.Prefs_background != null)
                request.AddParameter("prefs_background", parameters.Prefs_background);

            if (parameters.Prefs_cardAging != null)
                request.AddParameter("prefs_cardAging", parameters.Prefs_cardAging);

            var response = client.Execute(request);

            VerifyOkCode(response);

            return JsonConvert.DeserializeObject<Board>(response.Content);
        }

        public Board GetBoard(string id)
        {
            var request = CreateRequest($"/boards/{id}", Method.GET);

            var response = client.Execute(request);

            VerifyOkCode(response);

            return JsonConvert.DeserializeObject<Board>(response.Content);
        }

        public Board UpdateBoardName(string id, string newName)
        {
            var request = CreateRequest($"/boards/{id}/name?value={newName}", Method.PUT);

            var response = client.Execute(request);

            VerifyOkCode(response);

            return JsonConvert.DeserializeObject<Board>(response.Content);
        }

        public void DeleteBoard(string id)
        {
            var request = CreateRequest($"/boards/{id}", Method.DELETE);
            var response = client.Execute(request);
        }

        public void DeleteAllBoards()
        {
            List<Board> boards = GetAllBoards();
            foreach(Board board in boards)
            {
                DeleteBoard(board.Id);
            }
        }

        public List<Board> GetAllBoards()
        {
            var request = CreateRequest("/members/margaritagladkova/boards", Method.GET);

            var response = client.Execute(request);
            VerifyOkCode(response);

            return JsonConvert.DeserializeObject<List<Board>>(response.Content);
        }

        public List<BoardList> GetLists(string boardId)
        {
            var request = CreateRequest("boards/" + boardId + "/lists", Method.GET);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode + response.Content);
            }

            return JsonConvert.DeserializeObject<List<BoardList>>(response.Content);
        }

        private RestRequest CreateRequest(string path, Method method)
        {
            var request = new RestRequest(path, method);
            request.AddParameter("key", "bba2bf9e4f007a7574747a0c049cf805");
            request.AddParameter("token", "3655984fd626a680f3ccaaf5acc1f08e01ce74077ac0435ea7cc09923501cf4a");
            return request;
        }

        private void VerifyOkCode(IRestResponse response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Response Status Code: {response.StatusCode}\n" +
                        $"Response Error Message: {response.ErrorMessage}\n" +
                        $"Response Content: {response.Content}");
            }
        }
    }
}
