using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRConnectorForm.SceneCreator
{
    public delegate void SendMessage(string message);
    class SceneCreator
    {
        private SendMessage _sendMessage;
        public SceneCreator(SendMessage sendMessage)
        {
            _sendMessage = sendMessage;
            //_sendMessag();
        }
    }
}
