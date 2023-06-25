import EventSource from "eventsource";

const stream = new EventSource('https://tdd-bowling-alcckkju2q-ez.a.run.app/');

stream.onmessage = (message: MessageEvent<string>) => {
    console.log(message.data)
}

stream.onerror = (message: MessageEvent<any>) => {
    console.log('error occured ' + JSON.stringify(message))
}
