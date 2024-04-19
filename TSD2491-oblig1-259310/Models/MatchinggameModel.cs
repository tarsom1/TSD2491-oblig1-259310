using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_oblig1_259310.Models
{
    public class MatchinggameModel
    {
        public int MatchesFound { get; private set; }
        public string GameStatus { get; set; }
        public List<User> Users { get; private set; } = new List<User>();

        public string CurrentUsername { get; private set; }


        public List<string> ShuffledEmoji { get; private set; }
        private string LastAnimalFound = string.Empty;
        private string LastDescription = string.Empty;

        private List<string> animalEmoji = new List<string>()
        {
            "🐶", "🐶", "🐺", "🐺", "🐮", "🐮",
            "🦊", "🦊", "🐱", "🐱", "🦁", "🦁",
            "🐯", "🐯", "🐭", "🐭"
        };

        private List<string> carEmoji = new List<string>()
        {
            "🚗", "🚗", "🚓", "🚓", "🚕", "🚕",
            "🛺", "🛺", "🛻", "🛻", "🚌", "🚌",
            "🚐", "🚐", "🚒", "🚒"
        };
        private List<string> fruitEmoji = new List<string>()
        {
            "🍏", "🍏", "🍎", "🍎", "🍐", "🍐",
            "🍊", "🍊", "🍋", "🍋", "🍌", "🍌",
            "🍉", "🍉", "🍇", "🍇"
        };

        private static Random random = new Random();

        public MatchinggameModel()
        {
            SetUpGame();
        }

        private List<string> PickRandomEmoji()
        {
            int listChoice = random.Next(0, 3);  // Now picks a number between 0 and 2
            List<string> emojiList;
            if (listChoice == 0)
                emojiList = animalEmoji;
            else if (listChoice == 1)
                emojiList = carEmoji;
            else
                emojiList = fruitEmoji;

            return new List<string>(emojiList.OrderBy(e => random.Next()));
        }

        private void SetUpGame()
        {
            ShuffledEmoji = PickRandomEmoji();
            MatchesFound = 0;
            LastAnimalFound = string.Empty;
            LastDescription = string.Empty;
        }

        public void ButtonClick(string animal, string animalDescription)
        {
            if (CurrentUsername == null)
                return;
            if (MatchesFound == 0)
            {
                GameStatus = "Game Running";
            }
            if (LastAnimalFound == string.Empty)
            {
                LastAnimalFound = animal;
                LastDescription = animalDescription;
            }
            else if (LastAnimalFound == animal && LastDescription != animalDescription)
            {
                LastAnimalFound = string.Empty;
                LastDescription = string.Empty;
                ShuffledEmoji = ShuffledEmoji.Select(a => a == animal ? string.Empty : a).ToList();
                MatchesFound++;
                if (MatchesFound == 8)
                {
                    GameStatus = "Game Complete";
                    SetUpGame();
                    if (CurrentUsername != null)
                    {
                        UpdateGamesPlayed(CurrentUsername);
                    }

                }
            }
            else
            {
                LastAnimalFound = string.Empty;
                LastDescription = string.Empty;
            }
        }
        public void RegisterUser(string username)
        {
            if (!Users.Any(u => u.Username == username))
            {
                Users.Add(new User { Username = username, GamesPlayed = 0 });
            }

            CurrentUsername = username;

        }

        
        public void UpdateGamesPlayed(string username)
        {
            var user = Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.GamesPlayed++;
            }
        }
    }
    public class User
    {
        public string Username { get; set; }
        public int GamesPlayed { get; set; }
    }
}


