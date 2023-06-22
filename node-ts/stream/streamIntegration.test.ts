import httpStream from "./httpStream"
import { Message } from "../game/playGame"

describe('stream integration test', () => {
    it('should integrate with actual stream', (done) => {
        const open = httpStream<Message>('https://tdd-bowling-alcckkju2q-ez.a.run.app/')
        
        open((data, close) => {
            expect(data.state).toBe('next')
            close()
            done()
        })
    })

    it.skip('SLOW TEST! should go in until last throw', (done) => {

        const open = httpStream<Message>('https://tdd-bowling-alcckkju2q-ez.a.run.app/')

        open((data, close) => {
            if (data.state === 'end') {
                close()
                done()
            }
        })
    }, 30000)
})