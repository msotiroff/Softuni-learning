function multiplyOrDivide(arr) {
    let numN = Number(arr[0]);
    let numX = Number(arr[1]);

    if (numX >= numN) {
        return numN * numX;
    }
    else {
        if (numX !== 0){
            return numN / numX;
        }
    }
}