describe('Unit Testing from Lab', () => {
    it('Should return correct added number/s', () => {
        let calculator = createCalculator();
        calculator.add(5);
        assert.equal(calculator.get(), 5);
    });

    it('Should return correct subtracted negative number/s', () => {
        let calculator = createCalculator();
        calculator.subtract(5);
        assert.equal(calculator.get(), -5);
    });

    it('Should return 0', () => {
        let calculator = createCalculator();
        calculator.add(5);
        calculator.subtract(5);
        assert.equal(calculator.get(), 0);
    });

    it('Should return the default value - 0', () => {
        let calculator = createCalculator();
        assert.equal(calculator.get(), 0);
    });

    it('Should return NaN if input is non numeric value', () => {
        let calculator = createCalculator();
        calculator.add('five');
        assert.deepEqual(calculator.get(), NaN);
    });
});