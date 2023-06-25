import httpStream from "./httpStream"
import { Message } from "../game/playGame"

describe('stream integration test', () => {
    it('should integrate with actual stream', (done) => {
        const open = httpStream<Message>('https://tdd-bowling-alcckkju2q-ez.a.run.app/')
        
        const close = open((data) => {
            expect(data.state).toBe('next')
            done()
            close()
        })
    })

    it.skip('SLOW TEST! should go in until last throw', (done) => {

        const open = httpStream<Message>('https://tdd-bowling-alcckkju2q-ez.a.run.app/')

        const close = open((data) => {
            if (data.state === 'end') {
                close()
                done()
            }
        })
    }, 30000)
})