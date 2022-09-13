describe('Unit Testing from Lab', () => {
    it('Should return false if not array', () => {
        assert.equal(isSymmetric({}), false);
    });

    it('Should return true if input is array', () => {
        assert.equal(isSymmetric([]), true);
    });

    it('Should return true if array is symmetric', () => {
        assert.equal(isSymmetric([4, 5, 5, 4]), true);
    });

    it('Should return false if array is not symmetric', () => {
        assert.equal(isSymmetric([1, 2, 3, 4]), false);
    });

    it('Should return false if not array', () => {
        assert.equal(isSymmetric([4, 5, 5, '4']), false);
    });
});