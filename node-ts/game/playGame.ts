import score from "../score/score";
import stream from "../stream/stream"

export type Message = {state: "next" | "end", pins: number};

export default function streamGame(newThrow: (gameState: {throws: number[], score: number}) => void, endGame: (resultScore: number) => void): void {
    const throws: number[] = []
    stream('http://localhost:8080/score', (data: Message, close) => {

        throws.push(data.pins)
        const currentScore = score(throws)

        newThrow({throws, score: currentScore})
        if (data.state == "end") {
            close()
            endGame(currentScore)
        }
    });
}