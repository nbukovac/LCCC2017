﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FindIt.Models;
using FindIt.Repositories.Interfaces;
using FindIt.ViewModels;

namespace FindIt.Repositories
{
    public class ChallengeRepository : BaseRepository<Challenge, Guid>, IChallengeRepository
    {

        public static Func<string, string> Challenged =
            x => "Player " + x + " challenged you to a game! Destroy him swiftly!";

        public static Func<string, string> Rejected = x => "Player " + x + " rejected your petty challenge!";
        public static Func<string, string, string> Accepted = 
            (x, y) => "Player " + x + " accepted to ride to battle!" + "And the winner is " + y;

        private readonly IPlayedGameRepository _playedGameRepository = new PlayedGameRepository();

        public async Task<IEnumerable<ChallengeViewModel>> GetChallenges(string userId)
        {
            var userGuid = Guid.Parse(userId);
            var challenges = await GetAllWhere(m => !m.Seen && m.ReceivingUserId == userGuid);
            var result = new List<ChallengeViewModel>();

            foreach (var challenge in challenges)
            {
                result.Add(new ChallengeViewModel(challenge));
            }

            return result;
        }

        public void CreateChallenge(UserInfo challenger, string challengeeId, string gameId)
        {
            var challenge = new Challenge()
            {
                ChallengeId = Guid.NewGuid(),
                GameId = Guid.Parse(gameId),
                SendingUserId = challenger.UserInfoId,
                ReceivingUserId = Guid.Parse(challengeeId),
                Seen = false,
                Message = Challenged(challenger.Username)
            };

            Insert(challenge);
        }

        public async void RespondToChallenge(string challengeId, string challengerId, UserInfo challengee, bool accepted = false,
            string gameId = null)
        {
            var challenge = GetById(Guid.Parse(challengeId));
            challenge.Seen = true;
            Update(challenge);

            var response = new Challenge()
            {
                ChallengeId = Guid.NewGuid(),
                ReceivingUserId = Guid.Parse(challengeId),
                SendingUserId = challengee.UserInfoId,
                Seen = false
            };

            if (!accepted)
            {
                response.Message = Rejected(challengee.Username);
            }
            else
            {
                var challengerGuid = Guid.Parse(challengerId);
                var challengerGame = (await _playedGameRepository.GetAllWhere(m => m.GameId == challenge.GameId
                                                                            && challengerGuid == m.UserInfoId)).FirstOrDefault();
                var challengeeGame = (await _playedGameRepository.GetAllWhere(m => m.GameId == challenge.GameId
                                                                            && challengerGuid == m.UserInfoId)).FirstOrDefault();

                if (challengeeGame.Score > challengerGame.Score)
                {
                    response.Message = Accepted(challengee.Username, challengee.Username);
                }
                else
                {
                    response.Message = Accepted(challengee.Username, "you");
                }
            }

            Insert(response);
        }
    }
}