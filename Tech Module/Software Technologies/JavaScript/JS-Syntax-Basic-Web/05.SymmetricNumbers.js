function Solve(arg) {
    let endNumber = Number(arg);

    for (let i = 1; i <= endNumber; i++){
        if(isSymetric(i)){
            console.log(i)
        }
    }

    function isSymetric(number) {
        let numAsString = number.toString();
        for (let i = 0; i < numAsString.length / 2; i++) {
            if (numAsString[i] !== numAsString[numAsString.length - 1 - i]){
                return false;
            }
        }
        return true;
    }
}