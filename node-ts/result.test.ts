const result = require('./result');

describe('result', () => {
    it('should return 0 when given an empty array', () => {
        expect(result([])).toEqual(0);
    });
});
