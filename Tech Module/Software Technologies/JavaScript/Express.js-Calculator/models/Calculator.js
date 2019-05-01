function Calculator(leftOperand, operator, rightOperand) {
    this.leftOperand = leftOperand;
    this.operator = operator;
    this.rightOperand = rightOperand;

    this.calculateResult = function () {
        let result = 0;

        if (this.operator === '+'){
            result = this.leftOperand + this.rightOperand;
        }
        else if (this.operator === '-') {
            result = this.leftOperand - this.rightOperand
        }
        else if (this.operator === '*') {
            result = this.leftOperand * this.rightOperand
        }
        else if (this.operator === '/') {
            result = this.leftOperand / this.rightOperand
        }
        // Calculate the power of given base with given exponent.
        // The base is leftOperand, exponent is the rightOperand.
        else if (this.operator === '^') {
            result = Math.pow(this.leftOperand, this.rightOperand)
        }
        // Calculate the N-th root of given base.
        // N-th root is leftOperand, base is rightOperand.
        else if (this.operator === 'radic') {
            result = Math.pow(this.rightOperand, 1 / this.leftOperand)
        }

        return result;
    }

}

module.exports = Calculator;

