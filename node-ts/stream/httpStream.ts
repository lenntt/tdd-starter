import EventSource from "eventsource";

export default <T>(url: string) => (consume: (data: T) => void): () => void => {
    const stream = new EventSource(url, {rejectUnauthorized: false, withCredentials: false});

    stream.onmessage = (message: MessageEvent<string>) => {
        const data = JSON.parse(message.data)
        consume(data)
    }

    stream.onerror = (message: MessageEvent<any>) => {
        console.log('error occured ' + JSON.stringify(message))
    }

    return () => {
        stream.close()
    }
}