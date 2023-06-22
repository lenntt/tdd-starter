import playGame from "./game/playGame";
import httpStream from "./stream/httpStream";

process.stdout.write("Lets score a game!\n");
playGame(httpStream('https://tdd-bowling-alcckkju2q-ez.a.run.app/'), ({throws, score}) => {
    process.stdout.cursorTo(1);
    process.stdout.write(JSON.stringify(throws) + ": " + score);
},
(resultScore) => process.stdout.write("\nGame has ended, with the grand total of: " + resultScore + "\n"))


// 1. Play with the API in browser: what is the shape of the data? What is the api like?
// 2. Try to get the stream in the node environment. What packages do I need? How do I parse the data?
// 3. Beginning with the first simple game mechanics. How do you make the stream testable?
