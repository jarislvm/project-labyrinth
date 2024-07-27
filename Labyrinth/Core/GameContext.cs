using System.Collections;
using Core.CardEngine;

namespace Core
{
    public class GameContext
    {
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxEnergy { get; set; }
        public int DisguisePoints { get; set; }
        public int Currency { get; set; }
        //public GameArea CurrentArea { get; set; }
        //public Location { get; set; }
        public Deck TopDeck { get; set; }
        public Deck BottomDeck { get; set; }
        //public IEnumerable<Consumable> Consumabbles { get; set; }
        //public IEnumerable<Artifact> Artifacts { get; set; }
        //public EventFlags { get; set; }
    }
}