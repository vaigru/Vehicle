namespace Vehicle.Core.ApiModels
{
    public class GenericAnswer
    {
        public object Result { get; set; }
        public AnswerMessage Message { get; set; }

        public GenericAnswer()
        {
            Message = new AnswerMessage();
        }
    }
}
