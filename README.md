# TDD Starter

This is a starter project for TDD, allowing us to do katas in our own IDEs. The value provided here:
- Simple predefined projects to get started quickly in different languages
- Present test execution history, similar to how [cyber-dojo.org](https://cyber-dojo.org) does, via our own test-runner-wrap script `tddiscipline`.

[link to demo](./screen_demo.mov)

# Get started
Pick the folder that suits your language and follow the instructions in the README.md file there.

# How to interpret the history

Example output:
> [🟢]🔴🔴🟢🟢🟡🔴🟢🔴

the left-most dot is the most recent execution.

- 🟢 = tests passed
- 🔴 = tests failed
- 🟡 = error, e.g. syntax error


## What this tells you

- If I am in the 🔴 for too long, you have probably taken too big of a step at once. Get back to green and think of a simpler step
- If there are no 🔴, I'm likely adding little new value.
- If there are only single 🟢, I'm probably are not refactoring. I might need to clean my code.
- If there is much time between dots, you are probably not doing TDD at all.
