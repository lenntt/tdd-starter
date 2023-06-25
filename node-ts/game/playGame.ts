import score from "../score/score";

export type Message = {state: "next" | "end", pins: number};

export default function streamGame(openStream: (consume: (data: Message) => void) => () => void, newThrow: (gameState: {throws: number[], score: number}) => void, endGame: (resultScore: number) => void): void {
    const throws: number[] = []
    const close = openStream((data) => {
        throws.push(data.pins)
        const currentScore = score(throws)

        newThrow({throws, score: currentScore})
        if (data.state == "end") {
            close()
            endGame(currentScore)
        }
    });
}