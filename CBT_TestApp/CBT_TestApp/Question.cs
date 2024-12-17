using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBT_TestApp
{
    class Question
    {
        public int QuestID { get; set; }
        public string CbtQuest { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer  { get; set; }


        public Question(int questId, string cbtQuest, string optionA, string optionB, string optionC, string optionD, string ans)
        {
            QuestID = questId;
            CbtQuest = cbtQuest;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            OptionD = optionD;
            Answer = ans;
        }

    }
}
