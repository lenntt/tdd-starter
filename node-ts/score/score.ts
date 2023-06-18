export default function(input: number[]) {
    let score = 0;
    let throwIndex = 0;

    const getPins = (index: number) => index < input.length ? input[index] : 0;

    for (let frame = 0; frame < 10; frame++) {
        if (getPins(throwIndex) === 10) {
            score += 10 + getPins(throwIndex + 1) + getPins(throwIndex + 2)
            throwIndex++
        } else if (getPins(throwIndex) + getPins(throwIndex+1) === 10) {
            score += 10 + getPins(throwIndex + 2)
            throwIndex++
            throwIndex++
        } else {
            score += getPins(throwIndex) + getPins(throwIndex + 1)
            throwIndex++
            throwIndex++
        }
    }
    return score;
}
