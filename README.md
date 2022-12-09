# TDD Starter

This is a starter project for TDD, allowing us to do katas in our own IDEs. The value provided here:
- Minimalistic boilerplate projects for different languages to run a test against code.
- Present test execution history, comparable to how [cyber-dojo.org](https://cyber-dojo.org) does, via our own test-runner-wrap script `tddiscipline`.

[link to demo](./screen_demo.mov)

# Get started
Pick the folder that suits your language and follow the instructions in the `README.md` file there.

# TDDiscipline
This is a simple script that wraps the test-runner command, and provides a history of results. Depends on NodeJS being installed. For example, go to one of the language folders, and run:
```
node ../tddiscipline/index.js <any command>
node ../tddiscipline/index.js pytest
node ../tddiscipline/index.js npm test
```

## How to interpret the history

Example output:
> 🟢 - 🔴🔴🟢🟢🟡🔴🟢🔴

the left-most dot is the most recent execution. The rest are the previous executions. The dots are colored as follows:

- 🟢 = tests passed
- 🔴 = tests failed
- 🟡 = error, e.g. syntax error

## What this tells you

- If I am in the 🔴 for too long, you have probably taken too big of a step at once. Get back to green and think of a simpler step
- If there are no 🔴, I'm likely adding little new value.
- If there are only single 🟢, I'm probably are not refactoring. I might need to clean my code.
- If there is much time between dots, you are probably not doing TDD at all.
