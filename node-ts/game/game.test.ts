import playGame, { Message } from "./playGame";

const close = jest.fn()
let next = (data: Message) => {}

jest.mock('../stream/stream', () => (url: string, consume: (data: Message, close: () => void) => void) => {
    next = (data: Message) => consume(data, close);
})

describe('stream bowling game', () => {
    it('should handle incoming messages and tally the score', () => {
        const nextThrow = jest.fn();
        const endGame = jest.fn();
        playGame(nextThrow, endGame);

        next({state: "next", pins: 1});
        expect(nextThrow).toHaveBeenLastCalledWith({throws: [1], score: 1})
        next({state: "next", pins: 2});
        expect(nextThrow).toHaveBeenLastCalledWith({throws: [1, 2], score: 3})
    })

    it('should close stream on end state and call end game', () => {
        const nextThrow = jest.fn();
        const endGame = jest.fn();
        playGame(nextThrow, endGame);

        next({state: "end", pins: 1});
        expect(nextThrow).toHaveBeenCalled()
        expect(close).toHaveBeenCalled()
        expect(endGame).toHaveBeenCalledWith(1)
    })

    it('should play a whole, realistic game', () => {
        const nextThrow = jest.fn();
        const endGame = jest.fn();
        playGame(nextThrow, endGame);

        const gameExceptLastThrow = [10,0,9,7,0,5,1,0,10,1,4,3,0,8,2,4,1,5,5];
        const lastThrow = 3;

        gameExceptLastThrow.forEach((pins) => {
            next({state: "next", pins});
        })
        next({state: "end", pins: lastThrow});

        expect(nextThrow).toHaveBeenLastCalledWith({throws: [...gameExceptLastThrow, lastThrow], score: 92})
    })
})