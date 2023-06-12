using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToVoice.Domain.Models
{
    public class ConversationResponseModel
    {
        public byte[] AudioBase64 { get; set; }
    }
}
