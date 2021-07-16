using System;
using System.Drawing;

namespace PoELevelingGuide_Lite
{
    /**
     * Classe abstraite Contact
     * nom, tel et photo du contact
     */
    [Serializable]
    public class Profile
    {
        private int act;
        private int quest;
        public Profile(int act, int quest)
        {
            this.act = act;
            this.quest = quest;
        }
        public int getAct()
        {
            return this.act;
        }
        public int getQuest()
        {
            return this.quest;
        }
    }
}