using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMystery.Models
{
    public class MurderSuspect
    {
        

        public string Name { get; set; }
        public string Description { get; set; }
        public string ClueOne { get; set; }
        public string ClueTwo { get; set; }
        public string ClueThree { get; set; }
        public string WinningMessage { get; set; }

        public MurderSuspect()
        {

        }

        public MurderSuspect(string name, string description, string clueOne, string clueTwo, string clueThree, string winningMessage)
        {
            this.Name = name;
            this.Description = description;
            this.ClueOne = clueOne;
            this.ClueTwo = clueTwo;
            this.ClueThree = clueThree;
            this.WinningMessage = winningMessage;
        }

        public override string ToString()
        {
            return $"{Name} - {Description} - {ClueOne} - {ClueTwo} - {ClueThree} - {WinningMessage}";
        }
    }
}
