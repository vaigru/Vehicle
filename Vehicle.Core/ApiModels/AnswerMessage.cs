using System.Collections.Generic;

namespace Vehicle.Core.ApiModels
{
    public class AnswerMessage
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }

        public AnswerMessage()
        {
            IsSuccess = true;
            ErrorMessages = new List<string>();
        }
    }
}
