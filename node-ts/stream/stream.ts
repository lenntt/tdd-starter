import EventSource from "eventsource";

export default function stream<T>(url: string, consume: (data: T, close: () => void) => void) {
    const stream = new EventSource(url, {rejectUnauthorized: false, withCredentials: false});

    const closeStream = () => {
        stream.close()
    }

    stream.onmessage = (message: MessageEvent<string>) => {
        const data = JSON.parse(message.data)
        consume(data, closeStream)
    }

    stream.onerror = (message: MessageEvent<any>) => {
        console.log('error occured ' + JSON.stringify(message))
    }
}