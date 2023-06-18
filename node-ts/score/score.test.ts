import result from './score';

describe('bowling', () => {
    it('no game played yet', () => {
        expect(result([])).toEqual(0);
    });
    it('throw down 1 pin', () => {
        expect(result([1])).toEqual(1);
    });
    it('gutter game', () => {
        expect(result([0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0])).toEqual(0);
    });
    it('throw down second throw 1 pin', () => {
        expect(result([0,1])).toEqual(1);
    });

    it('strike', () => {
        expect(result([10,1,1])).toEqual(12 + 2);
    });
    it('strike but without all bonus throws', () => {
        expect(result([10,1])).toEqual(11 + 1);
    });
    it('strike at the end', () => {
        expect(result([0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0 ,0,0, 10,1,1])).toEqual(12);
    });

    it('spare', () => {
        expect(result([5,5,1,1])).toEqual(11 + 2);
    });

    it('spare', () => {
        expect(result([5,5,10,2,2])).toEqual(20 + 14 + 4);
    });

    it('spare', () => {
        expect(result([5,5,10,2,2])).toEqual(20 + 14 + 4);
    });
});