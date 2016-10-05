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
        public List<TrainingStep> AllSteps = new List<TrainingStep>();

        public List<dynamic> SendTraining()
        {
            List<dynamic> ToSend = new List<dynamic>();
            foreach (TrainingStep step in AllSteps)
            {    
                ToSend.Add(GetMessageToSend(step.Resistance, step.Duration));
            }
            return ToSend;
        }

        public void AddStep(int resistance, int duration) { AllSteps.Add(new TrainingStep(resistance, duration));}

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
