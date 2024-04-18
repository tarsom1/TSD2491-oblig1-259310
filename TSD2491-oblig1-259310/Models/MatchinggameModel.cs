using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_oblig1_259310.Models
{
    public class MatchinggameModel
    {
        public int MatchesFound { get; private set; }
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

        private static Random random = new Random();

        public MatchinggameModel()
        {
            SetUpGame();
        }

        private List<string> PickRandomEmoji()
        {
            var emojiList = (random.Next(0, 2) == 0) ? animalEmoji : carEmoji;
            return new List<string>(emojiList.OrderBy(e => random.Next()));
        }

        private void SetUpGame()
        {
            ShuffledEmoji = PickRandomEmoji();
            MatchesFound = 0;
            LastAnimalFound = string.Empty;
            LastDescription = string.Empty;
        }

       
    }
}
