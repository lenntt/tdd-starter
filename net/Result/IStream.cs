namespace Result {
    public interface IStream<T> {
        public Task Start();

        public Task<T> ConsumeNextMessage();

        public Task Close();
    }
}