using MurderMystery.Interfaces;
using MurderMystery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderMystery.Data
{
    public class SuspectListDAL : IDataAccessLayer
    {
        public static List<MurderSuspect> murderSuspects = new List<MurderSuspect>()
        {
            new MurderSuspect("Elodie Mitchell", "Daughter of the Victim. All her life she was seen as the favorite daughter of the victim. The victim was very protective of Elodie, maybe even too protective. She recently got accepted into a college of the victims' choosing. The question is 'Is that what she really wants to do?'", "Bracelet engraved with 'To My Loving Daughter'", "College acceptance letter on victims desk", " A smashed 'Best Father' mug", "You have figured out the murderer. Dun dun dun!!!!! She had a good life ahead of her, but she decided to rebel."),
            new MurderSuspect("Alex Mitchell", "Married to the Victim. World renowned Chemist. To everyone else this may be a loving family, but Alex suspects the victim may have been unfaithful.","A vile of poison", "A wedding band", "Divorce Papers", "You have figured out the murderer. Dun dun dun!!!!! They wanted revenge on their cheating partner."),
            new MurderSuspect("Bryan Mitchell", "Father-in-law of the victim. Zookeeper who mainly cared for big cats. He cared for the victim deeply, but suspects they have hurt his granddaughter and he does not appreciate that.", "Claw Marks", "ZooKeeper Badge", "Bloody paw prints", "You have figured out the murderer. Dun dun dun!!!!! He stole one of the big cats from the zoo and used it in his plan to kill the victim."),
            new MurderSuspect("Luke Mitchell", "Son of the victim. College student who is working on his degree in Electrical Engineering. He has been getting tired of watching his sister be the favorite child.", "A torn will", "Check for $1,000 made out to Elodie", "A piece of long flexible wire. Used in electrical equipment.", "You have figured out the murderer. Dun dun dun!!!!! He got his revenge but now, what does he have to show for it?"),
            new MurderSuspect("Micheal Scott", "Micheal Scott in The Office", "Paper", "Worlds Best Boss Mug", "Dunder Mifflin Inc. pen", "You have figured out the murderer Dun dun dun!!!!! ' 'You miss 100% of the shots you don’t take. - Wayne Gretzky ' - Michael Scott'"),
            new MurderSuspect("Missy Smith", "Missy was found having an affair with the victim. Works in cosmetology. Some say she loved him dearly, others say she was after their money.", "Lipstick found on the victim", "Empty Safe", "Necklace with the letter M", "You have figured out the murderer. Dun dun dun!!!!! At least she looked good. *snap snap*"),
            new MurderSuspect("Christopher Smith", "Husband of Missy Smith. Police Officer. Found Missy having an affair with the victim. He thought he could trust her…", "Victim found with gunshot wounds", "Police Badge", "Police car seen leaving the scene", "You have figured out the murderer. Dun dun dun!!!!! He will never have to worry about her again."),
            new MurderSuspect("Count Dracula", "Local Vampire. Lives in a creepy mansion in town. Usually wears a red cape but seems to have misplaced it recently.", "Victim drained of blood", "Red Cape", "‘Drac was here’ written in blood on the walls.", "You have figured out the murderer. Dun dun dun!!!!! I vant to suck your blood."),
            new MurderSuspect("Guy Fieri", "Come on you know who this is.", "Ticket to flavor town", "Keys to a Red Camero", "Blonde Hair", "You have figured out the murderer. Dun dun dun!!!!! Sometimes you pull up to a place, and you know it's going to be good."),
            new MurderSuspect("Ghostface", "No, please don't kill me, Mr. Ghostface. I wanna be in the sequel!", "White scream mask", "Telephone call from unknown number", "Do you wanna play a game?", "You have figured out the murderer. Dun dun dun!!!!! What's your favorite scary movie?")
        };

        public void AddSuspect(MurderSuspect suspect)
        {
            murderSuspects.Remove(suspect);
            murderSuspects.Add(suspect);
        }

        public MurderSuspect GetSuspect(int? id)
        {
            MurderSuspect foundSuspect = null;
            if(id != null)
            {
                murderSuspects.ForEach(m =>
                {
                    if (m.ID == id)
                    {
                        foundSuspect = m;
                    }
                });
                
            }
            return foundSuspect;
        }

        public IEnumerable<MurderSuspect> GetSuspects()
        {
            return murderSuspects;
        }
    }
}
