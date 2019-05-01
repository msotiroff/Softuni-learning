package com.softuni.entity;

public class Calculator {

    private double leftOperand;
    private String operator;
    private  double rightOperand;

    public Calculator(double leftOperand, String operator, double rightOperand) {
        this.leftOperand = leftOperand;
        this.operator = operator;
        this.rightOperand = rightOperand;
    }

    public double getLeftOperand() {
        return leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public String getOperator() {
        return operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }


    public double calculateResult () {

        double result = 0;

        if (this.operator.equals("+")) {
            result =  this.leftOperand + this.rightOperand;
        } else if (this.operator.equals("-")) {
            result =  this.leftOperand - this.rightOperand;
        } else if (this.operator.equals("*")) {
            result =  this.leftOperand * this.rightOperand;
        } else if (this.operator.equals("/")) {
            if (this.rightOperand != 0) {
                result =  this.leftOperand / this.rightOperand;
            }
        } else if (this.operator.equals("^")) {                         // Calculate the power of given base with given exponent.
            result = Math.pow(this.leftOperand, this.rightOperand);     // The base is leftOperand, exponent is the rightOperand.
        } else if (this.operator.equals("√")) {                             // Calculate the N-th root of given base.
            result = Math.pow(this.rightOperand, 1 / this.leftOperand);     // N-th root is leftOperand, base is rightOperand.
        }
        return  result;
    }
}
