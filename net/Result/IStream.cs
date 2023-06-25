namespace Result {
    public interface IStream<T> {
        public Task Start(Action<T> onMessage);

        public Task Close();
    }
}