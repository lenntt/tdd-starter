#!/usr/bin / env node

const { spawn } = require("child_process");
const fs = require('fs');

const args = process.argv.slice(2);

const RESULT_FILE = '.tddiscipline.result.json';

cmd = spawn(args[0], args.slice(1), { stdio: 'inherit' });
cmd.on('exit', (code) => {
    const dot = code === 0 ? '🟢' : (code > 1 ? '🟡' : '🔴');
    let oldResults = [];

    if (fs.existsSync(RESULT_FILE)) {
        oldResults = JSON.parse(fs.readFileSync(RESULT_FILE));
    }
    saveResults(oldResults, dot);
});

function saveResults(previousResults, newResult) {
    const results = [newResult, ...previousResults];
    fs.writeFile(RESULT_FILE, JSON.stringify(results), () => {
        console.log(`${newResult} - ${previousResults.join('')}`);
    });
}
