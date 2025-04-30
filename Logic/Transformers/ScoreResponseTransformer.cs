using Logic.DTOs.Responses;
using Logic.Transformers.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Transformers
{
    public class ScoreResponseTransformer : ITransformer<Score, ScoreResponse>
    {
        public ScoreResponse Transform(Score input)
        {
            ScoreResponse response = new ScoreResponse();
            response.Bounces = input.Bounces;
            response.PlayedSeconds = input.PlayedSeconds;
            return response;
        }
        public List<ScoreResponse> Transform(IQueryable<Score> input)
        {
            List<ScoreResponse> responseList = new List<ScoreResponse>();
            foreach (Score response in input)
            {
                responseList.Add(Transform(response));
            }
            return responseList;
        }
    }
}
