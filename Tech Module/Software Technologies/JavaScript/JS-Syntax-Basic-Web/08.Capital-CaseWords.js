function extractCapitalCaseWords(arr) {

    let result = [];

    for (let i = 0; i < arr.length; i++) {

        let currentText = arr[i];

        let words = currentText.split(/[^A-Za-z]+/);

        for (let j = 0; j < words.length; j++) {
            if (words[j] === words[j].toUpperCase() && words[j].length > 0) {
                result.push(words[j]);
            }
        }
    }

    console.log(result.join(', '));
}