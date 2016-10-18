using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Classes
{
    class Training
    {
        private List<TrainingStep> AllSteps = new List<TrainingStep>();
        public string TrainingName;

        public Training(string name)
        {
            TrainingName = name;
        }

        public Training()
        {
            TrainingName = "Dummy";
            AddStep(100, 60);
            AddStep(200, 30);
            AddStep(150, 30);
            AddStep(300, 120);
            AddStep(50, 60);
        }

        public List<dynamic> SendTraining()
        {
            List<dynamic> toSend = new List<dynamic>();
            foreach (TrainingStep step in AllSteps)
            {    
                toSend.Add(GetMessageToSend(step.Resistance, step.Duration));
            }
            return toSend;
        }

        public void AddStep(int resistance, int duration) { AllSteps.Add(new TrainingStep(resistance, duration));}

        public void RemoveStep(TrainingStep step)
        {
            int tempCount = 0;
            foreach (TrainingStep Tstep in AllSteps)
            {
                if (step.Equals(Tstep)) {AllSteps.RemoveAt(tempCount); }
                tempCount++;
            }
        }

        private dynamic GetMessageToSend(int newResistance, int newDuration)
        {
            dynamic toSend = new
            {
                id = "change/resistance",
                data = new
                {
                    resistance = newResistance,
                    duration = newDuration
                }
            };
            return toSend;
        }
    }

    class TrainingStep
    {
        public int Resistance;
        public int Duration;

        public TrainingStep(int resistance, int duration)
        {
            Resistance = resistance;
            Duration = duration;
        }
    }
}
