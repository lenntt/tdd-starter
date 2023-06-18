import stream from "./stream"
import { Message } from "../game/playGame"

describe('stream integration test', () => {
    it('should integrate with actual stream', (done) => {
        stream('http://localhost:8080/score', (data: Message, close) => {
            expect(data.state).toBe('next')
            close()
            done()
        })
    })

    it.skip('SLOW TEST! should go in until last throw', (done) => {
        stream('http://localhost:8080/score', (data: Message, close) => {
            if (data.state === 'end') {
                close()
                done()
            }
        })
    }, 30000)
})